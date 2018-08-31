using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Inventario_CG
{
    public class inv_fabricantes_Info
    {
        
        public  int  fabricante_id { get; set; }
        public string descripcion { get; set; }
        public string registro_invima { get; set; }
        public Nullable<decimal> pais_id { get; set; }
    }
}
