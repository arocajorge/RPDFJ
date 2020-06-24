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
   public class ro_rubros_calculados_Bus
    {
        string mensaje;
        ro_rubros_calculados_Data oData = new ro_rubros_calculados_Data();

        public ro_rubros_calculados_Info get_info(int IdEmpresa)
        {
            try
            {
                return oData.get_info(IdEmpresa);
            }
            catch (Exception ex)
            {
                throw;

             }
        }

     
        public bool GuardarDB(ro_rubros_calculados_Info Info)
        {
            try
            {
                return oData.guardarDB(Info);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        }
}
