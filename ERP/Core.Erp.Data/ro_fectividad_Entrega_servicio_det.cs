//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ro_fectividad_Entrega_servicio_det
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
        public double Por_bebida { get; set; }
        public double Por_alimento { get; set; }
    
        public virtual ro_fectividad_Entrega_servicio ro_fectividad_Entrega_servicio { get; set; }
    }
}
