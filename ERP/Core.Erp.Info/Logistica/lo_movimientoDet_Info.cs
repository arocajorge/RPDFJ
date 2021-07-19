using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Logistica
{
    public class lo_movimientoDet_Info
    {
        public decimal IdMovimientoDet { get; set; }
        public decimal IdMovimiento { get; set; }
        public int IdRecurso { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Total { get; set; }
        public string CodigoBarra { get; set; }
        public string CodigoBarraDesde { get; set; }
        public string CodigoBarraHasta { get; set; }
    }
}
