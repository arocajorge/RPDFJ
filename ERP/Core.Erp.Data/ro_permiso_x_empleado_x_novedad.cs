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
    
    public partial class ro_permiso_x_empleado_x_novedad
    {
        public int IdEmpresa { get; set; }
        public int IdNomina_Tipo { get; set; }
        public decimal IdEmpleado { get; set; }
        public decimal IdPermiso { get; set; }
        public int IdEmpresa_nov { get; set; }
        public decimal IdNovedad { get; set; }
        public decimal IdEmpleado_nov { get; set; }
        public string Observacion { get; set; }
    
        public virtual ro_empleado_Novedad ro_empleado_Novedad { get; set; }
        public virtual ro_permiso_x_empleado ro_permiso_x_empleado { get; set; }
    }
}
