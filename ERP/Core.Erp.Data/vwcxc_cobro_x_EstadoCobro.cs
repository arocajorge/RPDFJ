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
    
    public partial class vwcxc_cobro_x_EstadoCobro
    {
        public decimal IdPersona { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdCobro { get; set; }
        public string IdCobro_tipo { get; set; }
        public decimal IdCliente { get; set; }
        public double cr_TotalCobro { get; set; }
        public System.DateTime cr_fecha { get; set; }
        public System.DateTime cr_fechaCobro { get; set; }
        public System.DateTime cr_fechaDocu { get; set; }
        public string cr_observacion { get; set; }
        public string cr_Banco { get; set; }
        public string cr_cuenta { get; set; }
        public string cr_Tarjeta { get; set; }
        public string cr_NumDocumento { get; set; }
        public string cr_estado { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<decimal> cr_recibo { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string nSucursal { get; set; }
        public string nCliente { get; set; }
        public string cr_NumCheque { get; set; }
        public string IdEstadoCobro { get; set; }
        public Nullable<System.DateTime> Fecha_Cobro { get; set; }
        public int IdVendedorCliente { get; set; }
        public string cr_Codigo { get; set; }
        public int IdCaja { get; set; }
    }
}
