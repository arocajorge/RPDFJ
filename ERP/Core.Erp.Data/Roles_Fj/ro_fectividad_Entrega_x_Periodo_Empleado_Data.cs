using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.Roles_Fj;
using Core.Erp.Data.General;
using Core.Erp.Info.General;

namespace Core.Erp.Data.Roles_Fj
{
  public  class ro_fectividad_Entrega_x_Periodo_Empleado_Data
  {
      string MensajeError = "";
      tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
      public bool Guardar_DB(ro_fectividad_Entrega_x_Periodo_Empleado_Info info, ref int IdEfectividad)
      {
          try
          {
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  db.ro_fectividad_Entrega_x_Periodo_Empleado.Add(new ro_fectividad_Entrega_x_Periodo_Empleado
                  {
                      IdEmpresa = info.IdEmpresa,
                      IdNomina_Tipo = info.IdNomina_Tipo,
                      IdNomina_tipo_Liq = info.IdNomina_tipo_Liq,
                      IdEfectividad =info.IdEfectividad= getId(info.IdEmpresa),
                      IdPeriodo = info.IdPeriodo,
                      Observacion = info.Observacion,
                      IdServicioTipo = info.IdServicioTipo,
                      FechaTransac =DateTime.Now,
                      IdUsuario = info.IdUsuario,
                      Estado = info.Estado,
                  });

                  foreach (var item in info.lista)
                  {
                      db.ro_fectividad_Entrega_x_Periodo_Empleado_Det.Add(new ro_fectividad_Entrega_x_Periodo_Empleado_Det
                      {
                          IdEmpresa = info.IdEmpresa,
                          IdNomina_Tipo = info.IdNomina_Tipo,
                          IdNomina_tipo_Liq = info.IdNomina_tipo_Liq,
                          IdEfectividad = info.IdEfectividad,
                          IdPeriodo = info.IdPeriodo,
                          IdEmpleado = item.IdEmpleado,
                          IdRuta = item.IdRuta,
                          Recuperacion_cartera = Convert.ToDouble(item.Recuperacion_cartera),
                          Recuperacion_cartera_aplica = item.Recuperacion_cartera_aplica,
                          Efectividad_Entrega = Convert.ToDouble(item.Efectividad_Entrega),
                          Efectividad_Entrega_aplica = item.Efectividad_Entrega_aplica,
                          Efectividad_Volumen = Convert.ToDouble(item.Efectividad_Volumen),
                          Efectividad_Volumen_aplica = item.Efectividad_Volumen_aplica,
                          Observacion = info.Observacion,
                      });       
                  }
                  
                 
                  db.SaveChanges();
                  IdEfectividad = info.IdEfectividad;
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

      public bool Modificar_DB(ro_fectividad_Entrega_x_Periodo_Empleado_Info info)
      {
          try
          {
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  var add = db.ro_planificacion_x_ruta_x_empleado.FirstOrDefault(v => v.IdEmpresa == info.IdEmpresa && v.IdNomina_Tipo == info.IdNomina_Tipo && v.IdPeriodo == info.IdPeriodo);

                  add.Observacion = info.Observacion;
                  add.Fecha_UltMod = DateTime.Now;
                  add.IdUsuarioUltModi = info.IdUsuarioUltModi;
                  db.Database.ExecuteSqlCommand(" delete Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado_Det where IdEmpresa='" + info.IdEmpresa + "' and IdNomina_Tipo='" + info.IdNomina_Tipo + "' and IdPeriodo='" + info.IdPeriodo + "' and IdEfectividad='" + info.IdEfectividad + "'  ");
                  foreach (var item in info.lista)
                  {
                      db.ro_fectividad_Entrega_x_Periodo_Empleado_Det.Add(new ro_fectividad_Entrega_x_Periodo_Empleado_Det
                      {
                          IdEmpresa = info.IdEmpresa,
                          IdNomina_Tipo = info.IdNomina_Tipo,
                          IdNomina_tipo_Liq = info.IdNomina_tipo_Liq,
                          IdEfectividad = info.IdEfectividad,
                          IdPeriodo = info.IdPeriodo,
                          IdEmpleado = item.IdEmpleado,
                          IdRuta = item.IdRuta,
                          Recuperacion_cartera = Convert.ToDouble(item.Recuperacion_cartera),
                          Recuperacion_cartera_aplica = item.Recuperacion_cartera_aplica,
                          Efectividad_Entrega = Convert.ToDouble(item.Efectividad_Entrega),
                          Efectividad_Entrega_aplica = item.Efectividad_Entrega_aplica,
                          Efectividad_Volumen = Convert.ToDouble(item.Efectividad_Volumen),
                          Efectividad_Volumen_aplica = item.Efectividad_Volumen_aplica,
                          Observacion = info.Observacion,
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

      public bool Anular_DB(ro_fectividad_Entrega_x_Periodo_Empleado_Info info)
      {
          try
          {
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  string IdCalendario = info.IdCalendario;
                  string DeteNov = "delete ro_empleado_novedad_det where idempresa='" + info.IdEmpresa + "' and IdCalendario like '" + IdCalendario + "'";
                  string CabeNov = "delete ro_empleado_novedad where idempresa='" + info.IdEmpresa + "' and IdCalendario like '" + IdCalendario + "'";
                  string DeteEfec = "delete fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado_Det where idempresa='" + info.IdEmpresa + "' and IdPeriodo = '" + info.IdPeriodo + "' and IdEfectividad='" + info.IdEfectividad + "'";
                  string CabeEfec = "delete fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado where idempresa='" + info.IdEmpresa + "' and IdPeriodo = '" + info.IdPeriodo + "'  and IdEfectividad='" + info.IdEfectividad + "'";
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

      public List<ro_fectividad_Entrega_x_Periodo_Empleado_Info> get_list(int IdEmpresa, DateTime Fecha_Inicio, DateTime Fecha_fin)
      {
          try
          {
              List<ro_fectividad_Entrega_x_Periodo_Empleado_Info> lista = new List<ro_fectividad_Entrega_x_Periodo_Empleado_Info>();
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  var query = from q in db.vwro_fectividad_Entrega_x_Periodo_Empleado
                              where
                              q.IdEmpresa == IdEmpresa
                              && q.pe_FechaIni >= Fecha_Inicio
                              && q.pe_FechaIni <= Fecha_fin
                              select q;

                  foreach (var item in query)
                  {
                      ro_fectividad_Entrega_x_Periodo_Empleado_Info info = new ro_fectividad_Entrega_x_Periodo_Empleado_Info();
                      info.IdEmpresa = item.IdEmpresa;
                      info.IdNomina_Tipo = item.IdNomina_Tipo;
                      info.IdNomina_tipo_Liq = item.IdNomina_tipo_Liq;
                      info.IdEfectividad = item.IdEfectividad;
                      info.Observacion = item.Observacion;
                      info.IdPeriodo = item.IdPeriodo;
                      info.pe_FechaIni = item.pe_FechaIni;
                      info.pe_FechaFin = item.pe_FechaFin;
                      lista.Add(info);
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

      public bool Si_existe(int IdEmpresa, int idNomina_tipo, int IdPeriodo)
      {
          try
          {
              List<ro_fectividad_Entrega_x_Periodo_Empleado_Info> lista = new List<ro_fectividad_Entrega_x_Periodo_Empleado_Info>();
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  var query = from q in db.ro_fectividad_Entrega_x_Periodo_Empleado
                              where
                              q.IdEmpresa == IdEmpresa
                              && q.IdNomina_Tipo == idNomina_tipo
                              && q.IdPeriodo == IdPeriodo
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


      public int getId(int IdEmpresa)
      {
          try
          {
              int Id;
              EntityRoles_FJ OEEmpleado = new EntityRoles_FJ();
              var select = from q in OEEmpleado.ro_fectividad_Entrega_x_Periodo_Empleado
                           where q.IdEmpresa == IdEmpresa
                           select q;

              if (select.Count() == 0)
              {
                  Id = 1;
              }
              else
              {
                  var select_em = (from q in OEEmpleado.ro_fectividad_Entrega_x_Periodo_Empleado
                                   where q.IdEmpresa == IdEmpresa
                                   select q.IdEfectividad).Max();
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
