using Core.Erp.Data.Logistica;
using Core.Erp.Info.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.Logistica
{
    public class lo_movimiento_Bus
    {
        lo_movimiento_Data odata = new lo_movimiento_Data();
        public lo_movimiento_Info GetInfo(int IdEmpresa, int IdTipoCbte, decimal IdCbteCble)
        {
            return odata.GetInfo(IdEmpresa, IdTipoCbte, IdCbteCble);
        }
    }
}
