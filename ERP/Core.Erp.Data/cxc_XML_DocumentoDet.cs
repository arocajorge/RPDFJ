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
    
    public partial class cxc_XML_DocumentoDet
    {
        public int IdEmpresa { get; set; }
        public decimal IdDocumento { get; set; }
        public int Secuencia { get; set; }
        public string TipoRetencion { get; set; }
        public string CodigoRetencion { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal PorcentajeRetencion { get; set; }
        public decimal ValorRetenido { get; set; }
        public string CodDocSustento { get; set; }
        public string NumDocSustento { get; set; }
        public System.DateTime FechaEmisionDocSustento { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public Nullable<decimal> IdCobro { get; set; }
        public string dc_TipoDocumento { get; set; }
        public Nullable<int> IdBodega_Cbte { get; set; }
        public Nullable<decimal> IdCbte_vta_nota { get; set; }
        public string IdCobro_tipo { get; set; }
    
        public virtual cxc_cobro cxc_cobro { get; set; }
        public virtual cxc_XML_Documento cxc_XML_Documento { get; set; }
    }
}
