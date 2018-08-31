using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.Roles_Fj;
using Core.Erp.Data.General;
using Core.Erp.Info.General;
using Core.Erp.Info.Roles;

namespace Core.Erp.Data.Roles_Fj
{
  public class ro_planificacion_x_jornada_desfasada_Data
  {
      string MensajeError = "";
      tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
      public bool Guardar_DB(ro_planificacion_x_jornada_desfasada_Info info, ref int IdPlanificacion)
      {
          try
          {
              if(!si_existe_planificacion(info.IdEmpresa,info.IdNomina_Tipo,info.IdPeriodo, info.IdDivision))
              {
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  ro_planificacion_x_jornada_desfasada add = new ro_planificacion_x_jornada_desfasada();
                  add.IdEmpresa = info.IdEmpresa;
                  add.IdPlanificacion = Get_Id(info.IdEmpresa);
                  add.IdNomina_Tipo = info.IdNomina_Tipo;
                  add.IdPeriodo = info.IdPeriodo;
                  add.Observación = info.Observación;
                  add.Esta_Proceso = "ABIERTO";
                  add.IdUsuario = info.IdUsuario;
                  add.Fecha_Transac = DateTime.Now;
                  add.Estado = "A";
                  add.IdDivision = info.IdDivision;
                  db.ro_planificacion_x_jornada_desfasada.Add(add);
                  db.SaveChanges();
                  IdPlanificacion=  add.IdPlanificacion ;
              }
               return true;

              }
              else
              {
                return Modificar_DB(info);
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

      public bool Modificar_DB(ro_planificacion_x_jornada_desfasada_Info Info)
      {
          try
          {
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {

                  var add = db.ro_planificacion_x_jornada_desfasada.FirstOrDefault(v => v.IdEmpresa == Info.IdEmpresa && v.IdPeriodo == Info.IdPeriodo && v.IdPlanificacion==Info.IdPlanificacion );
                  add.Observación = Info.Observación;
                  add.Fecha_UltMod = DateTime.Now;
                  add.IdDivision = Info.IdDivision;
                  add.IdUsuarioUltMod = Info.IdUsuarioUltMod;
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

      public bool Anular_DB(ro_planificacion_x_jornada_desfasada_Info info)
      {
          try
          {
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {

                  string SQL = "";
                  SQL = " delete Fj_servindustrias.ro_planificacion_x_jornada_desfasada_empleado where IdEmpresa='" + info.IdEmpresa + "'  and IdNomina_Tipo='" + info.IdNomina_Tipo + "'  and IdPeriodo='" + info.IdPeriodo + "' and IdPlanificacion='" + info.IdPlanificacion + "'";

                  db.Database.ExecuteSqlCommand(SQL);

                  SQL = " delete Fj_servindustrias.ro_planificacion_x_jornada_desfasada where IdEmpresa='" + info.IdEmpresa + "'  and IdNomina_Tipo='" + info.IdNomina_Tipo + "'  and IdPeriodo='" + info.IdPeriodo + "' and IdPlanificacion='" + info.IdPlanificacion + "'";

                  db.Database.ExecuteSqlCommand(SQL);
                  

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

      public List<ro_planificacion_x_jornada_desfasada_Info> Listado_planificacion_x_periodo(int IdEmpresa, DateTime Fecha_Inicio,DateTime Fecha_Fin)
      {
          try
          {
              Fecha_Inicio = Convert.ToDateTime(Fecha_Inicio.ToShortDateString());
              Fecha_Fin = Convert.ToDateTime(Fecha_Fin.ToShortDateString());
              List<ro_planificacion_x_jornada_desfasada_Info> lista = new List<ro_planificacion_x_jornada_desfasada_Info>();
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  var query = from q in db.vwro_planificacion_x_jornada_desfasada
                              where
                              q.IdEmpresa == IdEmpresa
                              && q.pe_FechaIni>=Fecha_Inicio
                              && q.pe_FechaIni<=Fecha_Fin
                              select q;

                  foreach (var item in query)
                  {
                      ro_planificacion_x_jornada_desfasada_Info add = new ro_planificacion_x_jornada_desfasada_Info();
                      add.IdEmpresa = item.IdEmpresa;
                      add.IdPlanificacion = item.IdPlanificacion;
                      add.IdNomina_Tipo = item.IdNomina_Tipo;
                      add.IdPeriodo = item.IdPeriodo;
                      add.Observación = item.Observación;
                      add.Esta_Proceso = item.Esta_Proceso;
                      add.pe_FechaFin = item.pe_FechaFin;
                      add.pe_FechaIni = item.pe_FechaIni;
                      add.pe_descripcion = item.pe_FechaIni.ToString().Substring(0, 10) + " al" + item.pe_FechaFin.ToString().Substring(0, 10);
                      add.Esta_Proceso = item.Esta_Proceso;
                      add.Descripcion = item.Descripcion;
                      lista.Add(add);
                  }
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
      public bool Cerrar_Planificacion(ro_planificacion_x_jornada_desfasada_Info Info)
      {
          try
          {
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {

                  var add = db.ro_planificacion_x_jornada_desfasada.FirstOrDefault(v => v.IdEmpresa == Info.IdEmpresa && v.IdPeriodo == Info.IdPeriodo && v.IdNomina_Tipo==Info.IdNomina_Tipo);
                  add.Esta_Proceso = "CERRADO";
                  add.Fecha_UltMod = DateTime.Now;
                  add.IdUsuarioUltMod = Info.IdUsuarioUltMod;
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


      public bool si_existe_planificacion(int IdEmpresa, int IdNomina_tipo, int IdPeriodo,int? IdDivision)
      {
          try
          {
              List<ro_planificacion_x_jornada_desfasada_Info> lista = new List<ro_planificacion_x_jornada_desfasada_Info>();
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  var query = from q in db.vwro_planificacion_x_jornada_desfasada
                              where
                              q.IdEmpresa == IdEmpresa
                              && q.IdNomina_Tipo == IdNomina_tipo
                              && q.IdPeriodo == IdPeriodo
                              && q.IdDivision==IdDivision
                              select q;

                  if (query.Count() > 0)
                      return true;
                  else
                      return false;
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

      public int Get_Id(int IdEmpresa)
      {
          try
          {
              int Id;
              EntityRoles_FJ db = new EntityRoles_FJ();
              var selecte = db.ro_planificacion_x_jornada_desfasada.Count(q => q.IdEmpresa == IdEmpresa);
              if (selecte == 0)
              {
                  Id = 1;
              }
              else
              {
                  var select_em = (from q in db.ro_planificacion_x_jornada_desfasada
                                   where q.IdEmpresa == IdEmpresa
                                   select q.IdPlanificacion).Max();
                  Id = Convert.ToInt32(select_em.ToString()) + 1;
              }
              return Id;
          }
          catch (Exception ex)
          {
              string arreglo = ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
              throw new Exception(ex.ToString());
          }
      }


    }
}
