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
    
    public partial class caj_parametro
    {
        public int IdEmpresa { get; set; }
        public int IdTipoCbteCble_MoviCaja_Ing { get; set; }
        public int IdTipoCbteCble_MoviCaja_Egr { get; set; }
        public int IdTipoCbteCble_MoviCaja_Ing_Anu { get; set; }
        public int IdTipoCbteCble_MoviCaja_Egr_Anu { get; set; }
        public Nullable<int> IdTipo_movi_ing_x_reposicion { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> FechaUltMod { get; set; }
    }
}