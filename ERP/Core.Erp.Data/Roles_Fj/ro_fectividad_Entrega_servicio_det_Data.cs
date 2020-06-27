using Core.Erp.Data.General;
using Core.Erp.Info.General;
using Core.Erp.Info.Roles_Fj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Roles_Fj
{
  public  class ro_fectividad_Entrega_servicio_det_Data
    {
      public List<ro_fectividad_Entrega_servicio_det_Info> get_list(int IdEmpresa, decimal IdNivelServicio)
      {
          try
          {
              List<ro_fectividad_Entrega_servicio_det_Info> lista = new List<ro_fectividad_Entrega_servicio_det_Info>();
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  lista = (from q in db.vwro_fectividad_Entrega_servicio_det
                           where q.IdEmpresa == IdEmpresa
                           && q.IdNivelServicio == IdNivelServicio
                           select new ro_fectividad_Entrega_servicio_det_Info
                           {
                               IdEmpresa = q.IdEmpresa,
                               IdNivelServicio = q.IdNivelServicio,
                               Secuencia = q.Secuencia,
                               IdRuta = q.IdRuta,
                               IdEmpleado = q.IdEmpleado,
                               Efe_car_bebi = q.Efe_car_bebi,
                               Efe_car_bebi_apl = q.Efe_car_bebi_apl,
                               Efe_vol_bebi = q.Efe_vol_bebi,
                               Efe_vol_bebi_apl = q.Efe_vol_bebi_apl,
                               Efe_ent_bebi = q.Efe_ent_bebi,
                               Efe_ent_bebi_apl = q.Efe_ent_bebi_apl,
                               Efe_car_alim = q.Efe_car_alim,
                               Efe_car_alim_ap = q.Efe_car_alim_ap,
                               Efe_vol_alim = q.Efe_vol_alim,
                               Efe_vol_alim_apl = q.Efe_vol_alim_apl,
                               Efe_ent_alim = q.Efe_ent_alim,
                               Efe_ent_alim_apl = q.Efe_ent_alim_apl,
                               Efe_serv = q.Efe_serv,
                               Efe_ser_apl = q.Efe_ser_apl,
                               Nivel_servicio = q.Nivel_servicio,
                               Valor_volumen = q.Valor_volumen,
                               Valor_servicio = q.Valor_servicio,
                               pe_nombreCompleto = q.pe_nombreCompleto,

                           }).ToList();


              }

              return lista;
          }
          catch (Exception )
          {

              
              throw ;
          }
      }

    }
}
