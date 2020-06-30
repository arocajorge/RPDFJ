
using Core.Erp.Info.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Erp.Business.Roles;
using Core.Erp.Info.Roles;
using Core.Erp.Business.General;
using Core.Erp.Winform.General;
using Core.Erp.Recursos.Properties;

namespace Core.Erp.Winform.Roles
{
    public partial class frmRo_Permisos_x_Empleado_Mant : Form
    {
        #region Declaración de variables
        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();
        //private Cl_Enumeradores.eTipo_action _Accion;
        private ro_permiso_x_empleado_Info _Info = new ro_permiso_x_empleado_Info();
        //public void set_Accion(Cl_Enumeradores.eTipo_action iAccion) { _Accion = iAccion; }
        ro_permiso_x_empleado_Bus oRo_permiso_x_empleado_Bus = new ro_permiso_x_empleado_Bus();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        List<ro_Empleado_Info> EmpInfo1 = new List<ro_Empleado_Info>();
        List<ro_Empleado_Info> EmpInfo2 = new List<ro_Empleado_Info>();
        List<ro_Empleado_Info> EmpInfo3 = new List<ro_Empleado_Info>();

        BindingList<ro_Catalogo_Info> oListEstadoAprobacion = new BindingList<ro_Catalogo_Info>();
        List<ro_Catalogo_Info> oRo_TipoLicencia_Info = new List<ro_Catalogo_Info>();

        ro_Empleado_Info empinfo = new ro_Empleado_Info();
        ro_Departamento_Info depInfo = new ro_Departamento_Info();
        ro_Cargo_Info carInfo = new ro_Cargo_Info();
        ro_Catalogo_Bus catBus = new ro_Catalogo_Bus();
        ro_Cargo_Bus carBus = new ro_Cargo_Bus();
        ro_Empleado_Bus empBus = new ro_Empleado_Bus();
        ro_Departamento_Bus depBus = new ro_Departamento_Bus();
        frmRo_Periodo_Cons frmCons = new frmRo_Periodo_Cons();
        Cl_Enumeradores.eTipo_action iAccion = new Cl_Enumeradores.eTipo_action();
        List<ro_Catalogo_Info> ListCatalogo = new List<ro_Catalogo_Info>();
        List<ro_Nomina_Tipoliqui_Info> ListadoTipoLiquidacion = new System.Collections.Generic.List<ro_Nomina_Tipoliqui_Info>();
        ro_Nomina_Tipoliqui_Bus bus_nomina_tipo_liq = new ro_Nomina_Tipoliqui_Bus();
        ro_Catalogo_Bus BusCatalogo = new ro_Catalogo_Bus();
        BindingList<ro_Empleado_Novedad_Det_Info> lst_novedades = new BindingList<ro_Empleado_Novedad_Det_Info>();
        
        public delegate void delegate_frmRo_Permisos_x_Empleado_Mant_FormClosing(object sender, FormClosingEventArgs e);
        public event delegate_frmRo_Permisos_x_Empleado_Mant_FormClosing event_frmRo_Permisos_x_Empleado_Mant_FormClosing;
        
        string mensaje = "";
     
        #endregion
     
