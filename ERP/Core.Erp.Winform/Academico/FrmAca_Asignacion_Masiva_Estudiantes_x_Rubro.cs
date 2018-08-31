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

using Core.Erp.Info.Academico;
using Core.Erp.Business.Academico;
using Core.Erp.Business.General;
using Core.Erp.Winform.General;

namespace Core.Erp.Winform.Academico
{
    public partial class FrmAca_Asignacion_Masiva_Estudiantes_x_Rubro : Form
    {
        #region "Variables"
        private Cl_Enumeradores.eTipo_action Accion;
        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        Aca_Rubro_Info rubroInfo = new Aca_Rubro_Info();

        List<Aca_Rubro_x_Aca_Periodo_Lectivo_Info> Lista_Periodo_x_Rubro = new List<Aca_Rubro_x_Aca_Periodo_Lectivo_Info>();
        Aca_Rubro_x_Aca_Periodo_Lectivo_Bus Periodo_x_Rubro_Bus = new Aca_Rubro_x_Aca_Periodo_Lectivo_Bus();
        BindingList<Aca_Rubro_x_Aca_Periodo_Lectivo_Info> BLista_Periodo_x_rubro = new BindingList<Aca_Rubro_x_Aca_Periodo_Lectivo_Info>();
        Aca_Rubro_x_Aca_Periodo_Lectivo_Info InfoRubroPeriodo = new Aca_Rubro_x_Aca_Periodo_Lectivo_Info();

        Aca_Contrato_x_Estudiante_Bus BusContratoEstudiante = new Aca_Contrato_x_Estudiante_Bus();
        Aca_Contrato_x_Estudiante_Info InfoContratoEstudiante = new Aca_Contrato_x_Estudiante_Info();
        List<Aca_Contrato_x_Estudiante_Info> ListaContratoEstudiante;
        BindingList<Aca_Contrato_x_Estudiante_Info> bndList_contr_Estudiante;
        List<Aca_Contrato_x_Estudiante_det_Info> List_Contrato_Estudiante_det;
        Aca_Contrato_x_Estudiante_det_Bus BusContratoEstudianteDet = new Aca_Contrato_x_Estudiante_det_Bus();
        Aca_Contrato_x_Estudiante_det_Info InfoContratoEstudianteDet = new Aca_Contrato_x_Estudiante_det_Info();       
        #endregion

        public FrmAca_Asignacion_Masiva_Estudiantes_x_Rubro()
        {
            InitializeComponent();
            ucAca_SedeJornadaSeccionCurso1.event_cmbSeccion_EditValueChanged += ucAca_SedeJornadaSeccionCurso1_event_cmbSeccion_EditValueChanged;

        }

