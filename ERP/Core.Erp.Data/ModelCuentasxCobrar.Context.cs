﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntitiesCuentas_x_Cobrar : DbContext
    {
        public EntitiesCuentas_x_Cobrar()
            : base("name=EntitiesCuentas_x_Cobrar")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<cxc_cancelacion_Intercompany> cxc_cancelacion_Intercompany { get; set; }
        public DbSet<cxc_cancelacion_Intercompany_det> cxc_cancelacion_Intercompany_det { get; set; }
        public DbSet<cxc_Catalogo> cxc_Catalogo { get; set; }
        public DbSet<cxc_CatalogoTipo> cxc_CatalogoTipo { get; set; }
        public DbSet<cxc_cobro> cxc_cobro { get; set; }
        public DbSet<cxc_cobro_det> cxc_cobro_det { get; set; }
        public DbSet<cxc_cobro_tipo_Param_conta_x_sucursal> cxc_cobro_tipo_Param_conta_x_sucursal { get; set; }
        public DbSet<cxc_cobro_tipo_x_anticipo> cxc_cobro_tipo_x_anticipo { get; set; }
        public DbSet<cxc_cobro_tipo_x_cobros_Docxc> cxc_cobro_tipo_x_cobros_Docxc { get; set; }
        public DbSet<cxc_cobro_x_Anticipo> cxc_cobro_x_Anticipo { get; set; }
        public DbSet<cxc_cobro_x_Anticipo_det> cxc_cobro_x_Anticipo_det { get; set; }
        public DbSet<cxc_cobro_x_caj_Caja_Movimiento> cxc_cobro_x_caj_Caja_Movimiento { get; set; }
        public DbSet<cxc_cobro_x_ct_cbtecble> cxc_cobro_x_ct_cbtecble { get; set; }
        public DbSet<cxc_cobro_x_ct_cbtecble_x_Anulado> cxc_cobro_x_ct_cbtecble_x_Anulado { get; set; }
        public DbSet<cxc_cobro_x_EstadoCobro> cxc_cobro_x_EstadoCobro { get; set; }
        public DbSet<cxc_cobro_x_tarjeta> cxc_cobro_x_tarjeta { get; set; }
        public DbSet<cxc_conciliacion> cxc_conciliacion { get; set; }
        public DbSet<cxc_conciliacion_det> cxc_conciliacion_det { get; set; }
        public DbSet<cxc_conciliacion_tipo> cxc_conciliacion_tipo { get; set; }
        public DbSet<cxc_EstadoCobro> cxc_EstadoCobro { get; set; }
        public DbSet<cxc_Parametros_x_cheqProtesto> cxc_Parametros_x_cheqProtesto { get; set; }
        public DbSet<cxc_Rango_dias_x_Vencimiento> cxc_Rango_dias_x_Vencimiento { get; set; }
        public DbSet<vwcxc_anticipos_x_cruzar> vwcxc_anticipos_x_cruzar { get; set; }
        public DbSet<vwcxc_cancelacion_Intercompany> vwcxc_cancelacion_Intercompany { get; set; }
        public DbSet<vwcxc_cancelacion_Intercompany_x_cxc_cobro_det> vwcxc_cancelacion_Intercompany_x_cxc_cobro_det { get; set; }
        public DbSet<vwCxc_Catalogo_IdAuto_numeric> vwCxc_Catalogo_IdAuto_numeric { get; set; }
        public DbSet<vwcxc_cobro> vwcxc_cobro { get; set; }
        public DbSet<vwcxc_cobro_tipo_Param_conta_x_sucursal> vwcxc_cobro_tipo_Param_conta_x_sucursal { get; set; }
        public DbSet<vwcxc_cobro_x_anticipo_total_respaldado> vwcxc_cobro_x_anticipo_total_respaldado { get; set; }
        public DbSet<vwcxc_Cobro_x_anticipo_x_cobros> vwcxc_Cobro_x_anticipo_x_cobros { get; set; }
        public DbSet<vwcxc_cobro_x_Anticipo_x_Persona> vwcxc_cobro_x_Anticipo_x_Persona { get; set; }
        public DbSet<vwcxc_cobro_x_caj_Caja_Movimiento> vwcxc_cobro_x_caj_Caja_Movimiento { get; set; }
        public DbSet<vwcxc_cobro_x_cobro_det> vwcxc_cobro_x_cobro_det { get; set; }
        public DbSet<vwcxc_cobro_x_documentos_x_cobrar> vwcxc_cobro_x_documentos_x_cobrar { get; set; }
        public DbSet<vwcxc_cobro_x_EstadoCobro> vwcxc_cobro_x_EstadoCobro { get; set; }
        public DbSet<vwcxc_cobro_x_movi_caja_x_cbtecble> vwcxc_cobro_x_movi_caja_x_cbtecble { get; set; }
        public DbSet<vwcxc_cobros_conciliados> vwcxc_cobros_conciliados { get; set; }
        public DbSet<vwcxc_cobros_Pendientes_x_conciliar> vwcxc_cobros_Pendientes_x_conciliar { get; set; }
        public DbSet<vwcxc_cobros_x_cheque_deposito> vwcxc_cobros_x_cheque_deposito { get; set; }
        public DbSet<vwcxc_cobros_x_vta_nota_x_RetFuente> vwcxc_cobros_x_vta_nota_x_RetFuente { get; set; }
        public DbSet<vwcxc_cobros_x_vta_nota_x_RetFuente_Sumatoria> vwcxc_cobros_x_vta_nota_x_RetFuente_Sumatoria { get; set; }
        public DbSet<vwcxc_cobros_x_vta_nota_x_RetIVA_Sumatoria> vwcxc_cobros_x_vta_nota_x_RetIVA_Sumatoria { get; set; }
        public DbSet<vwcxc_conciliacion> vwcxc_conciliacion { get; set; }
        public DbSet<vwcxc_conciliacion_Det_Anticipo> vwcxc_conciliacion_Det_Anticipo { get; set; }
        public DbSet<vwcxc_conciliacion_Det_Cobro> vwcxc_conciliacion_Det_Cobro { get; set; }
        public DbSet<vwcxc_conciliacion_Det_CreDeb> vwcxc_conciliacion_Det_CreDeb { get; set; }
        public DbSet<vwcxc_Detalle_Deposito> vwcxc_Detalle_Deposito { get; set; }
        public DbSet<vwcxc_EstadoCobro_Actual> vwcxc_EstadoCobro_Actual { get; set; }
        public DbSet<vwCXC_EstadoCta_x_Cliente> vwCXC_EstadoCta_x_Cliente { get; set; }
        public DbSet<vwcxc_Parametros_x_cheqProtesto> vwcxc_Parametros_x_cheqProtesto { get; set; }
        public DbSet<vwcxc_cobros_x_vta_nota_x_RetIVA> vwcxc_cobros_x_vta_nota_x_RetIVA { get; set; }
        public DbSet<cxc_cobro_tipo_motivo> cxc_cobro_tipo_motivo { get; set; }
        public DbSet<cxc_cobro_tipo> cxc_cobro_tipo { get; set; }
        public DbSet<cxc_cobro_det_x_ct_cbtecble_det> cxc_cobro_det_x_ct_cbtecble_det { get; set; }
        public DbSet<vwcxc_cobro_det> vwcxc_cobro_det { get; set; }
        public DbSet<vwcxc_cobros_x_vta_x_RetFte_x_Cliente_x_AnioMes> vwcxc_cobros_x_vta_x_RetFte_x_Cliente_x_AnioMes { get; set; }
        public DbSet<vwcxc_cobros_x_vta_x_RetIva_x_Cliente_x_AnioMes> vwcxc_cobros_x_vta_x_RetIva_x_Cliente_x_AnioMes { get; set; }
        public DbSet<vwcxc_cobros_x_ND_x_RetFte_x_Cliente_x_AnioMes> vwcxc_cobros_x_ND_x_RetFte_x_Cliente_x_AnioMes { get; set; }
        public DbSet<vwcxc_cobros_x_ND_x_RetIva_x_Cliente_x_AnioMes> vwcxc_cobros_x_ND_x_RetIva_x_Cliente_x_AnioMes { get; set; }
        public DbSet<vwcxc_cartera_x_cobrar> vwcxc_cartera_x_cobrar { get; set; }
        public DbSet<cxc_Parametro> cxc_Parametro { get; set; }
        public DbSet<cxc_XML_Documento> cxc_XML_Documento { get; set; }
        public DbSet<cxc_XML_DocumentoDet> cxc_XML_DocumentoDet { get; set; }
    }
}
