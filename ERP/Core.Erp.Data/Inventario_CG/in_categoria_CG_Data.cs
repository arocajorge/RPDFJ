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
    public class in_categoria_CG_Data
    {
        #region "Insertar, Actualizar, Eliminar"
        public bool GrabarDB(in_categoria_CG_Info info, ref string mensaje)
        {
            try
            {
                bool resultado = false;
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    in_categoria_CG address = new in_categoria_CG();
                    address.IdEmpresa = info.IdEmpresa;
                    address.IdCategoria = info.IdCategoria;
                    address.sw_formulacion = info.sw_formulacion;
                    address.sw_insumos = info.sw_insumos;
                    address.sw_medicamento = info.sw_medicamento;
                    address.sw_vende = info.sw_vende;
                    address.Estado = "A";
                    address.IdUsuario = info.IdUsuario;
                    address.Fecha_Transac = DateTime.Now;
                    address.ip = info.ip;
                    address.nom_pc = info.nom_pc;
                    Base.in_categoria_CG.Add(address);
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

        public bool ActualizarDB(in_categoria_CG_Info info, ref string mensaje)
        {
            try
            {

                bool resultado = false;
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    var address = Base.in_categoria_CG.FirstOrDefault(o => o.IdEmpresa == info.IdEmpresa && o.IdCategoria == info.IdCategoria);
                    if (address != null)
                    {

                        address.sw_formulacion = info.sw_formulacion;
                        address.sw_insumos = info.sw_insumos;
                        address.sw_medicamento = info.sw_medicamento;
                        address.sw_vende = info.sw_vende;
                        address.IdUsuarioUltMod = info.IdUsuarioUltMod;
                        address.Fecha_UltMod = DateTime.Now;
                        address.ip = info.ip;
                        address.nom_pc = info.nom_pc;
                        Base.SaveChanges();
                        resultado = true;
                    }
                    else
                        resultado = GrabarDB(info, ref mensaje);
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

        public bool AnularDB(in_categoria_CG_Info info, ref string mensaje)
        {
            try
            {

                bool resultado = false;
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    var address = Base.in_categoria_CG.FirstOrDefault(o => o.IdEmpresa == info.IdEmpresa && o.IdCategoria == info.IdCategoria);
                    if (address != null)
                    {
                        address.IdUsuarioUltAnu = info.IdUsuarioUltAnu;
                        address.Fecha_UltAnu = DateTime.Now;
                        address.MotiAnula = info.MotiAnula;
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


        public List<in_categoria_CG_Info> Get_list(int IdEmpresa, ref string mensaje)
        {
            try
            {
                List<in_categoria_CG_Info> lista = new List<in_categoria_CG_Info>();



                Entities_Inventario_CG Base = new Entities_Inventario_CG();
                var Select = from q in Base.in_categoria_CG
                             where q.IdEmpresa == IdEmpresa
                             select q;
                if (Select != null)
                {
                    foreach (var item in Select)
                    {
                        in_categoria_CG_Info Info = new in_categoria_CG_Info();
                        Info.IdEmpresa = item.IdEmpresa;
                        Info.IdCategoria = item.IdCategoria;
                        Info.sw_formulacion = item.sw_formulacion;
                        Info.sw_insumos = item.sw_insumos;
                        Info.sw_medicamento = item.sw_medicamento;
                        Info.sw_vende = item.sw_vende;
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

        public in_categoria_CG_Info Get_Info(int IdEmpresa, string categoria)
        {
            try
            {
                in_categoria_CG_Info Info = new in_categoria_CG_Info();
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    var address = Base.in_categoria_CG.FirstOrDefault(o => o.IdEmpresa == IdEmpresa && o.IdCategoria == categoria);
                    if (address != null)
                    {
                        Info.IdCategoria = address.IdCategoria;
                        Info.sw_formulacion = address.sw_formulacion;
                        Info.sw_insumos = address.sw_insumos;
                        Info.sw_medicamento = address.sw_medicamento;
                        Info.sw_vende = address.sw_vende;
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


        public Boolean es_medicina (int IdEmpresa, string idcategoria)
        {
            try
            {
                Boolean Existe = false;
                using (Entities_Inventario_CG Base = new Entities_Inventario_CG())
                {
                    var address = Base.in_categoria_CG.FirstOrDefault(o => o.IdEmpresa == IdEmpresa && o.IdCategoria == idcategoria);
                    if (address != null)
                    {
                     if(address.sw_medicamento == true)
                     {
                           Existe = true;
                     }
                    }
                }
                return Existe;
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
