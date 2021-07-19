using Core.Erp.Data.Logistica;
using Core.Erp.Info.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.Logistica
{
    public class lo_catalogo_Bus
    {
        lo_catalogo_Data odata = new lo_catalogo_Data();
        public List<lo_catalogo_Info> GetList(int IdCatalogoTipo)
        {
            return odata.GetList(IdCatalogoTipo);
        }
    }
}
