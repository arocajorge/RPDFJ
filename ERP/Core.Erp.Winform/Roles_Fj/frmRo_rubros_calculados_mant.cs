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
using Core.Erp.Info.Roles;
using Core.Erp.Business.Roles_Fj;
using Core.Erp.Business.Roles;
using Core.Erp.Business.General;
using Core.Erp.Info.General;
using Core.Erp.Winform.General;

namespace Core.Erp.Winform.Roles_Fj
{
    public partial class frmRo_rubros_calculados_mant : Form
    {
        #region varibales
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();
        Cl_Enumeradores.eTipo_action _Accion;
        ro_rubros_calculados_Info ro_rubros_calculados_Info = new ro_rubros_calculados_Info();
        ro_rubro_tipo_Bus bus_rubro = new ro_rubro_tipo_Bus();
        BindingList<ro_rubro_tipo_Info> ro_rubro_tipo_Info = new BindingList<ro_rubro_tipo_Info>();
        ro_rubros_calculados_Bus ro_rubros_calculados_Bus = new ro_rubros_calculados_Bus();
        public delegate void delegate_frmRo_placa_mant_FormClosing(object sender, FormClosingEventArgs e);
        public event delegate_frmRo_placa_mant_FormClosing event_frmRo_placa_mant_FormClosing;

        string mensaje = "";
        int IdPlaca = 0;
        #endregion

        public frmRo_rubros_calculados_mant()
        {
            InitializeComponent();
            event_frmRo_placa_mant_FormClosing += frmRo_placa_mant_event_frmRo_placa_mant_FormClosing;
        }

        void frmRo_placa_mant_event_frmRo_placa_mant_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void frmRo_placa_mant_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.event_frmRo_placa_mant_FormClosing(sender, e);
            }
            catch (Exception ex)
            {
                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
       
        private void set_info()
        {
            try
            {
                cmb_dias_trabajados.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_ingresos.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_egresos.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_iess.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_sueldo.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_total_pagar.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_aporte_patronal.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_fondo_reserva.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_provision_vacaciones.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_prov_dIII.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_prov_cuarto.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_prov_fr.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_decimo_iii.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_decimo_iv.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_ir.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_anticipo.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_dias_efectivos.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_alimentacion.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_transporte.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_otros_descuentos.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_otros_descuentos.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_horas_extras.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_subtotal_variable.Properties.DataSource = ro_rubro_tipo_Info;

                cmb_car_alim.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_ent_alim.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_vol_alim.Properties.DataSource = ro_rubro_tipo_Info;

                cmb_car_beb.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_ent_beb.Properties.DataSource = ro_rubro_tipo_Info;
                cmb_vol_beb.Properties.DataSource = ro_rubro_tipo_Info;

                cmb_nivel_serv.Properties.DataSource = ro_rubro_tipo_Info;


                cmb_dias_trabajados.EditValue = ro_rubros_calculados_Info.IdRubro_dias_trabajados;
                cmb_ingresos.EditValue = ro_rubros_calculados_Info.IdRubro_tot_ing;
                cmb_egresos.EditValue = ro_rubros_calculados_Info.IdRubro_tot_egr;
                cmb_iess.EditValue = ro_rubros_calculados_Info.IdRubro_iess_perso;
                cmb_sueldo.EditValue = ro_rubros_calculados_Info.IdRubro_sueldo;
                cmb_total_pagar.EditValue = ro_rubros_calculados_Info.IdRubro_tot_pagar;
                cmb_aporte_patronal.EditValue = ro_rubros_calculados_Info.IdRubro_aporte_patronal;
                cmb_fondo_reserva.EditValue = ro_rubros_calculados_Info.IdRubro_fondo_reserva;
                cmb_provision_vacaciones.EditValue = ro_rubros_calculados_Info.IdRubro_prov_vac;
                cmb_prov_dIII.EditValue = ro_rubros_calculados_Info.IdRubro_prov_DIII;
                cmb_prov_cuarto.EditValue = ro_rubros_calculados_Info.IdRubro_prov_DIV;
                cmb_prov_fr.EditValue = ro_rubros_calculados_Info.IdRubro_prov_FR;
                cmb_decimo_iii.EditValue = ro_rubros_calculados_Info.IdRubro_DIII;
                cmb_decimo_iv.EditValue = ro_rubros_calculados_Info.IdRubro_DIV;
                cmb_ir.EditValue = ro_rubros_calculados_Info.IdRubro_IR;
                cmb_anticipo.EditValue = ro_rubros_calculados_Info.IdRubro_anticipo;
                cmb_dias_efectivos.EditValue = ro_rubros_calculados_Info.IdRubro_dias_efectivos;
                cmb_alimentacion.EditValue = ro_rubros_calculados_Info.IdRubro_alimentacion;
                cmb_transporte.EditValue = ro_rubros_calculados_Info.IdRubro_transporte;
                cmb_otros_descuentos.EditValue = ro_rubros_calculados_Info.IdRubro_otros_descuentos;
                cmb_horas_extras.EditValue = ro_rubros_calculados_Info.IdRubro_horas_extras;
                cmb_subtotal_variable.EditValue = ro_rubros_calculados_Info.IdRubro_subtotal_variable;

                cmb_car_alim.EditValue = ro_rubros_calculados_Info.IdRubro_alm_car;
                cmb_ent_alim.EditValue = ro_rubros_calculados_Info.IdRubro_alm_ent;
                cmb_vol_alim.EditValue = ro_rubros_calculados_Info.IdRubro_alm_vol;

                cmb_car_beb.EditValue = ro_rubros_calculados_Info.IdRubro_beb_car;
                cmb_ent_beb.EditValue = ro_rubros_calculados_Info.IdRubro_beb_ent;
                cmb_vol_beb.EditValue = ro_rubros_calculados_Info.IdRubro_beb_vol;

                cmb_nivel_serv.EditValue = ro_rubros_calculados_Info.IdRubro_servicio;


            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas) + ex.Message + " ", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
            }
        }

