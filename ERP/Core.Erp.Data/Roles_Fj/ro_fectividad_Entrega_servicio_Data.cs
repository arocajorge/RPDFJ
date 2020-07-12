using Core.Erp.Data.General;
using Core.Erp.Info.General;
using Core.Erp.Info.Roles_Fj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Data.Roles;
namespace Core.Erp.Data.Roles_Fj
{
   public class ro_fectividad_Entrega_servicio_Data
    {
       ro_Empleado_Novedad_Data odata = new ro_Empleado_Novedad_Data();

        string MensajeError = "";
        tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
        ro_rubros_calculados_Data odata_calculado = new ro_rubros_calculados_Data();
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
        public bool Modificar_DB(ro_fectividad_Entrega_servicio_Info info)
        {
            try
            {
                ro_periodo_Data odata_perido = new ro_periodo_Data();
                var infoperiodo = odata_perido.ObtenerPeriodo(info.IdEmpresa, info.IdPeriodo).FirstOrDefault();
                #region variables
                EntitiesRoles context = new EntitiesRoles();
                EntityRoles_FJ db = new EntityRoles_FJ();
                decimal IdNovedad = 0;
                var info_calculado = odata_calculado.get_info(info.IdEmpresa);
                #endregion
                    var add = db.ro_fectividad_Entrega_servicio.FirstOrDefault(v => v.IdEmpresa == info.IdEmpresa && v.IdNivelServicio == info.IdNivelServicio);
                    //add.Observacion = info.Observacion;
                    add.FechaUltModi = DateTime.Now;
                    add.IdUsuarioUltModi = info.IdUsuarioUltModi;
                    string idcalendario = info.IdPeriodo.ToString() + info.IdNivelServicio.ToString();
                    string DeteNov = "delete ro_empleado_novedad_det where idempresa='" + info.IdEmpresa + "' and IdCalendario = '" + idcalendario + "'";
                    string CabeNov = "delete ro_empleado_novedad where idempresa='" + info.IdEmpresa + "' and IdCalendario = '" + idcalendario + "'";
                    string detalle = "delete Fj_servindustrias.ro_fectividad_Entrega_servicio_det where IdEmpresa='" + info.IdEmpresa + "'  and IdNivelServicio='" + info.IdNivelServicio + "'  ";

                    db.Database.ExecuteSqlCommand(DeteNov);
                    db.Database.ExecuteSqlCommand(CabeNov);
                    db.Database.ExecuteSqlCommand(detalle);

                    foreach (var item in info.lst)
                    {
                        #region servicio
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
                        #endregion

                        #region novedades
                         IdNovedad=odata.GetIdNovedad(item.IdEmpresa,item.IdEmpleado);

                         #region servicio
                         if (item.Valor_servicio > 0)
                         {
                             context.ro_empleado_Novedad.Add(new ro_empleado_Novedad
                             {
                                 IdNovedad = IdNovedad,
                                 IdEmpresa = info.IdEmpresa,
                                 IdEmpleado = item.IdEmpleado,
                                 TotalValor = item.Valor_servicio,
                                 Fecha = infoperiodo.pe_FechaFin,
                                 IdNomina_Tipo = info.IdNomina_Tipo,
                                 IdNomina_TipoLiqui = info.IdNomina_tipo_Liq,
                                 IdUsuario = info.IdUsuario,
                                 Fecha_Transac = info.FechaTransac = DateTime.Now,
                                 nom_pc = "",
                                 ip = "",
                                 Estado = "A",
                                 IdCalendario = info.IdCalendario,
                             });
                             context.ro_empleado_novedad_det.Add(new ro_empleado_novedad_det
                             {
                                 IdEmpresa = info.IdEmpresa,
                                 IdNovedad = IdNovedad,
                                 IdEmpleado = item.IdEmpleado,
                                 Secuencia = item.Secuencia = 1,
                                 FechaPago = infoperiodo.pe_FechaFin,
                                 Valor = item.Valor_servicio,
                                 EstadoCobro = "PEN",
                                 Estado = "A",
                                 Observacion = info.Observacion,
                                 IdRubro = info_calculado.IdRubro_servicio,
                                 IdCalendario = info.IdPeriodo.ToString()+info.IdNivelServicio.ToString(),
                                 Num_Horas = 0,
                                 IdNomina_tipo = info.IdNomina_Tipo,
                                 IdNomina_Tipo_Liq = info.IdNomina_tipo_Liq,
                                 IdPeriodo = info.IdPeriodo
                             });
                         }
                         #endregion

                         #region cartera
                         if (item.Valor_volumen > 0)
                         {
                             IdNovedad++;
                             context.ro_empleado_Novedad.Add(new ro_empleado_Novedad
                             {
                                 IdNovedad = IdNovedad,
                                 IdEmpresa = info.IdEmpresa,
                                 IdEmpleado = item.IdEmpleado,
                                 TotalValor = item.Valor_volumen,
                                 Fecha = infoperiodo.pe_FechaFin,
                                 IdNomina_Tipo = info.IdNomina_Tipo,
                                 IdNomina_TipoLiqui = info.IdNomina_tipo_Liq,
                                 IdUsuario = info.IdUsuario,
                                 Fecha_Transac = info.FechaTransac = DateTime.Now,
                                 nom_pc = "",
                                 ip = "",
                                 Estado = "A",
                                 IdCalendario = info.IdCalendario,
                             });
                             context.ro_empleado_novedad_det.Add(new ro_empleado_novedad_det
                             {
                                 IdEmpresa = info.IdEmpresa,
                                 IdNovedad = IdNovedad,
                                 IdEmpleado = item.IdEmpleado,
                                 Secuencia = item.Secuencia = 1,
                                 FechaPago = infoperiodo.pe_FechaFin,
                                 Valor = item.Valor_volumen,
                                 EstadoCobro = "PEN",
                                 Estado = "A",
                                 Observacion = info.Observacion,
                                 IdRubro = info_calculado.IdRubro_beb_car,
                                 IdCalendario = info.IdPeriodo.ToString() + info.IdNivelServicio.ToString(),
                                 Num_Horas = 0,
                                 IdNomina_tipo = info.IdNomina_Tipo,
                                 IdNomina_Tipo_Liq = info.IdNomina_tipo_Liq,
                                 IdPeriodo = info.IdPeriodo
                             });
                         }
                         #endregion
                         
                        #endregion
                    }




                    context.SaveChanges();
                    return true;
                
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
                    string idcalendario = info.IdPeriodo.ToString() + info.IdNivelServicio.ToString();
                    string DeteNov = "delete ro_empleado_novedad_det where idempresa='" + info.IdEmpresa + "' and IdCalendario = '" + idcalendario + "'";
                    string CabeNov = "delete ro_empleado_novedad where idempresa='" + info.IdEmpresa + "' and IdCalendario = '" + idcalendario + "'";
                    string detalle = "delete Fj_servindustrias.ro_fectividad_Entrega_servicio_det where IdEmpresa='" + info.IdEmpresa + "' and IdNomina_Tipo='" + info.IdNomina_Tipo + "' and IdPeriodo='" + info.IdPeriodo + "' and IdNivelServicio='" + info.IdNivelServicio + "'  ";

                    db.Database.ExecuteSqlCommand(DeteNov);
                    db.Database.ExecuteSqlCommand(CabeNov);
                    db.Database.ExecuteSqlCommand(detalle);

             
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
        public bool procesar(ro_fectividad_Entrega_servicio_Info info)
        {
            try
            {
               
                info.Observacion = " ";
                using (EntityRoles_FJ db = new EntityRoles_FJ())
                {
                    var Entity = db.ro_fectividad_Entrega_servicio.FirstOrDefault(v => v.IdEmpresa == info.IdEmpresa 
                        && v.IdNomina_Tipo == info.IdNomina_Tipo 
                        && v.IdNomina_tipo_Liq==info.IdNomina_tipo_Liq
                        && v.IdPeriodo == info.IdPeriodo
                        && v.Estado==true);
                    if (Entity == null)
                        info.IdNivelServicio = getId(info.IdEmpresa);
                    else
                        info.IdNivelServicio = Entity.IdNivelServicio;
                       db.spro_calculo_nivel_servicio(info.IdEmpresa, info.IdNomina_Tipo, info.IdNomina_tipo_Liq, info.IdPeriodo,
                        info.IdNivelServicio, info.Observacion, info.IdUsuario);

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

      
      
    }
}
