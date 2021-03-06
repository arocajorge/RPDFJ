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
    
    public partial class ro_permiso_x_empleado
    {
        public ro_permiso_x_empleado()
        {
            this.ro_permiso_x_empleado_x_novedad = new HashSet<ro_permiso_x_empleado_x_novedad>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdNomina_Tipo { get; set; }
        public decimal IdEmpleado { get; set; }
        public decimal IdPermiso { get; set; }
        public string IdEstadoAprob { get; set; }
        public Nullable<decimal> IdEmpleado_Apro { get; set; }
        public Nullable<decimal> IdEmpleado_Soli { get; set; }
        public string IdTipoLicencia { get; set; }
        public string Id_Forma_descuento_permiso_Cat { get; set; }
        public Nullable<int> Dias_tomados { get; set; }
        public System.DateTime Fecha { get; set; }
        public string MotivoAusencia { get; set; }
        public System.TimeSpan TiempoAusencia { get; set; }
        public string FormaRecuperacion { get; set; }
        public string MotivoAproba { get; set; }
        public string Observacion { get; set; }
        public Nullable<bool> EsLicencia { get; set; }
        public Nullable<bool> EsPermiso { get; set; }
        public Nullable<System.DateTime> FechaSalida { get; set; }
        public Nullable<System.DateTime> FechaEntrada { get; set; }
        public string HoraSalida { get; set; }
        public string HoraRegreso { get; set; }
        public string Estado { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuario_Anu { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public string ip { get; set; }
        public string nom_pc { get; set; }
        public string MotivoAnulacion { get; set; }
        public Nullable<decimal> IdNovedad { get; set; }
    
        public virtual ICollection<ro_permiso_x_empleado_x_novedad> ro_permiso_x_empleado_x_novedad { get; set; }
    }
}
