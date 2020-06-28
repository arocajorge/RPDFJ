using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Roles_Fj
{
    public class ro_Calculo_Pago_Variable_Porcentaje_servicio_Info
    {
        public int IdEmpresa { get; set; }
        public int IdEfectividad { get; set; }
        public int IdTipo_Nomina { get; set; }
        public int IdTipoServicio { get; set; }
        public double Efec_desde { get; set; }
        public double Efec_hasta { get; set; }
        public double Efec_aplica { get; set; }
    }
}
