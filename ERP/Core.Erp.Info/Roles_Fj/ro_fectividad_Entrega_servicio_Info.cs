using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Roles_Fj
{
   public class ro_fectividad_Entrega_servicio_Info
   {
       public int IdEmpresa { get; set; }
       public decimal IdNivelServicio { get; set; }
       public int IdServicioTipo { get; set; }
       public int IdNomina_Tipo { get; set; }
       public int IdNomina_tipo_Liq { get; set; }
       public int IdPeriodo { get; set; }
       public string Observacion { get; set; }
       public bool Estado { get; set; }
       public string IdUsuario { get; set; }
       public string IdUsuarioAnu { get; set; }
       public string MotivoAnu { get; set; }
       public string IdUsuarioUltModi { get; set; }
       public Nullable<System.DateTime> FechaAnu { get; set; }
       public System.DateTime FechaTransac { get; set; }
       public Nullable<System.DateTime> FechaUltModi { get; set; }



       public string DescripcionProcesoNomina { get; set; }
       public string Descripcion { get; set; }
       public Nullable<System.DateTime> pe_FechaIni { get; set; }
       public Nullable<System.DateTime> pe_FechaFin { get; set; }
       public string IdCalendario { get; set; }

       public List<ro_fectividad_Entrega_servicio_det_Info> lst { get; set; }
    }
}
