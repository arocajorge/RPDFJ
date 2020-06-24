

 CREATE function [dbo].[calcular_dias_trabajados]
 (
   @IdEmpresa int,
  @IdEmpleado numeric,
  @Fecha_inicio date,
  @Fecha_fin date,
  @fecha_ingreso date,
  @em_status varchar(10),
  @Fecha_salida date

 )
 returns int 
 as
 begin 
   declare 
   @dias int,
   @dias_falta int,
   @dias_vacasiones int


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

   if(@em_status='EST_ACT')
   set @dias =  CASE WHEN @fecha_ingreso<=@Fecha_inicio 
	THEN DATEDIFF(day ,@Fecha_inicio, @Fecha_fin)+1
   ELSE
	DATEDIFF(day ,@fecha_ingreso, @Fecha_fin)+1 END
   if(@em_status='EST_PLQ')
   set @dias= DATEDIFF(day ,@Fecha_inicio, @Fecha_salida)+1


----------------------------------------------------------------------------------------------------------------------------------------------
-------------CALCULANDO FALTA POR EMPLEADO--------------------------- ------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------


   select @dias_falta=ISNULL( COUNT(IdEmpleado),0) from Fj_servindustrias.ro_marcaciones_x_empleado_x_incidentes_falt_Perm where IdEmpresa=@IdEmpresa
   and IdEmpleado=@IdEmpleado
   and IdEmpresa=@IdEmpresa
   and es_fecha_registro between @Fecha_inicio and @Fecha_fin
   and Id_catalogo_Cat='FAL'
  -- return( @dias-@dias_falta)
----------------------------------------------------------------------------------------------------------------------------------------------
-------------CALCULANDO DIAS DE VACACIONES--------------------------- ------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------




select @dias_vacasiones=
iif( month (Fecha_Desde)!=month(Fecha_Hasta), 
	iif(Fecha_Desde between @Fecha_inicio and @Fecha_fin, DATEDIFF(day ,Fecha_Desde, @Fecha_fin)+1 , dATEDIFF(day ,@Fecha_inicio, Fecha_hasta)+1   )  ,dias_a_disfrutar)  
	from ro_Solicitud_Vacaciones_x_empleado where IdEmpresa=@idempresa
	and ro_Solicitud_Vacaciones_x_empleado.idempleado=@idempleado
   and (( Fecha_Desde between @Fecha_inicio and @Fecha_fin) or  ( Fecha_Hasta between @Fecha_inicio and @Fecha_fin) )


  --SELECT @dias-(isnull( @dias_vacasiones,0)+isnull(@dias_falta,0))

  return @dias-(isnull( @dias_vacasiones,0)+isnull(@dias_falta,0))
   end;