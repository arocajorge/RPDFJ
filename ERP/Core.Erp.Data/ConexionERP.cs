using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data
{
    public class ConexionERP
    {
        public static string GetConnectionString()
        {
            /*
            string ip = "localhost";
            string password = "admin*2016";
           */
            
            string ip = "192.168.0.254";
            string password = "admin*2016";
             
            string user = "sa";
            string InitialCatalog = "DBERP_FJ_PRODUCCION";

            return "data source=" + ip + ";initial catalog=" + InitialCatalog + ";user id=" + user + ";password=" + password + ";MultipleActiveResultSets=True;";
        }
    }
}
