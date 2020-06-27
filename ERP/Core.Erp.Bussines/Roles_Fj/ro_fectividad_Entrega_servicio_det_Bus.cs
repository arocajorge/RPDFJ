using Core.Erp.Data.Roles_Fj;
using Core.Erp.Info.Roles_Fj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.Roles_Fj
{
   public class ro_fectividad_Entrega_servicio_det_Bus
    {
       ro_fectividad_Entrega_servicio_det_Data odata = new ro_fectividad_Entrega_servicio_det_Data();
       public List<ro_fectividad_Entrega_servicio_det_Info> get_list(int IdEmpresa, decimal IdNivelServicio)
       {
           try
           {
               return odata.get_list(IdEmpresa, IdNivelServicio);
           }
           catch (Exception )
           {
               
               throw ;
           }
       }

    }
}
