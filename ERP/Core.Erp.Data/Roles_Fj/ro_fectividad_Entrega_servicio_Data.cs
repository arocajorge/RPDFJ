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
   public class ro_fectividad_Entrega_servicio_Data
    {

        string MensajeError = "";
        tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
        public List<ro_fectividad_Entrega_servicio_Info> listado_Grupos(int IdEmpresa, DateTime Fecha_Inicio, DateTime Fecha_fin)
        {
            try
            {
                List<ro_fectividad_Entrega_servicio_Info> lista = new List<ro_fectividad_Entrega_servicio_Info>();
                using (EntityRoles_FJ db = new EntityRoles_FJ())
                {
                    lista = (from q in db.vwro_fectividad_Entrega_servicio
                             where
                             q.IdEmpresa == IdEmpresa
                             && q.pe_FechaIni >= Fecha_Inicio
                             && q.pe_FechaIni <= Fecha_fin
                             select new ro_fectividad_Entrega_servicio_Info
                             {
                                 IdEmpresa = q.IdEmpresa,
                                IdNomina_Tipo = q.IdNomina_Tipo,
                                IdNomina_tipo_Liq = q.IdNomina_tipo_Liq,
                                 IdNivelServicio = q.IdNivelServicio,
                                Observacion = q.Observacion,
                                IdPeriodo = q.IdPeriodo,
                                IdServicioTipo=q.IdServicioTipo,
                                pe_FechaIni = q.pe_FechaIni,
                                pe_FechaFin = q.pe_FechaFin,
                                Descripcion=q.Descripcion,
                                DescripcionProcesoNomina=q.DescripcionProcesoNomina
                             }).ToList();

                   
                }

                return lista;
            }
            catch (Exception ex)
            {

                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                MensajeError = ex.ToString();
                throw new Exception(ex.ToString());
            }
        }

        public bool Guardar_DB(ro_fectividad_Entrega_servicio_Info info)
        {
            try
            {
                using (EntityRoles_FJ db = new EntityRoles_FJ())
                {
                    db.ro_fectividad_Entrega_servicio.Add(new ro_fectividad_Entrega_servicio
                    {
                        IdEmpresa = info.IdEmpresa,
                        IdNomina_Tipo = info.IdNomina_Tipo,
                        IdNomina_tipo_Liq = info.IdNomina_tipo_Liq,
                        IdNivelServicio = info.IdNivelServicio = getId(info.IdEmpresa),
                        IdPeriodo = info.IdPeriodo,
                        Observacion = info.Observacion,
                        IdServicioTipo = info.IdServicioTipo,
                        FechaTransac = DateTime.Now,
                        IdUsuario = info.IdUsuario,
                        Estado = info.Estado,
                    });

                    foreach (var item in info.lst)
                    {
                        db.ro_fectividad_Entrega_servicio_det.Add(new ro_fectividad_Entrega_servicio_det
                        {
                         IdEmpresa=item.IdEmpresa,
                         IdNivelServicio=info.IdNivelServicio,
                         Secuencia = item.Secuencia,
                         IdRuta = item.IdRuta,
                         IdEmpleado = item.IdEmpleado,
                         Efe_car_bebi = item.Efe_car_bebi,
                         Efe_car_bebi_apl = item.Efe_car_bebi_apl,
                         Efe_vol_bebi = item.Efe_vol_bebi,
                         Efe_vol_bebi_apl = item.Efe_vol_bebi_apl,
                         Efe_ent_bebi = item.Efe_ent_bebi,
                         Efe_ent_bebi_apl = item.Efe_ent_bebi_apl,
                         Efe_car_alim = item.Efe_car_alim,
                         Efe_car_alim_ap = item.Efe_car_alim_ap,
                         Efe_vol_alim = item.Efe_vol_alim,
                         Efe_vol_alim_apl = item.Efe_vol_alim_apl,
                         Efe_ent_alim = item.Efe_ent_alim,
                         Efe_ent_alim_apl = item.Efe_ent_alim_apl,
                         Efe_serv = item.Efe_serv,
                         Efe_ser_apl = item.Efe_ser_apl,
                         Nivel_servicio = item.Nivel_servicio,
                         Valor_volumen = item.Valor_volumen,
                         Valor_servicio = item.Valor_servicio


                        });
                    }


                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                MensajeError = ex.ToString();
                throw new Exception(ex.ToString());
            }
        }
        public bool Modificar_DB(ro_fectividad_Entrega_servicio_Info info)
        {
            try
            {
                using (EntityRoles_FJ db = new EntityRoles_FJ())
                {
                    var add = db.ro_planificacion_x_ruta_x_empleado.FirstOrDefault(v => v.IdEmpresa == info.IdEmpresa && v.IdNomina_Tipo == info.IdNomina_Tipo && v.IdPeriodo == info.IdPeriodo);

                    add.Observacion = info.Observacion;
                    add.Fecha_UltMod = DateTime.Now;
                    add.IdUsuarioUltModi = info.IdUsuarioUltModi;
                    db.Database.ExecuteSqlCommand(" delete Fj_servindustrias.ro_fectividad_Entrega_servicio_det where IdEmpresa='" + info.IdEmpresa + "' and IdNomina_Tipo='" + info.IdNomina_Tipo + "' and IdPeriodo='" + info.IdPeriodo + "' and IdNivelServicio='" + info.IdNivelServicio + "'  ");
                    foreach (var item in info.lst)
                    {
                        db.ro_fectividad_Entrega_servicio_det.Add(new ro_fectividad_Entrega_servicio_det
                        {
                            IdEmpresa = item.IdEmpresa,
                            IdNivelServicio = info.IdNivelServicio,
                            Secuencia = item.Secuencia,
                            IdRuta = item.IdRuta,
                            IdEmpleado = item.IdEmpleado,
                            Efe_car_bebi = item.Efe_car_bebi,
                            Efe_car_bebi_apl = item.Efe_car_bebi_apl,
                            Efe_vol_bebi = item.Efe_vol_bebi,
                            Efe_vol_bebi_apl = item.Efe_vol_bebi_apl,
                            Efe_ent_bebi = item.Efe_ent_bebi,
                            Efe_ent_bebi_apl = item.Efe_ent_bebi_apl,
                            Efe_car_alim = item.Efe_car_alim,
                            Efe_car_alim_ap = item.Efe_car_alim_ap,
                            Efe_vol_alim = item.Efe_vol_alim,
                            Efe_vol_alim_apl = item.Efe_vol_alim_apl,
                            Efe_ent_alim = item.Efe_ent_alim,
                            Efe_ent_alim_apl = item.Efe_ent_alim_apl,
                            Efe_serv = item.Efe_serv,
                            Efe_ser_apl = item.Efe_ser_apl,
                            Nivel_servicio = item.Nivel_servicio,
                            Valor_volumen = item.Valor_volumen,
                            Valor_servicio = item.Valor_servicio
                         
                        });
                    }

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                MensajeError = ex.ToString();
                throw new Exception(ex.ToString());
            }
        }
        public bool Anular_DB(ro_fectividad_Entrega_servicio_Info info)
        {
            try
            {
                using (EntityRoles_FJ db = new EntityRoles_FJ())
                {
                    string IdCalendario = info.IdCalendario;
                    string DeteNov = "delete ro_empleado_novedad_det where idempresa='" + info.IdEmpresa + "' and IdCalendario like '" + IdCalendario + "'";
                    string CabeNov = "delete ro_empleado_novedad where idempresa='" + info.IdEmpresa + "' and IdCalendario like '" + IdCalendario + "'";
                    string DeteEfec = "delete fj_servindustrias.ro_fectividad_Entrega_servicio_det where idempresa='" + info.IdEmpresa + "' and IdPeriodo = '" + info.IdPeriodo + "' and IdNivelServicio='" + info.IdNivelServicio + "'";
                    string CabeEfec = "delete fj_servindustrias.ro_fectividad_Entrega_servicio where idempresa='" + info.IdEmpresa + "' and IdPeriodo = '" + info.IdPeriodo + "'  and IdNivelServicio='" + info.IdNivelServicio + "'";
                    db.Database.ExecuteSqlCommand(DeteNov);
                    db.Database.ExecuteSqlCommand(CabeNov);
                    db.Database.ExecuteSqlCommand(DeteEfec);
                    db.Database.ExecuteSqlCommand(CabeEfec);
                    return true;
                }
            }
            catch (Exception ex)
            {

                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                MensajeError = ex.ToString();
                throw new Exception(ex.ToString());
            }
        }
        public int getId(int IdEmpresa)
        {
            try
            {
                int Id;
                EntityRoles_FJ OEEmpleado = new EntityRoles_FJ();
                var select = from q in OEEmpleado.ro_fectividad_Entrega_servicio
                             where q.IdEmpresa == IdEmpresa
                             select q;

                if (select.Count() == 0)
                {
                    Id = 1;
                }
                else
                {
                    var select_em = (from q in OEEmpleado.ro_fectividad_Entrega_servicio
                                     where q.IdEmpresa == IdEmpresa
                                     select q.IdNivelServicio).Max();
                    Id = Convert.ToInt32(select_em) + 1;
                }
                return Id;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                MensajeError = ex.ToString();
                throw new Exception(ex.ToString());
            }

        }
    }
}
