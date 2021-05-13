
 CREATE function [dbo].[calcular_dias_trabajados]
 (
   @IdEmpresa int,
  @IdEmpleado numeric,
  @Fecha_inicio date,
  @Fecha_fin date,
  @fecha_ingreso date,
  @em_status varchar(10),
  @Fecha_salida date,
  @IdNominaTipo int,
  @IdNomina int

 )
 returns int 
 as
 begin 
   declare 
   @dias int,
   @dias_susp int,
   @dias_fal int,
   @dias_vacasiones int,
   @Resta_dias_trab_idas_fal bit


  --declare  @IdEmpleado numeric
  --declare @IdEmpresa int
  --declare @Fecha_inicio date
  --declare @Fecha_fin date
  --declare @fecha_ingreso date
  --declare @em_status varchar(10)
  --declare @Fecha_salida date


  --set @IdEmpresa=2
  --set @IdEmpleado=249
  --set @Fecha_inicio='2020-03-01'
  --set @Fecha_fin='2020-03-30'
  --set @fecha_ingreso='2019-02-28'
  --set @em_status='EST_ACT'
  --set @Fecha_salida=null
----------------------------------------------------------------------------------------------------------------------------------------------
-------------CALCULANDO LOS DIAS TRABAJADOS BASADO EN PERIODO--------------------------- -----------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------

   SET @Fecha_fin = CASE WHEN DAY(@Fecha_fin) = 31 THEN DATEADD(DAY,-1,@Fecha_fin) 
						WHEN DAY(@Fecha_fin) = 28 THEN DATEADD(DAY,2,@Fecha_fin)
						WHEN DAY(@Fecha_fin) = 29 THEN DATEADD(DAY,1,@Fecha_fin)
						ELSE @Fecha_fin
						END

   if(@em_status!='EST_LIQ')
   set @dias =  CASE WHEN @fecha_ingreso<=@Fecha_inicio 
	THEN DATEDIFF(day ,@Fecha_inicio, @Fecha_fin)+1
   ELSE
	DATEDIFF(day ,@fecha_ingreso, @Fecha_fin)+1 END
   if(@em_status='EST_PLQ')
   set @dias= DATEDIFF(day ,@Fecha_inicio, @Fecha_salida)+1


----------------------------------------------------------------------------------------------------------------------------------------------
-------------CALCULANDO FALTA POR EMPLEADO--------------------------- ------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------
select @Resta_dias_trab_idas_fal=isnull(restas_dias_con_falta,0) from ro_Nomina_Tipoliqui where IdEmpresa=@IdEmpresa and IdNomina_Tipo=@IdNomina and IdNomina_TipoLiqui=@IdNominaTipo
   if(@Resta_dias_trab_idas_fal=1)
   select @dias_susp=ISNULL( COUNT(IdEmpleado),0) from Fj_servindustrias.ro_marcaciones_x_empleado_x_incidentes_falt_Perm where IdEmpresa=@IdEmpresa
   and IdEmpleado=@IdEmpleado
   and IdEmpresa=@IdEmpresa
   and es_fecha_registro between @Fecha_inicio and @Fecha_fin
   and Id_catalogo_Cat  IN('SUSP')

   
   select @Resta_dias_trab_idas_fal=isnull(restas_dias_con_falta,0) from ro_Nomina_Tipoliqui where IdEmpresa=@IdEmpresa and IdNomina_Tipo=@IdNomina and IdNomina_TipoLiqui=@IdNominaTipo
   if(@Resta_dias_trab_idas_fal=1)
   select @dias_fal=ISNULL( COUNT(IdEmpleado),0) from Fj_servindustrias.ro_marcaciones_x_empleado_x_incidentes_falt_Perm where IdEmpresa=@IdEmpresa
   and IdEmpleado=@IdEmpleado
   and IdEmpresa=@IdEmpresa
   and es_fecha_registro between @Fecha_inicio and @Fecha_fin
   and Id_catalogo_Cat  IN('FAL')
   
----------------------------------------------------------------------------------------------------------------------------------------------
-------------CALCULANDO DIAS DE VACACIONES--------------------------- ------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------




select @dias_vacasiones=sum( a.Dias_a_disfrutar)
from 
(
select 
case when  Fecha_Desde>=@Fecha_inicio and Fecha_Hasta<=@Fecha_fin then Dias_a_disfrutar end Dias_a_disfrutar
	from ro_Solicitud_Vacaciones_x_empleado where IdEmpresa=@idempresa
	and ro_Solicitud_Vacaciones_x_empleado.idempleado=@idempleado
	and ro_Solicitud_Vacaciones_x_empleado.Estado='A'
    and (( Fecha_Desde between @Fecha_inicio and @Fecha_fin) or  ( Fecha_Hasta between @Fecha_inicio and @Fecha_fin) )
	)a


	if(@idempresa in(2))
    set @dias=@dias-(isnull( @dias_vacasiones,0)+isnull(@dias_susp,0)+isnull(@dias_fal,0)*2)
   return @dias
   end;