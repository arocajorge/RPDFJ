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
    public class inv_fabricantes_Data
    {

        public List<inv_fabricantes_Info> Get_List_fabricantes(NpgsqlConnection cc, ref string mensaje)
        {
            try
            {

                List<inv_fabricantes_Info> lista_ = new List<inv_fabricantes_Info>();
                string sql = string.Empty;
                sql = "SELECT fabricante_id, descripcion, registro_invima, pais_id FROM inv_fabricantes";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cc);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.IsDBNull(0) == false)
                    {
                        inv_fabricantes_Info info = new inv_fabricantes_Info();
                        if (!reader.IsDBNull(0))
                        info.fabricante_id = reader.GetInt32(0);
                        info.descripcion = reader.GetString(1);
                        info.registro_invima = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                        info.pais_id = reader.GetDecimal(3);
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
