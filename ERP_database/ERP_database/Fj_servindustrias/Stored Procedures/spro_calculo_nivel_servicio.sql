
CREATE PROCEDURE [Fj_servindustrias].[spro_calculo_nivel_servicio] (
@IdEmpresa int,
@IdNomina numeric,
@IdNominaTipo numeric,
@IdPEriodo numeric,
@IdNivelServicio numeric,
@Observacion varchar(max),
@IdUsuario varchar(100)
)
AS
begin
--declare
--@IdEmpresa int,
--@IdNomina numeric,
--@IdNominaTipo numeric,
--@IdPEriodo numeric,
--@IdNivelServicio numeric(18,0),
--@IdUsuario varchar(10),
--@Observacion varchar(max)

--set @IdEmpresa =2
--set @IdNomina =1
--set @IdNominaTipo =3
--set @IdPEriodo= 202002
--set @IdNivelServicio=1
--set @IdUsuario='admin'
--set @Observacion=''



delete Fj_servindustrias.ro_fectividad_Entrega_servicio_det where 
IdEmpresa=@IdEmpresa and IdNivelServicio=@IdNivelServicio

if( (select COUNT(*) from Fj_servindustrias.ro_fectividad_Entrega_servicio where IdEmpresa=@IdEmpresa and IdNivelServicio=@IdNivelServicio)=0)
insert into Fj_servindustrias.ro_fectividad_Entrega_servicio
(
IdEmpresa,			IdNivelServicio,IdServicioTipo,			IdNomina_Tipo,				IdNomina_tipo_Liq,			IdPeriodo,
Observacion,		Estado,						IdUsuario,					IdUsuarioAnu,				MotivoAnu,		
IdUsuarioUltModi,	FechaAnu,					FechaTransac,				FechaUltModi
)
values
(
@IdEmpresa,			@IdNivelServicio,3,				@IdNomina,					@IdNominaTipo,				@IdPEriodo,
@Observacion,		1,							@IdUsuario,					null,						null,
null,				null,						GETDATE(),					null
)

insert into Fj_servindustrias.ro_fectividad_Entrega_servicio_det
(
IdEmpresa,			IdNivelServicio,			Secuencia,			IdRuta,				IdEmpleado,			Efe_car_bebi,			Efe_car_bebi_apl,
Efe_vol_bebi,		Efe_vol_bebi_apl,			Efe_ent_bebi,		Efe_ent_bebi_apl,	Efe_car_alim,		Efe_car_alim_ap,		Efe_vol_alim,
Efe_vol_alim_apl,	Efe_ent_alim,				Efe_ent_alim_apl,	Efe_serv,		Efe_ser_apl,		Nivel_servicio,				Valor_volumen,
Valor_servicio,		Por_bebida,					Por_alimento
)
SELECT 
efec.IdEmpresa,		@IdNivelServicio,				 ROW_NUMBER() OVER(ORDER BY efec.idempresa DESC) AS Row, efe_det.IdRuta,efe_det.IdEmpleado,0,0,
0,					0,							0,					0,					0,					0,						0,
0,					0,							0,					0,					0,					0,						0,
0,					0,							0

FROM            Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado AS efec LEFT OUTER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado_Det AS efe_det ON efec.IdEmpresa = efe_det.IdEmpresa AND efec.IdNomina_Tipo = efe_det.IdNomina_Tipo AND 
                         efec.IdNomina_tipo_Liq = efe_det.IdNomina_tipo_Liq AND efec.IdPeriodo = efe_det.IdPeriodo AND efec.IdEfectividad = efe_det.IdEfectividad

where efec.IdEmpresa=@IdEmpresa
and efec.IdNomina_Tipo=@IdNomina
and efec.IdNomina_tipo_Liq=@IdNominaTipo
and efec.IdPeriodo=@IdPEriodo
GROUP BY efec.IdEmpresa, efec.IdNomina_Tipo, efec.IdNomina_tipo_Liq, efec.IdPeriodo, efe_det.IdEmpleado,efe_det.IdRuta





