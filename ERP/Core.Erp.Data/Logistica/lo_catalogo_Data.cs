using Core.Erp.Info.Logistica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Logistica
{
    public class lo_catalogo_Data
    {
        public List<lo_catalogo_Info> GetList(int IdCatalogoTipo)
        {
            List<lo_catalogo_Info> Lista = new List<lo_catalogo_Info>();

            using (SqlConnection connection = new SqlConnection(ConexionERP.GetConnectionString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select IdCatalogo, IdCatalogoTipo, Descripcion "
                                    +" from Logistica.lo_catalogo"
                                    +" where Estado = 1 and IdCatalogoTipo = "+IdCatalogoTipo.ToString();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Lista.Add(new lo_catalogo_Info
                    {
                        IdCatalogo = Convert.ToInt32(reader["IdCatalogo"]),
                        IdCatalogoTipo = Convert.ToInt32(reader["IdCatalogoTipo"]),
                        Descripcion = Convert.ToString(reader["Descripcion"])
                    });
                }
                reader.Close();
            }

            return Lista;
        }
    }
}
