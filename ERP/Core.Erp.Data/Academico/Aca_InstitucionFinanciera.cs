//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data.Academico
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aca_InstitucionFinanciera
    {
        public int IdInstitucionFinaciera { get; set; }
        public string IdTipoCuenta_catalogo { get; set; }
        public string CodigoInstitucion { get; set; }
        public string NombreInstitucion { get; set; }
        public string CodAlterno { get; set; }
        public string NombreAlterno { get; set; }
        public decimal Porc_comision { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string UsuarioAnulacion { get; set; }
        public string MotivoAnulacion { get; set; }
    
        public virtual Aca_Catalogo Aca_Catalogo { get; set; }
    }
}