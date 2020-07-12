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
    public class ro_Calculo_Pago_Variable_Porcentaje_servicio_Data
    {
        string mensaje = "";

        public ro_Calculo_Pago_Variable_Porcentaje_servicio_Info get_info(int IdEmpresa, int IdTipo_Nomina, int IdTipoServicio)
        {
            try
            {
                ro_Calculo_Pago_Variable_Porcentaje_servicio_Info Info = new ro_Calculo_Pago_Variable_Porcentaje_servicio_Info();
                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {
                    var contact = from q in Context.ro_Calculo_Pago_Variable_Porcentaje_servicio
                                  where q.IdEmpresa == IdEmpresa
                                  && q.IdTipo_Nomina == IdTipo_Nomina
                                  && q.IdTipoServicio==IdTipoServicio
                                  select q;

                    foreach (var item in contact)
                    {
                        Info.IdEmpresa = item.IdEmpresa;
                        Info.IdTipo_Nomina = item.IdTipo_Nomina;
                        Info.IdEfectividad = item.IdEfectividad;
                        Info.IdTipoServicio = item.IdTipoServicio;
                        Info.Efec_desde = item.Efec_desde;
                        Info.Efec_hasta = item.Efec_hasta;
                        Info.Efec_aplica = item.Efec_aplica;
                    }
                }
                return Info;
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString() + " " + ex.Message;
                throw new Exception(ex.ToString());
            }
        }

        public List<ro_Calculo_Pago_Variable_Porcentaje_servicio_Info> get_lis(int IdEmpresa, int IdTipo_Nomina, int IdTipoServicio)
        {
            try
            {
                List<ro_Calculo_Pago_Variable_Porcentaje_servicio_Info> Lista_Calculo = new List<ro_Calculo_Pago_Variable_Porcentaje_servicio_Info>();
                
                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {
                    var contact = from q in Context.ro_Calculo_Pago_Variable_Porcentaje_servicio
                                  where q.IdEmpresa == IdEmpresa
                                  && q.IdTipo_Nomina == IdTipo_Nomina
                                  && q.IdTipoServicio==IdTipoServicio
                                  select q;

                    foreach (var item in contact)
                    {
                        ro_Calculo_Pago_Variable_Porcentaje_servicio_Info Info = new ro_Calculo_Pago_Variable_Porcentaje_servicio_Info();
                        Info.IdEmpresa = item.IdEmpresa;
                        Info.IdTipo_Nomina = item.IdTipo_Nomina;
                        Info.IdEfectividad = item.IdEfectividad;
                        Info.IdTipoServicio = item.IdTipoServicio;
                        Info.Efec_desde = item.Efec_desde;
                        Info.Efec_hasta = item.Efec_hasta;
                        Info.Efec_aplica = item.Efec_aplica;
                        Lista_Calculo.Add(Info);
                    }
                }
                return Lista_Calculo;
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString() + " " + ex.Message;
                throw new Exception(ex.ToString());
            }
        }

        public int Get_Id(int IdEmpresa)
        {
            try
            {
                int Id;
                EntityRoles_FJ db = new EntityRoles_FJ();
                var selecte = db.ro_Calculo_Pago_Variable_Porcentaje_servicio.Count(q => q.IdEmpresa == IdEmpresa);
                if (selecte == 0)
                {
                    Id = 1;
                }
                else
                {
                    var select_em = (from q in db.ro_Calculo_Pago_Variable_Porcentaje_servicio
                                     where q.IdEmpresa == IdEmpresa
                                     select q.IdEfectividad).Max();
                    Id = Convert.ToInt32(select_em.ToString()) + 1;
                }
                return Id;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString();
                throw new Exception(ex.ToString());
            }
        }

        public bool GuardarDB(List<ro_Calculo_Pago_Variable_Porcentaje_servicio_Info> Info, int IdTipo_Nomina, int idempresa)
        {
            try
            {
                int IdEfectividad = Get_Id(idempresa);
                string sql = "delete  Fj_servindustrias.ro_Calculo_Pago_Variable_Porcentaje_servicio where IdEmpresa= '" + idempresa + "' and IdTipo_Nomina='" + IdTipo_Nomina + "'";
                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {
                    Context.Database.ExecuteSqlCommand(sql);
                    foreach (var item in Info)
                    {
                        Context.ro_Calculo_Pago_Variable_Porcentaje_servicio.Add(new
                        ro_Calculo_Pago_Variable_Porcentaje_servicio
                        {
                            IdEmpresa = item.IdEmpresa,
                            IdTipo_Nomina = item.IdTipo_Nomina,
                            IdEfectividad = item.IdEfectividad = IdEfectividad,
                            IdTipoServicio = item.IdTipoServicio,
                            Efec_desde = item.Efec_desde,
                            Efec_hasta = item.Efec_hasta,
                            Efec_aplica = item.Efec_aplica

                        });
                        IdEfectividad++;
                    }

                    
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString();
                throw new Exception(ex.ToString());
            }
        }

        public List<ro_Calculo_Pago_Variable_Porcentaje_servicio_Info> get_lis(double cumplimiento)
        {
            try
            {
                List<ro_Calculo_Pago_Variable_Porcentaje_servicio_Info> Lista_Calculo = new List<ro_Calculo_Pago_Variable_Porcentaje_servicio_Info>();

                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {
                    string sql = "select * from Fj_servindustrias.ro_Calculo_Pago_Variable_Porcentaje_servicio where idempresa=2 and '" + cumplimiento + "' between  Efec_desde and Efec_hasta ";

                    var resultado=Context.Database.SqlQuery<ro_Calculo_Pago_Variable_Porcentaje_servicio_Info>(sql).ToList();

                    if (resultado != null)
                    {
                        Lista_Calculo = resultado;
                    }
                }
                
                return Lista_Calculo;
            }
            catch (Exception ex)
            {
                string array = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", array, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.ToString() + " " + ex.Message;
                throw new Exception(ex.ToString());
            }
        }

     

    }
}
