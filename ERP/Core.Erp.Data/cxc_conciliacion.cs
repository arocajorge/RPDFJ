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
    
    public partial class cxc_conciliacion
    {
        public cxc_conciliacion()
        {
            this.cxc_conciliacion_det = new HashSet<cxc_conciliacion_det>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdConciliacion { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public Nullable<decimal> IdCliente { get; set; }
        public string Estado { get; set; }
        public string IdUsuario { get; set; }
        public System.DateTime Fecha_Transaccion { get; set; }
        public string IdUsuarioUltModi { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotivoAnulacion { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public Nullable<int> IdEmpresa_cbte_cble { get; set; }
        public Nullable<int> IdTipoCbte_cbte_cble { get; set; }
        public Nullable<decimal> IdCbteCble_cbte_cble { get; set; }
    
        public virtual ICollection<cxc_conciliacion_det> cxc_conciliacion_det { get; set; }
    }
}
