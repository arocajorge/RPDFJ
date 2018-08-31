using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Erp.Recursos.Properties;
using Core.Erp.Business.General;
using Core.Erp.Info.General;
using Core.Erp.Winform.General;
using Core.Erp.Winform.Controles;
using Core.Erp.Business.Academico;
using Core.Erp.Info.Academico;
using Core.Erp.Info.Bancos;
using Core.Erp.Business.Bancos;
using System.IO;
using Core.Erp.Business.Academico.Archivo_Para_Banco;
using System.Globalization;
namespace Core.Erp.Winform.Academico
{
    public partial class FrmAcaAdministrador_Archivos_Banco_Mant : Form
    {
        public FrmAcaAdministrador_Archivos_Banco_Mant()
        {
            InitializeComponent();
            Cargar_Data();
            ucBa_Proceso.cmbProceso.EditValueChanged += cmbProceso_EditValueChanged;
        }
        #region variable

        int iIdAnioLectivo = 0;
        int iIdPeriodo = 0;
        int iIdSede = 0;
        int iIdJornada = 0;
        int iIdGrupoFe = 0;
        int iIdBanco = 0;
        string sIdProcesoBancario = "";
        int iEstaEnArchivo = 0;

        string msg = "";
        string mensaje = "";
        string sFechaActual;
        string sCodigoEstblecimiento = "";
        System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("es-ES");

        public Cl_Enumeradores.eTipo_action accion { get; set; }
        List<Aca_Anio_Lectivo_Info> lista_anio_lectivo = new List<Aca_Anio_Lectivo_Info>();
        List<Aca_Periodo_Info> lista_periodo = new List<Aca_Periodo_Info>();
        List<Aca_Curso_Info> lista_curso = new List<Aca_Curso_Info>();

        List<ba_Archivo_Transferencia_Det_Info> lista_Detalle = new List<ba_Archivo_Transferencia_Det_Info>();
        List<ba_Archivo_Transferencia_Det_Info> lista_ArchivoTransferDetalle = new List<ba_Archivo_Transferencia_Det_Info>();

        Aca_Anio_Lectivo_Bus bus_anio_lectivo = new Aca_Anio_Lectivo_Bus();
        Aca_Periodo_Bus bus_periodo = new Aca_Periodo_Bus();
        Aca_Pre_Facturacion_det_Bus bus_detalle = new Aca_Pre_Facturacion_det_Bus();
        Aca_Curso_Bus bus_curso = new Aca_Curso_Bus();
        Aca_Pre_Facturacion_Bus bus_pre_facturacion = new Aca_Pre_Facturacion_Bus();
        Aca_Pre_Facturacion_det_Bus bus_pre_facturacion_det = new Aca_Pre_Facturacion_det_Bus();



        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;

        List<fa_factura_aca_Info> lista_facturas = new List<fa_factura_aca_Info>();
        fa_factura_aca_Bus bus_facturas = new fa_factura_aca_Bus();
        Aca_Periodo_Info info_periodo = new Aca_Periodo_Info();

        Aca_Pre_Facturacion_Info info_prefac = new Aca_Pre_Facturacion_Info();

        ba_Archivo_Transferencia_Info Archivo_Info = new ba_Archivo_Transferencia_Info();
        ba_Archivo_Transferencia_Det_Info ArchivoDet_Info = new ba_Archivo_Transferencia_Det_Info();

        BindingList<ba_Archivo_Transferencia_Det_Info> BindingList_Archivo_Detalle = new BindingList<ba_Archivo_Transferencia_Det_Info>();
        ba_Archivo_Transferencia_Bus Archivo_Bus = new ba_Archivo_Transferencia_Bus();
        ba_Archivo_Transferencia_Det_Bus Archivo_Detalle_Bus = new ba_Archivo_Transferencia_Det_Bus();
        string nombre_file = "";
        int IdArchivo = 0;
        public Cl_Enumeradores.eTipo_action Accion { get; set; }
        VisaMastercardBankard_Bolivariano_Bus bus_Bolivariano = new VisaMastercardBankard_Bolivariano_Bus();
         string Inicial_Nom_archivo="";


