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
    
    public partial class ro_empleado_x_Activo_Fijo
    {
        public int IdEmpresa { get; set; }
        public decimal IdEmpleado { get; set; }
        public Nullable<int> IdNomina_tipo { get; set; }
        public Nullable<int> IdPeriodo { get; set; }
        public int IdActivo_fijo { get; set; }
        public System.DateTime Fecha_Asignacion { get; set; }
        public System.DateTime Fecha_Hasta { get; set; }
        public string IdCentroCosto { get; set; }
        public string IdCentroCosto_sub_centro_costo { get; set; }
    }
}
