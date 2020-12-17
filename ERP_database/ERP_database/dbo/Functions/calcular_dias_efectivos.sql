
 CREATE function [dbo].[calcular_dias_efectivos]
 (
  @IdEmpresa int,
  @IdEmpleado numeric,
  @Fecha_inicio date,
  @Fecha_fin date
 )
 returns int 
 as
 begin 

   declare
    @dias int,
    @DiasIntegrales int
    
	select @dias= count(idempleado) 
    FROM  dbo.vwro_marcaciones_dias_efectivos 
    where idempresa=@IdEmpresa
	and  idempleado=@Idempleado  and es_fecha_registro between @Fecha_inicio and @Fecha_fin
	and Id_catalogo_Cat  in ('ASIST','ATRA','S/S')

	select @DiasIntegrales=cast( dias_integrales as int) from  Fj_servindustrias.ro_Parametro_calculo_Horas_Extras where idempresa=@IdEmpresa
	if(@dias >@DiasIntegrales)
	begin
	set @dias=@DiasIntegrales
	end
   return @dias
 end;