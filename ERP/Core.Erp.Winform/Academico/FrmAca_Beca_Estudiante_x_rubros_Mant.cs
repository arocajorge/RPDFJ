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
using Core.Erp.Info.General;
using Core.Erp.Business.General;
using Core.Erp.Business.Facturacion;
using Core.Erp.Info.Facturacion;
namespace Core.Erp.Winform.Academico
{
    public partial class FrmAca_Beca_Estudiante_x_rubros_Mant : Form
    {

        #region variables

        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        private Cl_Enumeradores.eTipo_action Accion;
        Aca_contrato_x_estudiante_det_beca_Bus bus_beca_estudiante = new Aca_contrato_x_estudiante_det_beca_Bus();

        List<Aca_Beca_Info> lista_beca = new List<Aca_Beca_Info>();
        Aca_Beca_Info Info_beca;
        Aca_Beca_Bus bus_beca = new Aca_Beca_Bus();
        public Aca_Contrato_x_Estudiante_Info InfoContrato { get; set; }
        BindingList<Aca_contrato_x_estudiante_det_beca_Info> lista_detalle_beca = new BindingList<Aca_contrato_x_estudiante_det_beca_Info>();
       

        List<Aca_Rubro_Info> Lista_rubros = new List<Aca_Rubro_Info>();
        Aca_Rubro_Bus Rubros_bus = new Aca_Rubro_Bus();

        List<Aca_Contrato_x_Estudiante_det_Info> Lista_rubros_x_Estudiante = new List<Aca_Contrato_x_Estudiante_det_Info>();
        Aca_Contrato_x_Estudiante_det_Bus Rubros_x_Estudiante_bus = new Aca_Contrato_x_Estudiante_det_Bus();

        Aca_Anio_Lectivo_Bus Anio_bus = new Aca_Anio_Lectivo_Bus();
        Aca_Anio_Lectivo_Info Anio_Info = new Aca_Anio_Lectivo_Info();
        Aca_Rubro_x_Aca_Periodo_Lectivo_Bus rubro_anio_bus = new Aca_Rubro_x_Aca_Periodo_Lectivo_Bus();

        List<Aca_Periodo_Info> Lista_Periodo = new List<Aca_Periodo_Info>();
        Aca_Periodo_Bus Periodo_Bus = new Aca_Periodo_Bus();

        fa_descuento_Bus fa_descuento_Bus = new fa_descuento_Bus();
        fa_descuento_Info fa_descuento_Info = new fa_descuento_Info();

        #endregion
        public FrmAca_Beca_Estudiante_x_rubros_Mant()
        {
            InitializeComponent();
            
        }