update
Fj_servindustrias.ro_fectividad_Entrega_servicio_det set
Efe_car_bebi=		efe_det.Recuperacion_cartera,
Efe_car_bebi_apl=	efe_det.Recuperacion_cartera_aplica,
Efe_vol_bebi=		efe_det.Efectividad_Volumen,	
Efe_vol_bebi_apl=	efe_det.Efectividad_Volumen_aplica,
Efe_ent_bebi=		efe_det.Efectividad_Entrega,
Efe_ent_bebi_apl=	efe_det.Efectividad_Entrega_aplica,
Por_bebida=Porcentaje

FROM            Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado AS efec INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado_Det AS efe_det ON efec.IdEmpresa = efe_det.IdEmpresa AND efec.IdNomina_Tipo = efe_det.IdNomina_Tipo AND 
                         efec.IdNomina_tipo_Liq = efe_det.IdNomina_tipo_Liq AND efec.IdPeriodo = efe_det.IdPeriodo AND efec.IdEfectividad = efe_det.IdEfectividad INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_tipoServicio ON efec.IdEmpresa = Fj_servindustrias.ro_fectividad_Entrega_tipoServicio.IdEmpresa AND 
                         efec.IdServicioTipo = Fj_servindustrias.ro_fectividad_Entrega_tipoServicio.IdServicio INNER JOIN
                         Fj_servindustrias.vwro_fectividad_Entrega_servicio_det ON efe_det.IdEmpresa = Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdEmpresa AND 
                         efe_det.IdNomina_Tipo = Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdNomina_Tipo AND efe_det.IdNomina_tipo_Liq = Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdNomina_tipo_Liq AND 
                         efe_det.IdPeriodo = Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdPeriodo AND efe_det.IdEmpleado = Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdEmpleado INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det ON Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdEmpresa = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpresa AND 
                         Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdNivelServicio = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdNivelServicio AND 
                         Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.Secuencia = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Secuencia AND 
                         Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdRuta = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdRuta AND 
                         Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdEmpleado = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpleado
where 
efec.IdEmpresa=@IdEmpresa
and efec.IdNomina_Tipo=@IdNomina
and efec.IdNomina_tipo_Liq=@IdNominaTipo
and efec.IdPeriodo=@IdPEriodo
and efec.IdServicioTipo=1
and vwro_fectividad_Entrega_servicio_det.IdEmpresa=@IdEmpresa
and vwro_fectividad_Entrega_servicio_det.IdNomina_Tipo=@IdNomina
and vwro_fectividad_Entrega_servicio_det.IdNomina_tipo_Liq=@IdNominaTipo
and vwro_fectividad_Entrega_servicio_det.IdPeriodo=@IdPEriodo



update
Fj_servindustrias.ro_fectividad_Entrega_servicio_det set
Efe_car_alim=		efe_det.Recuperacion_cartera,
Efe_car_alim_ap=	efe_det.Recuperacion_cartera_aplica,
Efe_vol_alim=		efe_det.Efectividad_Volumen,	
Efe_vol_alim_apl=	efe_det.Efectividad_Volumen_aplica,
Efe_ent_alim=		efe_det.Efectividad_Entrega,
Efe_ent_alim_apl=	efe_det.Efectividad_Entrega_aplica,
Por_alimento=Porcentaje

FROM            Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado AS efec INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado_Det AS efe_det ON efec.IdEmpresa = efe_det.IdEmpresa AND efec.IdNomina_Tipo = efe_det.IdNomina_Tipo AND 
                         efec.IdNomina_tipo_Liq = efe_det.IdNomina_tipo_Liq AND efec.IdPeriodo = efe_det.IdPeriodo AND efec.IdEfectividad = efe_det.IdEfectividad INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_tipoServicio ON efec.IdEmpresa = Fj_servindustrias.ro_fectividad_Entrega_tipoServicio.IdEmpresa AND 
                         efec.IdServicioTipo = Fj_servindustrias.ro_fectividad_Entrega_tipoServicio.IdServicio INNER JOIN
                         Fj_servindustrias.vwro_fectividad_Entrega_servicio_det ON efe_det.IdEmpresa = Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdEmpresa AND 
                         efe_det.IdNomina_Tipo = Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdNomina_Tipo AND efe_det.IdNomina_tipo_Liq = Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdNomina_tipo_Liq AND 
                         efe_det.IdPeriodo = Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdPeriodo AND efe_det.IdEmpleado = Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdEmpleado INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det ON Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdEmpresa = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpresa AND 
                         Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdNivelServicio = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdNivelServicio AND 
                         Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.Secuencia = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Secuencia AND 
                         Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdRuta = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdRuta AND 
                         Fj_servindustrias.vwro_fectividad_Entrega_servicio_det.IdEmpleado = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpleado
