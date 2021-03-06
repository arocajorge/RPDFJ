﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Erp.Info.Roles;
using Core.Erp.Business.Roles;
using Core.Erp.Info.General;
using Core.Erp.Business.General;
using Core.Erp.Winform.Roles;
using Core.Erp.Winform.General;

namespace Core.Erp.Winform.Roles
{
    public partial class frmRo_Liquidacion_Vacaciones_Consul : Form
    {
        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        ro_SolicitudVacaciones_Info info = new ro_SolicitudVacaciones_Info();
        List<ro_SolicitudVacaciones_Info> Lista_solicitud_Vavaciones = new List<ro_SolicitudVacaciones_Info>();
        ro_historico_liquidacion_vacaciones_Bus Bus_liquidacion_vacaciones = new ro_historico_liquidacion_vacaciones_Bus();

        frmRo_Solicitud_Vacaciones_Mant vacacionesMant = new frmRo_Solicitud_Vacaciones_Mant();

        ro_SolicitudVacaciones_Bus solicitudBus = new ro_SolicitudVacaciones_Bus();

        ro_historico_vacaciones_x_empleado_Bus oRo_historico_vacaciones_x_empleado_Bus = new ro_historico_vacaciones_x_empleado_Bus();
        BindingList<ro_historico_vacaciones_x_empleado_Info> RoHistoricoVacaInfoLst = new BindingList<ro_historico_vacaciones_x_empleado_Info>();


        string mensaje = "";

        public frmRo_Liquidacion_Vacaciones_Consul()
        {
            InitializeComponent();
            ucGe_Menu.btnCancelarCuotas.Caption = "Liq. Vacaciones";
        }

        private void ucGe_Menu_event_btnCancelarCuotas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (info.IdOrdenPago != null)
                {
                    MessageBox.Show(" La solicitud de vacaciones ya fue liquidada; ¡revise las ordenes de pagos! ", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmRo_Liquidacion_Vacaciones_Mant frm = new frmRo_Liquidacion_Vacaciones_Mant();
                frm.Set(info);
                frm.Accion = Cl_Enumeradores.eTipo_action.grabar;
                frm.ShowDialog();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }



        void pu_Cargar()
        {
            try
            {
                Lista_solicitud_Vavaciones = solicitudBus.ConsultaPermisosVacaciones(param.IdEmpresa, ucGe_Menu.fecha_desde, ucGe_Menu.fecha_hasta);
                gridControlVacaciones.DataSource = Lista_solicitud_Vavaciones;
            }
            catch (Exception ex)
            {
                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString());
            }

        }

        private void gridViewVacaciones_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                info = new ro_SolicitudVacaciones_Info();
                info = (ro_SolicitudVacaciones_Info)gridViewVacaciones.GetFocusedRow();
            }
            catch (Exception ex)
            {
                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmRo_Liquidacion_Vacaciones_Consul_Load(object sender, EventArgs e)
        {
            pu_Cargar();
        }

        private void ucGe_Menu_event_btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                pu_Cargar(); 
            }
            catch (Exception ex)
            {
                
                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void ucGe_Menu_event_btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void ucGe_Menu_event_btnconsultar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmRo_Liquidacion_Vacaciones_Mant frm = new frmRo_Liquidacion_Vacaciones_Mant();
                frm.Set(info);
                frm.Accion = Cl_Enumeradores.eTipo_action.consultar;
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

        private void gridViewVacaciones_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                 var data = gridViewVacaciones.GetRow(e.RowHandle) as ro_SolicitudVacaciones_Info;
                if (data == null)
                    return;
                if (data.IdOrdenPago !=null)
                e.Appearance.ForeColor = Color.Blue;

                if (data == null)
                    return;
                if (data.Estado == "I")
                    e.Appearance.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                
              
            }
        }

        private void ucGe_Menu_event_btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea anular la Solicitud No. " + info.IdSolicitudVaca + " ? ", "Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    info = new ro_SolicitudVacaciones_Info();
                    info = (ro_SolicitudVacaciones_Info)gridViewVacaciones.GetFocusedRow();
                    ro_historico_liquidacion_vacaciones_Info info_liquidacion = new ro_historico_liquidacion_vacaciones_Info();
                    info_liquidacion.IdEmpresa = param.IdEmpresa;
                    info_liquidacion.IdEmpleado = info.IdEmpleado;
                    info_liquidacion.IdLiquidacion = info.IdSolicitudVaca;
                    info_liquidacion.IdSolicitud_Vacaciones = info.IdSolicitudVaca;
                    if (Bus_liquidacion_vacaciones.EliminarDB(info_liquidacion))
                        MessageBox.Show("El registro fue anulado, revise por favor", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("El registro no ha sido anulado, revise por favor", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
               

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
