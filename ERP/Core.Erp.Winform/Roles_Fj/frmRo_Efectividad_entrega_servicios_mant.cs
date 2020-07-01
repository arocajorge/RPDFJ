using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Erp.Info.Roles_Fj;
using Core.Erp.Business.Roles_Fj;
using Core.Erp.Info.General;
using Core.Erp.Business.General;
using Core.Erp.Info.Roles;
using Core.Erp.Business.Roles;
using System.IO;
using System.Data.OleDb;
namespace Core.Erp.Winform.Roles_Fj
{
    public partial class frmRo_Efectividad_entrega_servicios_mant : Form
    { 
        #region variable

        DataTable dt;
        string fileName = "";
        string path = "";
        string tipofile = "";
        string ruta = "";


        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();
        public Cl_Enumeradores.eTipo_action Accion { get; set; }

        
        List<ro_ruta_Info> lista_ruta = new List<ro_ruta_Info>();
        ro_ruta_Bus bus_ruta = new ro_ruta_Bus();




        ro_Nomina_Tipoliqui_Bus Bus_TipoL = new ro_Nomina_Tipoliqui_Bus();
        List<ro_Nomina_Tipoliqui_Info> InfoTipoLiqui = new List<ro_Nomina_Tipoliqui_Info>();
        ro_Nomina_Tipo_Bus oRo_Nomina_Tipo_Bus = new ro_Nomina_Tipo_Bus();
        ro_Nomina_Tipoliqui_Bus nominatipo_Bus = new ro_Nomina_Tipoliqui_Bus();
        ro_periodo_x_ro_Nomina_TipoLiqui_Bus periodo_nomina_bus = new ro_periodo_x_ro_Nomina_TipoLiqui_Bus();

        List<ro_Nomina_Tipo_Info> listadoNomina = new System.Collections.Generic.List<ro_Nomina_Tipo_Info>();
        List<ro_Nomina_Tipoliqui_Info> ListadoTipoLiquidacion = new System.Collections.Generic.List<ro_Nomina_Tipoliqui_Info>();
        List<ro_periodo_x_ro_Nomina_TipoLiqui_Info> listadoPeriodo = new System.Collections.Generic.List<ro_periodo_x_ro_Nomina_TipoLiqui_Info>();
        ro_periodo_x_ro_Nomina_TipoLiqui_Info info_periodo = new ro_periodo_x_ro_Nomina_TipoLiqui_Info();



       ro_fectividad_Entrega_servicio_Info info_efectividad= new ro_fectividad_Entrega_servicio_Info();
       ro_fectividad_Entrega_servicio_Bus bus_efectividad = new ro_fectividad_Entrega_servicio_Bus();
       BindingList<ro_fectividad_Entrega_servicio_det_Info> lista_efectividad = new BindingList<ro_fectividad_Entrega_servicio_det_Info>();
       ro_fectividad_Entrega_servicio_det_Bus bus_efectividad_detalle = new ro_fectividad_Entrega_servicio_det_Bus();

        List<ro_Grupo_empleado_Info> lst_grupo = new List<ro_Grupo_empleado_Info>();
        ro_Grupo_empleado_Bus bus_grupo = new Business.Roles_Fj.ro_Grupo_empleado_Bus();
        ro_fectividad_Entrega_tipoServicio_Bus ro_fectividad_Entrega_tipoServicio_Bus = new ro_fectividad_Entrega_tipoServicio_Bus();
        ro_fectividad_Entrega_tipoServicio_Info ro_fectividad_Entrega_tipoServicio_Info_ = new ro_fectividad_Entrega_tipoServicio_Info();
        List<ro_Calculo_Pago_Variable_Porcentaje_Info> Lista_Calculo = new List<ro_Calculo_Pago_Variable_Porcentaje_Info>();

        ro_Calculo_Pago_Variable_Porcentaje_Bus Bus_Calculo = new ro_Calculo_Pago_Variable_Porcentaje_Bus();
        
