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
    
    public partial class vwfa_liquidacion_x_punto_cargo_x_fa_factura_x_aplicar
    {
        public long IdRow { get; set; }
        public string ID { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdCbteVta { get; set; }
        public string Su_Descripcion { get; set; }
        public string bo_Descripcion { get; set; }
        public string vt_serie1 { get; set; }
        public string vt_serie2 { get; set; }
        public string vt_NumFactura { get; set; }
        public decimal IdCliente { get; set; }
        public string pe_nombreCompleto { get; set; }
        public double vt_Subtotal { get; set; }
        public double vt_iva { get; set; }
        public double vt_total { get; set; }
        public Nullable<double> vt_saldo { get; set; }
        public string num_oc { get; set; }
        public string descripcion_fact { get; set; }
        public string IdCentroCosto_cc { get; set; }
    }
}