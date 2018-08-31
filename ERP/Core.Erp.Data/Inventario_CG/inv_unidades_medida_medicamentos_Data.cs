using Core.Erp.Data.General;
using Core.Erp.Info.General;
using Core.Erp.Info.Inventario_CG;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Inventario_CG
{
    public class inv_unidades_medida_medicamentos_Data
    {
        public List<inv_unidades_medida_medicamentos_Info> Get_List_unidades_med_medicamentos(NpgsqlConnection cc, ref string mensaje)
        {
            try
            {
                List<inv_unidades_medida_medicamentos_Info> lista_ = new List<inv_unidades_medida_medicamentos_Info>();
                string sql = string.Empty;
                sql = "SELECT unidad_medida_medicamento_id, descripcion FROM inv_unidades_medida_medicamentos";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cc);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.IsDBNull(0) == false)
                    {
                        inv_unidades_medida_medicamentos_Info info = new inv_unidades_medida_medicamentos_Info();
                        if (!reader.IsDBNull(0))
                            info.unidad_medida_medicamento_id = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                            info.descripcion = reader.GetString(1);

                        lista_.Add(info);
                    }

                }
                reader.Close();
                cc.Close();
                return lista_;
            }
            catch (Exception ex)
            {
                string arreglo = ToString();
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
                mensaje = ex.InnerException + " " + ex.Message;
                throw new Exception(ex.ToString());
            }
        }
    }
}
