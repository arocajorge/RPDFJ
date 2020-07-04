using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Erp.Reports.FJ.Roles
{
    public class XROLES_Rpt011_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdEmpleado { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string Empleado { get; set; }
        public string ca_descripcion { get; set; }
        public Nullable<double> SueldoActual { get; set; }
        public double Valor_bono { get; set; }
        public string zo_descripcion { get; set; }
        public string ru_descripcion { get; set; }
        public Nullable<System.DateTime> em_fechaIngaRol { get; set; }
        public Nullable<System.DateTime> em_fechaSalida { get; set; }
        public string em_status { get; set; }
        public double Efectividad_Entrega { get; set; }
        public double Efectividad_Entrega_aplica { get; set; }
        public double Efectividad_Volumen { get; set; }
        public double Efectividad_Volumen_aplica { get; set; }
        public double Recuperacion_cartera { get; set; }
        public double Recuperacion_cartera_aplica { get; set; }
        public double Valor { get; set; }
        public string Rubro { get; set; }
        public string fu_descripcion { get; set; }
        public Nullable<double> variable { get; set; }
        public Nullable<double> Iess { get; set; }
        public Nullable<double> dias_trabajados { get; set; }
        public Nullable<double> dias_Efectivos { get; set; }

        public Nullable<double> Efectividad_Entrega_ali { get; set; }
        public Nullable<double> Efectividad_Entrega_aplica_ali { get; set; }
        public Nullable<double> Efectividad_Volumen_ali { get; set; }
        public Nullable<double> Efectividad_Volumen_aplica_ali { get; set; }
        public Nullable<double> Recuperacion_cartera_ali { get; set; }
        public Nullable<double> Recuperacion_cartera_aplica_ali { get; set; }
        public Nullable<double> NivelServicio { get; set; }

    }
}
