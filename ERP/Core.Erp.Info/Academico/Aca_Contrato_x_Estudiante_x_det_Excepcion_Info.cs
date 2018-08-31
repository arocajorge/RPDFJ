using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Academico
{
    public class Aca_Contrato_x_Estudiante_x_det_Excepcion_Info
    {
        public int IdInstitucion { get; set; }
        public decimal IdContrato { get; set; }
        public decimal IdRubro { get; set; }
        public int IdInstitucion_Per { get; set; }

        //public string IdAnioLectivo_Per { get; set; }
        public int IdAnioLectivo_Per { get; set; }

        public int IdPeriodo_Per { get; set; }
        public decimal IdExepcion { get; set; }
        public double ValorExepcion { get; set; }
        public bool estado { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaAnulaicon { get; set; }
        public string UsuarioAnulacion { get; set; }

        public bool check { get; set; }
        public double ValorRubro { get; set; }      
        public Nullable<int> IdEmpresa { get; set; }       
        public string descuento { get; set; }
        public int TieneDescuento { get; set; }        
        public string AnioLectivo { get; set; }

        public decimal IdDescuento { get; set; }
        public string nom_descuento { get; set; }
        public int IdPeriodo { get; set; }
        public string Descripcion_rubro { get; set; }
       


        public Nullable<double> porcentaje_excepcion { get; set; }
       
    }
}
