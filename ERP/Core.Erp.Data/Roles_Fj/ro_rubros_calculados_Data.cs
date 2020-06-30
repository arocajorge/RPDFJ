using Core.Erp.Info.Roles_Fj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Roles_Fj
{
   public class ro_rubros_calculados_Data
   {
       public ro_rubros_calculados_Info get_info(int IdEmpresa)
       {
           try
           {
               ro_rubros_calculados_Info info = new ro_rubros_calculados_Info();

               using (EntityRoles_FJ Context = new EntityRoles_FJ())
               {
                   ro_rubros_calculados Entity = Context.ro_rubros_calculados.FirstOrDefault(q => q.IdEmpresa == IdEmpresa);
                   if (Entity == null) return null;

                   info = new ro_rubros_calculados_Info
                   {
                       IdEmpresa = Entity.IdEmpresa,
                       IdRubro_dias_trabajados = Entity.IdRubro_dias_trabajados,
                       IdRubro_iess_perso = Entity.IdRubro_iess_perso,
                       IdRubro_sueldo = Entity.IdRubro_sueldo,
                       IdRubro_tot_egr = Entity.IdRubro_tot_egr,
                       IdRubro_tot_ing = Entity.IdRubro_tot_ing,
                       IdRubro_tot_pagar = Entity.IdRubro_tot_pagar,
                       IdRubro_aporte_patronal = Entity.IdRubro_aporte_patronal,
                       IdRubro_fondo_reserva = Entity.IdRubro_fondo_reserva,
                       IdRubro_prov_vac = Entity.IdRubro_prov_vac,
                       IdRubro_prov_DIII = Entity.IdRubro_prov_DIII,
                       IdRubro_prov_DIV = Entity.IdRubro_prov_DIV,
                       IdRubro_prov_FR = Entity.IdRubro_prov_FR,
                       IdRubro_DIII = Entity.IdRubro_DIII,
                       IdRubro_DIV = Entity.IdRubro_DIV,
                       IdRubro_IR = Entity.IdRubro_IR,
                       IdRubro_alimentacion=Entity.IdRubro_alimentacion,
                       IdRubro_transporte=Entity.IdRubro_transporte,
                       IdRubro_otros_ingresos=Entity.IdRubro_otros_ingresos,
                       IdRubro_anticipo = Entity.IdRubro_anticipo,
                       IdRubro_horas_extras=Entity.IdRubro_horas_extras,
                       IdRubro_otros_descuentos=Entity.IdRubro_otros_descuentos,
                       IdRubro_dias_efectivos=Entity.IdRubro_dias_efectivos,
                       IdRubro_subtotal_variable=Entity.IdRubro_subtotal_variable,
                       IdRubro_descuento_permiso=Entity.IdRubro_descuento_permiso
                       
                   };
               }

               return info;
           }
           catch (Exception)
           {

               throw;
           }
       }
        public bool guardarDB(ro_rubros_calculados_Info info)
       {
           try
           {
               using (EntityRoles_FJ Context = new EntityRoles_FJ())
               {
                   ro_rubros_calculados Entity = Context.ro_rubros_calculados.FirstOrDefault(q => q.IdEmpresa == info.IdEmpresa);
                   if (Entity == null)
                   {
                       ro_rubros_calculados Entity_add = new ro_rubros_calculados
                       {
                           IdEmpresa = info.IdEmpresa,
                           IdRubro_dias_trabajados = info.IdRubro_dias_trabajados,
                           IdRubro_iess_perso = info.IdRubro_iess_perso,
                           IdRubro_sueldo = info.IdRubro_sueldo,
                           IdRubro_tot_egr = info.IdRubro_tot_egr,
                           IdRubro_tot_ing = info.IdRubro_tot_ing,
                           IdRubro_tot_pagar = info.IdRubro_tot_pagar,
                           IdRubro_aporte_patronal = info.IdRubro_aporte_patronal,
                           IdRubro_fondo_reserva = info.IdRubro_fondo_reserva,
                           IdRubro_prov_vac = info.IdRubro_prov_vac,
                           IdRubro_prov_DIII = info.IdRubro_prov_DIII,
                           IdRubro_prov_DIV = info.IdRubro_prov_DIV,
                           IdRubro_prov_FR = info.IdRubro_prov_FR,
                           IdRubro_DIII = info.IdRubro_DIII,
                           IdRubro_DIV = info.IdRubro_DIV,
                           IdRubro_IR = info.IdRubro_IR,
                           IdRubro_anticipo = info.IdRubro_anticipo,
                           IdRubro_alimentacion = info.IdRubro_alimentacion,
                           IdRubro_transporte = info.IdRubro_transporte,
                           IdRubro_otros_ingresos = info.IdRubro_otros_ingresos,
                           IdRubro_dias_efectivos=info.IdRubro_dias_efectivos,
                           IdRubro_horas_extras=info.IdRubro_horas_extras,
                           IdRubro_subtotal_variable=info.IdRubro_subtotal_variable,
                           IdRubro_otros_descuentos=info.IdRubro_otros_descuentos,
                           IdRubro_descuento_permiso=info.IdRubro_descuento_permiso
                       };
                       Context.ro_rubros_calculados.Add(Entity_add);
                   }
                   else
                   {
                       Entity.IdRubro_dias_trabajados = info.IdRubro_dias_trabajados;
                       Entity.IdRubro_iess_perso = info.IdRubro_iess_perso;
                       Entity.IdRubro_sueldo = info.IdRubro_sueldo;
                       Entity.IdRubro_tot_egr = info.IdRubro_tot_egr;
                       Entity.IdRubro_tot_ing = info.IdRubro_tot_ing;
                       Entity.IdRubro_tot_pagar = info.IdRubro_tot_pagar;
                       Entity.IdRubro_aporte_patronal = info.IdRubro_aporte_patronal;
                       Entity.IdRubro_fondo_reserva = info.IdRubro_fondo_reserva;
                       Entity.IdRubro_prov_vac = info.IdRubro_prov_vac;
                       Entity.IdRubro_prov_DIII = info.IdRubro_prov_DIII;
                       Entity.IdRubro_prov_DIV = info.IdRubro_prov_DIV;
                       Entity.IdRubro_prov_FR = info.IdRubro_prov_FR;
                       Entity.IdRubro_DIII = info.IdRubro_DIII;
                       Entity.IdRubro_DIV = info.IdRubro_DIV;
                       Entity.IdRubro_IR = info.IdRubro_IR;
                       Entity.IdRubro_anticipo = info.IdRubro_anticipo;
                       Entity.IdRubro_alimentacion = info.IdRubro_alimentacion;
                       Entity.IdRubro_transporte = info.IdRubro_transporte;
                       Entity.IdRubro_otros_descuentos = info.IdRubro_otros_descuentos;
                       Entity.IdRubro_horas_extras = info.IdRubro_horas_extras;
                       Entity.IdRubro_dias_efectivos = info.IdRubro_dias_efectivos;
                       Entity.IdRubro_subtotal_variable = info.IdRubro_subtotal_variable;
                       Entity.IdRubro_descuento_permiso = info.IdRubro_descuento_permiso;
                   }
                   
                  

                   Context.SaveChanges();
               }

               return true;
           }
           catch (Exception)
           {

               throw;
           }
       }
    }
}
