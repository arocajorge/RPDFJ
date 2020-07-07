using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Erp.Data.Roles;
using Core.Erp.Info.Roles;
using Core.Erp.Business.General;
using Core.Erp.Info.General;
using Core.Erp.Data.Roles_Fj;
namespace Core.Erp.Business.Roles
{


    public class ro_permiso_x_empleado_Bus
    {
        tb_sis_Log_Error_Vzen_Bus oLog = new tb_sis_Log_Error_Vzen_Bus();
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        string mensaje = "";
        ro_historico_vacaciones_x_empleado_Bus Bus_Historico_vacaciones = new ro_historico_vacaciones_x_empleado_Bus();
        ro_Empleado_Bus Bus_empleado = new ro_Empleado_Bus();
        ro_permiso_x_empleado_Data oData = new ro_permiso_x_empleado_Data();
        public List<ro_permiso_x_empleado_Info> ConsultaGeneral(int IdEmpresa, DateTime Fecha_inicio, DateTime Fecha_Fin)
        {
            try
            {
                return oData.ConsultaGeneral(IdEmpresa, Fecha_inicio, Fecha_Fin);

            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "ConsultaGeneral", ex.Message), ex) { EntityType = typeof(ro_permiso_x_empleado_Bus) };
            }
        }
        public List<ro_permiso_x_empleado_Info> GetListLicenciaPorEmpleado(int IdEmpresa, int idEmpleado, DateTime fecha_I, DateTime fecha_F)
        {
            try
            {
                return oData.GetListLicenciaPorEmpleado(IdEmpresa, idEmpleado,fecha_I,fecha_F);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "GetListLicenciaPorEmpleado", ex.Message), ex) { EntityType = typeof(ro_permiso_x_empleado_Bus) };
            }
        }
        public Boolean GuardarDB(ro_permiso_x_empleado_Info info, ref decimal id, ref string msg)
               {
            try
            {
                info.ip = param.ip;
                info.nom_pc = param.nom_pc;

                //MODIFICA
                if(info.IdPermiso!=0)
                {
                    info.Fecha_UltMod = param.Fecha_Transac;
                    info.IdUsuarioUltMod = param.IdUsuario;
                    return oData.ModificarDB(info, ref msg);        
               }
                        else
                        {
                            //GRABA
                            info.Fecha_Transac=param.Fecha_Transac;
                            info.IdUsuario = param.IdUsuario;
                            info.Estado = "A";
                            info.IdUsuario_Anu = "";
                            info.FechaAnulacion = null;
                            info.IdUsuarioUltMod = "";
                            info.MotivoAnulacion = "";

                          return oData.GuardarDB(info, ref id,ref msg);
            
                        }

         
    }    catch (Exception ex)    {
        Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
        throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "GuardarDB", ex.Message), ex) { EntityType = typeof(ro_permiso_x_empleado_Bus) };
    }
}
        public Boolean ModificarDB(ro_permiso_x_empleado_Info info, ref string msg)
{
    try{
        info.Fecha_UltMod = param.Fecha_Transac;
        info.IdUsuarioUltMod = param.IdUsuario;
        return oData.ModificarDB(info, ref msg);
    }catch (Exception ex){
        Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
        throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "ModificarDB", ex.Message), ex) { EntityType = typeof(ro_permiso_x_empleado_Bus) };
    }
}
        public Boolean AnularDB(ro_permiso_x_empleado_Info info, ref string msg)
            {
                try
                {
                    info.Fecha_UltMod = param.Fecha_Transac;
                    info.IdUsuarioUltMod = param.IdUsuario;
                    return oData.AnularDB(info, ref msg);
                }
                catch (Exception ex)
                {
                    Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                    throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "ModificarDB", ex.Message), ex) { EntityType = typeof(ro_permiso_x_empleado_Bus) };
                }
            }
        public int MaxPermiso(int IdEmpresa)
        {
            try
            {
                return oData.MaxPermiso(IdEmpresa);

            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "MaxPermiso", ex.Message), ex) { EntityType = typeof(ro_permiso_x_empleado_Bus) };                
            }
        }
        public ro_permiso_x_empleado_Info Get_Info_Dias_Permiso(int idempresa, int IdNomina_Tipo, int idempleado, DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                return oData.Get_Info_Dias_Permiso(idempresa, IdNomina_Tipo, idempleado, fechaIni, fechaFin);

            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "MaxPermiso", ex.Message), ex) { EntityType = typeof(ro_permiso_x_empleado_Bus) };
            }
        }
        public int Get_Dias_Permiso(int idempresa, int IdNomina_Tipo, int idempleado, DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                return oData.Get_Dias_Permiso(idempresa, IdNomina_Tipo, idempleado, fechaIni, fechaFin);

            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "MaxPermiso", ex.Message), ex) { EntityType = typeof(ro_permiso_x_empleado_Bus) };
            }
        }
        public List<ro_Empleado_Novedad_Det_Info> get_novedad(int IdEmpresa, decimal IdEmpleado, decimal IdPermiso)
        {

            try
            {
                return oData.get_novedad(IdEmpresa, IdEmpleado, IdPermiso);

            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "MaxPermiso", ex.Message), ex) { EntityType = typeof(ro_permiso_x_empleado_Bus) };
            }
        }
    
    }
}
