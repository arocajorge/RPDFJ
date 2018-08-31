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
    public class Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Data
    {
        public List<Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info> Get_List_ProcesoBanco_x_GrupoFE(int IdInstitucion, int IdEmpresa)
        {
            List<Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info> lstProcesoBanco_x_GrupoFE = new List<Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info>();
            try
            {
                using (Entities_Academico Base = new Entities_Academico())
                {
                    var vaspirante = from a in Base.Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE
                                     where a.IdInstitucion == IdInstitucion
                                     && a.IdEmpresa == IdEmpresa
                                     select a;

                    foreach (var item in vaspirante)
                    {
                        Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info info = new Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info();
                        info.IdInstitucion = item.IdInstitucion;
                        info.IdGrupoFE = item.IdGrupoFE;
                        info.IdEmpresa = item.IdEmpresa;
                        info.IdProceso_bancario_tipo = item.IdProceso_bancario_tipo;
                        info.CodGrupoFE = item.CodGrupoFE;
                        info.Codigo_establecimiento = item.Codigo_establecimiento;
                        info.porcentaje_comision = item.porcentaje_comision;
                        info.Observacion = item.Observacion;


                        lstProcesoBanco_x_GrupoFE.Add(info);
                    }

                }
                return lstProcesoBanco_x_GrupoFE;
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


        public Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info Get_Info_ProcesoBanco_x_GrupoFE(int IdInstitucion, int IdGrupoFE, int IdEmpresa, string IdProcesoBancarioTipo)
        {

            try
            {
                Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info info = new Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Info();

                using (Entities_Academico Base = new Entities_Academico())
                {
                    var vaspirante = from a in Base.Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE
                                     where a.IdInstitucion == IdInstitucion
                                     && a.IdGrupoFE == IdGrupoFE
                                     && a.IdEmpresa == IdEmpresa
                                     && a.IdProceso_bancario_tipo == IdProcesoBancarioTipo
                                     select a;

                    foreach (var item in vaspirante)
                    {
                        
                        info.IdInstitucion = item.IdInstitucion;
                        info.IdGrupoFE = item.IdGrupoFE;
                        info.IdEmpresa = item.IdEmpresa;
                        info.IdProceso_bancario_tipo = item.IdProceso_bancario_tipo;
                        info.CodGrupoFE = item.CodGrupoFE;
                        info.Codigo_establecimiento = item.Codigo_establecimiento;
                        info.porcentaje_comision = item.porcentaje_comision;
                        info.Observacion = item.Observacion;


                        
                    }

                }
                return info;
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


    }
}