where 
efec.IdEmpresa=@IdEmpresa
and efec.IdNomina_Tipo=@IdNomina
and efec.IdNomina_tipo_Liq=@IdNominaTipo
and efec.IdPeriodo=@IdPEriodo
and efec.IdServicioTipo=2
and vwro_fectividad_Entrega_servicio_det.IdEmpresa=@IdEmpresa
and vwro_fectividad_Entrega_servicio_det.IdNomina_Tipo=@IdNomina
and vwro_fectividad_Entrega_servicio_det.IdNomina_tipo_Liq=@IdNominaTipo
and vwro_fectividad_Entrega_servicio_det.IdPeriodo=@IdPEriodo


-- CALCULANDO PORCENTAJE DE NIVEL DE SERVICIO
update Fj_servindustrias.ro_fectividad_Entrega_servicio_det set
Efe_serv= (((Efe_ent_bebi+Efe_vol_bebi)/2)*Por_bebida)+ (((Efe_ent_alim+Efe_vol_alim)/2)*Por_alimento)
where IdEmpresa=@IdEmpresa and IdNivelServicio=@IdNivelServicio

-- CALCULANDO PORCENTAJE QUE APLICA NE NIVEL DE SERVICIO
update Fj_servindustrias.ro_fectividad_Entrega_servicio_det set 
Efe_ser_apl=isnull((select Fj_servindustrias.ro_Calculo_Pago_Variable_Porcentaje_servicio.Efec_aplica from Fj_servindustrias.ro_Calculo_Pago_Variable_Porcentaje_servicio
where Efe_serv between Fj_servindustrias.ro_Calculo_Pago_Variable_Porcentaje_servicio.Efec_desde and  Fj_servindustrias.ro_Calculo_Pago_Variable_Porcentaje_servicio.Efec_hasta),0)



-- CALCULANDO VALOR MONETATARIO NIVEL DE SERVICIO
update Fj_servindustrias.ro_fectividad_Entrega_servicio_det set
Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Valor_servicio=(Fj_servindustrias.ro_Grupo_empleado.Valor_bono*0.8)*Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_ser_apl
FROM            Fj_servindustrias.ro_fectividad_Entrega_servicio_det INNER JOIN
                         dbo.ro_empleado ON Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpresa = dbo.ro_empleado.IdEmpresa AND 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpleado = dbo.ro_empleado.IdEmpleado INNER JOIN
                         Fj_servindustrias.ro_Grupo_empleado ON dbo.ro_empleado.IdEmpresa = Fj_servindustrias.ro_Grupo_empleado.IdEmpresa AND dbo.ro_empleado.IdGrupo = Fj_servindustrias.ro_Grupo_empleado.IdGrupo
where Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpresa=@IdEmpresa and IdNivelServicio=@IdNivelServicio


-- CALCULANDO VALOR MONETATARIO CARTERA
update Fj_servindustrias.ro_fectividad_Entrega_servicio_det set
Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Valor_volumen=(Fj_servindustrias.ro_Grupo_empleado.Valor_bono*0.2)*Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_car_bebi_apl
FROM            Fj_servindustrias.ro_fectividad_Entrega_servicio_det INNER JOIN
                         dbo.ro_empleado ON Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpresa = dbo.ro_empleado.IdEmpresa AND 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpleado = dbo.ro_empleado.IdEmpleado INNER JOIN
                         Fj_servindustrias.ro_Grupo_empleado ON dbo.ro_empleado.IdEmpresa = Fj_servindustrias.ro_Grupo_empleado.IdEmpresa AND dbo.ro_empleado.IdGrupo = Fj_servindustrias.ro_Grupo_empleado.IdGrupo
where Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpresa=@IdEmpresa and IdNivelServicio=@IdNivelServicio

END