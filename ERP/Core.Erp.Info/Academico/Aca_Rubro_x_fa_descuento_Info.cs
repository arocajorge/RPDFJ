using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Academico
{
    public class Aca_Rubro_x_fa_descuento_Info
    {
        public int IdInstitucion_rub { get; set; }
        public int IdRubro { get; set; }
        public int IdEmpresa_fadesc { get; set; }
        public decimal IdDescuento { get; set; }
        public bool Estado { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> FechaUltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> FechaUltAnu { get; set; }
        public string MotivoAnulacion { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }


        //vista vwAca_Rubro_x_fa_descuento
        public Nullable<int> IdSede { get; set; }
        public string rubro { get; set; }
        public string descuento { get; set; }
        public double porcentaje_descuento { get; set; }
        public char estado { get; set; }

        //public virtual Aca_Rubro_x_fa_descuento_Info Aca_Rubro { get; set; }
    }
}
