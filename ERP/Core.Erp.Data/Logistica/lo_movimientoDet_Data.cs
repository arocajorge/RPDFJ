using Core.Erp.Info.Logistica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Logistica
{
    public class lo_movimientoDet_Data
    {
        public List<lo_movimientoDet_Info> GetList(decimal IdMovimiento)
        {
            List<lo_movimientoDet_Info> Lista = new List<lo_movimientoDet_Info>();

            using (SqlConnection connection = new SqlConnection(ConexionERP.GetConnectionString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select IdMovimiento, IdMovimientoDet, IdRecurso, Cantidad, Costo, Total, CodigoBarra, CodigoBarraDesde, CodigoBarraHasta"
                                    + " from Logistica.lo_movimientoDet with (nolock)"
                                    + " where IdMovimiento = "+IdMovimiento.ToString();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Lista.Add(new lo_movimientoDet_Info
                    {
                        IdMovimiento = Convert.ToDecimal(reader["IdMovimiento"]),
                        IdMovimientoDet = Convert.ToDecimal(reader["IdMovimientoDet"]),
                        IdRecurso = Convert.ToInt32(reader["IdRecurso"]),
                        Cantidad = Convert.ToDecimal(reader["Cantidad"]),
                        Costo = Convert.ToDecimal(reader["Costo"]),
                        Total = Convert.ToDecimal(reader["Total"]),
                        CodigoBarra = Convert.ToString(reader["CodigoBarra"]),
                        CodigoBarraDesde = Convert.ToString(reader["CodigoBarraDesde"]),
                        CodigoBarraHasta = Convert.ToString(reader["CodigoBarraHasta"])
                    });
                }
                reader.Close();
            }

            return Lista;
        }
    }
}
