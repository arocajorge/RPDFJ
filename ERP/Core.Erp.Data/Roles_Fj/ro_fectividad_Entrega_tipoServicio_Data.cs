using Core.Erp.Data.General;
using Core.Erp.Info.General;
using Core.Erp.Info.Roles_Fj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Roles_Fj
{
  public  class ro_fectividad_Entrega_tipoServicio_Data
    {
        string mensaje = "";

        public List<ro_fectividad_Entrega_tipoServicio_Info> Get_List(int IdEmpresa)
        {
            List<ro_fectividad_Entrega_tipoServicio_Info> list_Ruta = new List<ro_fectividad_Entrega_tipoServicio_Info>();
            try
            {
                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {
                    var contact = from q in Context.ro_fectividad_Entrega_tipoServicio
                                  where q.IdEmpresa == IdEmpresa
                                  select q;

                    foreach (var item in contact)
                    {
                        ro_fectividad_Entrega_tipoServicio_Info Info = new ro_fectividad_Entrega_tipoServicio_Info();
                        Info.IdEmpresa = item.IdEmpresa;
                        Info.IdServicio = item.IdServicio;
                        Info.ts_Descripcion = item.ts_Descripcion;
                        Info.Estado = item.Estado;
                        Info.IdUsuario = item.IdUsuario;
                        Info.Fecha_Transaccion = item.Fecha_Transaccion;
                        Info.IdUsuarioUltModi = item.IdUsuarioUltModi;
                        Info.Fecha_UltMod = item.Fecha_UltMod;
                        Info.IdUsuarioUltAnu = item.IdUsuarioUltAnu;
                        Info.Fecha_UltAnu = item.Fecha_UltAnu;
                        list_Ruta.Add(Info);
                    }
                }
                return list_Ruta;
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString() + " " + ex.Message;
                throw new Exception(ex.ToString());
            }
        }
    
        public ro_fectividad_Entrega_tipoServicio_Info Get_Info(int IdEmpresa, int IdServicio)
        {
            try
            {
                ro_fectividad_Entrega_tipoServicio_Info Info = new ro_fectividad_Entrega_tipoServicio_Info();
                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {
                    var contact = from q in Context.ro_fectividad_Entrega_tipoServicio
                                  where q.IdEmpresa == IdEmpresa
                                  && q.IdServicio == IdServicio
                                  select q;

                    foreach (var item in contact)
                    {
                        Info.IdEmpresa = item.IdEmpresa;
                        Info.IdServicio = item.IdServicio;
                        Info.ts_Descripcion = item.ts_Descripcion;
                        Info.Estado = item.Estado;
                        Info.IdUsuario = item.IdUsuario;
                        Info.Fecha_Transaccion = item.Fecha_Transaccion;
                        Info.IdUsuarioUltModi = item.IdUsuarioUltModi;
                        Info.Fecha_UltMod = item.Fecha_UltMod;
                        Info.IdUsuarioUltAnu = item.IdUsuarioUltAnu;
                        Info.Fecha_UltAnu = item.Fecha_UltAnu;
                    }
                }
                return Info;
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString() + " " + ex.Message;
                throw new Exception(ex.ToString());
            }
        }

        public int Get_Id(int IdEmpresa, ref string mensaje)
        {
            try
            {
                int Id;
                EntityRoles_FJ db = new EntityRoles_FJ();
                var selecte = db.ro_fectividad_Entrega_tipoServicio.Count(q => q.IdEmpresa == IdEmpresa);
                if (selecte == 0)
                {
                    Id = 1;
                }
                else
                {
                    var select_em = (from q in db.ro_fectividad_Entrega_tipoServicio
                                     where q.IdEmpresa == IdEmpresa
                                     select q.IdServicio).Max();
                    Id = Convert.ToInt32(select_em.ToString()) + 1;
                }
                return Id;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString();
                throw new Exception(ex.ToString());
            }
        }

        public bool GuardarDB(ro_fectividad_Entrega_tipoServicio_Info Info, ref int IdServicio, ref string mensaje)
        {
            try
            {
                IdServicio = Get_Id(Info.IdEmpresa, ref mensaje);

                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {
                    ro_fectividad_Entrega_tipoServicio contact = new ro_fectividad_Entrega_tipoServicio();

                    contact.IdEmpresa = Info.IdEmpresa;
                    contact.IdServicio = Info.IdServicio = IdServicio;
                    contact.ts_Descripcion = Info.ts_Descripcion;
                    contact.ts_codigo = Info.ts_codigo;
                    contact.Estado = Info.Estado;
                    contact.IdUsuario = Info.IdUsuario;
                    contact.Fecha_Transaccion = Info.Fecha_Transaccion;

                    Context.ro_fectividad_Entrega_tipoServicio.Add(contact);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString();
                throw new Exception(ex.ToString());
            }
        }

        public bool ModificarDB(ro_fectividad_Entrega_tipoServicio_Info Info, ref string mensaje)
        {
            try
            {
                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {
                    ro_fectividad_Entrega_tipoServicio contact = Context.ro_fectividad_Entrega_tipoServicio.FirstOrDefault(q => q.IdEmpresa == Info.IdEmpresa && q.IdServicio == Info.IdServicio);
                    if (contact != null)
                    {
                        contact.ts_Descripcion = Info.ts_Descripcion;
                        contact.ts_codigo = Info.ts_codigo;
                        contact.IdUsuarioUltModi = Info.IdUsuarioUltModi;
                        contact.Fecha_UltMod = DateTime.Now;
                        Context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString();
                throw new Exception(ex.ToString());
            }
        }

        public bool AnularDB(ro_fectividad_Entrega_tipoServicio_Info Info, ref string mensaje)
        {
            try
            {
                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {
                    ro_fectividad_Entrega_tipoServicio contact = Context.ro_fectividad_Entrega_tipoServicio.FirstOrDefault(q => q.IdEmpresa == Info.IdEmpresa && q.IdServicio == Info.IdServicio);
                    if (contact != null)
                    {
                        contact.IdUsuarioUltAnu = Info.IdUsuarioUltAnu;
                        contact.Fecha_UltAnu = Info.Fecha_UltAnu;
                        contact.Estado = false;
                        Context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString();
                throw new Exception(ex.ToString());
            }
        }
    }
}
