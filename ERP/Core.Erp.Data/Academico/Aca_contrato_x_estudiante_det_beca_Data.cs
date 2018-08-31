using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.Academico;
using Core.Erp.Info.General;
using Core.Erp.Data.General;
using Core.Erp.Data.Academico;

namespace Core.Erp.Data.Academico
{
   public class Aca_contrato_x_estudiante_det_beca_Data
    {
       string msj = "";
       public bool Grabar_DB(List<Aca_contrato_x_estudiante_det_beca_Info> lista)
       {
           try
           {
               bool resultado = false;
               Aca_contrato_x_estudiante_det_beca_Info info=new Aca_contrato_x_estudiante_det_beca_Info();
               info=lista.FirstOrDefault();
               Eliminar_DB(info.IdInstitucion,Convert.ToInt32( info.IdContrato));
               using (Entities_Academico context = new Entities_Academico())
               {


                   foreach (var item in lista)
                   {
                       Aca_Contrato_x_Estudiante_det_Beca add = new Aca_Contrato_x_Estudiante_det_Beca();
                       add.IdInstitucion=item.IdInstitucion;
                       add.IdContrato = item.IdContrato;
                       add.IdBeca = item.IdBeca;
                       add.IdAnioLectivo_Per = item.IdAnioLectivo_Per;
                       add.IdInstitucion_Per = item.IdInstitucion_Per;
                       add.IdPeriodo_Per = item.IdPeriodo_Per;
                       add.IdRubro = item.IdRubro;
                       add.porc_beca = item.porc_beca;
                       add.valor_beca = item.valor_beca;
                       add.IdEmpresa = item.IdEmpresa;
                       add.IdDescuento = item.IdDescuento;

                       context.Aca_Contrato_x_Estudiante_det_Beca.Add(add);
                       context.SaveChanges();
                       resultado= true;
                       

                   }
                   
               }
               return resultado;
           }
           catch (Exception ex)
           {

               string arreglo = ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "",
                                   "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref msj);
               msj = ex.InnerException + " " + ex.Message;
               throw new Exception(ex.InnerException.ToString());
           }
       }


       private bool Eliminar_DB(int IdInstitucion, int idcontrato)
       {
           try
           {
               using (Entities_Academico context = new Entities_Academico())
               {

                   context.Database.ExecuteSqlCommand("delete Aca_Contrato_x_Estudiante_det_Beca where IdInstitucion='" + IdInstitucion + "' and IdContrato='"+idcontrato+"' ");
                   return true;
               }

           }
           catch (Exception ex)
           {

               string arreglo = ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "",
                                   "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref msj);
               msj = ex.InnerException + " " + ex.Message;
               throw new Exception(ex.InnerException.ToString());
           }
       }


       public List<Aca_contrato_x_estudiante_det_beca_Info> Get_lista(int IdIntitucion, decimal IdEstudiante, decimal IdContrato,int IdAnioLectivo)
       {
           try
           {
               List<Aca_contrato_x_estudiante_det_beca_Info> lista = new List<Aca_contrato_x_estudiante_det_beca_Info>();              
                   using (Entities_Academico context = new Entities_Academico())
                   {
                       var select = from q in context.vwAca_Contrato_x_Estudiante_det_Beca
                                    where q.IdInstitucion == IdIntitucion
                                    && q.IdContrato==IdContrato
                                    && q.IdEstudiante==IdEstudiante
                                    && q.IdEmpresa != null
                                    && q.IdDescuento != null
                                    select q;
                    
                       foreach (var item in select)
                       {
                           Aca_contrato_x_estudiante_det_beca_Info add = new Aca_contrato_x_estudiante_det_beca_Info();
                           add.IdInstitucion = item.IdInstitucion;
                           add.IdContrato = item.IdContrato;
                           add.IdAnioLectivo_Per = item.IdAnioLectivo_Per;
                           add.IdInstitucion_Per = item.IdInstitucion_Per;
                           add.IdPeriodo_Per = item.IdPeriodo_Per;
                           add.IdRubro = item.IdRubro;
                           add.valor_beca = Convert.ToDouble((item.valor_beca == null) ? 0 : item.valor_beca);
                           add.porc_beca = Convert.ToDouble((item.Porcentaje_beca== null) ? 0 :item.Porcentaje_beca);
                           add.Descripcion=item.Descripcion;
                           add.Descripcion_rubro=item.Descripcion_rubro;
                           add.pe_FechaFin=item.pe_FechaFin;
                           add.pe_FechaIni=item.pe_FechaIni;
                           add.IdAnioLectivo_Per=item.IdAnioLectivo_Per;
                           add.IdPeriodo_Per=item.IdPeriodo_Per;
                           add.Valor = item.Valor;
                           add.nom_beca = item.nom_beca;
                           add.IdEmpresa = item.IdEmpresa;
                           add.IdDescuento = item.IdDescuento;
                           add.IdBeca = Convert.ToInt16(item.IdBeca);

                           if(item.TieneBeca==1)
                               add.check=true;
                           else
                               add.check=false;
                           lista.Add(add);
                       }
                       return lista;
                   }


           }
           catch (Exception ex)
           {

               string arreglo = ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "",
                                   "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref msj);
               msj = ex.InnerException + " " + ex.Message;
               throw new Exception(ex.InnerException.ToString());
           }
       }


       private bool si_tiene_beca(int IdIntitucion, int IdBeca, int IdEstudiante)
       {

           try
           {
               List<Aca_contrato_x_estudiante_det_beca_Info> lista = new List<Aca_contrato_x_estudiante_det_beca_Info>();
               using (Entities_Academico context = new Entities_Academico())
               {
                   var select = from q in context.Aca_Contrato_x_Estudiante_det_Beca
                                where q.IdInstitucion == IdIntitucion
                                && q.IdBeca == IdBeca
                                select q;

                   if (select.Count() > 0)
                       return true;
                   else
                       return false;
               }
           }
           catch (Exception ex)
           {

               string arreglo = ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "",
                                   "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref msj);
               msj = ex.InnerException + " " + ex.Message;
               throw new Exception(ex.InnerException.ToString());
           }
       }


       public bool AnularBD(Aca_contrato_x_estudiante_det_beca_Info Info)
       {
           try
           {
               bool resultado = false;
               using (Entities_Academico context = new Entities_Academico())
               {

                   var Select = context.Aca_Contrato_x_Estudiante_det_Beca.FirstOrDefault(a => a.IdInstitucion == Info.IdInstitucion && a.IdContrato == Info.IdContrato
                       && a.IdRubro == Info.IdRubro && a.IdDescuento == Info.IdDescuento && a.IdAnioLectivo_Per == Info.IdAnioLectivo_Per && a.IdBeca == Info.IdBeca);

                   if (Select != null)
                   {
                       Select.IdUsuarioUltAnulo = Info.IdUsuarioUltAnulo;
                       Select.FechaAnulacion = DateTime.Now;
                       Select.estado = false;
                       context.SaveChanges();
                       resultado = true;
                   }
               }
               return resultado;
           }
           catch (Exception ex)
           {

               string arreglo = ToString();
               tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
               tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "",
                                   "", "", "", "", DateTime.Now);
               oDataLog.Guardar_Log_Error(Log_Error_sis, ref msj);
               msj = ex.InnerException + " " + ex.Message;
               throw new Exception(ex.InnerException.ToString());
           }
       }
    }
}
