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
    
    public partial class cxc_cancelacion_Intercompany_det
    {
        public int IdEmpresa { get; set; }
        public decimal IdCancelacion { get; set; }
        public int Secuencia { get; set; }
        public int cbteVta_IdEmpresa { get; set; }
        public int cbteVta_IdSucursal { get; set; }
        public int cbteVta_IdBodega { get; set; }
        public string cbteVta_TipoDoc { get; set; }
        public decimal cbteVta_IdCbteVta { get; set; }
        public Nullable<int> cbr_IdEmpresa { get; set; }
        public Nullable<int> cbr_IdSucursal { get; set; }
        public Nullable<decimal> cbr_IdCobro { get; set; }
        public double Valor_Aplicado { get; set; }
    
        public virtual cxc_cancelacion_Intercompany cxc_cancelacion_Intercompany { get; set; }
    }
}
