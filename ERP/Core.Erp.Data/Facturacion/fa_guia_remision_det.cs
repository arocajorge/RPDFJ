//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data.Facturacion
{
    using System;
    using System.Collections.Generic;
    
    public partial class fa_guia_remision_det
    {
        public fa_guia_remision_det()
        {
            this.fa_guia_remision_det_x_fa_orden_Desp_det = new HashSet<fa_guia_remision_det_x_fa_orden_Desp_det>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdGuiaRemision { get; set; }
        public int Secuencia { get; set; }
        public decimal IdProducto { get; set; }
        public double gi_cantidad { get; set; }
        public double gi_Precio { get; set; }
        public double gi_PorDescUnitario { get; set; }
        public double gi_DescUnitario { get; set; }
        public double gi_PrecioFinal { get; set; }
        public double gi_Subtotal { get; set; }
        public double gi_iva { get; set; }
        public double gi_total { get; set; }
        public double gi_costo { get; set; }
        public string gi_tieneIVA { get; set; }
        public string gi_detallexItems { get; set; }
        public Nullable<double> gi_peso { get; set; }
    
        public virtual fa_guia_remision fa_guia_remision { get; set; }
        public virtual ICollection<fa_guia_remision_det_x_fa_orden_Desp_det> fa_guia_remision_det_x_fa_orden_Desp_det { get; set; }
    }
}