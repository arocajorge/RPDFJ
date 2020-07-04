using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Data.General;
using Core.Erp.Info.General;
using Core.Erp.Business.Roles;
using Core.Erp.Business.General;
namespace Cus.Erp.Reports.FJ.Roles
{
  public  class XROLES_Rpt011_Data
  {
      tb_Empresa_Info Cbt = new tb_Empresa_Info();
      tb_Empresa_Data empresaData = new tb_Empresa_Data();

      public List<XROLES_Rpt011_Info> Get_list_Horas_Extras(int IdEmpresa, int IdNomina_Tipo,int IdNomina_Tipo_Liqui,int IdPeriodo, DateTime Fecha_Inicio, DateTime Fecha_Fin)
      {
          List<XROLES_Rpt011_Info> lista = new List<XROLES_Rpt011_Info>();
          try
          {
         

              int cont = 0;
              using (Entities_Roles_Fj_Rpt db = new Entities_Roles_Fj_Rpt())
              {

                 // db.SetCommandTimeOut(50000);
                  var query = from q in db.spROLES_Rpt011(IdEmpresa, IdNomina_Tipo, IdNomina_Tipo_Liqui, IdPeriodo, Fecha_Inicio, Fecha_Fin)
                            
                              select q;

                  foreach (var item in query)
                  {
                      XROLES_Rpt011_Info info = new XROLES_Rpt011_Info();
                      cont++;
                      info.IdEmpresa = item.IdEmpresa;
                      info.IdEmpleado = item.IdEmpleado;
                      info.pe_cedulaRuc = item.pe_cedulaRuc;
                      info.ca_descripcion = item.ca_descripcion;
                      info.SueldoActual = item.SueldoActual;
                      info.Valor_bono = item.Valor_bono;
                      info.zo_descripcion = item.zo_descripcion;
                      info.ru_descripcion = item.ru_descripcion;
                      info.em_fechaIngaRol = item.em_fechaIngaRol;
                      info.em_fechaSalida = item.em_fechaSalida;
                      info.em_status = item.em_status;
                      info.Efectividad_Entrega = item.Efectividad_Entrega;
                      info.Empleado = item.Empleado;
                      info.Efectividad_Entrega_aplica = item.Efectividad_Entrega_aplica;
                      info.Efectividad_Volumen = item.Efectividad_Volumen;
                      info.Efectividad_Volumen_aplica = item.Efectividad_Volumen_aplica;
                      info.Recuperacion_cartera = item.Recuperacion_cartera;
                      info.Recuperacion_cartera_aplica = item.Recuperacion_cartera_aplica;
                      info.Valor = item.Valor;
                      info.Rubro = item.Rubro;
                      info.fu_descripcion = item.fu_descripcion;
                      info.variable = item.variable;
                      info.Iess = item.Iess;
                      info.dias_trabajados = item.dias_trabajados;
                      info.dias_Efectivos = item.dias_Efectivos;

                      info.Efectividad_Entrega_ali = item.Efectividad_Entrega_ali;
                      info.Efectividad_Entrega_aplica_ali = item.Efectividad_Entrega_aplica_ali;
                      info.Efectividad_Volumen_ali = item.Efectividad_Volumen_ali;
                      info.Efectividad_Volumen_aplica_ali = item.Efectividad_Volumen_aplica_ali;
                      info.Recuperacion_cartera_ali = item.Recuperacion_cartera_ali;
                      info.Recuperacion_cartera_aplica_ali = item.Recuperacion_cartera_aplica_ali;
                      info.NivelServicio=item.NivelServicio;
                      lista.Add(info);







                  }
              }
              return lista;
          }
          catch (Exception ex)
          {
              string mensaje = "";
              mensaje = ex.ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", mensaje, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
              throw new Exception(mensaje);
          }
      }
   
    }
}
