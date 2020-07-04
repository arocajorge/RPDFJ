
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Erp.Info.Roles;
using Core.Erp.Info.General;
using Core.Erp.Data.General;
using IExcel = Microsoft.Office.Interop.Excel;
using System.Data.Entity.Validation;
using Core.Erp.Data.Roles_Fj;
namespace Core.Erp.Data.Roles
{
    public class ro_permiso_x_empleado_Data
    {
        string mensaje = "";
        ro_Empleado_Novedad_Data odata_novedad = new ro_Empleado_Novedad_Data();
        ro_rubros_calculados_Data odata_calculados = new ro_rubros_calculados_Data();
        public List<ro_permiso_x_empleado_Info> ConsultaGeneral(int IdEmpresa, DateTime Fecha_inicio, DateTime Fecha_Fin)
        {   
            List<ro_permiso_x_empleado_Info> lst = new List<ro_permiso_x_empleado_Info>();
            try
            {
                Fecha_inicio = Convert.ToDateTime(Fecha_inicio.ToShortDateString());
                Fecha_Fin = Convert.ToDateTime(Fecha_Fin.ToShortDateString());

                using (EntitiesRoles Gene = new EntitiesRoles())
                {                    
                    var cons = from q in Gene.vwRo_Permiso_x_Empleado
                               where q.IdEmpresa == IdEmpresa  
                               &&q.FechaSalida>=Fecha_inicio
                               &&q.FechaSalida<=Fecha_Fin
                               orderby q.IdPermiso descending
                               select q;
                    foreach (var item in cons)
                    {
                        ro_permiso_x_empleado_Info info = new ro_permiso_x_empleado_Info();
                        ro_Empleado_Info InfoEmpleado = new ro_Empleado_Info();
                        info.IdEmpresa = item.IdEmpresa;
                        info.IdPermiso = item.IdPermiso;
                        info.Fecha = item.Fecha;
                        info.IdEmpleado = item.IdEmpleado;
                        info.MotivoAusencia = item.MotivoAusencia;
                        info.TiempoAusencia = item.TiempoAusencia;
                        info.FormaRecuperacion = item.FormaRecuperacion;
                        info.IdEmpleado_Soli = item.IdEmpleado_Soli;
                        info.IdEstadoAprob = item.IdEstadoAprob;
                        info.IdEmpleado_Apro = item.IdEmpleado_Apro;
                        info.MotivoAproba = item.MotivoAproba;
                        info.Observacion = item.Observacion;
                        info.Estado = item.Estado;
                        info.pe_nombre = item.pe_apellido + " " + item.pe_nombre;
                        info.em_codigo = item.em_codigo;
                        info.pe_cedulaRuc = item.pe_cedulaRuc;
                        info.IdTipoLicencia = item.IdTipoLicencia;
                        info.EsLicencia = item.EsLicencia;
                        info.EsPermiso = item.EsPermiso;
                        info.FechaEntrada = item.FechaEntrada;
                        info.FechaSalida = item.FechaSalida;
                        info.ca_descripcion = item.ca_descripcion;
                        info.de_descripcion = item.de_descripcion;
                        info.pe_cedulaRuc = item.pe_cedulaRuc;
                        info.NomEmpleado = item.NomEmpleado;
                        info.DiasPermiso = item.DiasPermiso;
                        info.Id_Forma_descuento_permiso_Cat = item.Id_Forma_descuento_permiso_Cat;
                        lst.Add(info);
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.InnerException + " " + ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }
        public List<ro_permiso_x_empleado_Info> GetListLicenciaPorEmpleado(int IdEmpresa, int idEmpleado, DateTime fecha_I,DateTime fecha_F)
        {
            List<ro_permiso_x_empleado_Info> lst = new List<ro_permiso_x_empleado_Info>();
            try
            {
                // ARREGLAR CARLOS

                using (EntitiesRoles Gene = new EntitiesRoles())
                {
                    var cons = from q in Gene.ro_permiso_x_empleado
                               where q.IdEmpresa==IdEmpresa
                               && q.IdEmpleado==idEmpleado
                               && q.IdTipoLicencia == "143"
                               && q.Estado=="A"
                               select q;
                    foreach (var item in cons)
                    {
                        ro_permiso_x_empleado_Info info = new ro_permiso_x_empleado_Info();
                        info.FechaEntrada = item.FechaEntrada;
                        info.FechaSalida = item.FechaSalida;
                        lst.Add(info);
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.InnerException + " " + ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }
        public decimal GetId(int idEmpresa) {
            try
            {
                decimal Id;
                EntitiesRoles db = new EntitiesRoles();

                var datos = (from a in db.ro_permiso_x_empleado
                             where a.IdEmpresa == idEmpresa
                             select a);
                if (datos.ToList().Count == 0)
                    return 1;
                else
                {
                    var select_ = (from a in db.ro_permiso_x_empleado
                                   where a.IdEmpresa == idEmpresa
                                   select a.IdPermiso).Max();
                    Id = Convert.ToInt32(select_.ToString()) + 1;
                    return Id;
                }
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.InnerException + " " + ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }        
        }
        public Boolean GuardarDB(ro_permiso_x_empleado_Info info, ref decimal id, ref string msg)
        {
            try
            {
                var calculado = odata_calculados.get_info(info.IdEmpresa);
                if (calculado == null)
                    return false;

                ro_Empleado_TipoNomina_Data odata_emp_nomi = new ro_Empleado_TipoNomina_Data();
                var info_emp_nom = odata_emp_nomi.Get_Info_Empleado_TipoNomina(info.IdEmpresa, info.IdEmpleado);
                if (info_emp_nom == null)
                    return false;
                info.IdNomina_Tipo = info_emp_nom.IdNomina_Tipo;

                    using (EntitiesRoles db = new EntitiesRoles())
                    {
   
                        ro_permiso_x_empleado data = new ro_permiso_x_empleado();                        
                        data.IdPermiso = info.IdPermiso =GetId(info.IdEmpresa);
                        data.IdEmpresa = info.IdEmpresa;
                        data.IdNomina_Tipo = info.IdNomina_Tipo;
                        data.Fecha = Convert.ToDateTime(info.Fecha);
                        data.IdEmpleado = info.IdEmpleado;
                        data.MotivoAusencia = info.MotivoAusencia;                       
                        data.TiempoAusencia = info.TiempoAusencia;
                        info.FormaRecuperacion = (info.FormaRecuperacion == null) ? "" : info.FormaRecuperacion;
                        data.IdEmpleado_Soli = info.IdEmpleado_Soli;
                        data.IdEstadoAprob = info.IdEstadoAprob="APRO";
                        data.IdEmpleado_Apro = info.IdEmpleado_Apro;
                        data.MotivoAproba = info.MotivoAproba;
                        data.Observacion = info.Observacion;
                        data.IdTipoLicencia = info.IdTipoLicencia;
                        data.EsLicencia = info.EsLicencia;
                        data.EsPermiso = info.EsPermiso;
                        data.FechaEntrada =Convert.ToDateTime( Convert.ToDateTime( info.FechaEntrada).ToShortDateString());
                        data.FechaSalida = Convert.ToDateTime(Convert.ToDateTime(info.FechaSalida).ToShortDateString());
                        data.HoraSalida = info.HoraSalida;
                        data.HoraRegreso = info.HoraRegreso;
                        data.Estado = info.Estado;
                        data.IdUsuario = info.IdUsuario;
                        data.Fecha_Transac = info.Fecha_Transac;
                        data.ip = info.ip;
                        data.Id_Forma_descuento_permiso_Cat = info.Id_Forma_descuento_permiso_Cat;
                        data.FormaRecuperacion = info.FormaRecuperacion = "";
                        db.ro_permiso_x_empleado.Add(data);
                        id = info.IdPermiso;
                        if (info.lst_novedad != null)
                        {
                            if (info.lst_novedad.Count > 0)
                            {
                                var info_nov = info.lst_novedad.FirstOrDefault();
                                db.ro_empleado_Novedad.Add(new ro_empleado_Novedad
                                {
                                    IdNovedad = info_nov.IdNovedad = odata_novedad.GetIdNovedad(info.IdEmpresa,info.IdEmpleado),
                                    IdEmpresa = info.IdEmpresa,
                                    IdEmpleado = info.IdEmpleado,
                                    TotalValor = info.lst_novedad.Sum(v=>v.Valor),
                                    Fecha =Convert.ToDateTime( info.FechaSalida),
                                    IdNomina_Tipo = info.IdNomina_Tipo,
                                    IdNomina_TipoLiqui = info_nov.IdNominaLiqui,
                                    IdUsuario = info.IdUsuario,
                                    Fecha_Transac = DateTime.Now,
                                    nom_pc = info.nom_pc,
                                    ip = info.ip,
                                    Estado = info.Estado,
                                });
                                int secuencia = 1;
                                foreach (var item in info.lst_novedad)
                                {
                                    db.ro_empleado_novedad_det.Add(new ro_empleado_novedad_det
                                    {
                                        IdEmpresa = info.IdEmpresa,
                                        IdNovedad = info_nov.IdNovedad,
                                        IdEmpleado = info.IdEmpleado,
                                        Secuencia = item.Secuencia=secuencia,
                                        FechaPago = item.FechaPago,
                                        Valor = item.Valor,
                                        EstadoCobro = "PEN",
                                        Estado = "A",
                                        Observacion = item.Observacion,
                                        IdRubro = calculado.IdRubro_descuento_permiso,
                                        IdCalendario = item.IdCalendario,
                                        Num_Horas = item.NumHoras,
                                        IdNomina_tipo = info.IdNomina_Tipo,
                                        IdNomina_Tipo_Liq = item.IdNominaLiqui,
                                        });
                                    secuencia++;
                                }
                                db.ro_permiso_x_empleado_x_novedad.Add(new ro_permiso_x_empleado_x_novedad
                                {
                                  IdEmpresa=info.IdEmpresa,
                                  IdEmpleado=info.IdEmpleado,
                                  IdPermiso=info.IdPermiso,
                                  IdEmpresa_nov=info.IdEmpresa,
                                  IdEmpleado_nov=info.IdEmpleado,
                                  IdNomina_Tipo=info.IdNomina_Tipo,
                                  IdNovedad = info_nov.IdNovedad,
                                  Observacion=info.Observacion,
                                  
                                });
                            }
                        }
                        db.SaveChanges();

                        string sql = "update Fj_servindustrias.ro_marcaciones_x_empleado_x_incidentes_falt_Perm set id_catalogo_Cat='PER' where IdEmpresa='" + info.IdEmpresa + "' and IdEmpleado='" + info.IdEmpleado + "' and es_fecha_registro between '" + Convert.ToDateTime(info.FechaSalida).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(info.FechaEntrada).ToString("yyyy-MM-dd") + "'";
                        db.Database.ExecuteSqlCommand(sql);
                    }

                    



                return true;
            }
            catch (DbEntityValidationException ex)
            {
                
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.InnerException + " " + ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }
        public Boolean ModificarDB(ro_permiso_x_empleado_Info info, ref string msg)
        {
            try
            {
                DateTime FechaSalida;
                DateTime FechaEntrada;
                var calculado = odata_calculados.get_info(info.IdEmpresa);
                if (calculado == null)
                    return false;
                  int secuencia = 1;
                ro_Empleado_TipoNomina_Data odata_emp_nomi=new ro_Empleado_TipoNomina_Data();

                var info_emp_nom = odata_emp_nomi.Get_Info_Empleado_TipoNomina(info.IdEmpresa, info.IdEmpleado);
                if (info_emp_nom == null)
                    return false;
                info.IdNomina_Tipo = info_emp_nom.IdNomina_Tipo;

                using (EntitiesRoles db = new EntitiesRoles())
                {

                      ro_permiso_x_empleado data = db.ro_permiso_x_empleado.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdPermiso == info.IdPermiso).FirstOrDefault();


                    if (data == null)
                        return false;

                     ro_permiso_x_empleado_x_novedad data_nov = db.ro_permiso_x_empleado_x_novedad.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdPermiso == info.IdPermiso).FirstOrDefault();



                    FechaSalida =Convert.ToDateTime( data.FechaSalida);
                    FechaEntrada = Convert.ToDateTime(data.FechaEntrada);

                    #region permiso
                    data.Fecha = Convert.ToDateTime(info.Fecha);
                    data.MotivoAusencia = info.MotivoAusencia;
                    data.TiempoAusencia = info.TiempoAusencia;
                    data.FormaRecuperacion = info.FormaRecuperacion;
                    data.IdEmpleado_Soli = info.IdEmpleado_Soli;
                    data.IdEstadoAprob = info.IdEstadoAprob;
                    data.IdEmpleado_Apro = info.IdEmpleado_Apro;
                    data.MotivoAproba = info.MotivoAproba;
                    data.Observacion = info.Observacion;
                    data.Fecha_UltMod = info.Fecha_Transac;
                    data.IdUsuarioUltMod = info.IdUsuarioUltMod;
                    data.IdTipoLicencia = info.IdTipoLicencia;
                    data.EsLicencia = info.EsLicencia;
                    data.EsPermiso = info.EsPermiso;
                    data.FechaEntrada = Convert.ToDateTime(Convert.ToDateTime(info.FechaEntrada).ToShortDateString());
                    data.FechaSalida = Convert.ToDateTime(Convert.ToDateTime(info.FechaSalida).ToShortDateString());
                    data.HoraSalida = info.HoraSalida;
                    data.HoraRegreso = info.HoraRegreso;
                    data.Id_Forma_descuento_permiso_Cat = info.Id_Forma_descuento_permiso_Cat;
                    #endregion
                    #region novedad
                    if (info.lst_novedad != null)
                    {
                        if (info.lst_novedad.Count > 0)
                        {
                            var info_novedad = info.lst_novedad.FirstOrDefault();
                            if (data_nov == null)
                            {
                                db.ro_empleado_Novedad.Add(new ro_empleado_Novedad
                                {
                                    IdNovedad =info_novedad.IdNovedad=  odata_novedad.GetIdNovedad(info.IdEmpresa, info.IdEmpleado),
                                    IdEmpresa = info.IdEmpresa,
                                    IdEmpleado = info.IdEmpleado,
                                    TotalValor = info.lst_novedad.Sum(v => v.Valor),
                                    Fecha = Convert.ToDateTime(info.FechaSalida),
                                    IdNomina_Tipo = info.IdNomina_Tipo,
                                    IdNomina_TipoLiqui = info_novedad.IdNominaLiqui,
                                    IdUsuario = info.IdUsuario,
                                    Fecha_Transac = DateTime.Now,
                                    nom_pc = info.nom_pc,
                                    ip = info.ip,
                                    Estado = info.Estado,
                                });
                                foreach (var item in info.lst_novedad)
                                {
                                    db.ro_empleado_novedad_det.Add(new ro_empleado_novedad_det
                                    {
                                        IdEmpresa = info.IdEmpresa,
                                        IdNovedad = info_novedad.IdNovedad,
                                        IdEmpleado = info.IdEmpleado,
                                        Secuencia = item.Secuencia=secuencia,
                                        FechaPago = item.FechaPago,
                                        Valor = item.Valor,
                                        EstadoCobro = "PEN",
                                        Estado = "A",
                                        Observacion = item.Observacion,
                                        IdRubro = calculado.IdRubro_descuento_permiso,
                                        IdCalendario = item.IdCalendario,
                                        Num_Horas = item.NumHoras,
                                        IdNomina_tipo = info.IdNomina_Tipo,
                                        IdNomina_Tipo_Liq = item.IdNominaLiqui,
                                    });
                                    secuencia++;
                                }

                                db.ro_permiso_x_empleado_x_novedad.Add(new ro_permiso_x_empleado_x_novedad
                                {
                                    IdEmpresa = info.IdEmpresa,
                                    IdNomina_Tipo = info.IdNomina_Tipo,
                                    IdEmpleado = info.IdEmpleado,
                                    IdPermiso = info.IdPermiso,

                                    IdEmpresa_nov = info.IdEmpresa,
                                    IdEmpleado_nov = info.IdEmpleado,                                   
                                    IdNovedad = info_novedad.IdNovedad,
                                    Observacion = info.Observacion
                                    
                                });
                            }
                            else
                            {
                                var nov_det=db.ro_empleado_novedad_det.Where(v=>v.IdEmpresa==info.IdEmpresa 
                                    && v.IdEmpleado==info.IdEmpleado
                                    && v.IdNovedad==data_nov.IdNovedad);
                                if(nov_det!=null)
                                foreach (var item in nov_det)
	                             {
		                                 db.ro_empleado_novedad_det.Remove(item);

	                             }
                                foreach (var item in info.lst_novedad)
                                {
                                    db.ro_empleado_novedad_det.Add(new ro_empleado_novedad_det
                                    {
                                        IdEmpresa = info.IdEmpresa,
                                        IdNovedad = data_nov.IdNovedad,
                                        IdEmpleado = data_nov.IdEmpleado,
                                        Secuencia = item.Secuencia = secuencia,
                                        FechaPago = item.FechaPago,
                                        Valor = item.Valor,
                                        EstadoCobro = "PEN",
                                        Estado = "A",
                                        Observacion = item.Observacion,
                                        IdRubro = calculado.IdRubro_descuento_permiso,
                                        IdCalendario = item.IdCalendario,
                                        Num_Horas = item.NumHoras,
                                        IdNomina_tipo = info.IdNomina_Tipo,
                                        IdNomina_Tipo_Liq = item.IdNominaLiqui,
                                      
                                    });
                                    secuencia++;
                                }
                            }
                            
                        }
                    }
                    #endregion
                    db.SaveChanges();
                    string sql = "update Fj_servindustrias.ro_marcaciones_x_empleado_x_incidentes_falt_Perm set id_catalogo_Cat='ASIST' where IdEmpresa='" + info.IdEmpresa + "' and IdEmpleado='" + info.IdEmpleado + "' and es_fecha_registro between '" + Convert.ToDateTime(FechaSalida).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(FechaEntrada).ToString("yyyy-MM-dd") + "'";
                    db.Database.ExecuteSqlCommand(sql);
                    sql = "update Fj_servindustrias.ro_marcaciones_x_empleado_x_incidentes_falt_Perm set id_catalogo_Cat='PER' where IdEmpresa='" + info.IdEmpresa + "' and IdEmpleado='" + info.IdEmpleado + "' and es_fecha_registro between '" + Convert.ToDateTime(info.FechaSalida).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(info.FechaEntrada).ToString("yyyy-MM-dd") + "'";
                    db.Database.ExecuteSqlCommand(sql);

                    
                }
                return true;
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.InnerException + " " + ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }
        public Boolean AnularDB(ro_permiso_x_empleado_Info info, ref string msg)
        {
            try
            {
                string sql = "";
                using (EntitiesRoles db = new EntitiesRoles())
                {

                    ro_permiso_x_empleado data = (from a in db.ro_permiso_x_empleado
                                                  where a.IdEmpresa == info.IdEmpresa && a.IdPermiso == info.IdPermiso
                                                  && a.IdEmpleado==info.IdEmpleado
                                                  select a).FirstOrDefault();

                    data.FechaAnulacion = info.FechaAnulacion;
                    data.IdUsuario_Anu = info.IdUsuario_Anu;
                    data.MotivoAnulacion = info.MotivoAnulacion;
                    data.Estado = "I";

                    ro_permiso_x_empleado_x_novedad data_nov = db.ro_permiso_x_empleado_x_novedad.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdPermiso == info.IdPermiso).FirstOrDefault();

                    if (data_nov != null)
                    {
                        var contact = db.ro_empleado_Novedad.First(minfo => minfo.IdEmpresa == info.IdEmpresa && minfo.IdNovedad == data_nov.IdNovedad && minfo.IdEmpleado == info.IdEmpleado);

                        if (contact != null)
                        {                           
                            contact.Estado = "I";
                            contact.MotiAnula = info.MotivoAnulacion;
                            contact.IdUsuarioUltAnu = info.IdUsuario_Anu;
                            contact.Fecha_UltAnu = info.FechaAnulacion;
                            sql = "update ro_empleado_novedad_det set estado='I' Where IdEmpresa='" + info.IdEmpresa + "'  and IdEmpleado='" + info.IdEmpleado + "'  and IdNovedad='" + contact.IdNovedad + "'";
                            db.Database.ExecuteSqlCommand(sql);

                        }
                        
                    }
                    


                    db.SaveChanges();

                    sql = "update Fj_servindustrias.ro_marcaciones_x_empleado_x_incidentes_falt_Perm set id_catalogo_Cat='ASIST' where IdEmpresa='" + info.IdEmpresa + "' and IdEmpleado='" + info.IdEmpleado + "' and es_fecha_registro between '" + Convert.ToDateTime(info.FechaSalida).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(info.FechaEntrada).ToString("yyyy-MM-dd") + "'";
                    db.Database.ExecuteSqlCommand(sql);

                }
                return true;
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.InnerException + " " + ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }
        public int MaxPermiso(int IdEmpresa)
        {
            try
            {
                using (EntitiesRoles rol = new EntitiesRoles())
                {
                    var numero =Convert.ToInt32(( from q in rol.ro_permiso_x_empleado
                                  where q.IdEmpresa == IdEmpresa
                                                     select q.IdPermiso).Max());
                    return numero;     
                }
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.InnerException + " " + ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }
        public Boolean GetExiste(ro_permiso_x_empleado_Info info, ref string msg)
        {
            try
            {
                Boolean valorRetornar = false;
                using (EntitiesRoles db = new EntitiesRoles())
                {
                    int cont = (from a in db.ro_permiso_x_empleado
                                where a.IdEmpresa == info.IdEmpresa && a.IdPermiso == info.IdPermiso
                                select a).Count();

                    if (cont > 0) { valorRetornar = true; }
                    else { valorRetornar = false; }
                }
                return valorRetornar;
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.InnerException + " " + ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }
        public ro_permiso_x_empleado_Info Get_Info_Dias_Permiso(int idempresa, int IdNomina_Tipo, int idempleado, DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                ro_permiso_x_empleado_Info info = new ro_permiso_x_empleado_Info();

                using (EntitiesRoles Gene = new EntitiesRoles())
                {
                    var cons = from q in Gene.ro_permiso_x_empleado
                               where q.IdEmpresa == idempresa
                               && q.IdEmpleado == idempleado
                               && q.IdTipoLicencia == "143"
                               && q.Estado == "A"

                                   && (
                                       (q.FechaSalida >= fechaIni && q.FechaEntrada <= fechaFin)
                                       || (q.FechaEntrada >= fechaIni && q.FechaEntrada <= fechaFin)
                                       || (q.FechaSalida <= fechaFin && q.FechaEntrada >= fechaFin
                                       )
                                     )
                               select q;
                    foreach (var item in cons)
                    {
                        info.FechaEntrada = item.FechaEntrada;
                        info.FechaSalida = item.FechaSalida;
                    }
                }
                return info;
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.InnerException + " " + ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }
        public int Get_Dias_Permiso(int idempresa, int IdNomina_Tipo, int idempleado, DateTime fechaIni, DateTime fechaFin)
        {
            try
            {

                using (EntitiesRoles Gene = new EntitiesRoles())
                {
                    var cons = from q in Gene.ro_permiso_x_empleado
                               where q.IdEmpresa == idempresa
                               && q.IdEmpleado == idempleado
                               && q.IdTipoLicencia == "143"
                               && q.Estado == "A"
                               && q.FechaEntrada >= fechaFin
                                  
                                     
                               select q;
                    if (cons.Count() > 0)
                        return cons.Count();
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.InnerException + " " + ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public List<ro_Empleado_Novedad_Det_Info> get_novedad(int IdEmpresa, decimal IdEmpleado, decimal IdPermiso)
        {
            try
            {
              List<ro_Empleado_Novedad_Det_Info>  lista = new List<ro_Empleado_Novedad_Det_Info>();


                EntitiesRoles ORol = new EntitiesRoles();

                lista = (from item in ORol.vwro_permiso_x_empleado_x_novedad
                         where item.IdEmpresa == IdEmpresa
                              && item.IdEmpleado == IdEmpleado
                              && item.IdPermiso == IdPermiso
                              select new 
                              ro_Empleado_Novedad_Det_Info
                              {

                                   
                                    FechaPago = item.FechaPago,
                                    Valor = item.Valor,
                                    Secuencia = item.Secuencia,
                                    IdNominaLiqui= (int)item.IdNomina_Tipo_Liq,
                                    IdNomina=item.IdNomina_Tipo
                              }).ToList();

               
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
    }
}
