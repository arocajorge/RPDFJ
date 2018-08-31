using Core.Erp.Data.General;
using Core.Erp.Info.General;
using Core.Erp.Info.Inventario_CG;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Inventario_CG
{
    public class vw_in_Producto_x_in_Producto_CG_Data
    {

        string grupo = string.Empty;
        int   clase = 0;
        int subclase = 0;
        public NpgsqlConnection conex {get; set;}
        public vw_in_Producto_x_inv_Producto_CG_Info Get_Info(int IdEmpresa, decimal idproducto)
        {
            try
            {
                vw_in_Producto_x_inv_Producto_CG_Info Info = new vw_in_Producto_x_inv_Producto_CG_Info();
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    var address = Base.vw_in_Producto_x_inv_Producto_CG.FirstOrDefault(o => o.IdEmpresa == IdEmpresa && o.IdProducto == idproducto);
                    if (address != null)
                    {
                        //Info.IdProducto = address.IdProducto;
                        Info.med_cod_anatofarmacologico = address.med_cod_anatofarmacologico;
                        Info.med_cod_forma_farmacologica = address.med_cod_forma_farmacologica;
                        Info.med_cod_principio_activo = address.med_cod_principio_activo;
                        Info.med_sw_farmacovigilancia = address.med_sw_farmacovigilancia;
                        Info.med_descripcion_alerta = address.med_descripcion_alerta;
                        Info.med_sw_alimento_parenteral = address.med_sw_alimento_parenteral;
                        Info.med_sw_alimento_enteral = address.med_sw_alimento_enteral;
                        Info.med_sw_manejo_luz = address.med_sw_manejo_luz;
                        Info.codigo_alterno = address.pr_codigo;
                        Info.codigo_cnmb = address.codigo_cnmb;
                        Info.contenido_unidad_venta = address.contenido_unidad_venta;
                        Info.sw_control_fecha_vencimiento = address.sw_control_fecha_vencimiento;
                        Info.sw_generico = address.sw_generico;
                        Info.sw_pos = address.sw_pos;
                        Info.sw_solicita_autorizacion = address.sw_solicita_autorizacion;
                        Info.sw_venta_directa = address.sw_venta_directa;
                        Info.estado_medicina = (address.estado_medicina == "A") ? "1" : "0";
                        Info.estado_producto = (address.estado_producto== "A") ? "1" : "0";
                        Info.IdCategoria = 0+address.IdCategoria;
                        Info.IdGrupo = address.IdGrupo ;
                        Info.IdLinea = address.IdLinea;
                        Info.IdMotivo_Vta = address.IdMotivo_Vta;
                        Info.IdUnidadMedida = "UN";
                        Info.pr_descripcion = address.pr_descripcion;
                        Info.pr_codigo_barra = address.pr_codigo_barra;
                        grupo = Info.IdCategoria;
                        clase =  Info.IdLinea;
                        subclase = Info.IdGrupo;
                    
                    }
                }
                return Info;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                string MensajeError = string.Empty;
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                MensajeError = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                throw new Exception(ex.InnerException.ToString());
            }
        }



        public bool Grabar_ProductoDBPostgres(int IdEmpresa, decimal idProducto, string idproductoCG, NpgsqlConnection conex_postg, ref string mensaje)
        {
            try
            {
                mensaje = string.Empty;
                bool resultado = false;
                vw_in_Producto_x_inv_Producto_CG_Info Info_proCG = new vw_in_Producto_x_inv_Producto_CG_Info();
                Info_proCG = Get_Info(IdEmpresa, idProducto);
                if (Info_proCG != null)
                {
                    string sql = "insert Into inventarios_productos(codigo_producto,grupo_id,clase_id,subclase_id,producto_id,descripcion,descripcion_abreviada,fabricante_id,unidad_id,porc_iva,estado,contenido_unidad_venta,sw_solicita_autorizacion,codigo_barras,codigo_alterno,sw_venta_directa,codigo_cum,iva_costo,porc_iva_venta,opc_costo_producto,opc_rotacion_producto,opc_consignacion_producto)values("
                                                              + idproductoCG + ",'" + Info_proCG.IdCategoria + "','01','01','3967', '" + Info_proCG.pr_descripcion + "',' " + Info_proCG.pr_descripcion + "','0', '"+Info_proCG.IdUnidadMedida+"', '0','" + Info_proCG.estado_producto + "','" + Info_proCG.contenido_unidad_venta + "','" + Info_proCG.sw_solicita_autorizacion + "', '" + Info_proCG.pr_codigo_barra + "','" + Info_proCG.codigo_alterno + "','" + Info_proCG.sw_venta_directa + "' ,'" + Info_proCG.codigo_cnmb + "', '0','0','0','0','0')";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conex_postg);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    resultado = true;
                }
                conex_postg.Close();
                return resultado; 

            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                string MensajeError = string.Empty;
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                MensajeError = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public bool Actualizar_ProductoDBPostgres(int IdEmpresa, decimal idProducto, NpgsqlConnection conex_postg, ref string mensaje)
        {
            try
            {
                bool resultado = false;
                vw_in_Producto_x_inv_Producto_CG_Info Info_proCG = new vw_in_Producto_x_inv_Producto_CG_Info();
                Info_proCG = Get_Info(IdEmpresa, idProducto);
                if (Info_proCG != null)
                {
                    
                    string sql = "UPDATE inventarios_productos  SET descripcion " + Info_proCG.pr_descripcion + ",descripcion_abreviada = '" + Info_proCG.pr_descripcion + "'WHERE producto_id=" + Convert.ToString(idProducto);
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conex_postg);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    resultado = true;
                }
                conex_postg.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                string MensajeError = string.Empty;
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                MensajeError = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public string  incremento_ProductoCG(NpgsqlConnection cc)
        {
            string  increm = string.Empty;
            try
            {
                bool ba = false;
                string sql = "SELECT max (producto_id) FROM inventarios_productos";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cc);
                NpgsqlDataReader readerr = cmd.ExecuteReader();
                while (readerr.Read())
                {

                    if (readerr.GetString(0).Count() != 0)
                    {
                        
                         string c= (readerr.GetString(0));
                         int s = 0;
                         s = Int32.Parse(c);
                         s = s + 1;

                         increm = Convert.ToString("01"+"01"+"01"+ s);
                        ba = true;
                    }
                }

                if (ba == false)
                    increm = "1";

                readerr.Close();
                cc.Close();
                return increm;

            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                string MensajeError = string.Empty;
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                MensajeError = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                throw new Exception(ex.InnerException.ToString());
            }

        }

        public bool Grabar_MedicamentoDBPostgres(int IdEmpresa, decimal idProducto, string idproductoCG,NpgsqlConnection conex_postg, ref string mensaje)
        {
            try
            {
                bool resultado = false;
                vw_in_Producto_x_inv_Producto_CG_Info Info_proCG = new vw_in_Producto_x_inv_Producto_CG_Info();
                Info_proCG = Get_Info(IdEmpresa, idProducto);
                if (Info_proCG != null)
                {
                    string sql = "insert Into medicamentos (codigo_medicamento,sw_liquidos_electrolitos,cod_anatomofarmacologico,cod_principio_activo,cod_forma_farmacologica,sw_uso_controlado,sw_antibiotico,sw_pos,sw_fotosensible,sw_refrigerado,unidad_medida_medicamento_id,sw_alimento_parenteral,sw_alimento_enteral,dias_previos_vencimiento,sw_manejo_luz,sw_farmacovigilancia,descripcion_alerta)values('"
                        +  idproductoCG + "','0','" + Info_proCG.med_cod_anatofarmacologico + "','" + Info_proCG.med_cod_principio_activo + "','" + Info_proCG.med_cod_forma_farmacologica + "','0','0'," 
                        + Info_proCG.sw_pos + ",'0','0','" + Info_proCG.contenido_unidad_venta + "'," + Info_proCG.med_sw_alimento_parenteral + ", " + Info_proCG.med_sw_alimento_enteral + ", '120',"+Info_proCG.med_sw_manejo_luz+", "+ Info_proCG.med_sw_farmacovigilancia+"," + Info_proCG.med_descripcion_alerta + ")";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conex_postg);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    resultado = true;
                }
                conex_postg.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                string MensajeError = string.Empty;
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                MensajeError = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                throw new Exception(ex.InnerException.ToString());
            }
        }

    }
}
