using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Roles_Fj
{
   public class ro_fectividad_Entrega_servicio_det_Info
   {
        public int IdEmpresa { get; set; }
        public decimal IdNivelServicio { get; set; }
        public int Secuencia { get; set; }
        public int IdRuta { get; set; }
        public decimal IdEmpleado { get; set; }
        public double Efe_car_bebi { get; set; }
        public double Efe_car_bebi_apl { get; set; }
        public double Efe_vol_bebi { get; set; }
        public double Efe_vol_bebi_apl { get; set; }
        public double Efe_ent_bebi { get; set; }
        public double Efe_ent_bebi_apl { get; set; }
        public double Efe_car_alim { get; set; }
        public double Efe_car_alim_ap { get; set; }
        public double Efe_vol_alim { get; set; }
        public double Efe_vol_alim_apl { get; set; }
        public double Efe_ent_alim { get; set; }
        public double Efe_ent_alim_apl { get; set; }
        public double Efe_serv { get; set; }
        public double Efe_ser_apl { get; set; }
        public double Nivel_servicio { get; set; }
        public double Valor_volumen { get; set; }
        public double Valor_servicio { get; set; }
        public string pe_nombreCompleto { get; set; }
    }
}
