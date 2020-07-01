using Core.Erp.Data.Roles_Fj;
using Core.Erp.Info.Roles_Fj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.Roles_Fj
{
   public class ro_fectividad_Entrega_servicio_Bus
    {
       ro_fectividad_Entrega_servicio_Data odata = new ro_fectividad_Entrega_servicio_Data();
       public List<ro_fectividad_Entrega_servicio_Info> get_list(int IdEmpresa, DateTime Fecha_Inicio, DateTime Fecha_fin)
       {

           try
           {
               return odata.listado_Grupos(IdEmpresa, Fecha_Inicio, Fecha_fin);
           }
           catch (Exception ex)
           {


               throw;
           }
       }

     
        public bool Modificar_DB( ro_fectividad_Entrega_servicio_Info info)
        {
           
            try
            {
                return odata.Modificar_DB(info);
            }
            catch (Exception ex)
            {

               
                throw ;
            }
        }

        public bool Anular_DB( ro_fectividad_Entrega_servicio_Info info)
        {
            try
            {
                return odata.Anular_DB(info);
            }
            catch (Exception ex)
            {

                
                throw ;
            }
        }
        public bool procesar(ro_fectividad_Entrega_servicio_Info info)
        {

            try
            {
                return odata.procesar(info);
            }
            catch (Exception ex)
            {


                throw;
            }
        }

    }
}
