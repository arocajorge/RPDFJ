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
    
    public partial class ro_empleado_x_parametro_x_pago_variable_Det
    {
        public int IdEmpresa { get; set; }
        public int IdNomina_Tipo { get; set; }
        public decimal IdEmpleado { get; set; }
        public int Id_Tipo_Pago_Variable { get; set; }
        public int Secuencia { get; set; }
    
        public virtual ro_parametro_x_pago_variable ro_parametro_x_pago_variable { get; set; }
        public virtual ro_empleado_x_parametro_x_pago_variable ro_empleado_x_parametro_x_pago_variable { get; set; }
    }
}
