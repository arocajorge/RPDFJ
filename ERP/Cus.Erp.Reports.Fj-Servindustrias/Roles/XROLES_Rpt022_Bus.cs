using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Erp.Reports.FJ.Roles
{
   public class XROLES_Rpt022_Bus
    {
       XROLES_Rpt022_Data odat = new XROLES_Rpt022_Data();

       public List<XROLES_Rpt022_Info> get_list(int IdEmpresa, int IdNomina_tipo)
       {
           try
           {
               return odat.get_list(IdEmpresa, IdNomina_tipo);

           }
           catch (Exception)
           {

               throw;
           }
       }
    }
}
