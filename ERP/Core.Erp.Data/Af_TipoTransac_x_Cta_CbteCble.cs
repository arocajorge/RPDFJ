//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Af_TipoTransac_x_Cta_CbteCble
    {
        public int IdEmpresa { get; set; }
        public decimal IdTipTransActivoFijo { get; set; }
        public string IdCatalogo { get; set; }
        public int ct_IdEmpresa { get; set; }
        public int ct_IdTipoCbte { get; set; }
        public decimal ct_IdCbteCble { get; set; }
    
        public virtual Af_Catalogo Af_Catalogo { get; set; }
    }
}