        private void FrmAca_Beca_Estudiante_x_rubros_Mant_Load(object sender, EventArgs e)
        {
            try
            {
                //ucAca_Estudiante1.CargarListEstudiante();
                set_accion_in_controls();
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

        #region "Set"
        public void set_Accion(Cl_Enumeradores.eTipo_action iAccion)
        {
            try
            {
                Accion = iAccion;
                if (Accion == 0)
                    Accion = Cl_Enumeradores.eTipo_action.grabar;

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


        private void set_accion_in_controls()
        {
            try
            {
                this.cargar_combos();
                Anio_Info = Anio_bus.Get_Info_Lectivo_Activo(param.IdInstitucion);
                switch (Accion)
                {
                    case Cl_Enumeradores.eTipo_action.grabar:
                        set_info_in_controls();
                        break;
                    default:
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


        private void set_info_in_controls()
        {
            try
            {
                ucAca_Estudiante1.CargarListEstudiante();
                ucAca_Estudiante1.set_Estudiante(InfoContrato.IdEstudiante);
                ucAca_Estudiante1.cmbEstudiante.Properties.ReadOnly = true;

                cargar_grid();
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
       
        private void Get()
        {
            try
            {
                foreach (var item in lista_detalle_beca)
                {
                    if (item.check == true)
                    {
                      
                       
                        item.IdInstitucion = param.IdInstitucion;
                        item.IdContrato = InfoContrato.IdContrato;
                        item.IdEmpresa = lista_beca.FirstOrDefault(a => a.IdDescuento == item.IdDescuento).IdEmpresa;
                        item.IdInstitucion_Per = Anio_Info.IdInstitucion;
                        item.IdAnioLectivo_Per = Anio_Info.IdAnioLectivo;
                        item.IdUsuarioCreacion = param.IdUsuario;
                        
                    }
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

        private void cargar_combos()
        {
            try
            {
                lista_beca = bus_beca.Get_List_Beca(param.IdInstitucion);
                cmbBeca.DataSource = lista_beca.FindAll(a => a.estado== "A");
                cmbBeca.DisplayMember = "nom_beca";
                cmbBeca.ValueMember = "IdBeca";

                //Lista_rubros = Rubros_bus.Get_List_Rubro(param.IdInstitucion, param.IdSucursal);
                //cmbRubro.DataSource = Lista_rubros;
                //cmbRubro.DisplayMember = "Descripcion_rubro";
                //cmbRubro.ValueMember = "IdRubro";

                Lista_rubros_x_Estudiante = Rubros_x_Estudiante_bus.Get_Lista_Rubro_x_Estudiante(param.IdInstitucion, InfoContrato.IdContrato);
                cmbRubro.DataSource = Lista_rubros_x_Estudiante;
                cmbRubro.DisplayMember = "Descripcion_rubro";
                cmbRubro.ValueMember = "IdRubro";

                Lista_Periodo = Periodo_Bus.Get_List_Periodo(param.IdInstitucion);
                cmbPeriodo.DataSource = Lista_Periodo.FindAll(a => a.pe_estado == "A");
                cmbPeriodo.DisplayMember = "IdPeriodo";
                cmbPeriodo.ValueMember = "IdPeriodo";

            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NameMetodo = NameMetodo + " - " + ex.ToString();
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
                MessageBox.Show(NameMetodo + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas)
                    , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_grid()
        {
            try
            {
                if (InfoContrato != null)
                {
                    lista_detalle_beca = new BindingList<Aca_contrato_x_estudiante_det_beca_Info>(bus_beca_estudiante.Get_lista(Convert.ToInt32(InfoContrato.IdInstitucion), Convert.ToInt32(InfoContrato.IdEstudiante), Convert.ToInt32(InfoContrato.IdContrato), Convert.ToInt32(InfoContrato.IdAnioLectivo)));
                    
                   
                    if (lista_detalle_beca.Count != 0)
                    {
                        foreach (var item in lista_detalle_beca)
                        {
                            Aca_Rubro_x_Aca_Periodo_Lectivo_Bus rubro_anio_bus = new Aca_Rubro_x_Aca_Periodo_Lectivo_Bus();
                            item.Valor = rubro_anio_bus.Get_Rubro_x_PeriodoLectivo(item.IdRubro).Valor;
                            item.pe_FechaFin = Anio_Info.FechaFin;
                            item.pe_FechaIni = Anio_Info.FechaInicio;
                            item.Descripcion = Anio_Info.Descripcion;
                            item.check = false;

                        }
                        gridControl_rubros.DataSource = lista_detalle_beca; 
                    }
                    else
                    {
                        lista_detalle_beca = new BindingList<Aca_contrato_x_estudiante_det_beca_Info>();
                        gridControl_rubros.DataSource = lista_detalle_beca;
                    }
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


        private bool Grabar()
        {
            ucAca_Estudiante1.Focus();
            try
            {
                bool resultado = false;
                if (lista_detalle_beca.Where(v => v.check == true).ToList().Count != 0)
                {
                    
                    Get();
                    if (bus_beca_estudiante.Grabar_DB(lista_detalle_beca.Where(v => v.check == true).ToList()))
                    {
                        MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Se_guardaron_los_datos_correctamente), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        resultado = true;
                    }
                    else
                    {
                        MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.No_se_guardaron_los_datos), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_un_registro), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    resultado = false;
                }
                return resultado;
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

       

        private void ucGe_Menu_Superior_Mant1_event_btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucGe_Menu_Superior_Mant1_event_btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Grabar();
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

        private void ucGe_Menu_Superior_Mant1_event_btnGuardar_y_Salir_Click(object sender, EventArgs e)
        {

            try
            {
                if (Grabar())
                    this.Close();
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
      
        private void chkAplicarBeca_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //double valor = 0;
                //double valor_beca = 0;
                //Info_beca = new Aca_Beca_Info();
                //    if (chkAplicarBeca.Checked == true)
                //    {
                //        if (cmb_beca.EditValue != null)
                //        {
                //            for (int i = 0; i < gridView_rubros.RowCount; i++)
                //            {
                //                Info_beca = lista_beca.FirstOrDefault(a => a.IdBeca == Convert.ToInt16(cmb_beca.EditValue));

                //                valor = Convert.ToDouble(gridView_rubros.GetRowCellValue(i, Col_Valor));
                //                if (valor != 0 && Info_beca != null)
                //                {
                //                    valor_beca = Info_beca.porcentaje * valor / 100;
                //                    gridView_rubros.SetRowCellValue(i, Col_check, true);
                //                    gridView_rubros.SetRowCellValue(i, Col_nom_beca, Info_beca.nom_beca);
                //                    gridView_rubros.SetRowCellValue(i, Col_valor_beca, valor_beca);
                //                    gridView_rubros.SetRowCellValue(i, Col_porc_beca, Info_beca.porcentaje);
                                    
                                    
                //                }

                //            }
                //        }
                //        else
                //        {
                //            chkAplicarBeca.Checked = false;
                //            cmb_beca.Focus();
                //            MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Por_Favor_) + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_la) + " beca"
                //           , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                //    }
                //    else
                //    {

                //        for (int i = 0; i < gridView_rubros.RowCount; i++)
                //        {
                //            gridView_rubros.SetRowCellValue(i, Col_check, false);
                //            gridView_rubros.SetRowCellValue(i, Col_porc_beca, 0);
                //            gridView_rubros.SetRowCellValue(i, Col_nom_beca, string.Empty);
                //            gridView_rubros.SetRowCellValue(i, Col_valor_beca, 0);
                //        }
                //    }
                
                 
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

        private void gridView_rubros_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal IdRubro = 0;
                decimal IdBeca = 0;
                decimal IdDescuento = 0;
                Aca_contrato_x_estudiante_det_beca_Info Info = new Aca_contrato_x_estudiante_det_beca_Info();
                Info = (Aca_contrato_x_estudiante_det_beca_Info)this.gridView_rubros.GetFocusedRow();
                Info.Descripcion  = Anio_Info.Descripcion;
                Info.pe_FechaFin = Anio_Info.FechaFin;
                Info.pe_FechaIni = Anio_Info.FechaInicio;
                Info.IdPeriodo_Per = Info.IdPeriodo;
                ucAca_Estudiante1.Focus();

                IdRubro = Convert.ToDecimal(gridView_rubros.GetFocusedRowCellValue(Col_Descripcion_rubro));
                IdBeca = Convert.ToDecimal(gridView_rubros.GetFocusedRowCellValue(Col_nom_beca));
                
                


                //if (IdDescuento != 0)
                    

                if (IdRubro != 0)
                    Info.Valor = rubro_anio_bus.Get_Rubro_x_PeriodoLectivo(IdRubro).Valor;
                if (IdBeca != 0)
                {
                    Info_beca = bus_beca.Get_List_Beca(param.IdInstitucion).FirstOrDefault(a => a.IdBeca == IdBeca);

                    Info.porc_beca = Info_beca.porcentaje;
                    Info.IdEmpresa = Info_beca.IdEmpresa;
                    Info.IdDescuento = Info_beca.IdDescuento;
                }

                if (Info.Valor != 0 && Info.porc_beca != 0)
                    Info.valor_beca = Convert.ToDouble(Info.Valor * Info.porc_beca / 100);
                
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

        private void gridView_rubros_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("¿Está seguro que desea anular este registro ?", param.Nombre_sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool resultado = false;
                        Aca_contrato_x_estudiante_det_beca_Info Info = new Aca_contrato_x_estudiante_det_beca_Info();
                        Info = (Aca_contrato_x_estudiante_det_beca_Info)this.gridView_rubros.GetFocusedRow();
                        if (Info != null)
                        {
                            Info.IdUsuarioUltAnulo = param.IdUsuario;
                            resultado = bus_beca_estudiante.Anular_DB(Info);
                            if (resultado)
                            {
                                //gridvwExepcion_x_Estudiante.DeleteSelectedRows();
                                //MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Se_Anulo_Correctamente) + " el rubro " + InfoExcepciones.Descripcion_rubro, param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            //else
                                //gridvwExepcion_x_Estudiante.DeleteSelectedRows();
                        }
                    }
                }
                //gridCtrlExepcion_x_Estudiante.RefreshDataSource();
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
    }
}
