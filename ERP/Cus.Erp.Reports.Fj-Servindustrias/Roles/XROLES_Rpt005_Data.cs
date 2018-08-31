using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Data.General;
using Core.Erp.Info.General;
using Core.Erp.Business.Roles;
using Core.Erp.Business.General;
namespace Cus.Erp.Reports.FJ.Roles
{
  public  class XROLES_Rpt005_Data
  {
      tb_Empresa_Info Cbt = new tb_Empresa_Info();
      tb_Empresa_Data empresaData = new tb_Empresa_Data();

      public List<XROLES_Rpt005_Info> Get_list_Horas_Extras(int IdEmpresa, int IdNomina_Tipo, DateTime Fecha_Inicio, DateTime Fecha_Fin, int idperiodo)
      {
          List<XROLES_Rpt005_Info> lista = new List<XROLES_Rpt005_Info>();
          try
          {


              DateTime fi;
              DateTime ff;
                  int diaCorte = 0;
                  int mes_anterior = 0;
                  int anio_siggui = Fecha_Inicio.Year;
                  int anio_ant = Fecha_Inicio.Year;

                  int mes_actual = Fecha_Inicio.Month;
                  mes_anterior = Fecha_Inicio.Month;
                  if (Fecha_Inicio.Month == 1)
                  {
                      mes_anterior = 12;
                      anio_ant = anio_ant - 1;
                  }
                  else
                      mes_anterior = mes_anterior - 1;
                  diaCorte = 26;
                  fi = Convert.ToDateTime(diaCorte.ToString().PadLeft(2, '0') + "/" + mes_anterior.ToString().PadLeft(2, '0') + "/" + anio_ant);

                  ff = Convert.ToDateTime("25" + "/" + mes_actual.ToString().PadLeft(2, '0') + "/" + anio_siggui);

              




              int cont = 0;
              using (Entities_Roles_Fj_Rpt db = new Entities_Roles_Fj_Rpt())
              {

                 // db.SetCommandTimeOut(50000);
                  var query = from q in db.spROLES_Rpt005(IdEmpresa, IdNomina_Tipo, fi, ff, idperiodo)
                            
                              select q;

                  foreach (var item in query)
                  {
                      XROLES_Rpt005_Info info = new XROLES_Rpt005_Info();
                      cont++;
                      info.IdEmpresa = item.IdEmpresa;
                      info.IdNomina_Tipo = item.IdNomina_Tipo;
                      info.IdEmpleado = item.IdEmpleado;
                      info.IdRegistro = item.IdRegistro;
                      info.IdNomina_Tipo = item.IdNomina_Tipo;
                      info.pe_cedulaRuc = item.pe_cedulaRuc;
                      info.pe_apellido = item.pe_apellido + ' ' + item.pe_nombre;
                      info.es_fecha_registro = item.es_fecha_registro.ToString();
                      info.Id_catalogo_Cat = item.Id_catalogo_Cat;
                      info.ca_descripcion = item.ca_descripcion;
                      info.Cargo = item.Cargo;
                      info.IdTurno = item.IdTurno;
                      info.es_jornada_desfasada = item.es_jornada_desfasada;
                      info.de_descripcion = item.de_descripcion;
                      info.Placa = item.Placa;
                      info.zo_descripcion = item.zo_descripcion;
                      info.ru_descripcion = item.ru_descripcion;
                      info.fu_descripcion = item.fu_descripcion;
                      info.Disco = item.Disco;
                      info.fu_descripcion = item.fu_descripcion;

                      info.DiasTrabajados = item.DiasTrabajados;
                      info.DiasEfectivos = item.DiasEfectivos;
                      info.Faltas = item.Faltas;
                      info.Permiso = item.Permiso;
                      info.Vacaciones = item.Vacaciones;

                      info.HorasExtras = item.HorasExtras;

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
      public List<XROLES_Rpt005_Info> Get_list_Horas_Extras(int IdEmpresa, int IdNomina_Tipo, DateTime Fecha_Inicio, DateTime Fecha_Fin, int idperiodo, int IdArea)
      {
          List<XROLES_Rpt005_Info> lista = new List<XROLES_Rpt005_Info>();
          try
          {


              int cont = 0;
              using (Entities_Roles_Fj_Rpt db = new Entities_Roles_Fj_Rpt())
              {

                  // db.SetCommandTimeOut(50000);
                  var query = from q in db.spROLES_Rpt005(IdEmpresa, IdNomina_Tipo, Fecha_Inicio, Fecha_Fin, idperiodo)
                              where q.IdArea==IdArea
                              select q;

                  foreach (var item in query)
                  {
                      XROLES_Rpt005_Info info = new XROLES_Rpt005_Info();
                      cont++;
                      info.IdEmpresa = item.IdEmpresa;
                      info.IdNomina_Tipo = item.IdNomina_Tipo;
                      info.IdEmpleado = item.IdEmpleado;
                      info.IdRegistro = item.IdRegistro;
                      info.IdNomina_Tipo = item.IdNomina_Tipo;
                      info.pe_cedulaRuc = item.pe_cedulaRuc;
                      info.pe_apellido = item.pe_apellido + ' ' + item.pe_nombre;
                      info.es_fecha_registro = item.es_fecha_registro.ToString();
                      info.Id_catalogo_Cat = item.Id_catalogo_Cat;
                      info.ca_descripcion = item.ca_descripcion;
                      info.Cargo = item.Cargo;
                      info.IdTurno = item.IdTurno;
                      info.es_jornada_desfasada = item.es_jornada_desfasada;
                      info.de_descripcion = item.de_descripcion;
                      info.Placa = item.Placa;
                      info.zo_descripcion = item.zo_descripcion;
                      info.ru_descripcion = item.ru_descripcion;
                      info.fu_descripcion = item.fu_descripcion;
                      info.Disco = item.Disco;
                      info.fu_descripcion = item.fu_descripcion;

                      info.DiasTrabajados = item.DiasTrabajados;
                      info.DiasEfectivos = item.DiasEfectivos;
                      info.Faltas = item.Faltas;
                      info.Permiso = item.Permiso;
                      info.Vacaciones = item.Vacaciones;

                      info.HorasExtras = item.HorasExtras;

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
   
    }
}
