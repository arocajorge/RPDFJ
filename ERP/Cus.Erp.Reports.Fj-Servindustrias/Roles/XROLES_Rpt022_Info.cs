using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Erp.Reports.FJ.Roles
{
   public class XROLES_Rpt022_Info
   {
       public int IdEmpresa { get; set; }
       public decimal IdEmpleado { get; set; }
       public int IdTipoNomina { get; set; }
       public string pe_cedulaRuc { get; set; }
       public string pe_apellido { get; set; }
       public string pe_nombre { get; set; }
       public string ca_descripcion { get; set; }
       public string de_descripcion { get; set; }
       public string Descripcion { get; set; }
       public string em_codigo { get; set; }
       public Nullable<System.DateTime> em_fecha_ingreso { get; set; }
       public Nullable<System.DateTime> em_fechaIngaRol { get; set; }
       public byte[] em_foto { get; set; }
       public Nullable<System.DateTime> pe_fechaNacimiento { get; set; }

    }
}
