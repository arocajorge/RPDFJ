using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Erp.Info.CuentasxCobrar;
using Core.Erp.Business.CuentasxCobrar;
using Core.Erp.Info.General;
using Core.Erp.Business.General;

namespace Core.Erp.Winform.CuentasxCobrar
{
    public partial class frmCXC_XML_Mantenimiento : Form
    {
        #region Variables
        cxc_XML_Documento_Bus busXML;
        cxc_XML_DocumentoDet_Bus busXMLDet;
        cxc_XML_Documento_Info infoXML;
        Cl_Enumeradores.eTipo_action Accion;
        BindingList<cxc_XML_DocumentoDet_Info> blst;
        cxc_cobro_tipo_Bus busTipoCobro;
        cl_parametrosGenerales_Bus param;
        #endregion

        #region Delegados
        public delegate void delegate_frmCXC_XML_Mantenimiento_FormClosed(object sender, FormClosedEventArgs e);
        public event delegate_frmCXC_XML_Mantenimiento_FormClosed event_delegate_frmCXC_XML_Mantenimiento_FormClosed;
        private void frmCXC_XML_Mantenimiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            event_delegate_frmCXC_XML_Mantenimiento_FormClosed(sender, e);
        }

        void frmCXC_XML_Mantenimiento_event_delegate_frmCXC_XML_Mantenimiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        #endregion

        public frmCXC_XML_Mantenimiento()
        {
            InitializeComponent();
            busXML = new cxc_XML_Documento_Bus();
            busXMLDet = new cxc_XML_DocumentoDet_Bus();
            infoXML = new cxc_XML_Documento_Info();
            blst = new BindingList<cxc_XML_DocumentoDet_Info>();
            busTipoCobro = new cxc_cobro_tipo_Bus();
            param = cl_parametrosGenerales_Bus.Instance;
            event_delegate_frmCXC_XML_Mantenimiento_FormClosed += frmCXC_XML_Mantenimiento_event_delegate_frmCXC_XML_Mantenimiento_FormClosed;
        }

        private void frmCXC_XML_Mantenimiento_Load(object sender, EventArgs e)
        {
            SetAccionInControls();
        }

        #region Metodos
        public void SetInfo(Cl_Enumeradores.eTipo_action _Accion, cxc_XML_Documento_Info _info)
        {
            Accion = _Accion;
            infoXML = _info;
        }

        private void SetAccionInControls()
        {
            CargarCombos();
            switch (Accion)
            {
                case Cl_Enumeradores.eTipo_action.actualizar:
                    SetInfoInControls();
                    ucGe_Menu_Superior_Mant1.btnGuardar.Visible = false;
                    ucGe_Menu_Superior_Mant1.btnGuardar_y_Salir.Visible = false;
                    ucGe_Menu_Superior_Mant1.Visible_bntAnular = false;
                    break;
                case Cl_Enumeradores.eTipo_action.Anular:
                    ucGe_Menu_Superior_Mant1.btnGuardar.Visible = false;
                    ucGe_Menu_Superior_Mant1.Visible_bntAnular = true;
                    ucGe_Menu_Superior_Mant1.btnGuardar_y_Salir.Visible = false;
                    SetInfoInControls();
                    break;
                case Cl_Enumeradores.eTipo_action.consultar:
                    ucGe_Menu_Superior_Mant1.btnGuardar.Visible = false;
                    ucGe_Menu_Superior_Mant1.Visible_bntAnular = false;
                    ucGe_Menu_Superior_Mant1.btnGuardar_y_Salir.Visible = false;
                    SetInfoInControls();
                    break;
            }
        }

        private void SetInfoInControls()
        {
            try
            {
                txtID.Text = infoXML.IdDocumento.ToString();
                txtContribuyente.Text = infoXML.emi_ContribuyenteEspecial;
                deFecha.DateTime = infoXML.FechaEmision.Date;
                txtCodDocumento.Text = infoXML.CodDocumento;
                txtTipo.Text = infoXML.Tipo;
                txtEstablecimiento.Text = infoXML.Establecimiento;
                txtPuntoEmision.Text = infoXML.PuntoEmision;
                txtNumDocumento.Text = infoXML.NumeroDocumento;
                txtClaveAcceso.Text = infoXML.ClaveAcceso;
                txtIdentificacion.Text = infoXML.emi_Ruc;
                txtRazonSocial.Text = infoXML.emi_RazonSocial;
                txtNombreComercial.Text = infoXML.emi_NombreComercial;
                txtDireccion.Text = infoXML.emi_DireccionMatriz;

                infoXML.ListaDet = busXMLDet.GetList(infoXML.IdEmpresa, infoXML.IdDocumento);
                blst = new BindingList<cxc_XML_DocumentoDet_Info>(infoXML.ListaDet);
                gcDetalleXML.DataSource = blst;


                txtTotalRetencionFuente.Text = infoXML.ListaDet.Where(q=> q.TipoRetencion == "FTE").Sum(q => q.ValorRetenido).ToString("n2");
                txtTotalRetencionIVA.Text = infoXML.ListaDet.Where(q => q.TipoRetencion == "IVA").Sum(q => q.ValorRetenido).ToString("n2");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CargarCombos()
        {
            try
            {
                var lst = busTipoCobro.Get_List_Cobro_Tipo();
                cmbCobroTipo.DataSource = lst;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private bool AnularDB()
        {
            try
            {
                if (busXML.AnularDB(infoXML.IdEmpresa, infoXML.IdDocumento, param.IdUsuario))
                {
                    MessageBox.Show("Registro anulado exitósamente", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se ha podido anular el registro", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n"+ex.Message,param.Nombre_sistema,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        #region Eventos
        private void ucGe_Menu_Superior_Mant1_event_btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void ucGe_Menu_Superior_Mant1_event_btnAnular_Click(object sender, EventArgs e)
        {
            if (AnularDB())
            {
                this.Close();
            }
        }

        
    }
}
