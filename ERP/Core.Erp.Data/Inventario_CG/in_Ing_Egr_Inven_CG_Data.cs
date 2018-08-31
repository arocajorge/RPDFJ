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
    public class in_Ing_Egr_Inven_CG_Data
    {
        #region "Insertar, Actualizar, Eliminar"
        public bool GrabarDB(in_Ing_Egr_Inven_CG_Info info, ref string mensaje)
        {
            try
            {
                bool resultado = false;
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    in_Ing_Egr_Inven_CG address = new in_Ing_Egr_Inven_CG();
                    address.IdEmpresa = info.IdEmpresa;
                    address.IdSucursal = info.IdSucursal;
                    address.IdCuenta = info.IdCuenta;
                    address.IdIngreso = info.IdIngreso;
                    address.IdMovi_inven_tipo = info.IdMovi_inven_tipo;
                    address.IdNumMovi = info.IdNumMovi;
                    address.Estado = "A";
                    address.IdUsuarioCreacion = info.IdUsuarioCreacion;
                    address.Fecha_Transac = DateTime.Now;
                    address.ip = info.ip;
                    address.nom_pc = info.nom_pc;
                    Base.in_Ing_Egr_Inven_CG.Add(address);
                    Base.SaveChanges();
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                //string MensajeError = string.Empty;
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                mensaje = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public bool ActualizarDB(in_Ing_Egr_Inven_CG_Info info)
        {
            try
            {

                bool resultado = false;
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    var address = Base.in_Ing_Egr_Inven_CG.FirstOrDefault(o => o.IdEmpresa == info.IdEmpresa && o.IdSucursal == info.IdSucursal 
                        && o.IdMovi_inven_tipo == info.IdMovi_inven_tipo && o.IdNumMovi == info.IdNumMovi);
                    if (address != null)
                    {
                        address.IdCuenta = info.IdCuenta;
                        address.IdIngreso = info.IdIngreso;
                        address.IdUsuarioUltModi = info.IdUsuarioUltModi;
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
                string MensajeError = string.Empty;
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                MensajeError = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public bool AnularDB(in_Ing_Egr_Inven_CG_Info info)
        {
            try
            {

                bool resultado = false;
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    var address = Base.in_Ing_Egr_Inven_CG.FirstOrDefault(o => o.IdEmpresa == info.IdEmpresa && o.IdSucursal == info.IdSucursal
                        && o.IdMovi_inven_tipo == info.IdMovi_inven_tipo && o.IdNumMovi == info.IdNumMovi);
                    if (address != null)
                    {
                        address.IdusuarioUltAnu = info.IdusuarioUltAnu;
                        address.Fecha_UltAnu = DateTime.Now;
                        address.MotivoAnulacion = info.MotivoAnulacion;
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
                string MensajeError = string.Empty;
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                MensajeError = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                throw new Exception(ex.InnerException.ToString());
            }
        }


        public List<in_Ing_Egr_Inven_CG_Info> Get_list(int IdEmpresa)
        {
            try
            {
                List<in_Ing_Egr_Inven_CG_Info> lista = new List<in_Ing_Egr_Inven_CG_Info>();



                Entities_Inventario_CG Base = new Entities_Inventario_CG();
                var Select = from q in Base.in_Ing_Egr_Inven_CG
                             where q.IdEmpresa == IdEmpresa
                             select q;
                if (Select != null)
                {
                    foreach (var item in Select)
                    {
                        in_Ing_Egr_Inven_CG_Info Info = new in_Ing_Egr_Inven_CG_Info();
                        Info.IdEmpresa = item.IdEmpresa;
                        Info.IdSucursal = item.IdSucursal;
                        Info.IdMovi_inven_tipo = item.IdMovi_inven_tipo;
                        Info.IdNumMovi = item.IdNumMovi;
                        Info.IdCuenta = item.IdCuenta;
                        Info.IdIngreso = item.IdIngreso;                        
                        Info.Estado = item.Estado;
                        lista.Add(Info);
                    }
                }
                return lista;
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

        public in_Ing_Egr_Inven_CG_Info Get_Info(int IdEmpresa, decimal IdNumMovi)
        {
            try
            {
                in_Ing_Egr_Inven_CG_Info Info = new in_Ing_Egr_Inven_CG_Info();
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG()) 
                {
                    var address = Base.in_Ing_Egr_Inven_CG.FirstOrDefault(o => o.IdEmpresa == IdEmpresa && o.IdNumMovi == IdNumMovi);
                    if (address != null)
                    {
                        Info.IdCuenta = address.IdCuenta;
                        Info.IdIngreso = address.IdIngreso; 
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
