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
    
    public partial class ct_GrupoEmpresarial_plancta_nivel
    {
        public ct_GrupoEmpresarial_plancta_nivel()
        {
            this.ct_GrupoEmpresarial_plancta = new HashSet<ct_GrupoEmpresarial_plancta>();
        }
    
        public int IdNivelCta_gr { get; set; }
        public int nv_NumDigitos_gr { get; set; }
        public string nv_Descripcion_gr { get; set; }
    
        public virtual ICollection<ct_GrupoEmpresarial_plancta> ct_GrupoEmpresarial_plancta { get; set; }
    }
}