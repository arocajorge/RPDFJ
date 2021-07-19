using Core.Erp.Data.Logistica;
using Core.Erp.Info.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.Logistica
{
    public class lo_recurso_Bus
    {
        lo_recurso_Data odata = new lo_recurso_Data();
        public List<lo_recurso_Info> GetList()
        {
            return odata.GetList();
        }
    }
}
