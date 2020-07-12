using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.Roles_Fj;
using Core.Erp.Data.Roles_Fj;
using Core.Erp.Info.General;
using Core.Erp.Data.General;

namespace Core.Erp.Business.Roles_Fj
{
    public class ro_Calculo_Pago_Variable_Porcentaje_servicio_Bus
    {
        string mensaje;
        ro_Calculo_Pago_Variable_Porcentaje_servicio_Data oData = new ro_Calculo_Pago_Variable_Porcentaje_servicio_Data();

        public ro_Calculo_Pago_Variable_Porcentaje_servicio_Info get_info(int IdEmpresa, int IdTipo_Nomina, int IdTipoServicio)
        {
            try
            {
                return oData.get_info(IdEmpresa, IdTipo_Nomina,  IdTipoServicio);
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString() + " " + ex.Message;
                throw new Exception(ex.ToString());
            }
        }

        public List<ro_Calculo_Pago_Variable_Porcentaje_servicio_Info> get_lis(int IdEmpresa, int IdTipo_Nomina, int IdTipoServicio)
        {
            try
            {
                return oData.get_lis(IdEmpresa, IdTipo_Nomina, IdTipoServicio);
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString() + " " + ex.Message;
                throw new Exception(ex.ToString());
            }
        }

        public List<ro_Calculo_Pago_Variable_Porcentaje_servicio_Info> get_lis(double cumpliento)
        {
            try
            {
                return oData.get_lis(cumpliento);
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString() + " " + ex.Message;
                throw new Exception(ex.ToString());
            }
        }


       

        public bool GuardarDB(List<ro_Calculo_Pago_Variable_Porcentaje_servicio_Info> List_Info, int IdTipo_Nomina,int IdEmpresa)
        {
            try
            {
                return oData.GuardarDB(List_Info, IdTipo_Nomina, IdEmpresa);
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString() + " " + ex.Message;
                throw new Exception(ex.ToString());
            }
        }

   
      
    }
}
