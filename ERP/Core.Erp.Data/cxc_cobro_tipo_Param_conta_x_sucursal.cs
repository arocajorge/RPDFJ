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
    
    public partial class cxc_cobro_tipo_Param_conta_x_sucursal
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public string IdCobro_tipo { get; set; }
        public string IdCtaCble { get; set; }
        public string IdCtaCble_Anticipo { get; set; }
    
        public virtual cxc_cobro_tipo cxc_cobro_tipo { get; set; }
    }
}
