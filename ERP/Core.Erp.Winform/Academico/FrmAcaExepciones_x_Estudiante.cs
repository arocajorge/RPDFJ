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
    public partial class FrmAcaExepciones_x_Estudiante : Form
    {
        #region "Variables"
        string mensaje = "";
        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;

        public Aca_Contrato_x_Estudiante_Info InfoContrato { get; set; }
        Aca_Contrato_x_Estudiante_Info ContratoInfo = new Aca_Contrato_x_Estudiante_Info();

        Aca_Contrato_x_Estudiante_x_det_Excepcion_Bus busExepciones = new Aca_Contrato_x_Estudiante_x_det_Excepcion_Bus();
        BindingList<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info> LstExcepciones;
        Aca_Contrato_x_Estudiante_x_det_Excepcion_Info InfoExcepciones =  new Aca_Contrato_x_Estudiante_x_det_Excepcion_Info();

        fa_descuento_Bus fa_descuento_Bus = new fa_descuento_Bus();
        fa_descuento_Info fa_descuento_Info = new fa_descuento_Info();
        List<fa_descuento_Info> List_fa_descuento_Info = new List<fa_descuento_Info>();

        List<Aca_Periodo_Info> Lista_Periodo = new List<Aca_Periodo_Info>();
        Aca_Periodo_Bus Periodo_Bus = new Aca_Periodo_Bus();

        List<Aca_Rubro_Info> Lista_rubros = new List<Aca_Rubro_Info>();
        Aca_Rubro_Bus Rubros_bus = new Aca_Rubro_Bus();

        List<Aca_Contrato_x_Estudiante_det_Info> Lista_rubros_x_Estudiante = new List<Aca_Contrato_x_Estudiante_det_Info>();
        Aca_Contrato_x_Estudiante_det_Bus Rubros_x_Estudiante_bus = new Aca_Contrato_x_Estudiante_det_Bus();

        Aca_Anio_Lectivo_Bus Anio_bus = new Aca_Anio_Lectivo_Bus();
        Aca_Anio_Lectivo_Info Anio_Info = new Aca_Anio_Lectivo_Info();
        private Cl_Enumeradores.eTipo_action Accion;
        string Anio_lectivo = string.Empty;
        #endregion


        public FrmAcaExepciones_x_Estudiante()
        {
            InitializeComponent();
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
                Anio_Info= Anio_bus.Get_Info_Lectivo_Activo(param.IdInstitucion);
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

        #region "Get"
        private void Get_Info()
        {
            try
            {
                foreach (var item in LstExcepciones)
                {

                    if (item.IdExepcion == 0)
                    {
                        item.IdInstitucion = param.IdInstitucion;
                        item.IdContrato = InfoContrato.IdContrato;
                        item.IdEmpresa = List_fa_descuento_Info.FirstOrDefault(a => a.IdDescuento == item.IdDescuento).IdEmpresa;
                        item.IdInstitucion_Per = Anio_Info.IdInstitucion;
                        item.IdAnioLectivo_Per = Anio_Info.IdAnioLectivo;
                        item.UsuarioCreacion = param.IdUsuario;
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
        #endregion

        private void cargar_combos()
        {
            try
            {
                List_fa_descuento_Info = fa_descuento_Bus.Get_Lista_Descuento(param.IdEmpresa, ref mensaje);
                cmbDescuento.DataSource = List_fa_descuento_Info.FindAll(a=> a.Estado == true);
                cmbDescuento.DisplayMember = "de_nombre";
                cmbDescuento.ValueMember = "IdDescuento";


                Lista_Periodo = Periodo_Bus.Get_List_Periodo(param.IdInstitucion);
                cmbPeriodo.DataSource = Lista_Periodo.FindAll(a => a.pe_estado == "A"); 

                cmbPeriodo.DisplayMember = "IdPeriodo";
                cmbPeriodo.ValueMember = "IdPeriodo";

                //Lista_rubros = Rubros_bus.Get_List_Rubro(param.IdInstitucion, param.IdSucursal);
                //cmbRubro.DataSource = Lista_rubros;
                //cmbRubro.DisplayMember = "Descripcion_rubro";
                //cmbRubro.ValueMember = "IdRubro";


                Lista_rubros_x_Estudiante = Rubros_x_Estudiante_bus.Get_Lista_Rubro_x_Estudiante(param.IdInstitucion,InfoContrato.IdContrato);
                cmbRubro.DataSource = Lista_rubros_x_Estudiante;
                cmbRubro.DisplayMember = "Descripcion_rubro";
                cmbRubro.ValueMember = "IdRubro";

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
                    LstExcepciones = new BindingList<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info>(busExepciones.Get_lista_excepciones_Contratos(param.IdInstitucion, InfoContrato.IdContrato));
                    if(LstExcepciones.Count !=0)
                    {
                        foreach (var item in LstExcepciones)
                        {
                            Aca_Rubro_x_Aca_Periodo_Lectivo_Bus rubro_anio_bus = new Aca_Rubro_x_Aca_Periodo_Lectivo_Bus();
                            item.ValorRubro = rubro_anio_bus.Get_Rubro_x_PeriodoLectivo(item.IdRubro).Valor;
                            item.AnioLectivo = Anio_Info.Descripcion;

                        }
                        gridCtrlExepcion_x_Estudiante.DataSource = LstExcepciones;
                    }
                    else
                    {
                        LstExcepciones = new BindingList<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info>();
                        gridCtrlExepcion_x_Estudiante.DataSource = LstExcepciones;
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

        private bool Guardar_DB()
        {
            bool resultado = false;
            ucAca_Estudiante1.Focus();
            try
            {
                Get_Info();
                if (busExepciones.Grabar_DB(LstExcepciones.Where(a=> a.IdExepcion ==0).ToList()))
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Se_guardaron_los_datos_correctamente), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resultado = true;
                }
                else
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.No_se_guardaron_los_datos) + ", " + param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas), param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region "Eventos"

        private void FrmAcaExepciones_x_Estudiante_Load(object sender, EventArgs e)
        {

            try
            {
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
 
        private void ucGe_Menu_Superior_Mant1_event_btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
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

        private void ucGe_Menu_Superior_Mant1_event_btnGuardar_y_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                if(Guardar_DB())
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

        private void ucGe_Menu_Superior_Mant1_event_btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Guardar_DB();
               
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

        private void chkAplicarDescuento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //double valor = 0;
                //double valor_Descuento = 0;
                //fa_descuento_Info = new fa_descuento_Info();
                //if (chkAplicarDescuento.Checked == true)
                //{
                //    if (cmbDescuento != null)
                //    {
                //        for (int i = 0; i < gridvwExepcion_x_Estudiante.RowCount; i++)
                //        {
                //            fa_descuento_Info = List_fa_descuento_Info.FirstOrDefault(a => a.IdDescuento == Convert.ToInt16(cmbDescuento));

                //            valor = Convert.ToDouble(gridvwExepcion_x_Estudiante.GetRowCellValue(i, Col_ValorRubro));
                //            if (valor != 0 && fa_descuento_Info != null)
                //            {
                //                valor_Descuento = fa_descuento_Info.de_porcentaje * valor / 100;
                //                gridvwExepcion_x_Estudiante.SetRowCellValue(i, Col_check, true);
                //                gridvwExepcion_x_Estudiante.SetRowCellValue(i, ColDescuento, fa_descuento_Info.de_nombre);
                //                gridvwExepcion_x_Estudiante.SetRowCellValue(i, Col_ValorExcepcion, valor_Descuento);
                //                gridvwExepcion_x_Estudiante.SetRowCellValue(i, Col_porcentaje_excepcion, fa_descuento_Info.de_porcentaje);


                //            }

                //        }
                //    }
                //    else
                //    {
                //        chkAplicarDescuento.Checked = false;
                        
                //        MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Por_Favor_) + " " + param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_la) + " Descuento"
                //       , param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
                //else
                //{

                //    for (int i = 0; i < gridvwExepcion_x_Estudiante.RowCount; i++)
                //    {
                //        gridvwExepcion_x_Estudiante.SetRowCellValue(i, Col_check, false);
                //        gridvwExepcion_x_Estudiante.SetRowCellValue(i, Col_porcentaje_excepcion, 0);
                //        gridvwExepcion_x_Estudiante.SetRowCellValue(i, ColDescuento, string.Empty);
                //        gridvwExepcion_x_Estudiante.SetRowCellValue(i, Col_ValorExcepcion, 0);
                //    }
                //}


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

        private void gridvwExepcion_x_Estudiante_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {    
                decimal IdRubro = 0;
                decimal IdDescuento = 0;
                InfoExcepciones = new Aca_Contrato_x_Estudiante_x_det_Excepcion_Info();
                InfoExcepciones = (Aca_Contrato_x_Estudiante_x_det_Excepcion_Info)this.gridvwExepcion_x_Estudiante.GetFocusedRow();
                InfoExcepciones.AnioLectivo = Anio_Info.Descripcion;
          
             
                IdRubro = Convert.ToDecimal(gridvwExepcion_x_Estudiante.GetFocusedRowCellValue(Col_IdRubro));
                IdDescuento = Convert.ToDecimal(gridvwExepcion_x_Estudiante.GetFocusedRowCellValue(ColDescuento));
               

                if (IdDescuento != 0)
                    InfoExcepciones.porcentaje_excepcion = List_fa_descuento_Info.FirstOrDefault(a => a.IdDescuento == IdDescuento).de_porcentaje;
                   
                
                Aca_Rubro_x_Aca_Periodo_Lectivo_Bus rubro_anio_bus = new Aca_Rubro_x_Aca_Periodo_Lectivo_Bus();
                if(IdRubro !=0)
                    InfoExcepciones.ValorRubro = rubro_anio_bus.Get_Rubro_x_PeriodoLectivo(IdRubro).Valor;
                if (InfoExcepciones.ValorRubro != 0 && InfoExcepciones.porcentaje_excepcion != 0)
                    InfoExcepciones.ValorExepcion = Convert.ToDouble(InfoExcepciones.ValorRubro * InfoExcepciones.porcentaje_excepcion / 100);

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

        private void gridvwExepcion_x_Estudiante_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("¿Está seguro que desea anular este registro ?", param.Nombre_sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool resultado = false;
                        InfoExcepciones = (Aca_Contrato_x_Estudiante_x_det_Excepcion_Info)this.gridvwExepcion_x_Estudiante.GetFocusedRow();
                        if (InfoExcepciones != null)
                        {
                            InfoExcepciones.UsuarioAnulacion = param.IdUsuario;
                            resultado =busExepciones.AnularBD(InfoExcepciones);
                            if (resultado)
                            {
                                gridvwExepcion_x_Estudiante.DeleteSelectedRows();
                                MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Se_Anulo_Correctamente) + " el rubro " + InfoExcepciones.Descripcion_rubro, param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else 
                            gridvwExepcion_x_Estudiante.DeleteSelectedRows();
                        }
                    }
                }
                gridCtrlExepcion_x_Estudiante.RefreshDataSource();
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

    }
}
