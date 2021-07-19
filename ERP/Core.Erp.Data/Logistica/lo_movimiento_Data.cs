using Core.Erp.Info.Logistica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Logistica
{
    public class lo_movimiento_Data
    {
        public lo_movimiento_Info GetInfo(int IdEmpresa, int IdTipoCbte, decimal IdCbteCble)
        {
            lo_movimiento_Info info = new lo_movimiento_Info();
            using (SqlConnection connection = new SqlConnection(ConexionERP.GetConnectionString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select IdMovimiento, IdCatalogoBodega, Fecha, Observacion"
                                    + " from [Logistica].[lo_movimiento] with (nolock)"
                                    + " where IdEmpresa = "+IdEmpresa.ToString()+" and IdTipoCbte_Ogiro = "+IdTipoCbte.ToString()+" and IdCbteCble_Ogiro = "+IdCbteCble.ToString();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    info = new lo_movimiento_Info
                    {
                        IdMovimiento = Convert.ToDecimal(reader["IdMovimiento"]),
                        IdCatalogoBodega = Convert.ToInt32(reader["IdCatalogoBodega"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        Observacion = Convert.ToString(reader["Observacion"])
                    };
                }
                reader.Close();
            }
            return info;
        }
    }
}