        void ucAca_SedeJornadaSeccionCurso1_event_cmbSeccion_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ucAca_Rubro1.Inicializar_Combo();
                gridCtrlEstudiantesContrato.DataSource = null;
                CargarDatos();
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NameMetodo = NameMetodo + " - " + ex.ToString();
                MessageBox.Show(NameMetodo + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas)
                    , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
            }
        }



        #region "Eventos"
        private void FrmAca_Asignacion_Masiva_Estudiantes_x_Rubro_Load(object sender, EventArgs e)
        {
            try
            {

                ucAca_SedeJornadaSeccionCurso1.cmbCurso.Visible = false;
                ucAca_SedeJornadaSeccionCurso1.cmbJornada.Visible = false;
                ucAca_SedeJornadaSeccionCurso1.cmbParalelo.Visible = false;
                ucAca_SedeJornadaSeccionCurso1.cmbSeccion.Visible = false;

                CargarCombos();

                switch (Accion)
                {
                    case Cl_Enumeradores.eTipo_action.grabar:
                        ucGe_Menu.Enabled_bntAnular = false;
                        ucGe_Menu.Enabled_bntImprimir = false;
                        break;

                    case Cl_Enumeradores.eTipo_action.actualizar:
                        ucGe_Menu.Enabled_bntAnular = false;
                        ucAca_Rubro1.Enabled(false);
                        break;

                    case Cl_Enumeradores.eTipo_action.Anular:
                        ucGe_Menu.Enabled_bntGuardar_y_Salir = false;
                        ucGe_Menu.Enabled_btnGuardar = false;
                        CargarDatos();
                        break;

                    case Cl_Enumeradores.eTipo_action.consultar:
                        ucGe_Menu.Enabled_bntGuardar_y_Salir = false;
                        ucGe_Menu.Enabled_btnGuardar = false;
                        ucGe_Menu.Enabled_bntAnular = false;
                        CargarDatos();
                        break;
                }

            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NameMetodo = NameMetodo + " - " + ex.ToString();
                MessageBox.Show(NameMetodo + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas)
                    , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());

            }
        }

        private void ucGe_Menu_event_btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarDatos();
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NameMetodo = NameMetodo + " - " + ex.ToString();
                MessageBox.Show(NameMetodo + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas)
                    , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());

            }
        }

        private void ucAca_Rubro1_Event_UCRubro_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ucAca_Rubro1.get_item().Trim() != "0" )
                {
                    BLista_Periodo_x_rubro = Periodo_x_Rubro_Bus.Get_List_rubro_x_periodo(param.IdInstitucion, Convert.ToInt16(ucAca_Rubro1.get_item()));
                    if (BLista_Periodo_x_rubro == null || BLista_Periodo_x_rubro.Count == 0)
                    {
                        MessageBox.Show("El rubro no tiene periodos asignados, Por favor asignar periodos al rubro elegido", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Aca_Contrato_x_Estudiante_det_Bus Bus = new Aca_Contrato_x_Estudiante_det_Bus();
                    List_Contrato_Estudiante_det = new List<Aca_Contrato_x_Estudiante_det_Info>();
                    List_Contrato_Estudiante_det = Bus.Get_Lista_Contrato_x_Estudiante_det_xRubro(param.IdInstitucion, Convert.ToDecimal(ucAca_Rubro1.get_item()), Convert.ToInt16(ucAca_SedeJornadaSeccionCurso1.cmbSede.EditValue));

                    for (int i = 0; i < gridvwEstudiantesContrato.RowCount; i++)
                    {
                        gridvwEstudiantesContrato.SetRowCellValue(i, ColChequear, false);
                        var data = gridvwEstudiantesContrato.GetRow(i) as Aca_Contrato_x_Estudiante_Info;
                        if (data == null)
                            return;
                        foreach (var item in List_Contrato_Estudiante_det)
                        {

                            if (data.IdContrato == item.IdContrato)
                            {
                                data.chequear = true;

                            }

                        }
                    }
                    gridvwEstudiantesContrato.Focus();
                }
                
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NameMetodo = NameMetodo + " - " + ex.ToString();
                MessageBox.Show(NameMetodo + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas)
                    , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
            }
        }
        #endregion

        #region "CargarDatos"
        public void CargarCombos()
        {
            try
            {
                ucAca_Anio_Lectivo1.cargaCmb_Anio_Lectivo_Activo();
                //ucAca_Rubro1.cargaCmb_Rubro();
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NameMetodo = NameMetodo + " - " + ex.ToString();
                MessageBox.Show(NameMetodo + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas)
                    , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
            }

        }

        public void CargarDatos()
        {
            try
            {
                if (ucAca_SedeJornadaSeccionCurso1.cmbSede.EditValue != null)
                {
                    ucAca_Rubro1.cargaCmb_Rubro_x_Sede(param.IdInstitucion, Convert.ToInt16(ucAca_SedeJornadaSeccionCurso1.cmbSede.EditValue));
                    ListaContratoEstudiante = new List<Aca_Contrato_x_Estudiante_Info>();
                    ListaContratoEstudiante = BusContratoEstudiante.Get_List_Estudiante_con_Contrato(param.IdInstitucion, Convert.ToInt16(ucAca_SedeJornadaSeccionCurso1.cmbSede.EditValue));
                    bndList_contr_Estudiante = new BindingList<Aca_Contrato_x_Estudiante_Info>(ListaContratoEstudiante);
                    gridCtrlEstudiantesContrato.DataSource = bndList_contr_Estudiante;
                    
                }
                else
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Por_Favor_) + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_la) + " sede", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ucAca_SedeJornadaSeccionCurso1.Focus();
                }
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NameMetodo = NameMetodo + " - " + ex.ToString();
                MessageBox.Show(NameMetodo + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas)
                    , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());

            }
        }
        #endregion

        #region "Proceso"

        public bool Grabar()
        {
            bool resultado = false;
            try
            {
                string mensaje = string.Empty;
                int id = 0;

                resultado = BusContratoEstudianteDet.GuardarDB(GetContratoEstudianteDet());            

                if (resultado)
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Se_guardaron_los_datos_correctamente), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {                  
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NameMetodo = NameMetodo + " - " + ex.ToString();
                MessageBox.Show(NameMetodo + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas)
                    , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());

            }
            return resultado;
        }

        public bool Actualizar()
        {
            bool resultado = false;
            try
            {

            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.Message);
            }
            return resultado;
        }

        private void Anular()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show("Error " + ex.Message.ToString(), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool GuardarDatos()
        {
            bool resultado = false;
            try
            {
                if (validaciones())
                {
                    resultado = Grabar();
                }
            }

            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NameMetodo = NameMetodo + " - " + ex.ToString();
                MessageBox.Show(NameMetodo + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas)
                    , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
                return false;
            }
            return resultado;
        }

        public bool validaciones()
        {
            try
            {
                ucAca_Rubro1.Focus();
                if (ucAca_Rubro1.get_item_info().IdRubro == 0 || ucAca_Rubro1.get_item_info() == null)
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_el) + " Rubro", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ucAca_Rubro1.UC_Rubro.Focus();
                    return false;
                }


                if (bndList_contr_Estudiante.Where(a => a.chequear == true).Count() == 0)
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_el) + " estudiante para la asignación de rubro", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (BLista_Periodo_x_rubro == null || BLista_Periodo_x_rubro.Count == 0)
                {
                    MessageBox.Show("El rubro no tiene periodos asignados, Por favor asignar periodos al rubro elegido", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NameMetodo = NameMetodo + " - " + ex.ToString();
                MessageBox.Show(NameMetodo + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas)
                    , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
                return false;
            }
        }
        #endregion

        #region "GET"
        public List<Aca_Contrato_x_Estudiante_det_Info> GetContratoEstudianteDet()
        {
            try
            {
                            
                List_Contrato_Estudiante_det = new List<Aca_Contrato_x_Estudiante_det_Info>();
                ListaContratoEstudiante = new List<Aca_Contrato_x_Estudiante_Info>(bndList_contr_Estudiante.Where(a=> a.chequear == true));
                
                    foreach (var item in BLista_Periodo_x_rubro)
                    {
                        foreach (var item1 in ListaContratoEstudiante)
                        {
                                InfoContratoEstudianteDet = new Aca_Contrato_x_Estudiante_det_Info();  
                                InfoContratoEstudianteDet.IdInstitucion = item1.IdInstitucion;
                                InfoContratoEstudianteDet.IdContrato = item1.IdContrato;
                                InfoContratoEstudianteDet.IdRubro = item.IdRubro;
                                InfoContratoEstudianteDet.IdInstitucion_Per = item.IdInstitucion_per;
                                InfoContratoEstudianteDet.IdAnioLectivo_Per = item.IdAnioLectivo;
                                InfoContratoEstudianteDet.IdPeriodo_Per = item.IdPeriodo;
                                InfoContratoEstudianteDet.FechaCreacion = DateTime.Now;
                                InfoContratoEstudianteDet.UsuarioCreacion = param.IdUsuario;
                                InfoContratoEstudianteDet.Observacion = "Asignaicon masiva de Estudiante x Rubro";
                                List_Contrato_Estudiante_det.Add(InfoContratoEstudianteDet);
                            
                        }
                     
                }
                  
                return List_Contrato_Estudiante_det;

            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NameMetodo = NameMetodo + " - " + ex.ToString();
                MessageBox.Show(NameMetodo + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas)
                    , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
                return new List<Aca_Contrato_x_Estudiante_det_Info>();
            }

        }
        #endregion

        private void ucGe_Menu_event_btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAplicarRubros_CheckedChanged(object sender, EventArgs e)
        {
            //foreach (var item in bndList_contr_Estudiante)
            //{
            //    item.chequear = true;
            //}

            for (int i = 0; i < gridvwEstudiantesContrato.RowCount; i++)
            {
                gridvwEstudiantesContrato.SetRowCellValue(i, ColChequear, chkAplicarRubros.Checked);
                //gridViewCons.SetRowCellValue(i, colIdEstadoAproba, chk_Seleccionar_visibles.Checked == true ? "APRO" : "PEND");
            }

        }

    }
}
