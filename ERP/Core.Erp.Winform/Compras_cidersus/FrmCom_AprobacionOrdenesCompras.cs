using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Erp.Business.Produc_Cirdesus;
using Core.Erp.Info.Produc_Cirdesus;
using Core.Erp.Business.General;
using Core.Erp.Business.Compras;
using Core.Erp.Info.Compras;
namespace Core.Erp.Winform.Compras_cidersus
{
    public partial class FrmCom_AprobacionOrdenesCompras : Form
    {
        #region variables
        prd_OrdenesComprasPendientes_Bus BusOrdenesCompra = new prd_OrdenesComprasPendientes_Bus();
        prd_OrdenesComprasPendientes_Info InfoOC = new prd_OrdenesComprasPendientes_Info();
        BindingList<prd_OrdenesComprasPendientes_Info> ListadoOC = new BindingList<prd_OrdenesComprasPendientes_Info>();
        List<prd_OrdenesComprasPendientes_Info> ListadoItemSeleccionado = new List<prd_OrdenesComprasPendientes_Info>();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        List<com_Catalogo_Info> ListaCatalogoOC = new List<com_Catalogo_Info>();
        com_Catalogo_Bus BusCatalogoOC = new com_Catalogo_Bus();
        
        #endregion
        
        public FrmCom_AprobacionOrdenesCompras()
        {
            InitializeComponent();
        }


        public void CargarDatosCombo()
        {
            try
            {
                ListaCatalogoOC = BusCatalogoOC.Get_ListEstadoAprobacion();
                cmbEstAproSC.Properties.DataSource = ListaCatalogoOC;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show(ex.Message);
            }
        }

        private void FrmCom_AprobacionOrdenesCompras_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosCombo();
                
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message);
            }
        }

        private bool Validar()
        {
            try
            {
                dtpFechaIni.Focus();

                if (ListadoOC.Where(q => q.check == true).Count() == 0)
                {
                    MessageBox.Show("Seleccione al menos una OC para aprobar", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void ucGe_Menu_event_btnAprobarGuardarSalir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar()) return;
                            

                ListadoItemSeleccionado = new List<prd_OrdenesComprasPendientes_Info>();
                SeleccionarIten_Ordenes();
                BusOrdenesCompra.AprobarOrdenesCompras(ListadoItemSeleccionado);
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        public void SeleccionarIten_Ordenes()
        {
            try
            {
               // gridControlConsulta.DataSource = ListadoOC;
                foreach (var item in ListadoOC)
                {
                    if (item.check == true)
                    {
                        item.IdEstadoAprobacion = "APRO";
                        ListadoItemSeleccionado.Add(item);
                    }
                }

                BusOrdenesCompra.AprobarOrdenesCompras(ListadoItemSeleccionado);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void cmbEstadoApro_EditValueChanged(object sender, EventArgs e)
        {

        }

        public void AprobarOrdenesCompras()
        {
            try
            {

            }
            catch (Exception ex)
            {
                
                 MessageBox.Show(ex.Message);
            }
        }

        private void cmbEstAproSC_EditValueChanged(object sender, EventArgs e)
        {

        }

        public void BuscarDatra()
        {
            try
            {
                DateTime Fecha_ini = dtpFechaIni.Value.Date;
                DateTime Fecha_fin = dtpFechaFin.Value.Date;
                string Estado_apro = cmbEstAproSC.EditValue == null ? "xAPRO" : Convert.ToString(cmbEstAproSC.EditValue);

                ListadoOC=new BindingList<prd_OrdenesComprasPendientes_Info>( BusOrdenesCompra.Get_lisOrdenesPendientesAprobar(param.IdEmpresa, Estado_apro, Fecha_ini, Fecha_fin));
                gridControlConsulta.DataSource = ListadoOC;
           
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                BuscarDatra();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ucGe_Menu_event_btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
