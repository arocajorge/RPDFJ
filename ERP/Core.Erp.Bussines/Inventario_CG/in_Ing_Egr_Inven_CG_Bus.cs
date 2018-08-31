using Core.Erp.Data.Inventario_CG;
using Core.Erp.Info.Inventario_CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.Inventario_CG
{
    public class in_Ing_Egr_Inven_CG_Bus
    {
        in_Ing_Egr_Inven_CG_Data da = new in_Ing_Egr_Inven_CG_Data();
        public bool GrabarDB(in_Ing_Egr_Inven_CG_Info info, ref string mensaje)
        {
            try
            {

                return da.GrabarDB(info, ref mensaje);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "GrabarDB", ex.Message), ex) { EntityType = typeof(in_Ing_Egr_Inven_CG_Bus) };
            }

        }

        public bool ActualizarDB(in_Ing_Egr_Inven_CG_Info info)
        {
            try
            {

                return da.ActualizarDB(info);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "ActualizarDB", ex.Message), ex) { EntityType = typeof(in_Ing_Egr_Inven_CG_Bus) };
            }

        }

        public bool AnularDB(in_Ing_Egr_Inven_CG_Info info)
        {
            try
            {

                return da.AnularDB(info);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "AnularDB", ex.Message), ex) { EntityType = typeof(in_Ing_Egr_Inven_CG_Bus) };
            }
        }


        public List<in_Ing_Egr_Inven_CG_Info> Get_list(int IdEmpresa)
        {
            try
            {

                return da.Get_list(IdEmpresa);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "Get_list", ex.Message), ex) { EntityType = typeof(in_Ing_Egr_Inven_CG_Bus) };
            }
        }

        public in_Ing_Egr_Inven_CG_Info Get_Info(int IdEmpresa, decimal IdNumMovi)
        {
            try
            {

                return da.Get_Info(IdEmpresa, IdNumMovi);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "Get_Info", ex.Message), ex) { EntityType = typeof(in_Ing_Egr_Inven_CG_Bus) };
            }
        }
    }
}
