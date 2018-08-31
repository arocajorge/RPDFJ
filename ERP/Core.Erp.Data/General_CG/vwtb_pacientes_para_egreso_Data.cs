using Core.Erp.Data.General;
using Core.Erp.Info.General;
using Core.Erp.Info.General_CG;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.General_CG
{
    public  class vwtb_pacientes_para_egreso_Data
    {
        string mensaje = "";
        public List<vwtb_pacientes_para_egreso_Info> Get_List_Paciente(int IdEmpresa,NpgsqlConnection cc, ref string msj)
        {
            try
            {

                List<vwtb_pacientes_para_egreso_Info> lista_ = new List<vwtb_pacientes_para_egreso_Info>();
                string sql = string.Empty;
                sql = "SELECT idempresa,idingreso,idcuenta,pe_cedularuc,pe_nombrecompleto,idplan,nom_plan,idestado,nom_estado,fecha_ingreso,fecha_salida FROM vwtb_pacientes_para_egreso where vwtb_pacientes_para_egreso.idempresa=" + IdEmpresa;
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cc);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.IsDBNull(0) == false)
                    {
                        vwtb_pacientes_para_egreso_Info info = new vwtb_pacientes_para_egreso_Info();
                        info.IdEmpresa = Convert.ToInt32(reader.GetDecimal(0));
                        if (!reader.IsDBNull(1))
                        info.IdIngreso = Convert.ToDecimal(reader.GetInt32(1));
                        if (!reader.IsDBNull(2))
                        info.IdCuenta = Convert.ToDecimal(reader.GetInt32(2));
                        info.pe_cedulaRuc = reader.GetString(3);
                        info.pe_nombreCompleto = reader.GetString(4);
                        info.IdPlan = reader.GetInt32(5);
                        info.nom_plan = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                        info.IdEstado = Convert.ToInt32( reader.GetString(7));
                        
                        info.nom_estado = reader.GetString(8);
                        if (!reader.IsDBNull(9))
                        info.Fecha_ingreso = Convert.ToDateTime(reader.GetTimeStamp(9));
                       
                        if (!reader.IsDBNull(10))
                            info.Fecha_salida = Convert.ToDateTime(reader.GetTimeStamp(10));
                        
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
                mensaje = msj = ex.InnerException + " " + ex.Message;

                if (msj != "")
                    return new List<vwtb_pacientes_para_egreso_Info>();
                else
                throw new Exception(ex.ToString());
            }

        }
    }
}
