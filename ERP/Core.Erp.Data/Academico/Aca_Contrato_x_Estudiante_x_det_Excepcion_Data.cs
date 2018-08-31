using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Erp.Info.Academico;
using Core.Erp.Info.General;
using Core.Erp.Data.General;

namespace Core.Erp.Data.Academico
{
    public class Aca_Contrato_x_Estudiante_x_det_Excepcion_Data
    {
        string msj = "";
        #region "Get"

        public int GetId()
        {
            int Id = 0;
            try
            {
                Entities_Academico Base = new Entities_Academico();
                int select = (from q in Base.Aca_Contrato_x_Estudiante_det_Excepcion   
                              select q).Count();

                if (select == 0)
                {
                    Id = 1;
                }
                else
                {
                    var select_as = (from q in Base.Aca_Contrato_x_Estudiante_det_Excepcion
                                     select q.IdExepcion).Max();
                    Id = Convert.ToInt32(select_as.ToString()) + 1;

                }
                return Id;
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

        public List<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info> Get_List_Rubros_Contrato(Aca_Contrato_x_Estudiante_Info InfoContrato)
        {
            List<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info> lstExcepcionEstudiante = new List<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info>();
            try
            {
                using (Entities_Academico Base = new Entities_Academico())
                {
                    var vaspirante = from a in Base.vwAca_Contrato_x_Estudiante_det_Excepciones
                                     where a.IdInstitucion == InfoContrato.IdInstitucion &&
                                     a.IdContrato == InfoContrato.IdContrato &&
                                     ////a.IdMatricula == InfoContrato.IdMatricula &&
                                     a.IdEstudiante == InfoContrato.IdEstudiante
                                     ////&& a.IdParalelo == InfoContrato.IdParalelo
                                     ////where a.est_apertura_periodo == "A"
                                     select a;

                    foreach (var item in vaspirante)
                    {
                        Aca_Contrato_x_Estudiante_x_det_Excepcion_Info info = new Aca_Contrato_x_Estudiante_x_det_Excepcion_Info();
                        info.IdInstitucion = item.IdInstitucion;
                        info.IdContrato = item.IdContrato;
                        info.IdInstitucion_Per = item.IdInstitucion_Per;
                        info.IdAnioLectivo_Per = item.IdAnioLectivo_Per;
                        info.AnioLectivo = item.Descripcion;
                        info.IdPeriodo_Per = item.IdPeriodo_Per;
                        info.IdRubro = item.IdRubro;
                        
                        
                        info.ValorRubro = Convert.ToDouble(item.Valor);
                        info.Descripcion_rubro = item.Descripcion_rubro;
                        //info.ValorExepcion = 0;
                        info.ValorExepcion = Convert.ToDouble(item.ValorExepcion);
                        info.nom_descuento = item.nom_descuento;
                        info.IdEmpresa = item.IdEmpresa;
                        info.IdDescuento = Convert.ToDecimal(item.IdDescuento);
                        info.IdExepcion = Convert.ToDecimal(item.IdExepcion);
                        info.porcentaje_excepcion = item.porcentaje_excepcion;
                        info.check = item.TieneDescuento == 1 ? true : false;
                        //info.estado = true;

                        lstExcepcionEstudiante.Add(info);
                    }

                }
                return lstExcepcionEstudiante;
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

        public List<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info> Get_lista_excepciones_Contratos(int IdIntitucion, decimal IdContrato)
        {
            try
            {
                List<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info> lstExcepcionEstudiante = new List<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info>();

                using (Entities_Academico context = new Entities_Academico())
                {
                    var select = from q in context.Aca_Contrato_x_Estudiante_det_Excepcion
                                 where q.IdInstitucion == IdIntitucion
                                 && q.IdContrato == IdContrato 
                                 && q.estado == true
                                 select q;

                    foreach (var item in select)
                    {
                        Aca_Contrato_x_Estudiante_x_det_Excepcion_Info info = new Aca_Contrato_x_Estudiante_x_det_Excepcion_Info();
                        info.IdInstitucion = item.IdInstitucion;
                        info.IdContrato = item.IdContrato;
                        info.IdRubro = item.IdRubro;  
                        info.IdInstitucion_Per = item.IdInstitucion_Per;
                        info.IdAnioLectivo_Per = item.IdAnioLectivo_Per;
                        info.IdPeriodo = item.IdPeriodo_Per;
                        info.IdExepcion = Convert.ToDecimal(item.IdExepcion);                
                        info.ValorExepcion = Convert.ToDouble(item.ValorExepcion);
                        info.porcentaje_excepcion = item.porcentaje_excepcion; 
                        info.IdEmpresa = item.IdEmpresa;
                        info.IdDescuento = Convert.ToDecimal(item.IdDescuento);
                        info.estado = item.estado;
                                               

                        lstExcepcionEstudiante.Add(info);
                    }
                    return lstExcepcionEstudiante;
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

        public List<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info> Get_lista(int IdIntitucion, decimal IdEstudiante, decimal IdContrato, int IdAnioLectivo)
        {
            try
            {
                List<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info> lstExcepcionEstudiante = new List<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info>();

                using (Entities_Academico context = new Entities_Academico())
                {
                    var select = from q in context.vwAca_Contrato_x_Estudiante_det_Excepciones
                                 where q.IdInstitucion == IdIntitucion
                                 && q.IdContrato == IdContrato
                                 && q.IdEstudiante == IdEstudiante
                                 && q.IdEmpresa != null
                                 && q.IdDescuento != null
                                 select q;

                    foreach (var item in select)
                    {
                        Aca_Contrato_x_Estudiante_x_det_Excepcion_Info info = new Aca_Contrato_x_Estudiante_x_det_Excepcion_Info();
                        info.IdInstitucion = item.IdInstitucion;
                        info.IdContrato = item.IdContrato;
                        info.IdInstitucion_Per = item.IdInstitucion_Per;
                        info.IdAnioLectivo_Per = item.IdAnioLectivo_Per;
                        info.AnioLectivo = item.Descripcion;
                        info.IdPeriodo_Per = item.IdPeriodo_Per;
                        info.IdRubro = item.IdRubro;


                        info.ValorRubro = Convert.ToDouble(item.Valor);
                        info.Descripcion_rubro = item.Descripcion_rubro;
                        //info.ValorExepcion = 0;
                        info.ValorExepcion = Convert.ToDouble(item.ValorExepcion);
                        info.nom_descuento = item.nom_descuento;
                        info.IdEmpresa = item.IdEmpresa;
                        info.IdDescuento = Convert.ToDecimal(item.IdDescuento);
                        info.IdExepcion = Convert.ToDecimal(item.IdExepcion);
                        info.porcentaje_excepcion = item.porcentaje_excepcion;
                        info.check = item.TieneDescuento == 1 ? true : false;
                        //info.estado = true;

                        lstExcepcionEstudiante.Add(info);
                    }
                    return lstExcepcionEstudiante;
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
        #endregion

        public bool Grabar_DB(List<Aca_Contrato_x_Estudiante_x_det_Excepcion_Info> lista)
        {
            try
            {
                bool resultado = false;
                Aca_Contrato_x_Estudiante_x_det_Excepcion_Info info = new Aca_Contrato_x_Estudiante_x_det_Excepcion_Info();
                info = lista.FirstOrDefault();
                using (Entities_Academico context = new Entities_Academico())
                {


                    foreach (var item in lista)
                    {
                        Aca_Contrato_x_Estudiante_det_Excepcion add = new Aca_Contrato_x_Estudiante_det_Excepcion();
                        add.IdInstitucion = item.IdInstitucion;
                        add.IdContrato = item.IdContrato;
                        add.IdExepcion = GetId();
                        add.IdAnioLectivo_Per = item.IdAnioLectivo_Per;
                        add.IdInstitucion_Per = item.IdInstitucion_Per;
                        add.IdPeriodo_Per = item.IdPeriodo;
                        add.IdRubro = item.IdRubro;
                        add.porcentaje_excepcion = Convert.ToDouble(item.porcentaje_excepcion);
                        add.ValorExepcion = item.ValorExepcion;
                        add.IdEmpresa = item.IdEmpresa;
                        add.IdDescuento = item.IdDescuento;
                        add.estado = true;
                        add.FechaCreacion = DateTime.Now;
                        add.UsuarioCreacion = info.UsuarioCreacion;
                        context.Aca_Contrato_x_Estudiante_det_Excepcion.Add(add);
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

        public bool AnularBD(Aca_Contrato_x_Estudiante_x_det_Excepcion_Info Info)
        {
            try
            {
                bool resultado = false;
                using (Entities_Academico context = new Entities_Academico())
                {

                    var Select = context.Aca_Contrato_x_Estudiante_det_Excepcion.FirstOrDefault(a => a.IdInstitucion == Info.IdInstitucion && a.IdContrato == Info.IdContrato 
                        && a.IdRubro == Info.IdRubro && a.IdExepcion == Info.IdExepcion && a.IdDescuento == Info.IdDescuento && a.IdAnioLectivo_Per == Info.IdAnioLectivo_Per);

                    if (Select != null)
                    {
                        Select.UsuarioAnulacion = Info.UsuarioAnulacion;
                        Select.FechaAnulaicon = DateTime.Now;
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
