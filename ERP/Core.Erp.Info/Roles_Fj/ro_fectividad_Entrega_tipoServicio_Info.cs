using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Roles_Fj
{
   public class ro_fectividad_Entrega_tipoServicio_Info
   {
       public int IdEmpresa { get; set; }
       public int IdServicio { get; set; }
       public string ts_Descripcion { get; set; }
       public string ts_codigo { get; set; }
       public double Porcentaje { get; set; }

       public bool Estado { get; set; }
       public string IdUsuario { get; set; }
       public Nullable<System.DateTime> Fecha_Transaccion { get; set; }
       public string IdUsuarioUltModi { get; set; }
       public Nullable<System.DateTime> Fecha_UltMod { get; set; }
       public string IdUsuarioUltAnu { get; set; }
       public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
    }
}
