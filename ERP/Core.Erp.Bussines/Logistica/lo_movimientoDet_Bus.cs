using Core.Erp.Data.Logistica;
using Core.Erp.Info.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.Logistica
{
    public class lo_movimientoDet_Bus
    {
        lo_movimientoDet_Data odata = new lo_movimientoDet_Data();
        public List<lo_movimientoDet_Info> GetList(decimal IdMovimiento)
        {
            return odata.GetList(IdMovimiento);
        }
    }
}
