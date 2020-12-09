using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using Core.Erp.Info.General;
using Core.Erp.Business.General;
using DevExpress.XtraBars;
using Core.Erp.Info.Roles;
using Core.Erp.Business.Roles;
using Cus.Erp.Reports.FJ.Roles;

namespace Cus.Erp.Reports.FJ.Roles
{
    public partial class XROLES_Rpt022_frm : Form
    {
        ro_Nomina_Tipo_Bus oRo_Nomina_Tipo_Bus = new ro_Nomina_Tipo_Bus();
        ro_Cargo_Bus bus_cargo = new ro_Cargo_Bus();

        public XROLES_Rpt022_frm()
        {
            InitializeComponent();
            
        }
        int _idEmpresa;
        decimal _idEmpleado;
        int _idNominaTipo;
        int _idNominaTipoLiqui;
        int _idPeriodo;
        int _IdDepartamento = 0;
        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        List<ro_Empleado_Info> ListaE = new List<ro_Empleado_Info>();
        ro_Empleado_Bus BusE = new ro_Empleado_Bus();



   

        private void ucRo_Menu_Reportes_Load(object sender, EventArgs e)
        {

            
        }

        private void pu_GenerarReporte()
        {
            try
            {
                XROLES_Rpt022_Rpt Reporte = new XROLES_Rpt022_Rpt();

                Reporte.RequestParameters = false;
                ReportPrintTool pt = new ReportPrintTool(Reporte);
                pt.AutoShowParametersPanel = false;

                    ro_periodo_x_ro_Nomina_TipoLiqui_Info info_perio = new ro_periodo_x_ro_Nomina_TipoLiqui_Info();
                    Reporte.Parameters["p_IdEmpresa"].Value = param.IdEmpresa;
                    Reporte.Parameters["p_IdNomina"].Value = cmbnomina.EditValue == null ? 0 : Convert.ToInt32(cmbnomina.EditValue);
                    Reporte.Parameters["p_idDepartamento"].Value = cmb_cargo.EditValue == null ? 0 : Convert.ToInt32(cmb_cargo.EditValue); 

                
                Reporte.ShowPreview();



            }
            catch (Exception ex)
            {
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

        

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                pu_GenerarReporte();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void XROLES_Rpt022_frm_Load(object sender, EventArgs e)
        {
            try
            {
                var lst_nom = oRo_Nomina_Tipo_Bus.Get_List_Nomina_Tipo(param.IdEmpresa);
                var ls_cargo = bus_cargo.ObtenerLstCargo(param.IdEmpresa);

                cmb_cargo.Properties.DataSource = ls_cargo;
                cmbnomina.Properties.DataSource = lst_nom;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