        private void get_info()
        {
            try
            {
                ro_rubros_calculados_Info = new Info.Roles_Fj.ro_rubros_calculados_Info();
                ro_rubros_calculados_Info.IdEmpresa = param.IdEmpresa;
                ro_rubros_calculados_Info.IdRubro_dias_trabajados=cmb_dias_trabajados.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_tot_ing=cmb_ingresos.EditValue.ToString() ;
                ro_rubros_calculados_Info.IdRubro_tot_egr=cmb_egresos.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_iess_perso=cmb_iess.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_sueldo = cmb_sueldo.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_tot_pagar= cmb_total_pagar.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_aporte_patronal=cmb_aporte_patronal.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_fondo_reserva=cmb_fondo_reserva.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_prov_vac=cmb_provision_vacaciones.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_prov_DIII=cmb_prov_dIII.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_prov_DIV=cmb_prov_cuarto.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_prov_FR=cmb_prov_fr.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_DIII=cmb_decimo_iii.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_DIV=cmb_decimo_iv.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_IR=cmb_ir.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_anticipo=cmb_anticipo.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_dias_efectivos = cmb_dias_efectivos.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_alimentacion = cmb_alimentacion.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_transporte = cmb_transporte.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_otros_descuentos = cmb_otros_descuentos.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_horas_extras = cmb_horas_extras.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_subtotal_variable = cmb_subtotal_variable.EditValue.ToString();


                ro_rubros_calculados_Info.IdRubro_alm_car= cmb_car_alim.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_alm_ent=cmb_ent_alim.EditValue.ToString();
                ro_rubros_calculados_Info.IdRubro_alm_vol = cmb_vol_alim.EditValue.ToString();

                ro_rubros_calculados_Info.IdRubro_beb_car=cmb_car_beb.EditValue .ToString() ;
                ro_rubros_calculados_Info.IdRubro_beb_ent=cmb_ent_beb.EditValue .ToString() ;
                ro_rubros_calculados_Info.IdRubro_beb_vol=cmb_vol_beb.EditValue .ToString() ;

                ro_rubros_calculados_Info.IdRubro_servicio = cmb_nivel_serv.EditValue.ToString();


            }
            catch (Exception)
            {
                
                throw;
            }
        }
       



        
        private Boolean GuardarDB()
        {
            try
            {
                if (validar())
                {
                    get_info();
                    if (ro_rubros_calculados_Bus.GuardarDB(ro_rubros_calculados_Info))
                        MessageBox.Show("Registro guardado correctamente");
                    else
                        MessageBox.Show("El registro guardado correctamente");
                }
               

               
                return true;
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas) + ex.Message + " ", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
                return false;
            }
        }

       
        public Boolean validar()
        {
            try
            {
                string mensaj="";


               if( cmb_dias_trabajados.EditValue ==null)
                  mensaj="No a seleccionado todos los rubro";
               if( cmb_ingresos.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";
                if( cmb_egresos.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";
                if( cmb_iess.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";
                if( cmb_sueldo.EditValue ==null)
                mensaj="No a seleccionado todos los rubro"; 
                 if( cmb_total_pagar.EditValue ==null)
                mensaj="No a seleccionado todos los rubro"; 
                if( cmb_aporte_patronal.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";  
                if( cmb_fondo_reserva.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";  
                if( cmb_provision_vacaciones.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";
                if( cmb_prov_dIII.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";
                if( cmb_prov_cuarto.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";
                if( cmb_prov_fr.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";
                if( cmb_decimo_iii.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";
                if( cmb_decimo_iv.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";
                if( cmb_ir.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";
                if( cmb_anticipo.EditValue ==null)
                mensaj="No a seleccionado todos los rubro";

                if (cmb_horas_extras.EditValue == null)
                    mensaj = "No a seleccionado todos los rubro";
                if (cmb_otros_descuentos.EditValue == null)
                    mensaj = "No a seleccionado todos los rubro";
                if (mensaj == "")
                {
                    return true;
                }

                else
                {
                    MessageBox.Show(mensaj);
                    return false;


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
        }

        public void limpiar()
        {
            try
            {
                
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
                GuardarDB();
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas) + ex.Message + " ", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
            }
        }

        private void ucGe_Menu_event_btnGuardar_y_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                
                    Close();
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas) + ex.Message + " ", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
            }
        }

        private void ucGe_Menu_event_btnlimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas) + ex.Message + " ", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
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
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas) + ex.Message + " ", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
            }
        }

        private void frmRo_placa_mant_Load(object sender, EventArgs e)
        {
            try
            {

                ro_rubro_tipo_Info = new BindingList<ro_rubro_tipo_Info>(bus_rubro.Get_List_Formulas(param.IdEmpresa));
                ro_rubros_calculados_Info = ro_rubros_calculados_Bus.get_info(param.IdEmpresa);

                set_info();
            }
            catch (Exception ex)
            {
                string NameMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                MessageBox.Show(param.Get_Mensaje_sys(enum_Mensajes_sys.Error_comunicarse_con_sistemas) + ex.Message + " ", param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log_Error_bus.Log_Error(NameMetodo + " - " + ex.ToString());
            }
        }
    }
}
