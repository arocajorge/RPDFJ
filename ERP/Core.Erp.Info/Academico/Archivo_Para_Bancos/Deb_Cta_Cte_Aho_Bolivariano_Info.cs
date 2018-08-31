using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Academico.Archivo_Para_Bancos
{
    public class Deb_Cta_Cte_Aho_Bolivariano_Info
    {
        //Cabecera
        public string Indicador { get; set; }
        public string CodigoColegio { get; set; }
        public string CodigoProceso { get; set; }
        public string FechaFacturacion { get; set; }

        //Detalle
        public string CodigoAlumno { get; set; }
        public string FechaIngresoPension { get; set; }
        public string Valor { get; set; }
        public string FechaTopePago { get; set; }
        public string FechaTopeProntoPago { get; set; }
        public string Estado { get; set; }
        public string NombreEstudiante { get; set; }
        public string Curso { get; set; }
        public string Paralelo { get; set; }
        public string Seccion { get; set; }
        public string ValorActual { get; set; }
        public string CuentaBanco { get; set; }
        public string Moneda { get; set; }
        public string Monto1 { get; set; }
        public string Monto2 { get; set; }

    }
}
