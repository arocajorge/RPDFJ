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
    
    public partial class ct_centro_costo_sub_centro_costo
    {
        public ct_centro_costo_sub_centro_costo()
        {
            this.ct_cbtecble_det = new HashSet<ct_cbtecble_det>();
        }
    
        public int IdEmpresa { get; set; }
        public string IdCentroCosto { get; set; }
        public string IdCentroCosto_sub_centro_costo { get; set; }
        public string cod_subcentroCosto { get; set; }
        public string Centro_costo { get; set; }
        public string pc_Estado { get; set; }
        public string IdCtaCble { get; set; }
        public Nullable<double> Valor_depreciacion { get; set; }
    
        public virtual ICollection<ct_cbtecble_det> ct_cbtecble_det { get; set; }
        public virtual ct_centro_costo ct_centro_costo { get; set; }
        public virtual ct_plancta ct_plancta { get; set; }
    }
}
