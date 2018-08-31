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
using System.IO;
using System.Diagnostics;
using Core.Erp.Info.Roles_Fj;
using Core.Erp.Business.Roles_Fj;
using Core.Erp.Business.Roles;
namespace Cus.Erp.Reports.FJ.Roles
{
    public partial class XROLES_Rpt007_frm : Form
    {
        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        List<XROLES_Rpt007_Info> lista = new List<XROLES_Rpt007_Info>();
        XROLES_Rpt007_Bus bus = new XROLES_Rpt007_Bus();
        ro_periodo_x_ro_Nomina_TipoLiqui_Info info_perio = new Core.Erp.Info.Roles.ro_periodo_x_ro_Nomina_TipoLiqui_Info();





        #region varibales
        Cl_Enumeradores.eTipo_action _Accion;

        BindingList<ro_presupuesto_x_fuerza_x_cargo_Info> listPresupuesto = new BindingList<ro_presupuesto_x_fuerza_x_cargo_Info>();
        List<ro_presupuesto_x_fuerza_x_cargo_Info> listatmp = new List<ro_presupuesto_x_fuerza_x_cargo_Info>();

        ro_presupuesto_x_fuerza_x_cargo_Bus bus_presupuesto = new ro_presupuesto_x_fuerza_x_cargo_Bus();



        List<ro_Cargo_Info> listaCargo = new List<ro_Cargo_Info>();
        ro_Cargo_Bus bus_cargo = new ro_Cargo_Bus();



        List<ro_fuerza_Info> listaFuerza = new List<ro_fuerza_Info>();
        ro_fuerza_Bus bus_fuerza = new ro_fuerza_Bus();



        ro_disco_Bus bus_Disco = new ro_disco_Bus();



        #endregion




        public XROLES_Rpt007_frm()
        {
            InitializeComponent();
            ucRo_Menu.event_cmdImprimir_ItemClick += ucRo_Menu_event_cmdImprimir_ItemClick;
        }

        void ucRo_Menu_event_cmdImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
        
        private void XROLES_Rpt007_frm_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show(ex.ToString());
            }
               
           
            
        }

       

        private void ucRo_Menu_event_cmdCargar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Generar_Excell();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ucRo_Menu_event_btnsalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }






        private void Generar_Excell()
        {
            try
            {

                ro_periodo_x_ro_Nomina_TipoLiqui_Info info = new ro_periodo_x_ro_Nomina_TipoLiqui_Info();


                info = ucRo_Menu.Get_Info_Periodo();
                listPresupuesto = new BindingList<ro_presupuesto_x_fuerza_x_cargo_Info>(bus_presupuesto.GetPresupuesto(param.IdEmpresa, Convert.ToInt32(info.pe_FechaIni.Year), Convert.ToInt32(info.pe_FechaIni.Month)));
                gridControlPresupuesto.DataSource = listPresupuesto;
     

               
                int IdNomina = Convert.ToInt32(ucRo_Menu.getIdNominaTipo());
                info_perio = ucRo_Menu.Get_Info_Periodo();
                lista = bus.Get_Mano_Obra(info);
                grid_control.DataSource = lista;


                // actualizando prsupuesto
                foreach (var item in listPresupuesto)
                {
                    item.costoRealMO = lista.Where(v => v.IdFuerza == item.IdFuerza && v.IdCargo == item.IdCargo).Sum(v => v.TOTAL_MO);
                    item.diferencia = Convert.ToDouble( item.costoRealMO)-item.Presupuesto;

                }

                gridViewPresupuesto.RefreshData();
                OpenFileDialog ofdDoc;//txt
                SaveFileDialog sfdDoc;//txt
                ofdDoc = new OpenFileDialog();
                sfdDoc = new SaveFileDialog();
                string Nombrefile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (sfdDoc.ShowDialog() == DialogResult.OK)
                {

                    if (File.Exists(sfdDoc.FileName))
                    {
                        File.Delete(sfdDoc.FileName);
                    }
                    sfdDoc.FileName = sfdDoc.FileName + ".csv";
                    grid_view.ExportToCsv(sfdDoc.FileName);
                    


                    if (MessageBox.Show("Desea ver el Archivo...?", "INFORMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Process.Start(sfdDoc.FileName);
                }






            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void grid_control_Click(object sender, EventArgs e)
        {

        }


        private void CargarDatos()
        {
            try
            {


                listaCargo = bus_cargo.ObtenerLstCargo(param.IdEmpresa);
                cmbCargo.DataSource = listaCargo;
                cmbCargo.ValueMember = "IdCargo";
                cmbCargo.DisplayMember = "ca_descripcion";


                listaFuerza = bus_fuerza.Get_List_Fuerza(param.IdEmpresa);

                cmbFuerza.DataSource = listaFuerza;
                cmbFuerza.ValueMember = "IdFuerza";
                cmbFuerza.DisplayMember = "fu_descripcion";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ucRo_Menu_event_cmbPeriodo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {      
            }
            catch (Exception ex)
            {
                
                  MessageBox.Show(ex.ToString());
            }
        }

        private void grid_view_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                var data = grid_view.GetRow(e.RowHandle) as XROLES_Rpt007_Info;
                if (data == null)
                    return;

                if (data.fu_descripcion == "AMARILLA")
                    e.Appearance.ForeColor = Color.Orange;

                if (data.fu_descripcion == "AZUL")
                    e.Appearance.ForeColor = Color.Blue;

            }
            catch (Exception ex)
            {

               
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
              

            }
            catch (Exception ex)
            {


            }
        }
       
    }
}