        #endregion
        public frmRo_Efectividad_entrega_servicios_mant()
        {
            InitializeComponent();
        }

      
        public void cargar_dato()
        {
            try
            {

                cmb_ruta.ValueMember = "IdRuta";
                cmb_ruta.DisplayMember = "ru_descripcion";

                // lista de rutas 
                lista_ruta = bus_ruta.Get_List_Ruta(param.IdEmpresa);
                cmb_ruta.DataSource = lista_ruta;


                

                listadoNomina = oRo_Nomina_Tipo_Bus.Get_List_Nomina_Tipo(param.IdEmpresa);
                cmbnomina.Properties.DataSource = listadoNomina;



                ro_fectividad_Entrega_tipoServicio_Bus bus_servicio = new Business.Roles_Fj.ro_fectividad_Entrega_tipoServicio_Bus();
                List<ro_fectividad_Entrega_tipoServicio_Info> lst_servicio = new List<ro_fectividad_Entrega_tipoServicio_Info>();
                lst_servicio = bus_servicio.Get_List(Convert.ToInt32(param.IdEmpresa));

               
                cmb_servicios.Properties.DataSource = lst_servicio.Where(v => v.Estado == true).ToList();

                lst_grupo = bus_grupo.listado_Grupos(param.IdEmpresa);
                cmb_grupo.DataSource = lst_grupo;
            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmRo_Efectividad_entrega_servicios_mant_Load(object sender, EventArgs e)
        {
            try
            {
                cargar_dato();
            

            switch (Accion)
            {
                case Cl_Enumeradores.eTipo_action.grabar:
                    break;
                case Cl_Enumeradores.eTipo_action.actualizar:
                    cmbnomina.Enabled = false;
                    cmbnominaTipo.Enabled = false;
                    cmbPeriodos.Enabled = false;
                    break;
                case Cl_Enumeradores.eTipo_action.Anular:
                      

                    break;
                case Cl_Enumeradores.eTipo_action.consultar:
                  
                    break;
                case Cl_Enumeradores.eTipo_action.duplicar:
                    break;
                
                default:
                    break;
            }

            }
            catch (Exception ex)
            {
                
               Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbnomina_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ListadoTipoLiquidacion = nominatipo_Bus.Get_List_Nomina_Tipoliqui_x_Nomina_Tipo(param.IdEmpresa, Convert.ToInt32(cmbnomina.EditValue));
                cmbnominaTipo.Properties.DataSource = ListadoTipoLiquidacion;


            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbnominaTipo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                listadoPeriodo = periodo_nomina_bus.ConsultaPerNomTipLiq(param.IdEmpresa, Convert.ToInt32(cmbnomina.EditValue), Convert.ToInt32(cmbnominaTipo.EditValue));
                cmbPeriodos.Properties.DataSource = listadoPeriodo.Where(v => v.Cerrado == "N").ToList();


            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPeriodos_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int IdTipoServicio = cmb_servicios.EditValue == null ? 0 : Convert.ToInt32(cmb_servicios.EditValue);

                info_periodo = (ro_periodo_x_ro_Nomina_TipoLiqui_Info)cmbPeriodos.Properties.View.GetFocusedRow();
                if (info_periodo == null)
                    info_periodo = listadoPeriodo.Where(v => v.IdPeriodo == info_efectividad.IdPeriodo).FirstOrDefault();
                lista_efectividad = new BindingList<ro_fectividad_Entrega_servicio_det_Info>(bus_efectividad_detalle.get_list(param.IdEmpresa, info_efectividad.IdNivelServicio));
                gridControl_Efectividad.DataSource = lista_efectividad;



                Lista_Calculo = Bus_Calculo.Get_List_Calculo_Pago_Porcentaje(param.IdEmpresa, Convert.ToInt32(cmbnomina.EditValue) , IdTipoServicio);
                gc_ro_Calculo_Pago_Variable_Porcentaje.DataSource = Lista_Calculo;
         

            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Get()
        {
            try
            {
                info_efectividad =  new ro_fectividad_Entrega_servicio_Info();
                info_efectividad.lst = new List<ro_fectividad_Entrega_servicio_det_Info>();
                info_efectividad.IdEmpresa = param.IdEmpresa;
                info_efectividad.IdNomina_Tipo = Convert.ToInt32(cmbnomina.EditValue);
                info_efectividad.IdNomina_tipo_Liq = Convert.ToInt32(cmbnominaTipo.EditValue);
                info_efectividad.IdPeriodo = Convert.ToInt32(cmbPeriodos.EditValue);
                info_efectividad.IdServicioTipo = Convert.ToInt32(cmb_servicios.EditValue);
                //info_efectividad.Observacion = txtobservacion.Text;
                info_efectividad.IdUsuario = param.IdUsuario;
                info_efectividad.FechaTransac = DateTime.Now;
                info_efectividad.IdUsuarioUltModi = param.IdUsuario;
                info_efectividad.FechaUltModi = DateTime.Now;

                

                info_efectividad.lst = lista_efectividad.ToList();
            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void set(ro_fectividad_Entrega_servicio_Info info)
        {
            try
            {
                info_efectividad = info;
                cmbnomina.EditValue = info.IdNomina_Tipo;
                cmbnominaTipo.EditValue = info.IdNomina_tipo_Liq;
                cmbPeriodos.EditValue = info.IdPeriodo;
               // txtobservacion.Text = info.Observacion;
                lista_efectividad = new BindingList<ro_fectividad_Entrega_servicio_det_Info>(bus_efectividad_detalle.get_list(info.IdEmpresa,info.IdNivelServicio));
                gridControl_Efectividad.DataSource = lista_efectividad;
            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool Validar()
        {
            try
            {
                if (cmbnomina.EditValue == null || cmbnomina.EditValue == "")
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_la) + " nomina", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cmbnominaTipo.EditValue == null || cmbnominaTipo.EditValue == "")
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_el) + " Proceso", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cmbPeriodos.EditValue == null || cmbPeriodos.EditValue == "")
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_la) + " Seleccione el periodo para la planificación", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cmb_servicios.EditValue == null || cmb_servicios.EditValue == "")
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_el) + " Seleccione el tipo de servicio", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                

                return true;
            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        bool Grabar()
        {
            try
            {
                Get();
                return bus_efectividad.Modificar_DB(info_efectividad);
            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        bool Modificar()
        {
            try
            {
                Get();
                return bus_efectividad.Modificar_DB(info_efectividad);
            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        bool Anular()
        {
            try
            {
                bool ba_asi_anulo = false;
                DialogResult dialogResult = MessageBox.Show("¿Esta seguro de querer anular el registro?", param.Nombre_sistema, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Get();
                    ba_asi_anulo= bus_efectividad.Anular_DB(info_efectividad);
                }
                return ba_asi_anulo;
            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        bool Guardar_Datos()
        {
            try
            {
                bool bandera_si_grabo = false;

                switch (Accion)
                {
                    case Cl_Enumeradores.eTipo_action.grabar:
                     bandera_si_grabo  = Modificar();
                        break;
                    case Cl_Enumeradores.eTipo_action.actualizar:
                     bandera_si_grabo  = Modificar();
                     break;
                    case Cl_Enumeradores.eTipo_action.Anular:
                     bandera_si_grabo = Anular();
                     break;                  
                    default:
                     bandera_si_grabo= false;
                     break;
                }

                if (bandera_si_grabo)
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Se_guardaron_los_datos_correctamente), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.No_se_guardaron_los_datos), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);


                return bandera_si_grabo;


            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void gridView_planificacion_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
           if (e.Column.Name == "Col_imagen")
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("¿Esta seguro de querer eliminar el registro?", param.Nombre_sistema, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        gridView_Efectividad.DeleteSelectedRows();
                    }

                }
                catch (Exception ex)
                {

                    Log_Error_bus.Log_Error(ex.ToString());
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
         bool Validar_Carga_Archivo()
        {
            try
            {
                return Validar_datos_periodo();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
                return false;
            }
        }
        bool Validar_datos_periodo()
        {
            try
            {
                if (cmbnomina.EditValue == null || cmbnomina.EditValue == "")
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_la) + " nomina", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cmbnominaTipo.EditValue == null || cmbnominaTipo.EditValue == "")
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_la) + " Proceso", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cmbPeriodos.EditValue == null || cmbPeriodos.EditValue == "")
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_la) + " Seleccione el periodo para la planificación", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

               

                if (lista_efectividad.Count() == 0)
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_la) + " No existe datos de planificación para la nomina y periodo seleccionado", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                
                 MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
                return false;
            }
        }     
        private void gvw_ro_Calculo_Pago_Variable_Porcentaje_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
           
        }
        private void gridView_Efectividad_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                var data = gridView_Efectividad.GetRow(e.RowHandle) as ro_fectividad_Entrega_servicio_det_Info;
                if (data == null)
                    return;
                if (data.IdRuta ==0)
                    e.Appearance.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }
       
      
      
        private void cmb_servicios_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int IdTipoServicio = cmb_servicios.EditValue == null ? 0 : Convert.ToInt32(cmb_servicios.EditValue);
                Lista_Calculo = Bus_Calculo.Get_List_Calculo_Pago_Porcentaje(param.IdEmpresa, Convert.ToInt32(cmbnomina.EditValue) , IdTipoServicio);
                gc_ro_Calculo_Pago_Variable_Porcentaje.DataSource = Lista_Calculo;
            }
            catch (Exception)
            {
                
            }
        }

        private void cmb_grabar_Click(object sender, EventArgs e)
        {
            try
            {
                Guardar_Datos();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void cmdProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                Get();
                bus_efectividad.procesar(info_efectividad);
                lista_efectividad =new BindingList<ro_fectividad_Entrega_servicio_det_Info>( bus_efectividad_detalle.get_list(param.IdEmpresa, info_efectividad.IdNivelServicio));
                gridControl_Efectividad.DataSource = lista_efectividad;
                gridControl_Efectividad.RefreshDataSource();
            }
            catch (Exception)
            {
               
            }
        }

        private void cmdDetener_Click(object sender, EventArgs e)
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
