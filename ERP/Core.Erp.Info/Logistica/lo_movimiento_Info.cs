using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Logistica
{
    public class lo_movimiento_Info
    {
        public decimal IdMovimiento { get; set; }
        public int IdCatalogoBodega { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
    }
}
