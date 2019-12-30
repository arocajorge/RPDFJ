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
  public  class ro_empleado_extension_salud_Data
    {

        string mensaje = "";

        public List<ro_empleado_extension_salud_Info> Get_List_Disco(int IdEmpresa)
        {
            List<ro_empleado_extension_salud_Info> Lista_Disco = new List<ro_empleado_extension_salud_Info>();
            try
            {
                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {
                    var contact = from q in Context.ro_empleado_extension_salud
                                  where q.IdEmpresa == IdEmpresa
                                  select q;

                    foreach (var item in contact)
                    {
                        ro_empleado_extension_salud_Info Info = new ro_empleado_extension_salud_Info();
                        Info.IdEmpresa = item.IdEmpresa;
                        Info.IdEmpleado = item.IdEmpleado;
                        Lista_Disco.Add(Info);
                    }
                }
                return Lista_Disco;
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

        public bool GuardarDB(List<ro_empleado_extension_salud_Info> Info,  ref string mensaje)
        {
            try
            {
                int IdEmpresa = 0;
                if (Info.Count > 0)
                {
                    IdEmpresa = Info.FirstOrDefault().IdEmpresa;
                }

                var groupedCustomerList = Info
                .GroupBy(u => u.IdEmpleado)
                .Select(grp => grp)
                .ToList();

                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {


                    Context.Database.ExecuteSqlCommand("delete Fj_servindustrias.ro_empleado_extension_salud where IdEmpresa= " + IdEmpresa + "");



                    foreach (var item in groupedCustomerList)
                    {
                        //var info = Context.ro_empleado_extension_salud.Where(v => v.IdEmpresa == item.IdEmpresa && v.IdEmpleado == item.IdEmpresa).FirstOrDefault();
                           Context.ro_empleado_extension_salud.Add(new ro_empleado_extension_salud
                        {
                        IdEmpresa=IdEmpresa,
                        IdEmpleado = item.Key
                       // Observacion=item.Observacion
                        });
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

        public int get_info(int IdEmpresa, decimal IdEmpleado)
        {
            try
            {
                using (EntityRoles_FJ Context = new EntityRoles_FJ())
                {
                    var contact = from q in Context.ro_empleado_extension_salud
                                  where q.IdEmpresa == IdEmpresa
                                  && q.IdEmpleado==IdEmpleado
                                  select q;
                    if (contact == null)
                        return 0;
                    else
                        if (contact.Count() > 0)
                            return 1;
                        else
                            return 0;
                }  
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
