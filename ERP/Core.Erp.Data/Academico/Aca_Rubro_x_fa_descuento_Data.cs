using Core.Erp.Data.General;
using Core.Erp.Info.Academico;
using Core.Erp.Info.Facturacion;
using Core.Erp.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Academico
{
    public class Aca_Rubro_x_fa_descuento_Data
    {
        string mensaje = "";

        public List<Aca_Rubro_x_fa_descuento_Info> Get_Lista(int IdInstitucion, int IdRubro, int IdEmpresa, decimal IdDescuento)
        {
            try
            {
                List<Aca_Rubro_x_fa_descuento_Info> Lista = new List<Aca_Rubro_x_fa_descuento_Info>();
                Entities_Academico Base = new Entities_Academico();
                var Select = from q in Base.vwAca_Rubro_x_fa_descuento
                             where q.IdInstitucion_rub == IdInstitucion
                                    && q.IdRubro == IdRubro
                                    && q.IdEmpresa_fadesc == IdEmpresa
                                    && q.IdDescuento == IdDescuento
                             select q;

                if (Select != null)
                {
                    foreach (var item in Select)
                    {
                        Aca_Rubro_x_fa_descuento_Info Info = new Aca_Rubro_x_fa_descuento_Info();
                        Info.IdInstitucion_rub = item.IdInstitucion_rub;
                        Info.IdRubro = item.IdRubro;
                        Info.IdEmpresa_fadesc = item.IdEmpresa_fadesc;
                        Info.IdDescuento = item.IdDescuento;
                        if (item.Estado == true)
                            Info.estado = 'A';
                        else
                            Info.estado = 'I';
                        Info.Estado = item.Estado;

                        Lista.Add(Info);
                    }
                }
                return Lista;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                string MensajeError = string.Empty;
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                MensajeError = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
                throw new Exception(ex.ToString());
            }
        }

        public bool GuardarDB(Aca_Rubro_x_fa_descuento_Info info, ref string mensaje)
        {
            try
            {
                bool resultado = false;

                using (Entities_Academico Base = new Entities_Academico())
                {
                    Aca_Rubro_x_fa_descuento Entity = new Aca_Rubro_x_fa_descuento();
                    Entity.IdInstitucion_rub = info.IdInstitucion_rub;
                    Entity.IdRubro = info.IdRubro;
                    Entity.IdEmpresa_fadesc = info.IdEmpresa_fadesc;
                    Entity.IdDescuento = info.IdDescuento;
                    Entity.Estado = true;
                    Entity.FechaCreacion = info.FechaCreacion;
                    Entity.IdUsuarioCreacion = info.IdUsuarioCreacion;
                    Entity.nom_pc = info.nom_pc;
                    Entity.ip = info.ip;

                    Base.Aca_Rubro_x_fa_descuento.Add(Entity);
                    Base.SaveChanges();
                    resultado = true;
                }


                return resultado;
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
        public bool EliminarBD(Aca_Rubro_x_fa_descuento_Info info, ref string mensaje)
        {
            try
            {
                using (Entities_Academico Base = new Entities_Academico())
                {
                    string comando = "delete Aca_Rubro_x_fa_descuento where IdInstitucion_rub = " + info.IdInstitucion_rub + " and IdRubro = " + info.IdRubro + " and IdEmpresa_fadesc = " + info.IdEmpresa_fadesc + " and IdDescuento = " + info.IdDescuento;
                    Base.Database.ExecuteSqlCommand(comando);
                }
                return true;
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

        public bool GuardarDB(List<Aca_Rubro_x_fa_descuento_Info> lst, ref string mensaje)
        {
            try
            {
                foreach (var item in lst)
                {
                    if (!GuardarDB(item, ref mensaje))
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                //string mensaje = "";
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                mensaje = ex.ToString();
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                throw new Exception(ex.ToString());
            }
        }

        public bool AnularDB(Aca_Rubro_x_fa_descuento_Info info, ref string msj)
        {
            try
            {
                using (Entities_Academico Base = new Entities_Academico())
                {

                    var address = Base.Aca_Rubro_x_fa_descuento.FirstOrDefault(a => a.IdInstitucion_rub == info.IdInstitucion_rub && a.IdRubro == info.IdRubro && a.IdEmpresa_fadesc == info.IdEmpresa_fadesc && a.IdDescuento == info.IdDescuento);

                    if (address != null)
                    {
                        address.Estado = false;
                        address.FechaUltAnu = DateTime.Now;
                        address.MotivoAnulacion = info.MotivoAnulacion;
                        address.IdUsuarioUltAnu = info.IdUsuarioUltAnu;
                        Base.SaveChanges();
                        msj = "Se ha procedido anular  #: " + info.IdDescuento.ToString() + " exitosamente.";
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                msj = ex.InnerException + " " + ex.Message;
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref msj);
                msj = "Se ha producido el siguiente error: " + ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }
    }
}
