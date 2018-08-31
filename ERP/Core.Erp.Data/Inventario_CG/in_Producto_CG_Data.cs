using Core.Erp.Data.General;
using Core.Erp.Info.General;
using Core.Erp.Info.Inventario_CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Inventario_CG
{
    public class in_Producto_CG_Data
    {

        #region "Insertar, Actualizar, Eliminar"
        public bool GrabarDB(in_Producto_CG_Info info, ref string mensaje)
        {
            try
            {
                bool resultado = false;
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    in_Producto_CG address = new in_Producto_CG();
                    address.IdEmpresa = info.IdEmpresa;
                    address.IdProducto = info.IdProducto;
                    address.med_cod_anatofarmacologico = info.med_cod_anatofarmacologico;
                    address.med_cod_forma_farmacologica = info.med_cod_forma_farmacologica;       
                    address.med_cod_principio_activo = info.med_cod_principio_activo;
                    address.med_sw_farmacovigilancia= info.med_sw_farmacovigilancia; 
                    address.med_descripcion_alerta= info.med_descripcion_alerta; 
                    address.med_sw_alimento_parenteral  = info.med_sw_alimento_parenteral; 
                    address.med_sw_alimento_enteral = info.med_sw_alimento_enteral;
                    address.med_sw_manejo_luz= info.med_sw_manejo_luz;
                    address.codigo_alterno = info.codigo_alterno;
                    address.codigo_cnmb = info.codigo_cnmb;
                    address.contenido_unidad_venta = info.contenido_unidad_venta;
                    address.sw_control_fecha_vencimiento = info.sw_control_fecha_vencimiento;
                    address.sw_generico = info.sw_generico;
                    address.sw_pos = info.sw_pos;
                    address.sw_solicita_autorizacion = info.sw_solicita_autorizacion;
                    address.sw_venta_directa = info.sw_venta_directa;
                    address.Estado = "A";
                    address.IdUsuario = info.IdUsuario;
                    address.Fecha_Transac = DateTime.Now;
                    address.ip = info.ip;
                    address.nom_pc = info.nom_pc;
                    Base.in_Producto_CG.Add(address);
                    Base.SaveChanges();
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                mensaje = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public bool ActualizarDB(in_Producto_CG_Info info, ref string mensaje)
        {
            try
            {

                bool resultado = false;
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    var address = Base.in_Producto_CG.FirstOrDefault(o => o.IdEmpresa == info.IdEmpresa && o.IdProducto == info.IdProducto);
                    if (address != null)
                    {
                        address.med_cod_anatofarmacologico = info.med_cod_anatofarmacologico;
                        address.med_cod_forma_farmacologica = info.med_cod_forma_farmacologica;
                        address.med_cod_principio_activo = info.med_cod_principio_activo;
                        address.med_sw_farmacovigilancia = info.med_sw_farmacovigilancia;
                        address.med_descripcion_alerta = info.med_descripcion_alerta;
                        address.med_sw_alimento_parenteral = info.med_sw_alimento_parenteral;
                        address.med_sw_alimento_enteral = info.med_sw_alimento_enteral;
                        address.med_sw_manejo_luz = info.med_sw_manejo_luz;
                        address.codigo_alterno = info.codigo_alterno;
                        address.codigo_cnmb = info.codigo_cnmb;
                        address.contenido_unidad_venta = info.contenido_unidad_venta;
                        address.sw_control_fecha_vencimiento = info.sw_control_fecha_vencimiento;
                        address.sw_generico = info.sw_generico;
                        address.sw_pos = info.sw_pos;
                        address.sw_solicita_autorizacion = info.sw_solicita_autorizacion;
                        address.sw_venta_directa = info.sw_venta_directa;
                        address.IdUsuarioUltMod = info.IdUsuarioUltMod;
                        address.Fecha_UltMod = DateTime.Now;
                        address.ip = info.ip;
                        address.nom_pc = info.nom_pc;
                        Base.SaveChanges();
                        resultado = true;
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                mensaje = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public bool AnularDB(in_Producto_CG_Info info, ref string mensaje)
        {
            try
            {

                bool resultado = false;
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    var address = Base.in_Producto_CG.FirstOrDefault(o => o.IdEmpresa == info.IdEmpresa && o.IdProducto == info.IdProducto);
                    if (address != null)
                    {
                        address.IdUsuarioUltAnu = info.IdUsuarioUltAnu;
                        address.Fecha_UltAnu = DateTime.Now;
                        address.pr_motivoAnulacion = info.pr_motivoAnulacion;
                        address.Estado = "I";
                        address.ip = info.ip;
                        address.nom_pc = info.nom_pc;
                        Base.SaveChanges();
                        resultado = true;
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                mensaje = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                throw new Exception(ex.InnerException.ToString());
            }
        }


        public List<in_Producto_CG_Info> Get_list(int IdEmpresa, ref string mensaje)
        {
            try
            {
                List<in_Producto_CG_Info> lista = new List<in_Producto_CG_Info>();



                Entities_Inventario_CG Base = new Entities_Inventario_CG();
                var Select = from q in Base.in_Producto_CG
                             where q.IdEmpresa == IdEmpresa
                             select q;
                if (Select != null)
                {
                    foreach (var item in Select)
                    {
                        in_Producto_CG_Info Info = new in_Producto_CG_Info();
                        Info.IdEmpresa = item.IdEmpresa;
                        Info.IdProducto = item.IdProducto;
                        Info.med_cod_anatofarmacologico = item.med_cod_anatofarmacologico;
                        Info.med_cod_forma_farmacologica = item.med_cod_forma_farmacologica;
                        Info.med_cod_principio_activo = item.med_cod_principio_activo;
                        Info.med_sw_farmacovigilancia = item.med_sw_farmacovigilancia;
                        Info.med_descripcion_alerta = item.med_descripcion_alerta;
                        Info.med_sw_alimento_parenteral = item.med_sw_alimento_parenteral;
                        Info.med_sw_alimento_enteral = item.med_sw_alimento_enteral;
                        Info.med_sw_manejo_luz = item.med_sw_manejo_luz;
                        Info.codigo_alterno = item.codigo_alterno;
                        Info.codigo_alterno = item.codigo_alterno;
                        Info.codigo_cnmb = item.codigo_cnmb;
                        Info.contenido_unidad_venta = item.contenido_unidad_venta;
                        Info.sw_control_fecha_vencimiento = item.sw_control_fecha_vencimiento;
                        Info.sw_generico = item.sw_generico;
                        Info.sw_pos = item.sw_pos;
                        Info.sw_solicita_autorizacion = item.sw_solicita_autorizacion;
                        Info.sw_venta_directa = item.sw_venta_directa;
                        Info.Estado = item.Estado;
                        lista.Add(Info);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                mensaje = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public in_Producto_CG_Info Get_Info(int IdEmpresa, decimal idproducto)
        {
            try
            {
                in_Producto_CG_Info Info = new in_Producto_CG_Info();
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    var address = Base.in_Producto_CG.FirstOrDefault(o => o.IdEmpresa == IdEmpresa && o.IdProducto == idproducto);
                    if (address != null)
                    {
                        Info.IdProducto = address.IdProducto;
                        Info.med_cod_anatofarmacologico = address.med_cod_anatofarmacologico;
                        Info.med_cod_forma_farmacologica = address.med_cod_forma_farmacologica;
                        Info.med_cod_principio_activo = address.med_cod_principio_activo;
                        Info.med_sw_farmacovigilancia = address.med_sw_farmacovigilancia;
                        Info.med_descripcion_alerta = address.med_descripcion_alerta;
                        Info.med_sw_alimento_parenteral = address.med_sw_alimento_parenteral;
                        Info.med_sw_alimento_enteral = address.med_sw_alimento_enteral;
                        Info.med_sw_manejo_luz = address.med_sw_manejo_luz;
                        Info.codigo_alterno = address.codigo_alterno;
                        Info.codigo_alterno = address.codigo_alterno;
                        Info.codigo_cnmb = address.codigo_cnmb;
                        Info.contenido_unidad_venta = address.contenido_unidad_venta;
                        Info.sw_control_fecha_vencimiento = address.sw_control_fecha_vencimiento;
                        Info.sw_generico = address.sw_generico;
                        Info.sw_pos = address.sw_pos;
                        Info.sw_solicita_autorizacion = address.sw_solicita_autorizacion;
                        Info.sw_venta_directa = address.sw_venta_directa;
                        Info.Estado = address.Estado;
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

        #endregion
    }
}
