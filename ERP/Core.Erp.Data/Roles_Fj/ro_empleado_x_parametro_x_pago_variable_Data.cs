﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.Roles_Fj;
using Core.Erp.Data.General;
using Core.Erp.Info.General;

namespace Core.Erp.Data.Roles_Fj
{
   public class ro_empleado_x_parametro_x_pago_variable_Data
   {
       string MensajeError = "";
       tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
       public bool Guardar_DB(ro_empleado_x_parametro_x_pago_variable_Info info)
       {
           try
           {
               using (EntityRoles_FJ db = new EntityRoles_FJ())
                   {
               if (!si_Existe(info.IdEmpresa, info.IdNomina_Tipo, info.IdEmpleado))
               {

                   
                       ro_empleado_x_parametro_x_pago_variable add = new ro_empleado_x_parametro_x_pago_variable();
                       add.IdEmpresa = info.IdEmpresa;
                       add.IdNomina_Tipo = info.IdNomina_Tipo; ;
                       add.IdEmpleado = info.IdEmpleado;
                       add.IdFuerza = info.IdFuerza;
                       add.IdUsuario = info.IdUsuario;
                       add.Fecha_Transaccion = DateTime.Now;
                       add.Estado = true;
                       db.ro_empleado_x_parametro_x_pago_variable.Add(add);
                       db.SaveChanges();
                  
               }
               else
               {
                   ro_empleado_x_parametro_x_pago_variable contact = db.ro_empleado_x_parametro_x_pago_variable.FirstOrDefault(q => q.IdEmpresa == info.IdEmpresa && q.IdNomina_Tipo == info.IdNomina_Tipo && q.IdEmpleado == info.IdEmpleado);
                   if (contact != null)
                   {
                       contact.IdFuerza = info.IdFuerza;
                      
                       db.SaveChanges();
                   }

               }
               }
               return true;

           }
           catch (Exception ex)
           {

               string arreglo = ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
               MensajeError = ex.ToString();
               throw new Exception(ex.ToString());
           }
       }

       public bool Anular_DB(ro_empleado_x_parametro_x_pago_variable_Info info)
       {
           try
           {
               using (EntityRoles_FJ db = new EntityRoles_FJ())
               {
                   db.Database.ExecuteSqlCommand("delete Fj_servindustrias.ro_empleado_x_parametro_x_pago_variable_Det where IdEmpresa='" + info.IdEmpresa + "' and IdNomina_Tipo= '" + info.IdNomina_Tipo + "' and IdEmpleado='" + info.IdEmpleado + "'");

                   db.Database.ExecuteSqlCommand("delete Fj_servindustrias.ro_empleado_x_parametro_x_pago_variable where IdEmpresa='" + info.IdEmpresa + "' and IdNomina_Tipo= '" + info.IdNomina_Tipo + "' and IdEmpleado='" + info.IdEmpleado + "'");
                   return true; 
               }
           }
           catch (Exception ex)
           {

               string arreglo = ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
               MensajeError = ex.ToString();
               throw new Exception(ex.ToString());
           }
       }


       public List<ro_empleado_x_parametro_x_pago_variable_Info> listado_empleado_x_parametro_variables(int IdEmpresa)
       {
           try
           {
               List<ro_empleado_x_parametro_x_pago_variable_Info> lista = new List<ro_empleado_x_parametro_x_pago_variable_Info>();
               using (EntityRoles_FJ db = new EntityRoles_FJ())
               {
                   var query = from q in db.vwro_empleado_x_parametro_x_pago_variable
                               where
                               q.IdEmpresa == IdEmpresa

                               select q;

                   foreach (var item in query)
                   {
                       ro_empleado_x_parametro_x_pago_variable_Info info = new ro_empleado_x_parametro_x_pago_variable_Info();

                       info.IdEmpresa = item.IdEmpresa;
                       info.IdNomina_Tipo = item.IdNomina_Tipo; ;
                       info.IdEmpleado = item.IdEmpleado;
                       info.pe_cedulaRuc = item.pe_cedulaRuc;
                       info.pe_nombre = item.pe_nombre;
                       info.pe_apellido = item.pe_apellido;
                       info.pe_nombreCompleto = item.pe_apellido+" "+item.pe_nombre;
                       info.IdFuerza = item.IdFuerza;
                       info.icono_eliminar = true;
                       lista.Add(info);
                   }
               }

               return lista;
           }
           catch (Exception ex)
           {

               string arreglo = ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
               MensajeError = ex.ToString();
               throw new Exception(ex.ToString());
           }
       }


       public bool si_Existe(int IdEmpresa, int idnomina_tipo, decimal idempleado)
       {
           try
           {
               using (EntityRoles_FJ db = new EntityRoles_FJ())
               {
                   var query = from q in db.ro_empleado_x_parametro_x_pago_variable
                               where
                               q.IdEmpresa == IdEmpresa
                               && q.IdNomina_Tipo == idnomina_tipo
                               && q.IdEmpleado == idempleado
                               select q;

                   if (query.Count() > 0)
                       return true;
                   else
                       return false;

               }  
           }
           catch (Exception ex)
           {

               string arreglo = ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
               MensajeError = ex.ToString();
               throw new Exception(ex.ToString());
           }
       }

     
    }
}
