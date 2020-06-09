using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.CuentasxCobrar
{
    public class cxc_XML_Documento_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdDocumento { get; set; }
        public string Comprobante { get; set; }
        public string XML { get; set; }
        public string Tipo { get; set; }
        public string emi_RazonSocial { get; set; }
        public string emi_NombreComercial { get; set; }
        public string emi_Ruc { get; set; }
        public string emi_DireccionMatriz { get; set; }
        public string emi_ContribuyenteEspecial { get; set; }
        public string ClaveAcceso { get; set; }
        public string CodDocumento { get; set; }
        public string Establecimiento { get; set; }
        public string PuntoEmision { get; set; }
        public string NumeroDocumento { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public string rec_RazonSocial { get; set; }
        public string rec_Identificacion { get; set; }
        public bool Estado { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public string Observacion { get; set; }

        #region Campos que no existen en la base
        public List<cxc_XML_DocumentoDet_Info> ListaDet { get; set; }
        #endregion
    }
}
