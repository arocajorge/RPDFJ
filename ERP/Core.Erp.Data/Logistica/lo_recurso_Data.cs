using Core.Erp.Info.Logistica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Logistica
{
    public class lo_recurso_Data
    {
        public List<lo_recurso_Info> GetList()
        {
            try
            {
                List<lo_recurso_Info> Lista = new List<lo_recurso_Info>();

                using (SqlConnection connection = new SqlConnection(ConexionERP.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "select IdRecurso, NomRecurso, ControlaSerie, ControlaKardex "
                                        +" from Logistica.lo_recurso with (nolock)"
                                        +" where ControlaKardex = 1 and Estado = 1";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Lista.Add(new lo_recurso_Info
                        {
                            IdRecurso = Convert.ToInt32(reader["IdRecurso"]),
                            NomRecurso = Convert.ToString(reader["NomRecurso"]),
                            ControlaSerie = Convert.ToBoolean(reader["ControlaSerie"]),
                            ControlKardex = Convert.ToBoolean(reader["ControlaKardex"])
                        });
                    }
                    reader.Close();
                }

                return Lista;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
