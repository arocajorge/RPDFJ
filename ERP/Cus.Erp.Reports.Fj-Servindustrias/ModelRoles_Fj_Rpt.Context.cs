﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cus.Erp.Reports.FJ
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class Entities_Roles_Fj_Rpt : DbContext
    {
        public Entities_Roles_Fj_Rpt()
            : base("name=Entities_Roles_Fj_Rpt")
        {
        }
        //poner esta funcion dentro de la clase entities no viene por defecto
        public void SetCommandTimeOut(int TimeOut)
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = TimeOut;
        }
    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<vwROLES_Rpt008> vwROLES_Rpt008 { get; set; }
        public DbSet<vwROLES_Rpt014> vwROLES_Rpt014 { get; set; }
        public DbSet<vwROLES_Rpt015> vwROLES_Rpt015 { get; set; }
        public DbSet<vwROLES_Rpt016> vwROLES_Rpt016 { get; set; }
        public DbSet<vwROLES_Rpt001> vwROLES_Rpt001 { get; set; }
        public DbSet<vwROLES_Rpt003> vwROLES_Rpt003 { get; set; }
        public DbSet<vwROLES_Rpt004> vwROLES_Rpt004 { get; set; }
        public DbSet<vwROLES_Rpt019> vwROLES_Rpt019 { get; set; }
        public DbSet<vwROLES_Rpt020> vwROLES_Rpt020 { get; set; }
        public DbSet<vwROLES_Rpt013> vwROLES_Rpt013 { get; set; }
        public DbSet<vwROLES_Rpt021> vwROLES_Rpt021 { get; set; }
    
        public virtual ObjectResult<spROLES_Rpt009_Result> spROLES_Rpt009(Nullable<int> idEmpresa, Nullable<int> idNomina_tipo, Nullable<int> anio, Nullable<int> mes)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idNomina_tipoParameter = idNomina_tipo.HasValue ?
                new ObjectParameter("IdNomina_tipo", idNomina_tipo) :
                new ObjectParameter("IdNomina_tipo", typeof(int));
    
            var anioParameter = anio.HasValue ?
                new ObjectParameter("Anio", anio) :
                new ObjectParameter("Anio", typeof(int));
    
            var mesParameter = mes.HasValue ?
                new ObjectParameter("Mes", mes) :
                new ObjectParameter("Mes", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spROLES_Rpt009_Result>("spROLES_Rpt009", idEmpresaParameter, idNomina_tipoParameter, anioParameter, mesParameter);
        }
    
        public virtual ObjectResult<spROLES_Rpt002_Result1> spROLES_Rpt002(Nullable<int> idEmpresa, Nullable<int> idNomina, Nullable<decimal> idEmpleado, Nullable<int> idPeriodo, Nullable<int> anio, Nullable<int> mes)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idNominaParameter = idNomina.HasValue ?
                new ObjectParameter("IdNomina", idNomina) :
                new ObjectParameter("IdNomina", typeof(int));
    
            var idEmpleadoParameter = idEmpleado.HasValue ?
                new ObjectParameter("IdEmpleado", idEmpleado) :
                new ObjectParameter("IdEmpleado", typeof(decimal));
    
            var idPeriodoParameter = idPeriodo.HasValue ?
                new ObjectParameter("IdPeriodo", idPeriodo) :
                new ObjectParameter("IdPeriodo", typeof(int));
    
            var anioParameter = anio.HasValue ?
                new ObjectParameter("Anio", anio) :
                new ObjectParameter("Anio", typeof(int));
    
            var mesParameter = mes.HasValue ?
                new ObjectParameter("Mes", mes) :
                new ObjectParameter("Mes", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spROLES_Rpt002_Result1>("spROLES_Rpt002", idEmpresaParameter, idNominaParameter, idEmpleadoParameter, idPeriodoParameter, anioParameter, mesParameter);
        }
    
        public virtual ObjectResult<spROLES_Rpt014_Result> spROLES_Rpt014(Nullable<int> idEmpresa, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("FechaInicio", fechaInicio) :
                new ObjectParameter("FechaInicio", typeof(System.DateTime));
    
            var fechaFinParameter = fechaFin.HasValue ?
                new ObjectParameter("FechaFin", fechaFin) :
                new ObjectParameter("FechaFin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spROLES_Rpt014_Result>("spROLES_Rpt014", idEmpresaParameter, fechaInicioParameter, fechaFinParameter);
        }
    
        public virtual ObjectResult<spROLES_Rpt017_Result> spROLES_Rpt017(Nullable<int> idEmpresa, Nullable<int> idNomina, Nullable<int> idDivision, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idNominaParameter = idNomina.HasValue ?
                new ObjectParameter("IdNomina", idNomina) :
                new ObjectParameter("IdNomina", typeof(int));
    
            var idDivisionParameter = idDivision.HasValue ?
                new ObjectParameter("IdDivision", idDivision) :
                new ObjectParameter("IdDivision", typeof(int));
    
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("FechaInicio", fechaInicio) :
                new ObjectParameter("FechaInicio", typeof(System.DateTime));
    
            var fechaFinParameter = fechaFin.HasValue ?
                new ObjectParameter("FechaFin", fechaFin) :
                new ObjectParameter("FechaFin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spROLES_Rpt017_Result>("spROLES_Rpt017", idEmpresaParameter, idNominaParameter, idDivisionParameter, fechaInicioParameter, fechaFinParameter);
        }
    
        public virtual ObjectResult<spROLES_Rpt006_Result> spROLES_Rpt006(Nullable<int> idEmpresa, Nullable<int> idNomina_tipo, Nullable<System.DateTime> fecha_Inicio, Nullable<System.DateTime> fecha_Fin)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idNomina_tipoParameter = idNomina_tipo.HasValue ?
                new ObjectParameter("IdNomina_tipo", idNomina_tipo) :
                new ObjectParameter("IdNomina_tipo", typeof(int));
    
            var fecha_InicioParameter = fecha_Inicio.HasValue ?
                new ObjectParameter("Fecha_Inicio", fecha_Inicio) :
                new ObjectParameter("Fecha_Inicio", typeof(System.DateTime));
    
            var fecha_FinParameter = fecha_Fin.HasValue ?
                new ObjectParameter("Fecha_Fin", fecha_Fin) :
                new ObjectParameter("Fecha_Fin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spROLES_Rpt006_Result>("spROLES_Rpt006", idEmpresaParameter, idNomina_tipoParameter, fecha_InicioParameter, fecha_FinParameter);
        }
    
        public virtual ObjectResult<spROLES_Rpt018_Result> spROLES_Rpt018(Nullable<int> idEmpresa, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("FechaInicio", fechaInicio) :
                new ObjectParameter("FechaInicio", typeof(System.DateTime));
    
            var fechaFinParameter = fechaFin.HasValue ?
                new ObjectParameter("FechaFin", fechaFin) :
                new ObjectParameter("FechaFin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spROLES_Rpt018_Result>("spROLES_Rpt018", idEmpresaParameter, fechaInicioParameter, fechaFinParameter);
        }
    
        public virtual ObjectResult<spROLES_Rpt010_Result> spROLES_Rpt010(Nullable<int> idEmpresa, Nullable<int> idNomina_tipo, Nullable<int> idNomina_tipo_Liqui, Nullable<int> idPeriodo, Nullable<System.DateTime> fecha_Inicio, Nullable<System.DateTime> fecha_Fin)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idNomina_tipoParameter = idNomina_tipo.HasValue ?
                new ObjectParameter("IdNomina_tipo", idNomina_tipo) :
                new ObjectParameter("IdNomina_tipo", typeof(int));
    
            var idNomina_tipo_LiquiParameter = idNomina_tipo_Liqui.HasValue ?
                new ObjectParameter("IdNomina_tipo_Liqui", idNomina_tipo_Liqui) :
                new ObjectParameter("IdNomina_tipo_Liqui", typeof(int));
    
            var idPeriodoParameter = idPeriodo.HasValue ?
                new ObjectParameter("IdPeriodo", idPeriodo) :
                new ObjectParameter("IdPeriodo", typeof(int));
    
            var fecha_InicioParameter = fecha_Inicio.HasValue ?
                new ObjectParameter("Fecha_Inicio", fecha_Inicio) :
                new ObjectParameter("Fecha_Inicio", typeof(System.DateTime));
    
            var fecha_FinParameter = fecha_Fin.HasValue ?
                new ObjectParameter("Fecha_Fin", fecha_Fin) :
                new ObjectParameter("Fecha_Fin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spROLES_Rpt010_Result>("spROLES_Rpt010", idEmpresaParameter, idNomina_tipoParameter, idNomina_tipo_LiquiParameter, idPeriodoParameter, fecha_InicioParameter, fecha_FinParameter);
        }
    
        public virtual ObjectResult<spROLES_Rpt005_Result> spROLES_Rpt005(Nullable<int> idEmpresa, Nullable<int> idNomina_tipo, Nullable<System.DateTime> fecha_Inicio, Nullable<System.DateTime> fecha_Fin, Nullable<int> idperiodo_inicio, Nullable<int> idperiodo_fin)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idNomina_tipoParameter = idNomina_tipo.HasValue ?
                new ObjectParameter("IdNomina_tipo", idNomina_tipo) :
                new ObjectParameter("IdNomina_tipo", typeof(int));
    
            var fecha_InicioParameter = fecha_Inicio.HasValue ?
                new ObjectParameter("Fecha_Inicio", fecha_Inicio) :
                new ObjectParameter("Fecha_Inicio", typeof(System.DateTime));
    
            var fecha_FinParameter = fecha_Fin.HasValue ?
                new ObjectParameter("Fecha_Fin", fecha_Fin) :
                new ObjectParameter("Fecha_Fin", typeof(System.DateTime));
    
            var idperiodo_inicioParameter = idperiodo_inicio.HasValue ?
                new ObjectParameter("Idperiodo_inicio", idperiodo_inicio) :
                new ObjectParameter("Idperiodo_inicio", typeof(int));
    
            var idperiodo_finParameter = idperiodo_fin.HasValue ?
                new ObjectParameter("Idperiodo_fin", idperiodo_fin) :
                new ObjectParameter("Idperiodo_fin", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spROLES_Rpt005_Result>("spROLES_Rpt005", idEmpresaParameter, idNomina_tipoParameter, fecha_InicioParameter, fecha_FinParameter, idperiodo_inicioParameter, idperiodo_finParameter);
        }
    
        public virtual ObjectResult<spROLES_Rpt011_Result> spROLES_Rpt011(Nullable<int> idEmpresa, Nullable<int> idNomina_tipo, Nullable<int> idNomina_tipo_Liqui, Nullable<int> idPeriodo, Nullable<System.DateTime> fecha_Inicio, Nullable<System.DateTime> fecha_Fin)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idNomina_tipoParameter = idNomina_tipo.HasValue ?
                new ObjectParameter("IdNomina_tipo", idNomina_tipo) :
                new ObjectParameter("IdNomina_tipo", typeof(int));
    
            var idNomina_tipo_LiquiParameter = idNomina_tipo_Liqui.HasValue ?
                new ObjectParameter("IdNomina_tipo_Liqui", idNomina_tipo_Liqui) :
                new ObjectParameter("IdNomina_tipo_Liqui", typeof(int));
    
            var idPeriodoParameter = idPeriodo.HasValue ?
                new ObjectParameter("IdPeriodo", idPeriodo) :
                new ObjectParameter("IdPeriodo", typeof(int));
    
            var fecha_InicioParameter = fecha_Inicio.HasValue ?
                new ObjectParameter("Fecha_Inicio", fecha_Inicio) :
                new ObjectParameter("Fecha_Inicio", typeof(System.DateTime));
    
            var fecha_FinParameter = fecha_Fin.HasValue ?
                new ObjectParameter("Fecha_Fin", fecha_Fin) :
                new ObjectParameter("Fecha_Fin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spROLES_Rpt011_Result>("spROLES_Rpt011", idEmpresaParameter, idNomina_tipoParameter, idNomina_tipo_LiquiParameter, idPeriodoParameter, fecha_InicioParameter, fecha_FinParameter);
        }
    
        public virtual ObjectResult<spROLES_Rpt012_Result> spROLES_Rpt012(Nullable<int> idEmpresa, Nullable<int> idNomina_tipo, Nullable<int> anio, Nullable<int> mes, Nullable<int> idPeriodo)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idNomina_tipoParameter = idNomina_tipo.HasValue ?
                new ObjectParameter("IdNomina_tipo", idNomina_tipo) :
                new ObjectParameter("IdNomina_tipo", typeof(int));
    
            var anioParameter = anio.HasValue ?
                new ObjectParameter("Anio", anio) :
                new ObjectParameter("Anio", typeof(int));
    
            var mesParameter = mes.HasValue ?
                new ObjectParameter("Mes", mes) :
                new ObjectParameter("Mes", typeof(int));
    
            var idPeriodoParameter = idPeriodo.HasValue ?
                new ObjectParameter("IdPeriodo", idPeriodo) :
                new ObjectParameter("IdPeriodo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spROLES_Rpt012_Result>("spROLES_Rpt012", idEmpresaParameter, idNomina_tipoParameter, anioParameter, mesParameter, idPeriodoParameter);
        }
    }
}
