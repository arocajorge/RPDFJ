using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Erp.Business.Roles;
using Core.Erp.Info.Roles;
using Core.Erp.Business.General;
using Core.Erp.Info.General;
using Core.Erp.Business.Roles_Fj;
using Core.Erp.Info.Roles_Fj;
namespace Core.Erp.Winform.Roles_Fj
{
    public partial class frm_Ro_empleados_x_extension_salud : Form
    {
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();
        BindingList<ro_empleado_extension_salud_Info> lista = new BindingList<ro_empleado_extension_salud_Info>();
        ro_empleado_extension_salud_Bus bus_parametro = new ro_empleado_extension_salud_Bus();
        ro_Empleado_Bus bus_empleado = new ro_Empleado_Bus();

        int IdNomina_tipo = 0;
        public frm_Ro_empleados_x_extension_salud()
        {
            InitializeComponent();
        }

        private void frm_Ro_empleados_x_extension_salud_Load(object sender, EventArgs e)
        {
            try
            {

                var lst_empleado = bus_empleado.get_list_empleado_cargar_combo(param.IdEmpresa);

                gridControl_parametros.DataSource = lista;

                //NomCompleto

                cmb_nomina_tipo.DisplayMember = "NomCompleto";
                cmb_nomina_tipo.ValueMember = "IdEmpleado";

                cmb_empleado.DataSource = lst_empleado;


                lista = new BindingList<ro_empleado_extension_salud_Info>(bus_parametro.Get_List_Fuerza(param.IdEmpresa));
                gridControl_parametros.DataSource = lista;
            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmb_nomina_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmb_nomina_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {

                IdNomina_tipo = Convert.ToInt32(e.NewValue);
                Get_nomina_tipo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }

        }


        public void Get_nomina_tipo()
        {
            try
            {
                // cmb_nomina_tipo.DataSource = lista_nomina_tipo_liq.Where(v=>v.IdNomina_Tipo==IdNomina_tipo).ToList();



            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void ucGe_Menu_event_btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucGe_Menu_event_btnGuardar_Click(object sender, EventArgs e)
        {

            ucGe_Menu.Focus();
            Grabar();
        }

        private void ucGe_Menu_event_btnGuardar_y_Salir_Click(object sender, EventArgs e)
        {
            if (Grabar())
                this.Close();
        }


        public bool Grabar()
        {
            try
            {

                string mensaje="";
                foreach (var item in lista)
                {
                    item.IdEmpresa = param.IdEmpresa;
                  //  item.Id_catalogo_repor = cmb_reporte.EditValue.ToString();
                }


                if (bus_parametro.GuardarDB( lista.ToList(),  mensaje))
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Se_guardo_correctamente), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {

                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.No_se_guardaron_los_datos), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            catch (Exception ex)
            {


                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void gridView_parametros_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {


                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void gridView_parametros_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
           
        }

        private void cmb_reporte_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
               // lista =new BindingList<ro_parametros_reporte_Info>( bus_parametro.Get_list_parametro(param.IdEmpresa, cmb_reporte.EditValue.ToString()));
                gridControl_parametros.DataSource = lista;

            }
            catch (Exception ex)
            {
                
                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gridView_parametros_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                
                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gridControl_parametros_Click(object sender, EventArgs e)
        {

        }

        private void gridView_parametros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Delete")
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("¿Esta seguro de querer eliminar el registro?", param.Nombre_sistema, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        gridView_parametros.DeleteSelectedRows();
                    }

                }
                catch (Exception ex)
                {

                    Log_Error_bus.Log_Error(ex.ToString());
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void ucGe_Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
