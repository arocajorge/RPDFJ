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
    
    public partial class fa_devol_venta
    {
        public fa_devol_venta()
        {
            this.fa_devol_venta_det = new HashSet<fa_devol_venta_det>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdDevolucion { get; set; }
        public string CodDevolucion { get; set; }
        public decimal IdNota { get; set; }
        public decimal IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public decimal IdCbteVta { get; set; }
        public System.DateTime dv_fecha { get; set; }
        public string Estado { get; set; }
        public string dv_Observacion { get; set; }
        public double dv_seguro { get; set; }
        public double dv_flete { get; set; }
        public double dv_interes { get; set; }
        public double dv_OtroValor1 { get; set; }
        public double dv_OtroValor2 { get; set; }
        public string IdUsuario { get; set; }
        public string MotivoAnulacion { get; set; }
        public Nullable<int> mvInv_IdEmpresa { get; set; }
        public Nullable<int> mvInv_IdSucursal { get; set; }
        public Nullable<int> mvInv_IdBodega { get; set; }
        public Nullable<int> mvInv_IdMovi_inven_tipo { get; set; }
        public Nullable<decimal> mvInv_IdNumMovi { get; set; }
        public Nullable<int> mvInv_IdEmpresa_x_Anu { get; set; }
        public Nullable<int> mvInv_IdSucursal_x_Anu { get; set; }
        public Nullable<int> mvInv_IdBodega_x_Anu { get; set; }
        public Nullable<int> mvInv_IdMovi_inven_tipo_x_Anu { get; set; }
        public Nullable<decimal> mvInv_IdNumMovi_x_Anu { get; set; }
    
        public virtual ICollection<fa_devol_venta_det> fa_devol_venta_det { get; set; }
        public virtual fa_Vendedor fa_Vendedor { get; set; }
        public virtual fa_factura fa_factura { get; set; }
        public virtual fa_notaCreDeb fa_notaCreDeb { get; set; }
        public virtual fa_cliente fa_cliente { get; set; }
    }
}