         Visa_Diners_Club_Bus bus_diner = new Visa_Diners_Club_Bus();
         Banco_Internacional_Bus bus_Internacional = new Banco_Internacional_Bus();
         Pacificar_Bus bus_pacificar = new Pacificar_Bus();

         Aca_RubroGrupoFE_Bus BusRubroGrupoFE = new Aca_RubroGrupoFE_Bus();
         Aca_RubroGrupoFE_Info InfoRubroGrupoFE = new Aca_RubroGrupoFE_Info();
         List<Aca_RubroGrupoFE_Info> ListInfoRubroGrupoFE = new List<Aca_RubroGrupoFE_Info>();

         Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info InfoProcesoBancario_GrupoFE = new Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info();
         Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Bus BusProcesoBancario_GrupoFE = new Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Bus();

        #endregion

        void cmbProceso_EditValueChanged(object sender, EventArgs e)
        {
            
        }
   
        private void ucGe_Menu_event_btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void FrmAcaAdministrador_Archivos_Banco_Mant_Load(object sender, EventArgs e)
        {
            try
            {
                ucAca_SedeJornadaSeccionCurso.CargarCombos();
            }
            catch (Exception ex)
            {
                
                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.Message);           
            }
        }

        private void Cargar_Data()
        {
            try
            {
                ////string anio = "";
                int anio = 0;

                int periodo = 0;
                lista_anio_lectivo = bus_anio_lectivo.Get_List_Anio_Lectivo(param.IdInstitucion);
                cmb_anio_lectivo.Properties.DataSource = lista_anio_lectivo;
                anio = lista_anio_lectivo.FirstOrDefault().IdAnioLectivo;
                cmb_anio_lectivo.EditValue = anio;
                lista_periodo = bus_periodo.Get_List_PeriodoActivo_x_AnioLectivo(param.IdInstitucion, Convert.ToInt16(cmb_anio_lectivo.EditValue.ToString()));
                cmb_periodo.Properties.DataSource = lista_periodo;
                periodo = lista_periodo.FirstOrDefault().IdPeriodo;
                cmb_periodo.EditValue = periodo;
                ucBa_Proceso.cargar_CuentaBanco();


                var now = DateTime.Now;
                var DaysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
                var lastDay = new DateTime(now.Year, now.Month, DaysInMonth);

                dtpFechaInicioPago.EditValue = DateTime.Now;
                dtFechaTopePago.EditValue = lastDay;

                ucAca_Rubro.cargaCmb_Rubro();
                ucAca_Estudiante1.CargarListEstudiante();

                cmb_GrupoFE.Properties.DataSource = BusRubroGrupoFE.Get_List_Rubro_Grupo_FE();

            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void cmb_periodo_EditValueChanged(object sender, EventArgs e)
        {

        }

        public void Get()
        {
            try
            {
                Archivo_Info.IdEmpresa = param.IdEmpresa;
                Archivo_Info.IdBanco = (int)ucBa_Proceso.get_BaCuentaInfo().IdBanco;
                Archivo_Info.Observacion = txtObservacion.Text;
                Archivo_Info.IdUsuario = param.IdUsuario;
                Archivo_Info.Nom_Archivo = nombre_file;
                Archivo_Info.Fecha =Convert.ToDateTime( dtpFechaInicioPago.EditValue);
                Archivo_Info.cod_archivo = cmb_anio_lectivo.EditValue.ToString()+cmb_periodo.EditValue.ToString();
                Archivo_Info.Fecha_Transac = DateTime.Now;
                Archivo_Info.Estado = true;
                Archivo_Info.IdEstadoArchivo_cat = "FIL_EMITID";
                Archivo_Info.IdProceso_bancario = ucBa_Proceso.get_Proceso_Info().IdProceso_bancario_tipo;
                Archivo_Info.Origen_Archivo = "COL";
                Archivo_Info.Nom_Archivo = ucBa_Proceso.get_Proceso_Info().IdProceso_bancario_tipo;
                Archivo_Info.IdUsuario = param.IdUsuario;
                Archivo_Info.Fecha_Transac = DateTime.Now;
                Archivo_Info.Contabilizado = false;
                Archivo_Info.Cod_Empresa = ucBa_Proceso.get_Proceso_Info().Codigo_Empresa;
                Archivo_Info.Archivo = StreamFile(Inicial_Nom_archivo);

                lista_ArchivoTransferDetalle = new List<ba_Archivo_Transferencia_Det_Info>();

                foreach (var item in lista_Detalle)
                {
                    ArchivoDet_Info = new ba_Archivo_Transferencia_Det_Info();

                    ArchivoDet_Info =  item;
                    ArchivoDet_Info.IdEmpresa = param.IdEmpresa;
                    ArchivoDet_Info.IdProceso_bancario = ucBa_Proceso.get_Proceso_Info().IdProceso_bancario_tipo;
                    ArchivoDet_Info.Estado = true;
                    ArchivoDet_Info.IdEstadoRegistro_cat = "REG_EMITI";
                    ArchivoDet_Info.FechaInicioFacturacion = Convert.ToDateTime(dtpFechaInicioPago.EditValue);
                    ArchivoDet_Info.FechaTopeFacturacion = Convert.ToDateTime(dtFechaTopePago.EditValue);

                    //CAMPOS SOLO PARA GARANTIZADOS
                    if (Convert.ToInt16(rdoFiltros.EditValue) == 2)
                    {
                        ArchivoDet_Info.IdContrato = item.IdContrato ;
                        ArchivoDet_Info.IdInstitucion_contra = item.IdInstitucion;
                        ArchivoDet_Info.IdInstitucion_Col = null;

                    }
                    
                    //ArchivoDet_Info.Valor = Convert.ToDecimal(item.vt_total);

                    //ArchivoDet_Info.IdInstitucion_Col = item.IdInstitucion_Col;
                    //ArchivoDet_Info.IdAnioLectivo_Col = (int)cmb_anio_lectivo.EditValue;
                    //ArchivoDet_Info.IdPeriodo_Col = Convert.ToInt32(cmb_periodo.EditValue);
                    //ArchivoDet_Info.IdRubro_col = Convert.ToInt32(item.IdRubro_Col);
                    //ArchivoDet_Info.IdEstudiante_Col = item.IdEstudiante_Col;

                    if (Convert.ToInt16(rdoFiltros.EditValue) != 2)
                    {
                        item.IdInstitucion_Col = item.IdInstitucion_Col;


                        ArchivoDet_Info.IdPreFacturacion_col = item.IdPreFacturacion_col;
                        ArchivoDet_Info.Secuencia_Proce_col = item.Secuencia_Proce_col;
                        ArchivoDet_Info.secuencia_col = item.secuencia_col;
                        ArchivoDet_Info.Valor = item.Valor;
                        ArchivoDet_Info.IdContrato = null;
                        ArchivoDet_Info.IdInstitucion_contra = null;
                    }
                    if (ArchivoDet_Info.Chequeo == true)
                    {
                        lista_ArchivoTransferDetalle.Add(ArchivoDet_Info);
                    }
                }
                Archivo_Info.Lst_Archivo_Transferencia_Det = lista_ArchivoTransferDetalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

        public void Set(ba_Archivo_Transferencia_Info Info_)
        {
            try
            {
                Archivo_Info = Info_;
                txtObservacion.Text = Info_.Observacion;
                dtpFechaInicioPago.EditValue = Info_.Fecha;
                ucBa_Proceso.SetIdBanco(Info_.IdBanco);
                ucBa_Proceso.SetIdProceso(Info_.IdProceso_bancario);
                txtObservacion.Text = Info_.Observacion;
                txtId.Text = Convert.ToString(Info_.IdArchivo);
                
               

                
                    //Archivo_Info.Lst_Archivo_Transferencia_Det = Archivo_Detalle_Bus.Get_List_Archivo_transferencia_Det(Info_.IdEmpresa,param.IdInstitucion, Convert.ToInt32(Info_.IdArchivo));
                    BindingList_Archivo_Detalle = new BindingList<Info.Bancos.ba_Archivo_Transferencia_Det_Info>(Archivo_Info.Lst_Archivo_Transferencia_Det);
                    gridControl_pre_fac.DataSource = BindingList_Archivo_Detalle;

               


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

        public byte[] StreamFile(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                byte[] ImageData = new byte[fs.Length];
                fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                return ImageData; //return the byte data
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return new byte[000];

            }
        }



        public bool Guardar()
        {
           
            bool Bandera = false;
            try
            {
                Get();
                switch (Accion)
                {
                    case Cl_Enumeradores.eTipo_action.grabar:
                        Bandera = GrabarDB();
                        break;
                    case Cl_Enumeradores.eTipo_action.actualizar:
                        Bandera = ModificarDB();
                        break;
                    case Cl_Enumeradores.eTipo_action.Anular:
                        Bandera = AnularDB();
                        break;
                    default:
                        break;
                }
                
                return Bandera;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
                return false;
            }
        }

        public bool GrabarDB()
        {
            try
            {
                bool Bandera = false;

                if (Archivo_Bus.GrabarDB(Archivo_Info, ref IdArchivo))
                {
                    MessageBox.Show("Registro Guardado Correctamente", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Bandera = true;
                    return Bandera;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Bandera = false;
                    return Bandera;

                }

                return Bandera;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
                return false;
            }
        }

        public bool ModificarDB()
        {
            try
            {
                bool Bandera = false;
                if (Archivo_Bus.ModificarDB(Archivo_Info))
                {
                    MessageBox.Show("Registro Actualizado Correctamente", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Bandera = true;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Bandera = false;
                }
                return Bandera;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
                return false;
            }
        }

        public bool AnularDB()
        {
            try
            {
                bool Bandera = false;

                if (MessageBox.Show("¿Está seguro que desea anular el Departamento...?", "Anulación de Departamento  " + param.Nombre_sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FrmGe_MotivoAnulacion ofrm = new FrmGe_MotivoAnulacion();
                    ofrm.ShowDialog();

                    Archivo_Info.IdUsuarioUltAnu = param.IdUsuario;
                    Archivo_Info.Fecha_UltMod = DateTime.Now;
                    Archivo_Info.Motivo_anulacion = ofrm.motivoAnulacion;

                    if (Archivo_Bus.AnularDB(Archivo_Info))
                    {
                        foreach (var item in Archivo_Info.Lst_Archivo_Transferencia_Det)
                        {
                            item.IdArchivo = Archivo_Info.IdArchivo;
                            item.IdProceso_bancario = Archivo_Info.IdProceso_bancario;
                        }

                        if (Archivo_Detalle_Bus.AnularDB(Archivo_Info.Lst_Archivo_Transferencia_Det))
                        {
                            MessageBox.Show("Registro Anulado Correctamente", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Bandera = true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Anular el registro", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Bandera = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Anular el registro", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Bandera = false;
                    }
                }

                return Bandera;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
                return false;
            }
        }

        private void ucGe_Menu_event_btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            Guardar();
        }

        private void ucGe_Menu_event_btnGuardar_y_Salir_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            if (Guardar())
                this.Close();
        }

        private void cmb_generar_Click(object sender, EventArgs e)
        {
            Generar();
        }

        private void Generar()
        {
            try
            {
               
                string formatoFecha = "dddd/MMMM/yyyy";

                

                if (!Validar())
                    return;
                string IdCodigo_Lega = "";
                

                IdCodigo_Lega = ucBa_Proceso.get_BaCuentaInfo().CodigoLegal;
                sIdProcesoBancario = ucBa_Proceso.cmbProceso.EditValue.ToString();

                Inicial_Nom_archivo = ucBa_Proceso.get_Proceso_Info().Iniciales_Archivo;
                Inicial_Nom_archivo = Inicial_Nom_archivo + DateTime.Now.Year;
                Inicial_Nom_archivo = txtruta.EditValue.ToString()+ Inicial_Nom_archivo+".txt";

                lista_ArchivoTransferDetalle = new List<ba_Archivo_Transferencia_Det_Info>();
                Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info infoProcesoBancario_GrupoFE = new Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info();

                infoProcesoBancario_GrupoFE = BusProcesoBancario_GrupoFE.Get_Info_ProcesoBanco_x_GrupoFE(param.IdInstitucion, Convert.ToInt16(cmb_GrupoFE.EditValue), param.IdEmpresa, sIdProcesoBancario);

                foreach (var item in lista_Detalle)
                {

                    if (item.Chequeo == true)
                    {
                        item.FechaInicioFacturacion = Convert.ToDateTime(dtpFechaInicioPago.EditValue);
                        item.FechaTopeFacturacion = Convert.ToDateTime(dtFechaTopePago.EditValue);
                        lista_ArchivoTransferDetalle.Add(item);
                    }
                }


                switch (IdCodigo_Lega)
                {
                case "34":
                    {

                        if (sIdProcesoBancario == "DEB_CTA_CTE_AHO_BB")
                        {
                            sFechaActual = DateTime.Now.ToString("dd MMMM yyyy", cultureinfo);
                            
                            if (ucAca_SedeJornadaSeccionCurso.cmbJornada.Text == "MATUTINA")
                            {
                                sCodigoEstblecimiento = "266 " + cmb_GrupoFE.Text;
                            }
                            if (ucAca_SedeJornadaSeccionCurso.cmbJornada.Text == "VESPERTINA")
                            {
                                sCodigoEstblecimiento = "298 " + cmb_GrupoFE.Text;
                            }
                            Inicial_Nom_archivo = "";
                            Inicial_Nom_archivo = ucBa_Proceso.get_Proceso_Info().Iniciales_Archivo + sCodigoEstblecimiento + " " + sFechaActual;
                            Inicial_Nom_archivo = txtruta.EditValue.ToString() + Inicial_Nom_archivo + ".txt";
                               
                        }
                        if (sIdProcesoBancario == "BANKCARD")
                        {
                            string sSecuencialArchivo = "";
                            sSecuencialArchivo = "001";
                            sFechaActual = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString();
                            sCodigoEstblecimiento = infoProcesoBancario_GrupoFE.Codigo_establecimiento;

                            
                            Inicial_Nom_archivo = "";
                            Inicial_Nom_archivo = sFechaActual + sCodigoEstblecimiento + "_" + sFechaActual + sSecuencialArchivo;
                            Inicial_Nom_archivo = txtruta.EditValue.ToString() + Inicial_Nom_archivo + ".txt";

                        }

                        bus_Bolivariano.Grabar(lista_ArchivoTransferDetalle.ToList(), Inicial_Nom_archivo, ucBa_Proceso.get_Proceso_Info().cod_Proceso);

                            break;
                    }
                case "10":
                    #region FiltroGrupoFE_Deshabilitada
                    //if (cmb_GrupoFE.Text == "MATRICULA")
                    //    {
                    //        //sCodigoEstblecimiento = "1482456";
                    //        sCodigoEstblecimiento = infoProcesoBancario_GrupoFE.Codigo_establecimiento;
                    //    }
                    //if (cmb_GrupoFE.Text == "PENSION")
                    //{
                    //    //sCodigoEstblecimiento = "1481524";
                    //    sCodigoEstblecimiento = infoProcesoBancario_GrupoFE.Codigo_establecimiento;
                    //}
                    //if (cmb_GrupoFE.Text == "RECAUD. COMITE PADRE")
                    //    {
                    //        //sCodigoEstblecimiento = "1482472";
                    //        sCodigoEstblecimiento = infoProcesoBancario_GrupoFE.Codigo_establecimiento;
                    //    }
                    //if (cmb_GrupoFE.Text == "CLASES COMPLEMENTARIAS")
                    //    {
                    //        //sCodigoEstblecimiento = "1482498";
                    //        sCodigoEstblecimiento = infoProcesoBancario_GrupoFE.Codigo_establecimiento;
                    //    }
                    //if (cmb_GrupoFE.Text == "EXAMENES BACHILLERATO INTERNACIONAL")
                    //    {
                    //        //sCodigoEstblecimiento = "1482480";
                    //        sCodigoEstblecimiento = infoProcesoBancario_GrupoFE.Codigo_establecimiento;
                    //    }
                    //if (cmb_GrupoFE.Text == "TRANSPORTE")
                    //{
                    //    //sCodigoEstblecimiento = "1498718";
                    //    sCodigoEstblecimiento = infoProcesoBancario_GrupoFE.Codigo_establecimiento;
                    //}
                    #endregion
                    sFechaActual = DateTime.Now.Year.ToString().Substring(0, 4) + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                    sCodigoEstblecimiento = infoProcesoBancario_GrupoFE.Codigo_establecimiento;

                        Inicial_Nom_archivo = "";
                        Inicial_Nom_archivo = ucBa_Proceso.get_Proceso_Info().Iniciales_Archivo + " " + sFechaActual + "_" + sCodigoEstblecimiento;
                        Inicial_Nom_archivo = txtruta.EditValue.ToString() + Inicial_Nom_archivo + ".txt";
                    bus_diner.Grabar(lista_ArchivoTransferDetalle.ToList(), Inicial_Nom_archivo, ucBa_Proceso.get_Proceso_Info().cod_Proceso);
                    break;


                //case "32":
                //    bus_Internacional.Grabar(lista_ArchivoTransferDetalle.ToList(), Inicial_Nom_archivo, ucBa_Proceso.get_Proceso_Info().cod_Proceso, ucBa_Proceso.get_BaCuentaInfo().ba_Num_Cuenta);
                //    break;

                case "30":
                        sFechaActual =  DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                            
                        Inicial_Nom_archivo = "";
                        Inicial_Nom_archivo = ucBa_Proceso.get_Proceso_Info().Iniciales_Archivo + "TE" + sFechaActual;
                        Inicial_Nom_archivo = txtruta.EditValue.ToString() + Inicial_Nom_archivo + ".txt";


                    bus_pacificar.Grabar(lista_ArchivoTransferDetalle.ToList(), Inicial_Nom_archivo, ucBa_Proceso.get_Proceso_Info().cod_Proceso, ucBa_Proceso.get_BaCuentaInfo().ba_Num_Cuenta);
                    break;

                default:
                    break;

            }
                MessageBox.Show(param.NombreEmpresa, "Se genero el archivo correctamente en: " + txtruta.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

      


        private bool Validar()
        {
            try
            {
                bool ba = true;
                if (txtruta.Text == "")
                {
                    MessageBox.Show("Seleccione la ruta para el archivo", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ba = false;
                }

                if (ucBa_Proceso.get_BaCuentaInfo()==null)
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_el)+ " banco", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ba = false;
                }
                if (ucBa_Proceso.get_Proceso_Info() == null)
                {
                    MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_el) + " proceso", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ba = false;
                }
                if(Convert.ToInt16(ucBa_Proceso.cmb_Banco.EditValue) == 3 ||  sIdProcesoBancario == "BANKCARD")
                {
                    if (cmb_GrupoFE.EditValue == "" || cmb_GrupoFE.EditValue == null)
                    {
                        MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_el) + " Grupo FE", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ba = false;
                    }
                }
                if (Convert.ToInt16(ucBa_Proceso.cmb_Banco.EditValue) == 2)
                {
                    if (ucAca_SedeJornadaSeccionCurso.cmbJornada.EditValue == "" || ucAca_SedeJornadaSeccionCurso.cmbJornada.EditValue == null)
                    {
                        MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Seleccione_la) + " Jornada", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ba = false;
                    }
                }

                return ba;
            }
            catch (Exception ex)
            {
                
                    MessageBox.Show(ex.ToString());
                    Log_Error_bus.Log_Error(ex.ToString()); return false;
            }
        }

     

      

       

        private void Buscar()
        {
            try
            {
                if (!Validar())
                    return;

                iIdAnioLectivo = Convert.ToInt32(cmb_anio_lectivo.EditValue);
                iIdPeriodo = Convert.ToInt32(cmb_periodo.EditValue);
                iIdSede = Convert.ToInt16(ucAca_SedeJornadaSeccionCurso.cmbSede.EditValue);
                iIdJornada = ucAca_SedeJornadaSeccionCurso.cmbJornada.EditValue == null ? 0 : Convert.ToInt16(ucAca_SedeJornadaSeccionCurso.cmbJornada.EditValue);
                iIdGrupoFe = cmb_GrupoFE.EditValue == null ? 0 : Convert.ToInt16(cmb_GrupoFE.EditValue);
                iIdBanco = ucBa_Proceso.get_Proceso_Info().IdBanco;
                sIdProcesoBancario = ucBa_Proceso.get_Proceso_Info().IdProceso_bancario_tipo;


                if (rdoFiltros.Text == "")
                {
                    lista_Detalle = new List<ba_Archivo_Transferencia_Det_Info>(
                        bus_detalle.Get_list_Generar_Archivo_Banco_Det_PeriodoActivo(
                                    param.IdInstitucion, iIdSede, iIdAnioLectivo, iIdPeriodo, iIdBanco, sIdProcesoBancario, 0, iIdGrupoFe, iIdJornada));
                }

                //SOLO PERIODO ACTIVO
                if (rdoFiltros.Text == "0")
                {
                    lista_Detalle = new List<ba_Archivo_Transferencia_Det_Info>(
                        bus_detalle.Get_list_Generar_Archivo_Banco_Det_PeriodoActivo(
                                    param.IdInstitucion, iIdSede, iIdAnioLectivo, iIdPeriodo, iIdBanco, sIdProcesoBancario, Convert.ToInt16(rdoFiltros.Text), iIdGrupoFe, iIdJornada));
                }
                //YA EXISTEN EN ARCHIVO
                if (rdoFiltros.Text == "1")
                {
                    lista_Detalle = new List<ba_Archivo_Transferencia_Det_Info>(
                        bus_detalle.Get_list_Generar_Archivo_Banco_Det_PeriodoActivo_y_Pendientes_Pago(
                                    param.IdInstitucion, iIdSede, iIdAnioLectivo, iIdPeriodo, iIdBanco, ucBa_Proceso.get_Proceso_Info().IdProceso_bancario_tipo));
                }
                //GARANTIZADOS
                if (rdoFiltros.Text == "2")
                {
                    lista_Detalle = new List<ba_Archivo_Transferencia_Det_Info>(
                        bus_detalle.Get_listGarantizados_Rubro_Pension(
                                    param.IdInstitucion, iIdSede, iIdAnioLectivo, iIdPeriodo, iIdBanco, sIdProcesoBancario));
                }


                foreach (var item in lista_Detalle)
                {
                    item.Chequeo = true;
                }
                gridControl_pre_fac.DataSource = lista_Detalle;


                if (lista_Detalle.Count() == 0)
                    MessageBox.Show("No hay registro para la consulta", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void txtruta_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.Description = "Select a folder";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {

                        txtruta.Text = dlg.SelectedPath + @"\";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

        private void cmb_buscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {


            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Generar();
        }

        

      
    }
}
