using Core.Erp.Business.General;
using Core.Erp.Data.General_CG;
using Core.Erp.Info.General_CG;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.General_CG
{
    public class vwtb_pacientes_para_egreso_Bus
    {
        vwtb_pacientes_para_egreso_Data da = new vwtb_pacientes_para_egreso_Data();
        tb_conexion_Postgres_Bus conex_post_bus = new tb_conexion_Postgres_Bus();
        
        public List<vwtb_pacientes_para_egreso_Info> Get_List_Paciente(int IdEmpresa, ref string mensaje)
        {
            List<vwtb_pacientes_para_egreso_Info> lst = new List<vwtb_pacientes_para_egreso_Info>();
            try
            {
                NpgsqlConnection cc = new NpgsqlConnection();
                string conex_postgres = string.Empty;
                cc = conex_post_bus.Conexion_Postgres(ref mensaje);
                if(conex_postgres != null && mensaje == "")
                    lst = da.Get_List_Paciente(IdEmpresa, cc, ref mensaje);
                if (mensaje != "")
                    throw new Exception();

                return lst;
               
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "Get_List_Paciente", ex.Message), ex) { EntityType = typeof(vwtb_pacientes_para_egreso_Bus) };
            }

        }
    }
}
