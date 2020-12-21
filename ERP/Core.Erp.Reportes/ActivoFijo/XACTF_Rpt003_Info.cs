﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Core.Erp.Reportes.ActivoFijo
{
    public class XACTF_Rpt003_Info
    {
        public int IdEmpresa { get; set; }
        public int IdActivoFijo { get; set; }
        public int IdSucursal { get; set; }
        public int IdActijoFijoTipo { get; set; }
        public int IdTipoDepreciacion { get; set; }
        public string CodActivoFijo { get; set; }
        public string nom_tipo_depreciacion { get; set; }
        public string Af_Descripcion { get; set; }
        public string Descripcion { get; set; }
        public string Su_Descripcion { get; set; }
        public string Af_Nombre { get; set; }
        public int IdDepartamento { get; set; }
        public string Af_Marca { get; set; }
        public string Af_Modelo { get; set; }
        public string Af_NumSerie { get; set; }
        public string Af_Color { get; set; }
        public string Af_Ubicacion { get; set; }
        public string Encargado { get; set; }
        public string Af_observacion { get; set; }
        public string Af_NumPlaca { get; set; }
        public int Af_Anio_fabrica { get; set; }
        public string Af_DescripcionCorta { get; set; }
        public DateTime Af_fecha_compra { get; set; }
        public double Af_costo_compra { get; set; }
        public double Af_Costo_historico { get; set; }
        public int Af_Vida_Util { get; set; }
        public int Af_Meses_depreciar { get; set; }
        public double Af_ValorSalvamento { get; set; }
        public double Af_ValorResidual { get; set; }
        public string Estado_Proceso { get; set; }
        public string IdPeriodoDeprec { get; set; }
        public string Descri_Periodo { get; set; }
        public Image Logo { get; set; }

        public double Valor_Depreciacion { get; set; }
        public double Valor_Depre_Acum { get; set; }
        public double Valor_Importe { get; set; }

        public XACTF_Rpt003_Info()
        {

        }

        public Bitmap AF_ruta { get; set; }
    }
}
