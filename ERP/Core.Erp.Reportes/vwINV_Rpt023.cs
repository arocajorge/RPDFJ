//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Reportes
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwINV_Rpt023
    {
        public int IdEmpresa { get; set; }
        public decimal IdDev_Inven { get; set; }
        public string cod_Dev_Inven { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public Nullable<int> IdBodega { get; set; }
        public Nullable<int> IdMovi_inven_tipo { get; set; }
        public Nullable<decimal> IdNumMovi { get; set; }
        public Nullable<decimal> IdProducto { get; set; }
        public double cantidad_a_devolver { get; set; }
        public Nullable<double> dm_cantidad { get; set; }
        public Nullable<double> mv_costo { get; set; }
        public string pr_descripcion { get; set; }
        public string Su_Descripcion { get; set; }
        public string tm_descripcion { get; set; }
        public int Secuencia_movi_inv { get; set; }
        public string observacion { get; set; }
    }
}
