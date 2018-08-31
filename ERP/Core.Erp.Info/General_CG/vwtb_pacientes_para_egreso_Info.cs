using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.General_CG
{
    public class vwtb_pacientes_para_egreso_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdIngreso { get; set; }
        public decimal IdCuenta { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string pe_nombreCompleto { get; set; }
        public int IdPlan { get; set; }
        public string nom_plan { get; set; }
        public int IdEstado { get; set; }
        public string nom_estado { get; set; }
        public DateTime Fecha_ingreso { get; set; }
        public DateTime Fecha_salida { get; set; }

    }
}