        public frmRo_Permisos_x_Empleado_Mant()
        {
            try
            {
                 InitializeComponent();
                 ucGe_Menu.event_btnGuardar_Click += ucGe_Menu_event_btnGuardar_Click;
                 ucGe_Menu.event_btnGuardar_y_Salir_Click += ucGe_Menu_event_btnGuardar_y_Salir_Click;
                 ucGe_Menu.event_btnSalir_Click += ucGe_Menu_event_btnSalir_Click;
                 ucGe_Menu.event_btnAnular_Click += ucGe_Menu_event_btnAnular_Click;
                
                 event_frmRo_Permisos_x_Empleado_Mant_FormClosing += frmRo_Permisos_x_Empleado_Mant_event_frmRo_Permisos_x_Empleado_Mant_FormClosing;            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
            
        }

        void ucGe_Menu_event_btnAnular_Click(object sender, EventArgs e)
        {
            PU_ANULAR();
        }

        void ucGe_Menu_event_btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

        void ucGe_Menu_event_btnGuardar_y_Salir_Click(object sender, EventArgs e)
        {
            try
            {  pu_Guardar();
            this.Close();

            }
            catch (Exception ex)
            {
                
                 MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

        void ucGe_Menu_event_btnGuardar_Click(object sender, EventArgs e)
        {
            //PU_GUARDAR_MODIFICAR();

            pu_Guardar();

        }

        void frmRo_Permisos_x_Empleado_Mant_event_frmRo_Permisos_x_Empleado_Mant_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                    //throw new NotImplementedException();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
            
        }

        private void frmRo_Permisos_x_Empleado_Mant_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                  event_frmRo_Permisos_x_Empleado_Mant_FormClosing(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }   

        }
                        
        public Boolean getInfo() {
            try
            {
                
                if (txtIdPermiso.Text != null && txtIdPermiso.Text != "")
                {
                    _Info.IdPermiso = decimal.Parse(txtIdPermiso.Text); 
                }
                _Info.IdEmpresa = param.IdEmpresa;
                _Info.IdNomina_Tipo = empinfo.IdNomina_Tipo;
                _Info.Fecha = Convert.ToDateTime(dtpFecha.EditValue);
                _Info.IdEmpleado = Convert.ToDecimal(cmbEmpleado.EditValue);
                _Info.MotivoAusencia = Convert.ToString(txtMotivoAusencia.EditValue);
                _Info.IdTipoLicencia = cmbTipoLicencia.EditValue == null ? "" : cmbTipoLicencia.EditValue.ToString();
                _Info.EsPermiso = rbPermiso.Checked;
                _Info.EsLicencia = rbLicencia.Checked;
                _Info.IdUsuario = param.IdUsuario;
                _Info.Fecha_Transac = param.Fecha_Transac;
                _Info.FechaSalida = Convert.ToDateTime(dtFechaSalida.EditValue);
                _Info.FechaEntrada = Convert.ToDateTime(dtFechaEntrada.EditValue);
                _Info.lst_novedad = new List<ro_Empleado_Novedad_Det_Info>(lst_novedades);          
                if (iAccion == Cl_Enumeradores.eTipo_action.Anular)
                {
                    _Info.Estado = "I";
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString()); return false;
            }
        }
      
        public Boolean setInfo(ro_permiso_x_empleado_Info info) 
        {
            try
            {
                _Info= info;

                txtIdPermiso.EditValue = _Info.IdPermiso;
                dtpFecha.EditValue = _Info.Fecha;
                cmbEmpleado.EditValue = _Info.IdEmpleado;
                txtMotivoAusencia.EditValue = _Info.MotivoAusencia;
               
                rbPermiso.Checked = Convert.ToBoolean(info.EsPermiso);
                rbLicencia.Checked = Convert.ToBoolean(info.EsLicencia);             
                cmbTipoLicencia.EditValue = info.IdTipoLicencia;
                dtFechaSalida.EditValue = info.FechaSalida;
                dtFechaEntrada.EditValue = info.FechaEntrada;
                if (_Info.Estado == "I"){
                    lblEstado.Visible = true;
                }else {
                    lblEstado.Visible = false;               
                }
                if (iAccion == Cl_Enumeradores.eTipo_action.actualizar)
                {
                    if (_Info.EsLicencia == true)
                    {
                        dtFechaEntrada.Enabled = true;
                        dtFechaSalida.Enabled = true;
                    }
                    else
                    {
                        dtFechaEntrada.Enabled = false;
                        dtFechaSalida.Enabled = false;

                    }
                }
               txtCedula.EditValue = info.pe_cedulaRuc;
               txtDepartamento.EditValue = (info.de_descripcion).Trim();
               txtCargo.EditValue = info.ca_descripcion;
               lst_novedades = new BindingList<ro_Empleado_Novedad_Det_Info>(oRo_permiso_x_empleado_Bus.get_novedad(_Info.IdEmpresa, _Info.IdEmpleado, _Info.IdPermiso));
               gridControl_novedades.DataSource = lst_novedades;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString()); return false;
            }
        
        }

 
        void PU_MOSTRAR_DETALLE(decimal IdEmpleado) {
            try
            {

               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }


        public Boolean PU_VALIDAR() {
            try
            {

                if (cmbEmpleado.EditValue == null)
                {
                    MessageBox.Show("El Empleado es obligatorio, revise por favor", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    cmbEmpleado.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString()); return false;
            }
        }




        public void PU_ANULAR()
        {
        try
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            FrmGe_MotivoAnulacion oFrm = new FrmGe_MotivoAnulacion();
                     DialogResult result = MessageBox.Show("Está seguro que desea ANULAR el registro, recuerde que se procederá a eliminar?", "ATENCION", buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                string msg = "";

                oFrm.ShowDialog();

                getInfo();

                _Info.IdUsuario_Anu = param.IdUsuario;
                _Info.FechaAnulacion = param.Fecha_Transac;
                _Info.MotivoAnulacion = oFrm.motivoAnulacion;
                _Info.Estado = "I";


               if (oRo_permiso_x_empleado_Bus.AnularDB(_Info, ref mensaje))
               {
                    setInfo(_Info);

                    lblEstado.Visible = true;
                    ucGe_Menu.Enabled_bntAnular = false;
                    MessageBox.Show(Resources.msgConfirmaAnulacionOk, Resources.msgTituloAnular, MessageBoxButtons.OK, MessageBoxIcon.Information);
     
                }
               else
               {
                    MessageBox.Show("Imposible anular el Registro No. " + txtIdPermiso.Text + " , débido a: "
                    + mensaje, "ANULACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            
        }
        
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            Log_Error_bus.Log_Error(ex.ToString());
        }
        
        
        }

        
        public void pu_Guardar()
        {
            try {
                decimal idPermiso=0;

                if (PU_VALIDAR())
                {

                    if (getInfo())
                    {
                        if (oRo_permiso_x_empleado_Bus.GuardarDB(_Info, ref idPermiso, ref mensaje))
                        {
                            txtIdPermiso.Text = idPermiso.ToString();
                          if(  rbLicencia.Checked==true)
                          {                            
                                empBus.Modificar_Estado(param.IdEmpresa, Convert.ToInt32(_Info.IdEmpleado), "EST_SUB");
                            }
                            else
                            {
                                empBus.Modificar_Estado(param.IdEmpresa, Convert.ToInt32(_Info.IdEmpleado), "EST_ACT");
                            }
                            MessageBox.Show(Resources.msgConfirmaGrabarOk, Resources.msgTituloGrabar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            iAccion = Cl_Enumeradores.eTipo_action.grabar;



                            // si teien descuento rol
                            if (rbLicencia.Checked == true)
                            {
                                if (MessageBox.Show("El empleado esta con licencia medica,¿ desea ingresar la novedad por descuento?", "PERMISO" + param.Nombre_sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {                                    
                                    frmRo_Empleado_Novedad_Mant Frm = new frmRo_Empleado_Novedad_Mant();
                                    Frm.set_Accion(Cl_Enumeradores.eTipo_action.grabar);                                   
                                    Frm.Set_IdEmpleado(Convert.ToInt32(_Info.IdEmpleado), Convert.ToInt32(_Info.IdNomina_Tipo), 2);
                                    Frm.ShowDialog();
                                   int novedad=  Frm.IdNonvedad_empleado;
                                }
                            }

                            PU_BLOQUEAR_CONTROLES(false);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }


        }
        public void PU_CARGAR_COMBOS()
        {
            try
            {
                ro_Empleado_Info inf = new ro_Empleado_Info();
    
                EmpInfo1.Add(new ro_Empleado_Info());

                oListEstadoAprobacion.Add(new ro_Catalogo_Info());


                oRo_TipoLicencia_Info.Add(new ro_Catalogo_Info());


                EmpInfo1.AddRange(empBus.Get_List_Empleado_(param.IdEmpresa));


                cmbEmpleado.Properties.DataSource = EmpInfo1;
              

                //LLENA EL COMBO TIPO DE LICENCIA
                oRo_TipoLicencia_Info.AddRange(catBus.Get_List_Catalogo_x_Tipo(23));
                cmbTipoLicencia.Properties.ValueMember = "IdCatalogo";
                cmbTipoLicencia.Properties.DisplayMember = "ca_descripcion";
                cmbTipoLicencia.Properties.DataSource = oRo_TipoLicencia_Info;
              // tipos de descuentos
                ListCatalogo = BusCatalogo.Get_List_Catalogo_x_DiasFalta(1);
              
                pu_ValidarCheck();


               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

        private void PU_BLOQUEAR_CONTROLES(Boolean estado){
            dtpFecha.Properties.ReadOnly = estado;
            txtMotivoAusencia.Properties.ReadOnly = estado;
           
            cmbEmpleado.Properties.ReadOnly = estado;
            dtFechaEntrada.Enabled = false;
            dtFechaSalida.Enabled = false;
           
        }


         public void setAccion(Cl_Enumeradores.eTipo_action Accion)
        {
            try
            {
                iAccion = Accion;

                cmbEmpleado.Enabled = false;
                cmbTipoLicencia.Properties.ReadOnly = true;
                rbPermiso.Enabled = false;
                rbLicencia.Enabled = false;

                switch (iAccion)
                {
                    case Cl_Enumeradores.eTipo_action.grabar:
                        ucGe_Menu.Visible_bntAnular = false;
                        ucGe_Menu.Visible_bntGuardar_y_Salir = true;
                        ucGe_Menu.Visible_btnGuardar = true;
                        ucGe_Menu.Visible_bntSalir = true;
                        dtpFecha.DateTime = System.DateTime.Now;                         
                        
                        PU_BLOQUEAR_CONTROLES(false);
                        cmbEmpleado.Enabled = true;
                        cmbTipoLicencia.Properties.ReadOnly = false;
                        rbPermiso.Enabled = true;
                        rbLicencia.Enabled = true;
                        break;
                    case Cl_Enumeradores.eTipo_action.actualizar:                    
                        ucGe_Menu.Visible_bntAnular = false;
                        ucGe_Menu.Visible_bntGuardar_y_Salir = true;
                        ucGe_Menu.Visible_btnGuardar = true;                    
                        dtpFecha.Enabled = false;
                        PU_BLOQUEAR_CONTROLES(false);
                        cmbTipoLicencia.Properties.ReadOnly = false;
                        rbPermiso.Enabled = false;
                        rbLicencia.Enabled = false;

                       
                        break;
                    case Cl_Enumeradores.eTipo_action.Anular:
                        ucGe_Menu.Enabled_bntAnular = true;
                        ucGe_Menu.Visible_bntGuardar_y_Salir = false;
                        ucGe_Menu.Visible_btnGuardar = false;
                        PU_BLOQUEAR_CONTROLES(true);
                        break;
                    case Cl_Enumeradores.eTipo_action.consultar:                
                        ucGe_Menu.Visible_bntAnular = false;
                        ucGe_Menu.Visible_bntGuardar_y_Salir = false;
                        ucGe_Menu.Visible_btnGuardar = false; 
                        
                        //dtpFecha.Enabled = false;
                        PU_BLOQUEAR_CONTROLES(true);

                        break;

                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        
        }


        private void frmRo_Permisos_x_Empleado_Mant_Load(object sender, EventArgs e)
        {
            try
            {
                if (iAccion == Cl_Enumeradores.eTipo_action.grabar)
                {


                }

                gridControl_novedades.DataSource = lst_novedades;
               
              
                txtIdPermiso.Enabled = false;
                txtCedula.Enabled = false;
                txtDepartamento.Enabled = false;
                txtCargo.Enabled = false;
                lblEstado.Visible = false;
                dtpFecha.EditValue = DateTime.Now;

                if (iAccion == Cl_Enumeradores.eTipo_action.grabar)
                {
                    dtFechaEntrada.Enabled = true;
                    dtFechaSalida.Enabled = true;
                    dtFechaEntrada.EditValue = DateTime.Now;
                    dtFechaSalida.EditValue = DateTime.Now;
                }

                PU_CARGAR_COMBOS ();
            
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }  
        }


   private void cmbAprobado_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpleado.EditValue == null)
                {
                    MessageBox.Show("Seleccione un Empleado", "Mensaje");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

     
        private void frmRo_Permisos_x_Empleado_Mant_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }


        private void pu_ValidarCheck() {
            try {

                if(rbLicencia.Checked)
                {
                    cmbTipoLicencia.Enabled = true;

                    
                  

                   
                }
                else
                {
                    if(rbPermiso.Checked){
                        cmbTipoLicencia.Enabled = false;
                    }
                
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }        
        }



        private void rbPermiso_CheckedChanged(object sender, EventArgs e)
        {
            pu_ValidarCheck();
        }

        private void rbLicencia_CheckedChanged(object sender, EventArgs e)
        {
            pu_ValidarCheck();
        }

        private void cmbIdEmpleado_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                cmb_nomina_tipo_liq.DisplayMember = "DescripcionProcesoNomina";
                cmb_nomina_tipo_liq.ValueMember = "IdNomina_TipoLiqui";


                if (iAccion == Cl_Enumeradores.eTipo_action.grabar)
                {
                    empinfo = (ro_Empleado_Info)cmbEmpleado.Properties.View.GetFocusedRow();
                    if (empinfo != null)
                    {
                        txtCedula.EditValue = empinfo.InfoPersona.pe_cedulaRuc;
                        txtDepartamento.EditValue = (empinfo.de_descripcion).Trim();
                        txtCargo.EditValue = empinfo.cargo;

                        ListadoTipoLiquidacion = bus_nomina_tipo_liq.Get_List_Nomina_Tipoliqui_x_Nomina_Tipo(param.IdEmpresa, Convert.ToInt32(empinfo.IdNomina_Tipo));
                        cmb_nomina_tipo_liq.DataSource = ListadoTipoLiquidacion;
                    }
                }
                else
                {


                    ro_Empleado_TipoNomina_Bus bus_emp_nom = new ro_Empleado_TipoNomina_Bus();
                    var info_emp_no = bus_emp_nom.Get_Info_Empleado_TipoNomina(_Info.IdEmpresa, _Info.IdEmpleado);
                    ListadoTipoLiquidacion = bus_nomina_tipo_liq.Get_List_Nomina_Tipoliqui_x_Nomina_Tipo(param.IdEmpresa, Convert.ToInt32(info_emp_no.IdNomina_Tipo));
                    cmb_nomina_tipo_liq.DataSource = ListadoTipoLiquidacion;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

        private void checkCumplioTiempo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }



        public void Limpiar()
        {
            try
            {
                
                cmbEmpleado.EditValue = null;


                txtCargo.Text = "";
                txtCedula.Text = "";
                txtDepartamento.Text = "";
                txtMotivoAusencia.Text = "";
              
                cmbEmpleado.Enabled = true;
               
                rbPermiso.Enabled = true;
                rbLicencia.Enabled = true;
                dtFechaEntrada.Enabled = true;
                dtFechaSalida.Enabled = true;
                lst_novedades = new BindingList<ro_Empleado_Novedad_Det_Info>();
                gridControl_novedades.DataSource = lst_novedades;
                txtIdPermiso.Text = "";
                PU_CARGAR_COMBOS();
            }
            catch (Exception ex)
            {
                
               MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

      

        public void set_IdEmpleado(int IdEmpleado)
        {
            try
            {
                cmbEmpleado.EditValue = IdEmpleado;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
            }
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtHoraS_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.ToString());
                Log_Error_bus.Log_Error(ex.ToString());
               
            }
        }

        private void TxtHoraI_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

    
      

   
    }
}
