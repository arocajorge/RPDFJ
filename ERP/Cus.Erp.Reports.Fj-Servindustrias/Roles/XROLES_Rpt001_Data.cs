using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Data.General;
using Core.Erp.Info.General;
namespace Cus.Erp.Reports.FJ.Roles
{
  public  class XROLES_Rpt001_Data
    {
      public List<XROLES_Rpt001_Info> Get_list_Horas_Extras(int IdEmpresa, int IdNomina_Tipo, int IdNomina_tipo_Liq, int IdPerido)
      {
          List<XROLES_Rpt001_Info> lista = new List<XROLES_Rpt001_Info>();
          try
          {

              using (Entities_Roles_Fj_Rpt db= new Entities_Roles_Fj_Rpt())
              {
                  var query = from q in db.vwROLES_Rpt001
                              where q.IdEmpresa==IdEmpresa
                              && q.IdNominaTipo==IdNomina_Tipo
                              && q.IdNominaTipoLiqui==IdNomina_tipo_Liq
                              && q.IdPeriodo==IdPerido
                              select q;

                  foreach (var item in query)
                  {
                      XROLES_Rpt001_Info info = new XROLES_Rpt001_Info();
                      info.IdEmpresa = item.IdEmpresa;
                      info.IdEmpleado = item.IdEmpleado;
                      info.IdNominaTipo = item.IdNominaTipo;

                      info.IdNominaTipoLiqui = item.IdNominaTipoLiqui;
                      info.IdPeriodo = item.IdPeriodo;
                      info.pe_nombreCompleto = item.pe_nombreCompleto;
                      info.pe_cedulaRuc = item.pe_cedulaRuc;
                      info.de_descripcion = item.de_descripcion;
                      info.ca_descripcion = item.ca_descripcion;
                      info.time_entrada1 = item.time_entrada1;
                      info.time_salida1 = item.time_salida1;
                      info.time_entrada2 = item.time_entrada2;
                      info.time_salida2 = item.time_salida2;
                      info.hora_extra25 = item.hora_extra25;
                      info.hora_extra50 = item.hora_extra50;
                      info.hora_extra100 = item.hora_extra100;
                      info.hora_trabajada = item.hora_trabajada;
                      info.FechaRegistro = item.FechaRegistro;
                      info.dia =Convert.ToInt32( Convert.ToDateTime(item.FechaRegistro).DayOfWeek);
                      if( ((TimeSpan)item.time_entrada1).TotalHours>0)
                          info.Tot_horas_1ra_jornada = TotalHoras((TimeSpan) item.time_entrada1,(TimeSpan)item.time_salida1);

                      if (((TimeSpan)item.time_entrada2).TotalHours > 0)
                          info.Tot_horas_1ra_jornada = TotalHoras((TimeSpan)item.time_entrada2, (TimeSpan)item.time_salida2);

                      if (info.Tot_horas_1ra_jornada < 0)
                      {
                          info.Tot_horas_1ra_jornada = info.Tot_horas_1ra_jornada * -1;
                      }
                      if (info.Tot_horas_2da_jornada < 0)
                      {
                          info.Tot_horas_2da_jornada = info.Tot_horas_2da_jornada * -1;
                      }
                      if (   ((TimeSpan)item.time_entrada1).Hours >= 18)
                      {
                          info.primer_turno = "NOCHE";
                      }
                      else
                      {
                          info.primer_turno = "DÍA";
                      }

                      if (((TimeSpan)item.time_entrada2).Hours >= 18)
                      {
                          info.segundo_turno = "NOCHE";
                      }
                      else
                      {
                          info.segundo_turno = "DÍA";
                      }

                      if (item.hora_trabajada > 8)
                      {
                          if (((TimeSpan)item.time_entrada2).Hours == 0)
                          {
                              info.almuerzo = 1;

                          }
                          else
                          {
                              info.almuerzo = 0;

                          }
                      }
                      else
                      {
                          info.almuerzo = 0;
                      }

                      info.totalHoras = info.Tot_horas_1ra_jornada + info.Tot_horas_2da_jornada;
                      info.Calculo_Horas_extras_Sobre = item.Calculo_Horas_extras_Sobre;
                      info.Centro_costo = item.Centro_costo;
                      lista.Add(info);
                  }
              }

              return lista;
          }
          catch (Exception ex)
          {


              string mensaje = "";
              mensaje = ex.ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", mensaje, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
              throw new Exception(mensaje);
           
          }
      }


      public double TotalHoras( TimeSpan HoraInicio, TimeSpan Horafin)
      {
          try
          {
              double Total_horas = 0;
              TimeSpan inicioHora100 = TimeSpan.FromHours(0); //00:00 PM

              if (((TimeSpan)HoraInicio).TotalHours > 0)
              {
                  if (((TimeSpan)HoraInicio).TotalHours > ((TimeSpan)Horafin).TotalHours)
                  {
                      if (((TimeSpan)Horafin).TotalHours > inicioHora100.TotalDays)
                      {
                          double horas_tmp = ((TimeSpan)Horafin).TotalHours - inicioHora100.TotalHours;
                          double horas_tm = 24 - ((TimeSpan)HoraInicio).TotalHours;
                          Total_horas = horas_tmp + horas_tm;
                      }
                      else
                      {
                          Total_horas = ((TimeSpan)Horafin - (TimeSpan)HoraInicio).TotalHours;
                      }
                  }
                  else
                  {
                      Total_horas = ((TimeSpan)Horafin - (TimeSpan)HoraInicio).TotalHours;
                  }
              }
             
            return Total_horas;

          }
          catch (Exception ex)
          {
              
             string mensaje = "";
              mensaje = ex.ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", mensaje, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
              throw new Exception(mensaje);
          }
      }
    }
}
