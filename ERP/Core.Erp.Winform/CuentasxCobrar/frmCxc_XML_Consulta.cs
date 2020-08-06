using Core.Erp.Business.CuentasxCobrar;
using Core.Erp.Info.CuentasxCobrar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Erp.Business.General;
using Core.Erp.Info.General;

namespace Core.Erp.Winform.CuentasxCobrar
{
    public partial class frmCxc_XML_Consulta : Form
    {
        #region Variables
        cxc_XML_Documento_Bus busXML = new cxc_XML_Documento_Bus();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        #endregion

        public frmCxc_XML_Consulta()
        {
            InitializeComponent();
        }

        #region Acciones
        private void ucGe_Menu_Mantenimiento_x_usuario1_event_btnNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LlamarFormulario(Cl_Enumeradores.eTipo_action.grabar);
        }

        private void ucGe_Menu_Mantenimiento_x_usuario1_event_btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LlamarFormulario(Cl_Enumeradores.eTipo_action.actualizar);
        }

        private void ucGe_Menu_Mantenimiento_x_usuario1_event_btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void ucGe_Menu_Mantenimiento_x_usuario1_event_btnconsultar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LlamarFormulario(Cl_Enumeradores.eTipo_action.consultar);
        }

        private void ucGe_Menu_Mantenimiento_x_usuario1_event_btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ucGe_Menu_Mantenimiento_x_usuario1_event_btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcDetalle.ShowPrintPreview();
        }
        #endregion

        #region Métodos
        private void Buscar()
        {
            try
            {
                var lst = busXML.GetList(param.IdEmpresa, ucGe_Menu_Mantenimiento_x_usuario1.fecha_desde.Date, ucGe_Menu_Mantenimiento_x_usuario1.fecha_hasta.Date);
                gcDetalle.DataSource = lst;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,param.Nombre_sistema,MessageBoxButtons.OK);
            }
        }

        private void LlamarFormulario(Cl_Enumeradores.eTipo_action Accion)
        {
            try
            {
                if (Accion == Cl_Enumeradores.eTipo_action.grabar)
                {
                    frmCxc_XML_Digitalizacion frm = new frmCxc_XML_Digitalizacion();
                    frm.MdiParent = this.MdiParent;
                    frm.event_delegate_frmCxc_XML_Digitalizacion_FormClosed += frm_event_delegate_frmCxc_XML_Digitalizacion_FormClosed;
                    frm.Show();
                }
                else
                {
                    var row = (cxc_XML_Documento_Info)gvDetalle.GetFocusedRow();
                    if (row == null)
                    {
                        MessageBox.Show("Seleccione un registro",param.Nombre_sistema,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (row.Estado == false && Accion != Cl_Enumeradores.eTipo_action.consultar)
                    {
                        MessageBox.Show("El registro se encuentra anulado",param.Nombre_sistema,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return;
                    }
                    frmCXC_XML_Mantenimiento frmMant = new frmCXC_XML_Mantenimiento();
                    frmMant.SetInfo(Accion, row);
                    frmMant.MdiParent = this.MdiParent;
                    frmMant.event_delegate_frmCXC_XML_Mantenimiento_FormClosed += frmMant_event_delegate_frmCXC_XML_Mantenimiento_FormClosed;
                    frmMant.Show();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        void frmMant_event_delegate_frmCXC_XML_Mantenimiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            Buscar();
        }

        void frm_event_delegate_frmCxc_XML_Digitalizacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Buscar();
        }
        #endregion

        #region Eventos
        private void gvDetalle_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                cxc_XML_Documento_Info row = (cxc_XML_Documento_Info)gvDetalle.GetRow(e.FocusedRowHandle);
                if (row == null)
                    return;

                if (!row.Estado)
                {
                    gvDetalle.Appearance.FocusedRow.ForeColor = Color.Red;
                    gvDetalle.Appearance.FocusedCell.ForeColor = Color.Red;
                }
                else
                {
                    gvDetalle.Appearance.FocusedRow.ForeColor = Color.Black;
                    gvDetalle.Appearance.FocusedCell.ForeColor = Color.Black;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void gvDetalle_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                cxc_XML_Documento_Info row = (cxc_XML_Documento_Info)gvDetalle.GetRow(e.RowHandle);
                if (row == null)
                    return;

                if (!row.Estado)
                    e.Appearance.ForeColor = Color.Red;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private void ucGe_Menu_Mantenimiento_x_usuario1_event_btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LlamarFormulario(Cl_Enumeradores.eTipo_action.Anular);
        }
        
    }
}
