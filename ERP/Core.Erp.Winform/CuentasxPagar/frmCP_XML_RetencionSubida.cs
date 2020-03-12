using Core.Erp.Business.CuentasxPagar;
using Core.Erp.Business.General;
using Core.Erp.Info.CuentasxPagar;
using Core.Erp.Info.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.Erp.Winform.CuentasxPagar
{
    public partial class frmCP_XML_RetencionSubida : Form
    {
        #region Variables
        public cp_XML_Documento_Info info { get; set; }
        cp_codigo_SRI_Bus bus_codigoSRI;
        BindingList<cp_XML_Documento_Retencion_Info> blst;
        cp_XML_Documento_Retencion_Bus bus_det;
        List<cp_codigo_SRI_Info> lst_codigoSRI;
        cl_parametrosGenerales_Bus param;
        cp_XML_Documento_Bus bus_xml;
        cp_XML_DocumentoDet_Bus bus_xml_det;
        #endregion

        public frmCP_XML_RetencionSubida()
        {
            InitializeComponent();
            info = new cp_XML_Documento_Info();
            bus_codigoSRI = new cp_codigo_SRI_Bus();
            lst_codigoSRI = new List<cp_codigo_SRI_Info>();
            blst = new BindingList<cp_XML_Documento_Retencion_Info>();
            bus_det = new cp_XML_Documento_Retencion_Bus();
            param = cl_parametrosGenerales_Bus.Instance;
            bus_xml = new cp_XML_Documento_Bus();
            bus_xml_det = new cp_XML_DocumentoDet_Bus();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmCP_XML_RetencionSubida_Load(object sender, EventArgs e)
        {
            blst = new BindingList<cp_XML_Documento_Retencion_Info>();
            gcRetencion.DataSource = blst;
            CargarCombos();
            SetInfoInControls();
        }

        private void CargarCombos()
        {
            try
            {
                txtEstablecimiento.Text = param.InfoSucursal.Su_CodigoEstablecimiento;
                tb_sis_Documento_Tipo_Talonario_Bus busTalonario = new tb_sis_Documento_Tipo_Talonario_Bus();
                var Talonario = busTalonario.GetInfoRetElectronico(param.IdEmpresa);
                txtEstablecimiento.Text = Talonario.Establecimiento;
                txtPuntoEmision.Text = Talonario.PuntoEmision;
                lst_codigoSRI = bus_codigoSRI.Get_List_codigo_SRI_IvaRet(param.IdEmpresa);
                cmbCodigoSRI.DataSource = lst_codigoSRI;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void SetInfoInControls()
        {
            try
            {
                txtID.Text = info.IdDocumento.ToString();
                txtTipo.Text = info.Tipo;
                txtCodDocumento.Text = info.CodDocumento;
                txtEstablecimiento.Text = info.Establecimiento;
                txtPuntoEmision.Text = info.PuntoEmision;
                txtNumDocumento.Text = info.NumeroDocumento;
                txtClaveAcceso.Text = info.ClaveAcceso;
                txtIdentificacion.Text = info.emi_Ruc;
                txtRazonSocial.Text = info.emi_RazonSocial;
                txtNombreComercial.Text = info.emi_NombreComercial;
                txtDireccion.Text = info.emi_DireccionMatriz;
                txtSubtotal0.Text = info.Subtotal0.ToString();
                txtSubtotalIVA.Text = info.SubtotalIVA.ToString();
                txtPorcentaje.Text = info.Porcentaje.ToString();
                txtIVA.Text = info.ValorIVA.ToString();
                txtTotal.Text = info.Total.ToString();

                txtRetSubtotal0.Text = info.Subtotal0.ToString();
                txtRetSubtotalIVA.Text = info.SubtotalIVA.ToString();
                txtRetIVA.Text = info.ValorIVA.ToString();
                txtRetTotal.Text = info.Total.ToString();

                deFecha.DateTime = Convert.ToDateTime(info.FechaEmision).Date;
                txtContribuyente.Text = info.emi_ContribuyenteEspecial;
                blst = new BindingList<cp_XML_Documento_Retencion_Info>(info.lstRetencion);
                gcRetencion.DataSource = blst;
                gcDetalleXML.DataSource = info.lstDetalle;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void gvRetencion_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                cp_XML_Documento_Retencion_Info row = (cp_XML_Documento_Retencion_Info)gvRetencion.GetRow(e.RowHandle);
                if (row == null)
                    return;

                if (colCodigoSRI == e.Column)
                {
                    if (e.Value != null)
                    {
                        var codigo = lst_codigoSRI.Where(q => q.IdCodigo_SRI == row.IdCodigo_SRI).FirstOrDefault();
                        if (codigo != null)
                        {
                            row.re_baseRetencion = (codigo.IdTipoSRI == "COD_RET_FUE" ? (info.Subtotal0 + info.SubtotalIVA) : info.ValorIVA);
                            row.re_Codigo_impuesto = codigo.codigoSRI;
                            row.re_Porcen_retencion = codigo.co_porRetencion;
                            row.re_tipoRet = (codigo.IdTipoSRI == "COD_RET_FUE" ? "RTF" : "IVA");
                            row.re_valor_retencion = Math.Round(row.re_baseRetencion * (row.re_Porcen_retencion / 100), 2, MidpointRounding.AwayFromZero);
                        }
                    }
                }
                if (colBaseImponible == e.Column)
                {
                    if (e.Value != null)
                    {
                        var codigo = lst_codigoSRI.Where(q => q.IdCodigo_SRI == row.IdCodigo_SRI).FirstOrDefault();
                        if (codigo != null)
                        {
                            row.re_valor_retencion = Math.Round(row.re_baseRetencion * (row.re_Porcen_retencion / 100), 2, MidpointRounding.AwayFromZero);
                        }
                    }
                }
                gcRetencion.Refresh();
            }
            catch (Exception)
            {

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRetSubtotal0.Focus();
                gvDetalleXML.MoveNext();
                info.lstRetencion = new List<cp_XML_Documento_Retencion_Info>(blst);

                this.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
