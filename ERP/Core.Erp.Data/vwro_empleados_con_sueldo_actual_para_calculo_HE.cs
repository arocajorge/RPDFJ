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
    
    public partial class vwro_empleados_con_sueldo_actual_para_calculo_HE
    {
        public int IdEmpresa { get; set; }
        public decimal IdEmpleado { get; set; }
        public int IdTipoNomina { get; set; }
        public decimal IdPersona { get; set; }
        public string pe_apellido { get; set; }
        public string pe_nombre { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string Descripcion { get; set; }
        public string em_status { get; set; }
        public Nullable<double> SueldoActual { get; set; }
        public string Estado { get; set; }
        public string Nombre_Grupo { get; set; }
        public int Calculo_Horas_extras_Sobre { get; set; }
        public int Max_num_horas_sab_dom { get; set; }
        public string de_descripcion { get; set; }
        public string ca_descripcion { get; set; }
        public int IdCargo { get; set; }
        public Nullable<double> Valor_Alimen { get; set; }
        public Nullable<double> Valor_Transp { get; set; }
        public Nullable<double> Valor_bono { get; set; }
    }
}