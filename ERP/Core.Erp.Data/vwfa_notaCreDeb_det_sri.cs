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
    
    public partial class vwfa_notaCreDeb_det_sri
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdNota { get; set; }
        public int Secuencia { get; set; }
        public decimal IdProducto { get; set; }
        public double sc_cantidad { get; set; }
        public double sc_Precio { get; set; }
        public double sc_descUni { get; set; }
        public double sc_PordescUni { get; set; }
        public double sc_precioFinal { get; set; }
        public double sc_subtotal { get; set; }
        public double sc_iva { get; set; }
        public double sc_total { get; set; }
        public string sc_estado { get; set; }
        public string pr_codigo { get; set; }
        public string pr_descripcion { get; set; }
        public double vt_por_iva { get; set; }
        public string IdCod_Impuesto_Iva { get; set; }
        public string IdCod_Impuesto_Ice { get; set; }
        public string sc_observacion { get; set; }
        public string IdCentroCosto { get; set; }
        public string IdCentroCosto_sub_centro_costo { get; set; }
    }
}