using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.CuentasxCobrar
{
    public class cxc_XML_DocumentoDet_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdDocumento { get; set; }
        public int Secuencia { get; set; }
        public string TipoRetencion { get; set; }
        public string CodigoRetencion { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal PorcentajeRetencion { get; set; }
        public decimal ValorRetenido { get; set; }
        public string CodDocSustento { get; set; }
        public string NumDocSustento { get; set; }
        public System.DateTime FechaEmisionDocSustento { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public Nullable<decimal> IdCobro { get; set; }
        public string dc_TipoDocumento { get; set; }
        public Nullable<int> IdBodega_Cbte { get; set; }
        public Nullable<decimal> IdCbte_vta_nota { get; set; }

        #region Campos que no existen en la tabla
        public string IdCobro_tipo { get; set; }
        public int AplicaRetencion { get; set; }
        #endregion
    }
}
