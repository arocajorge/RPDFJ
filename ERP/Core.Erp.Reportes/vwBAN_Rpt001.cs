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
    
    public partial class vwBAN_Rpt001
    {
        public int IdEmpresa { get; set; }
        public string Tipo_Cbte { get; set; }
        public decimal Num_Cbte { get; set; }
        public int IdBanco { get; set; }
        public string Banco { get; set; }
        public System.DateTime Fch_Cbte { get; set; }
        public string Observacion { get; set; }
        public double Valor { get; set; }
        public string Cheque { get; set; }
        public string Chq_Girado_A { get; set; }
        public Nullable<int> IdTipoNota { get; set; }
        public string Tipo_Nota { get; set; }
        public string Fch_PostFechado { get; set; }
        public Nullable<System.DateTime> Fch_Chq { get; set; }
        public string Cta_Cble_Banco { get; set; }
        public int IdCalendario { get; set; }
        public Nullable<int> AnioFiscal { get; set; }
        public string NombreMes { get; set; }
        public string NombreCortoFecha { get; set; }
        public Nullable<int> IdMes { get; set; }
        public string pc_Cuenta { get; set; }
        public string Estado { get; set; }
        public string IdEstado_cheque_cat { get; set; }
        public string ca_descripcion { get; set; }
    }
}