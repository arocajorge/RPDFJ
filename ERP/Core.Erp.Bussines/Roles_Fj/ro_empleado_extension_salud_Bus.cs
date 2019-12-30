using Core.Erp.Data.General;
using Core.Erp.Data.Roles_Fj;
using Core.Erp.Info.General;
using Core.Erp.Info.Roles_Fj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.Roles_Fj
{
   public class ro_empleado_extension_salud_Bus
    {

       string mensaje = "";

       ro_empleado_extension_salud_Data odata = new ro_empleado_extension_salud_Data();
       public List<ro_empleado_extension_salud_Info> Get_List_Fuerza(int IdEmpresa)
       {
           try
           {
               return odata.Get_List_Disco(IdEmpresa);
           }
           catch (Exception ex)
           {
               mensaje = ex.ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", mensaje, "", "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
               throw new Exception(mensaje);
           }
       }
       public bool GuardarDB(List<ro_empleado_extension_salud_Info> Info, string mensaje)
       {
           try
           {
               return odata.GuardarDB(Info, ref mensaje);
           }
           catch (Exception ex)
           {
               mensaje = ex.ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", mensaje, "", "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
               throw new Exception(mensaje);
           }
       }
       public int get_info(int IdEmpresa, decimal IdEmpleado)
       {
           try
           {
               return odata.get_info(IdEmpresa, IdEmpleado);
           }
           catch (Exception ex)
           {
               mensaje = ex.ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", mensaje, "", "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
               throw new Exception(mensaje);
           }
       }
     
    }
}
