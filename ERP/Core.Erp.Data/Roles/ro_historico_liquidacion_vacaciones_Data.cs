using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Erp.Info.Roles;
using Core.Erp.Data.General;
using Core.Erp.Info.General;

namespace Core.Erp.Data.Roles
{
  public  class ro_historico_liquidacion_vacaciones_Data
    {
          ro_Empleado_Data empleado_data = new ro_Empleado_Data();  
          string mensaje = "";
      
        public Boolean EliminarDB(ro_historico_liquidacion_vacaciones_Info info)
        {
            try
            {


                info.IdLiquidacion = info.IdSolicitud_Vacaciones;

                int dias_tomados = 0;
                using (EntitiesRoles db = new EntitiesRoles())
                {
                    var Entity = db.ro_Solicitud_Vacaciones_x_empleado.Where(v => v.IdEmpresa == info.IdEmpresa
                        && v.IdSolicitudVaca == info.IdLiquidacion).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Estado = "I";
                    Entity.MotivoAnulacion = "ERROR DE RRHH";
                    var ro_historico_vacaciones_x_empleado = db.ro_historico_vacaciones_x_empleado.Where(
                        v => v.IdEmpresa == info.IdEmpresa
                        && v.IdEmpleado == info.IdEmpleado
                        && v.FechaIni == Entity.Anio_Desde
                        && v.FechaFin == Entity.Anio_Hasta).FirstOrDefault();
                    if (ro_historico_vacaciones_x_empleado != null)
                    {
                        dias_tomados = ro_historico_vacaciones_x_empleado.DiasTomados == null ? 0 : Convert.ToInt32(ro_historico_vacaciones_x_empleado.DiasTomados);
                        dias_tomados = dias_tomados - Entity.Dias_a_disfrutar;
                        ro_historico_vacaciones_x_empleado.DiasTomados = dias_tomados;
                    }

                    var entity_liquidacion = db.ro_Historico_Liquidacion_Vacaciones.Where(v => v.IdEmpresa == info.IdEmpresa
                        && v.IdLiquidacion == info.IdSolicitud_Vacaciones).FirstOrDefault();

                    if (entity_liquidacion != null)
                    {
                        entity_liquidacion.Estado = "I";
                        entity_liquidacion.MotiAnula = "ERROR DE RRHH";
                    }
                    db.SaveChanges();
                }
                return true;


            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                mensaje = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                throw new Exception(ex.InnerException.ToString());
            }
        }
        public double Get_Valor_vacaciones_Provisiones(int IdEmpresa,int IdNomina_tipo,int IdEmpleado,DateTime Fecha_Inicio,DateTime Fecha_Fin,string IdRubro)
        {
            try
            {
                double Valor = 0;

                using (EntitiesRoles db = new EntitiesRoles())
                {
                var select = from C in db.spROL_Valor_Ganado_Vacaciones(IdEmpresa,IdNomina_tipo,IdEmpleado,Fecha_Inicio,Fecha_Fin,IdRubro)
                             select C;

                foreach (var item in select)
                {
                    Valor =Convert.ToDouble( item.Valor);
                }
                   
                }
                return Valor;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                mensaje = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public double Get_Valor_Vacaciones_Cancelados(int IdEmpresa,int IdNomina_tipo,int IdEmpleado,DateTime Fecha_Inicio,DateTime Fecha_Fin,string IdRubro)
        {
            try
            {
                double Valor = 0;

                using (EntitiesRoles db = new EntitiesRoles())
                {
                var select = from C in db.spROL_Valor_Ganado_Vacaciones(IdEmpresa,IdNomina_tipo,IdEmpleado,Fecha_Inicio,Fecha_Fin,IdRubro)
                             select C;

                foreach (var item in select)
                {
                    Valor =Convert.ToDouble( item.Valor);
                }
                   
                }
                return Valor;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                mensaje = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                throw new Exception(ex.InnerException.ToString());
            }
        }
        public int getId(int IdEmpresa, int IdEmpleado)
        {
            try
            {
                int Id;
                EntitiesRoles OEEmpleado = new EntitiesRoles();
                var select = from q in OEEmpleado.ro_Historico_Liquidacion_Vacaciones
                             where q.IdEmpresa == IdEmpresa && q.IdEmpleado == IdEmpleado
                             select q;

                if (select.ToList().Count() == 0)
                {
                    Id = 1;
                }
                else
                {
                    var select_em = (from q in OEEmpleado.ro_Historico_Liquidacion_Vacaciones
                                     where q.IdEmpresa == IdEmpresa && q.IdEmpleado == IdEmpleado
                                     select q.IdLiquidacion).Max();
                    Id = Convert.ToInt32(select_em.ToString()) + 1;
                }
                return Id;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                mensaje = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public Boolean GrabarBD(ro_historico_liquidacion_vacaciones_Info Info)
        {
            try
            {

                using (EntitiesRoles db = new EntitiesRoles())
                {
                    var select = from q in db.ro_Historico_Liquidacion_Vacaciones
                                 where q.IdEmpresa == Info.IdEmpresa
                                 && q.IdLiquidacion == Info.IdSolicitud_Vacaciones
                                 && q.IdEmpleado == Info.IdEmpleado
                                 select q;

                    if (select.ToList().Count > 0)
                    {

                        var contact = db.ro_Historico_Liquidacion_Vacaciones.First(obj => obj.IdEmpresa == Info.IdEmpresa &&
                        obj.IdLiquidacion == Info.IdSolicitud_Vacaciones && obj.IdEmpleado == Info.IdEmpleado);
                        contact.FechaPago = Info.FechaPago;
                        contact.IdNomina_Tipo = Info.IdNomina_Tipo;
                        contact.ValorCancelado = Info.ValorCancelado;
                        db.SaveChanges();

                    }
                    else
                    {

                        ro_Historico_Liquidacion_Vacaciones Data = new ro_Historico_Liquidacion_Vacaciones();
                        Data.IdEmpresa = Info.IdEmpresa;
                        Data.IdNomina_Tipo = Info.IdNomina_Tipo;
                        Data.IdLiquidacion = Info.IdSolicitud_Vacaciones;
                        Data.IdEmpresa_OP = Info.IdEmpresa_OP;
                        Data.IdOrdenPago = Info.IdOrdenPago;
                        Data.IdEmpleado = Info.IdEmpleado;
                        Data.ValorCancelado = Info.ValorCancelado;
                        Data.FechaPago = Info.FechaPago;
                        Data.Observaciones = Info.Observaciones;
                        Data.IdUsuario = Info.IdUsuario;
                        Data.Estado = "A";
                        Data.Fecha_Transac = DateTime.Now;
                        Data.Iess = Info.Iess;
                        db.ro_Historico_Liquidacion_Vacaciones.Add(Data);
                        db.SaveChanges();

                      //  IdSolicitud = Data.IdLiquidacion;
                        // empleado_data.Modificar_Estado(Info.IdEmpresa, Info.IdNomina_Tipo, Convert.ToInt32(Info.IdEmpleado), "EST_VAC");
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                mensaje = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                throw new Exception(ex.InnerException.ToString());
            }

        }

    }
    }

