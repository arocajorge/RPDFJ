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
    
    public partial class in_movi_inve_detalle_x_Producto_CusCider
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public int IdMovi_inven_tipo { get; set; }
        public decimal IdNumMovi { get; set; }
        public int mv_Secuencia { get; set; }
        public int Secuencia { get; set; }
        public decimal IdProducto { get; set; }
        public decimal secmax { get; set; }
        public string CodigoBarra { get; set; }
        public string mv_tipo_movi { get; set; }
        public double dm_cantidad { get; set; }
        public string dm_observacion { get; set; }
        public double dm_precio { get; set; }
        public double mv_costo { get; set; }
        public Nullable<int> et_IdEmpresa { get; set; }
        public Nullable<int> et_IdProcesoProductivo { get; set; }
        public Nullable<int> et_IdEtapa { get; set; }
        public Nullable<int> ot_IdEmpresa { get; set; }
        public Nullable<int> ot_IdSucursal { get; set; }
        public string ot_CodObra { get; set; }
        public Nullable<decimal> ot_IdOrdenTaller { get; set; }
        public string CodObra_preasignada { get; set; }
        public Nullable<decimal> IdOrdenTaller_preasignada { get; set; }
        public Nullable<double> Alto { get; set; }
        public Nullable<double> Largo { get; set; }
        public Nullable<double> Ancho { get; set; }
        public Nullable<decimal> ocd_IdOrdenCompra { get; set; }
        public string NumDocumentoRelacionadoProveedor { get; set; }
        public string NumFacturaProveedor { get; set; }
    }
}