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
    
    public partial class vwro_Parametros
    {
        public int IdEmpresa { get; set; }
        public Nullable<int> IdTipoCbte_AsientoSueldoXPagar { get; set; }
        public Nullable<int> IdTipoCbte_AsientoProvision { get; set; }
        public Nullable<int> IdTipo_mov_Ingreso { get; set; }
        public Nullable<int> IdTipo_mov_Egreso { get; set; }
        public Nullable<int> Dias_considerado_ultimo_pago_quincela_Liq { get; set; }
        public Nullable<int> IdNomina_Tipo_Para_Desc_Automat { get; set; }
        public Nullable<int> IdNominatipoLiq_Para_Desc_Automat { get; set; }
        public Nullable<bool> GeneraraOP_PagoTerceros { get; set; }
        public string IdTipoOP_PagoTerceros { get; set; }
        public Nullable<int> IdTipoFlujoOP_PagoTerceros { get; set; }
        public string IdFormaOP_PagoTerceros { get; set; }
        public Nullable<int> IdBancoOP_PagoTerceros { get; set; }
        public Nullable<bool> GeneraOP_PagoPrestamos { get; set; }
        public string IdTipoOP_PagoPrestamos { get; set; }
        public Nullable<int> IdTipoFlujoOP_PagoPrestamos { get; set; }
        public string IdFormaOP_PagoPrestamos { get; set; }
        public Nullable<int> IdBancoOP_PagoPrestamos { get; set; }
        public string IdCtaCble { get; set; }
        public string IdCtaCble_Credito { get; set; }
    }
}