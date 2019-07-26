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
   public class ro_fectividad_Entrega_tipoServicio_Bus
    {
        string mensaje;
        ro_fectividad_Entrega_tipoServicio_Data oData = new ro_fectividad_Entrega_tipoServicio_Data();

        public List<ro_fectividad_Entrega_tipoServicio_Info> Get_List(int IdEmpresa)
        {
            try
            {
                return oData.Get_List(IdEmpresa);
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
        public ro_fectividad_Entrega_tipoServicio_Info Get_Info(int IdEmpresa, int IdRuta)
        {
            try
            {
                return oData.Get_Info(IdEmpresa, IdRuta);
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
        public bool GuardarDB(ro_fectividad_Entrega_tipoServicio_Info Info, ref int IdRuta, ref string mensaje)
        {
            try
            {
                return oData.GuardarDB(Info, ref IdRuta, ref mensaje);
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
        public bool ModificarDB(ro_fectividad_Entrega_tipoServicio_Info Info, ref string mensaje)
        {
            try
            {
                return oData.ModificarDB(Info, ref mensaje);
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
        public bool AnularDB(ro_fectividad_Entrega_tipoServicio_Info Info, ref string mensaje)
        {
            try
            {
                return oData.AnularDB(Info, ref mensaje);
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
