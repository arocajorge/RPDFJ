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
    
    public partial class Af_Depreciacion_Det
    {
        public int IdEmpresa { get; set; }
        public decimal IdDepreciacion { get; set; }
        public int IdTipoDepreciacion { get; set; }
        public int Secuencia { get; set; }
        public int IdActivoFijo { get; set; }
        public int Ciclo { get; set; }
        public string Concepto { get; set; }
        public double Valor_Compra { get; set; }
        public double Valor_Salvamento { get; set; }
        public int Vida_Util { get; set; }
        public double Porc_Depreciacion { get; set; }
        public double Valor_Depreciacion { get; set; }
        public double Valor_Depre_Acum { get; set; }
        public double Valor_Importe { get; set; }
        public bool Es_Activo_x_Mejora { get; set; }
    
        public virtual Af_Depreciacion Af_Depreciacion { get; set; }
        public virtual Af_Activo_fijo Af_Activo_fijo { get; set; }
    }
}
