/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------


select * from tb_empresa

declare @IdEmpresa int
declare @nom_Empresa varchar(50)
set @IdEmpresa =3
set @nom_Empresa ='GLOBAL S.A'


if (@IdEmpresa=0 or @nom_Empresa='')
begin
	print 'no hay datos de empresa id y nombre'
	return 
end 


delete caj_parametro where IdEmpresa=@IdEmpresa
DELETE com_parametro WHERE IdEmpresa=@IdEmpresa
DELETE cp_parametros WHERE IdEmpresa=@IdEmpresa
delete Af_Parametros WHERE IdEmpresa=@IdEmpresa
delete fa_parametro WHERE IdEmpresa=@IdEmpresa
delete tb_sis_Documento_Tipo_x_Empresa WHERE IdEmpresa=@IdEmpresa
delete [tb_banco_procesos_bancarios_x_empresa]  WHERE IdEmpresa=@IdEmpresa

DELETE Af_Activo_fijo_tipo WHERE IdEmpresa=@IdEmpresa


delete com_Motivo_Orden_Compra WHERE IdEmpresa=@IdEmpresa

delete [dbo].[in_Marca] WHERE IdEmpresa=@IdEmpresa
delete [dbo].[in_Motivo_Inven] WHERE IdEmpresa=@IdEmpresa
delete [dbo].[in_presentacion] WHERE IdEmpresa=@IdEmpresa
delete [dbo].[in_ProductoTipo] WHERE IdEmpresa=@IdEmpresa


DELETE in_subgrupo WHERE IdEmpresa=@IdEmpresa
DELETE in_grupo WHERE IdEmpresa=@IdEmpresa
DELETE in_linea WHERE IdEmpresa=@IdEmpresa
DELETE in_categorias WHERE IdEmpresa=@IdEmpresa
DELETE in_Motivo_Inven WHERE IdEmpresa=@IdEmpresa



DELETE in_movi_inven_tipo WHERE IdEmpresa=@IdEmpresa

DELETE ba_Cbte_Ban_tipo_x_ct_CbteCble_tipo WHERE IdEmpresa=@IdEmpresa
DELETE ba_tipo_nota WHERE IdEmpresa=@IdEmpresa
DELETE ba_TipoFlujo WHERE IdEmpresa=@IdEmpresa
delete ba_parametros WHERE IdEmpresa=@IdEmpresa


delete caj_Caja where IdEmpresa=@IdEmpresa



delete seg_Usuario_x_Empresa where IdEmpresa=@IdEmpresa
delete seg_Menu_x_Empresa_x_Usuario where IdEmpresa=@IdEmpresa
delete seg_Menu_x_Empresa where IdEmpresa=@IdEmpresa
--delete seg_usuario

DELETE ct_parametro where IdEmpresa=@IdEmpresa
delete ct_plancta_nivel where IdEmpresa=@IdEmpresa
delete ct_cbtecble_tipo where IdEmpresa=@IdEmpresa
delete ct_periodo where IdEmpresa=@IdEmpresa
delete ct_parametro where IdEmpresa=@IdEmpresa



delete cp_orden_pago_tipo_x_empresa where idempresa=@idempresa
delete cp_proveedor_clase where idempresa=@idempresa


delete fa_VendedorxSucursal where IdEmpresa=@IdEmpresa
delete fa_Vendedor where IdEmpresa=@IdEmpresa
delete fa_cliente_tipo where IdEmpresa=@IdEmpresa


delete tb_bodega where IdEmpresa=@IdEmpresa
delete tb_sucursal where IdEmpresa=@IdEmpresa
delete tb_empresa where IdEmpresa=@IdEmpresa

delete ro_nomina_tipo_liqui_orden where IdEmpresa=@IdEmpresa
delete ro_Nomina_Tipoliqui where IdEmpresa=@IdEmpresa
delete ro_Nomina_Tipo where IdEmpresa=@IdEmpresa
delete tb_sucursal where IdEmpresa=@IdEmpresa
delete ct_periodo where IdEmpresa=@IdEmpresa
delete tb_empresa where IdEmpresa=@IdEmpresa
delete ro_cargo where IdEmpresa=@IdEmpresa
INSERT INTO [dbo].[tb_empresa]
([IdEmpresa]	,[codigo]		,[em_nombre]	,[RazonSocial]		,[NombreComercial]		,[ContribuyenteEspecial]	,[ObligadoAllevarConta]
,[em_ruc]		,[em_gerente]	,[em_contador]  ,[em_rucContador]	,[em_telefonos]			,[em_fax]					,[em_notificacion]
,[em_direccion]	,[em_tel_int]	,[em_logo]		,[em_fondo]			,[em_fechaInicioContable],[Estado]					,[em_fechaInicioActividad])
VALUES
(@IdEmpresa				,'001'	,@nom_Empresa	,@nom_Empresa		,@nom_Empresa			,'N'						,'S'
,'0000000000000',''				,''				,'000000000000'		,''						,''							,''
,''				,''				,null			,null				,GETDATE()				,'A'						,GETDATE()
)						



INSERT INTO [dbo].[ba_tipo_nota]
		([IdEmpresa],[IdTipoNota],[Tipo],[Descripcion]	,[IdCtaCble],[IdCentroCosto],[Estado])
VALUES	(@IdEmpresa	,1			 ,'NDBA'	,'NO APLICA'	,NULL		,NULL			,'A')

INSERT INTO [dbo].[ba_tipo_nota]
		([IdEmpresa],[IdTipoNota],[Tipo],[Descripcion]	,[IdCtaCble],[IdCentroCosto],[Estado])
VALUES	(@IdEmpresa	,2			 ,'NCBA'	,'NO APLICA'	,NULL		,NULL			,'A')




---------------------------------


INSERT INTO [dbo].[tb_sucursal]
([IdEmpresa]			,[IdSucursal]	,[codigo]		,[Su_Descripcion]	,[Su_CodigoEstablecimiento],[Su_Ubicacion]		,[Su_Ruc] ,[Estado]
 ,[Su_JefeSucursal]		,[Su_Telefonos]	,[Su_Direccion] ,[IdUsuario]		,[Fecha_Transac]			,[IdUsuarioUltMod]	,[Fecha_UltMod]
 ,[IdUsuarioUltAnu]		 ,[Fecha_UltAnu],[nom_pc]       ,[ip]				,[MotiAnula]
 )
 values 
 (@IdEmpresa						,1				,'001'			,'MATRIZ'			,'001'						,''				,'0000000000000' ,'A'
 ,''					,''				,''				,''					,NULL						,NULL				,NULL
 ,NULL					,NULL			,NULL			,NULL				,NULL
 )


------------------------------------

 INSERT INTO [dbo].[tb_bodega]
([IdEmpresa]	,[IdSucursal]	,[IdBodega]							,[bo_Descripcion]	,[cod_punto_emision]	,[bo_manejaFacturacion]	,[bo_EsBodega]
,[IdUsuario]	,[Fecha_Transac],[IdUsuarioUltMod]					,[Fecha_UltMod]		,[IdUsuarioUltAnu]		,[Fecha_UltAnu]			,[nom_pc]
,[ip]			,[Estado]		,[IdEstadoAproba_x_Ing_Egr_Inven]   ,[IdCentroCosto]
)
values 
(
@IdEmpresa				,1				,1									,'Matriz'			,'001'					,'N'					,'S'
,null			,GETDATE()			,null								,null				,null					,null					,null
,null			,'A'			,NULL								,NULL
)

----------------------------- creacion de usuarios ------------------------------------------------------
---- se crea usuario admin



-----------------------------------------------------------------------------------------------------------




INSERT INTO [dbo].[seg_Menu_x_Empresa]
([IdEmpresa]	,[IdMenu]	,[Habilitado]	,[NombreAsambly_x_Emp]	,[NomFormulario_x_Emp])
SELECT        
@IdEmpresa		,IdMenu		,1				, nom_Asembly			,nom_Formulario
FROM            seg_Menu



----------------------------


INSERT INTO [dbo].[seg_Menu_x_Empresa_x_Usuario]
([IdEmpresa]	,[IdUsuario]	,[IdMenu]	,[Lectura]	,[Escritura]	,[Eliminacion])
SELECT        
@IdEmpresa		,'admin'		,IdMenu		,1			,1				,1
FROM            seg_Menu


---------------------------

INSERT INTO [dbo].[seg_Usuario_x_Empresa]
([IdUsuario],[IdEmpresa],[Observacion])
values
('admin'	,@IdEmpresa	,'')







----------------------------------------------------------------------------
----------------------------------------------------------------------------
-------------------------- BANCO ----------------------------------

INSERT INTO [dbo].[ba_Cbte_Ban_tipo_x_ct_CbteCble_tipo]
([IdEmpresa]	,[CodTipoCbteBan]	,[IdTipoCbteCble]	,[IdTipoCbteCble_Anu]
,[IdCtaCble]	,[Tipo_DebCred]
)
SELECT        
@IdEmpresa		,CodTipoCbteBan		,1					,1
,NULL			,'D'
FROM            ba_Cbte_Ban_tipo

update ba_Cbte_Ban_tipo_x_ct_CbteCble_tipo set IdTipoCbteCble=2 ,Tipo_DebCred ='C' ,IdTipoCbteCble_Anu=6 where CodTipoCbteBan='CHEQ'
update ba_Cbte_Ban_tipo_x_ct_CbteCble_tipo set IdTipoCbteCble=3 ,Tipo_DebCred ='D' ,IdTipoCbteCble_Anu=6 where CodTipoCbteBan='DEPO'
update ba_Cbte_Ban_tipo_x_ct_CbteCble_tipo set IdTipoCbteCble=4 ,Tipo_DebCred ='D' ,IdTipoCbteCble_Anu=6 where CodTipoCbteBan='NCBA'
update ba_Cbte_Ban_tipo_x_ct_CbteCble_tipo set IdTipoCbteCble=5 ,Tipo_DebCred ='C' ,IdTipoCbteCble_Anu=6 where CodTipoCbteBan='NDBA'

--select * from ct_cbtecble_tipo


INSERT INTO [dbo].[ba_TipoFlujo]	
		([IdEmpresa]	,[IdTipoFlujo]	,[IdTipoFlujoPadre]	,[Descricion]	,[Estado])
VALUES	(@IdEmpresa		,1				,null				,'NO APLICA'	,'A')
           



INSERT INTO [dbo].[ba_parametros]
([IdEmpresa]	,[El_Diario_Contable_es_modificable]	,[CiudadDefaultParaCrearCheques],[IdUsuario])
VALUES
(@IdEmpresa		,1										,'09','sysadmin')



----------------------------------------------------------------------------
----------------------------------------------------------------------------
		   

---------------------------------------------------------------------
---------------------------------------------------------------------
------------------- parametros por contabilidad ---------------------


--tipo cbtecble
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa, [IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,1, N'CD        ', N'DIARIO CONTABLE                                   ', N'A', N'S', N'CD        ', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,2, N'CHE       ', N'CHEQUE                                            ', N'A', N'N', N'CH        ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,3, N'DEP       ', N'DEPOSITO                                          ', N'A', N'N', N'DEP       ', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,4, N'NCB       ', N'NOTA CREDITO BANCARIA                             ', N'A', N'N', N'NCB       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,5, N'NDB       ', N'NOTA DEBITO BANCARIA                              ', N'A', N'N', N'NDB       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,6, N'ABAN      ', N'ANULACIONES BANCARIAS                             ', N'A', N'N', N'ABA       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,7, N'CTCXP     ', N'COMPROBANTE DE PROVEEDOR                          ', N'A', N'N', N'CCP       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,8, N'ACTCXP    ', N'ANULACION  COMPROBANTE PROVEEDOR                  ', N'A', N'N', N'ACP       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,9, N'NCCP      ', N'NOTA CREDITO POR PAGAR                            ', N'A', N'N', N'NCP       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,10, N'NDCXP     ', N'NOTA DEBITO POR PAGAR                             ', N'A', N'N', N'NDP       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,11, N'PFXP      ', N'PROVISION FACTURA X PAGAR                         ', N'A', N'N', N'PF        ', NULL, NULL, NULL, NULL, NULL, N'', CAST(N'2015-11-10 11:28:31.377' AS Date), N'')
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,12, N'AJCXP     ', N'AJUSTE DE CTAS. X  PAGAR                          ', N'A', N'N', N'PP        ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,13, N'ANCCXP    ', N'ANULACION CXP  N/C N/D                            ', N'A', N'N', N'ANC       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,14, N'RTXPRV    ', N'RETENCION POR PROVEEDOR                           ', N'A', N'N', N'RPV       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,15, N'ARTXPR    ', N'ANULACION RETENCION POR PROVEEDOR                 ', N'A', N'N', N'ARP       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,16, N'CPANT     ', N'CONCILIACION X CXP                                ', N'A', N'N', N'CANT      ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,17, N'CTOP      ', N'COMPROBANTE ORDEN DE PAGO                         ', N'A', N'N', N'COP       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,18, N'ANUOP     ', N'ANULACION ORDEN PAGO                              ', N'A', N'N', N'AOP       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,19, N'CVTA      ', N'COMPROBANTE DE VENTA X CLIENTE                    ', N'A', N'N', N'CV        ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,20, N'N/C       ', N'NOTAS DE CREDITO X CLIENTE                        ', N'A', N'N', N'N/C       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,21, N'N/D       ', N'NOTAS DE DEBITO X CLIENTE                         ', N'A', N'N', N'N/D       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,22, N'AVTANCD   ', N'ANULACION DE CBTES VTA/NC/ND CLIENTE              ', N'A', N'N', N'AN/D      ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,23, N'INGCAJ    ', N'INGRESO CAJA                                      ', N'A', N'N', N'ICJ       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,24, N'EGRCAJ    ', N'EGRESO CAJA                                       ', N'A', N'N', N'ECJ       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,25, N'AIECAJ    ', N'ANULACION ING/EGR CAJA                            ', N'A', N'N', N'ACJ       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,26, N'IMP       ', N'IMPORTACIONES                                     ', N'A', N'N', N'IMP       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,27, N'AIMP      ', N'ANULACION IMPORTACIONES                           ', N'A', N'N', N'AIM       ', 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,28, N'COMPR     ', N'COMPRAS                                           ', N'A', N'N', N'CMP       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,29, N'COMPR     ', N'ANULACION DE COMPRAS                              ', N'A', N'N', N'CMP       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,30, N'SI        ', N'SALDO INICIAL                                     ', N'A', N'S', N'SIN       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,31, N'CM        ', N'CIERRE DE MES                                     ', N'A', N'N', N'CM        ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ct_cbtecble_tipo] (IdEmpresa,[IdTipoCbte], [CodTipoCbte], [tc_TipoCbte], [tc_Estado], [tc_Interno], [tc_Nemonico], [IdTipoCbte_Anul], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [MotiAnula]) VALUES (@IdEmpresa ,32, N'RP        ', N'ROL DE PAGOS                                      ', N'A', N'N', N'RP        ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)





insert into ct_parametro
(IdEmpresa,IdTipoCbte_SaldoInicial,IdTipoCbte_AsientoCierre_Anual )
values
(@IdEmpresa,1,1)



----------------------------------------------------------------
----------------------------------------------------------------
--------------- Periodo POR CONTABILIDAD ---------------

declare @W_Count int
declare @IdAnio_Actual int
declare @w_fechaIni Date
declare @w_fechaFin Date
declare @w_IdPeriodo int

set @IdAnio_Actual =  DATEPART(year, GETDATE()) 
set @w_fechaIni=cast( '01-01-' + cast(@IdAnio_Actual as varchar(4)) as Date)
set @w_fechaFin= DATEADD(month,1, @w_fechaIni)
set @w_fechaFin= DATEADD(DAY,-1, @w_fechaFin)

set @W_Count =1
set @w_IdPeriodo = (@IdAnio_Actual * 100)+@W_Count



while (@W_Count<=12)
begin

	insert into ct_periodo 
	(IdEmpresa	,IdPeriodo		,IdanioFiscal	,pe_mes		,pe_FechaIni	,pe_FechaFin	,pe_cerrado		,pe_estado)
	values
	(@IdEmpresa		   , @w_IdPeriodo	,@IdAnio_Actual ,@W_Count	,@w_fechaIni	,@w_fechaFin	,'N'			,'A')
	
	set @W_Count=@W_Count+1

	set @w_fechaIni=DATEADD(month,1,@w_fechaIni)
	set @w_fechaFin= DATEADD(month,1, @w_fechaIni)
	set @w_fechaFin= DATEADD(DAY,-1, @w_fechaFin)
	set @w_IdPeriodo = (@IdAnio_Actual * 100)+@W_Count


end 



----------------------------------------------------------------
--------------------------PARAMETRIZACION inventario -----------------

INSERT INTO [dbo].[in_movi_inven_tipo]  
		([IdEmpresa],[IdMovi_inven_tipo] ,[Codigo],[tm_descripcion] ,[cm_tipo_movi] ,[cm_interno] ,[cm_descripcionCorta] ,[Estado]	,[IdTipoCbte]	)
values	(@IdEmpresa	,1					,1			,'INGRESOS'		,'+'			,'N'		,'ING'					,'A'		,1)
INSERT INTO [dbo].[in_movi_inven_tipo]  
		([IdEmpresa],[IdMovi_inven_tipo] ,[Codigo],[tm_descripcion] ,[cm_tipo_movi] ,[cm_interno] ,[cm_descripcionCorta] ,[Estado]	,[IdTipoCbte]	)
values	(@IdEmpresa	,2					,1			,'EGRESOS'		,'-'			,'N'		,'EGR'					,'A'		,1)


INSERT INTO [dbo].[in_movi_inven_tipo]  
		([IdEmpresa],[IdMovi_inven_tipo] ,[Codigo],[tm_descripcion] ,[cm_tipo_movi] ,[cm_interno] ,[cm_descripcionCorta] ,[Estado]	,[IdTipoCbte]	)
values	(@IdEmpresa	,3					,3			,'INGRESOS x DEV. EN VTA'		,'+'			,'N'		,'IDV'					,'A'		,1)

INSERT INTO [dbo].[in_movi_inven_tipo]  
		([IdEmpresa],[IdMovi_inven_tipo] ,[Codigo],[tm_descripcion] ,[cm_tipo_movi] ,[cm_interno] ,[cm_descripcionCorta] ,[Estado]	,[IdTipoCbte]	)
values	(@IdEmpresa	,4					,4			,'INGRESOS x ANU DE FACTURAS'		,'+'			,'N'		,'IANF'					,'A'		,1)

INSERT INTO [dbo].[in_movi_inven_tipo]  
		([IdEmpresa],[IdMovi_inven_tipo] ,[Codigo],[tm_descripcion] ,[cm_tipo_movi] ,[cm_interno] ,[cm_descripcionCorta] ,[Estado]	,[IdTipoCbte]	)
values	(@IdEmpresa	,5				,5			,'INGRESOS x TRANSFERENCIAS'		,'+'			,'N'		,'IXTR'					,'A'		,1)


INSERT INTO [dbo].[in_movi_inven_tipo]  
		([IdEmpresa],[IdMovi_inven_tipo] ,[Codigo],[tm_descripcion] ,[cm_tipo_movi] ,[cm_interno] ,[cm_descripcionCorta] ,[Estado]	,[IdTipoCbte]	)
values	(@IdEmpresa	,6				,6			,'ANULACION DE EGRESOS'		,'-'			,'N'		,'AEG'					,'A'		,1)


INSERT INTO [dbo].[in_movi_inven_tipo]  
		([IdEmpresa],[IdMovi_inven_tipo] ,[Codigo],[tm_descripcion] ,[cm_tipo_movi] ,[cm_interno] ,[cm_descripcionCorta] ,[Estado]	,[IdTipoCbte]	)
values	(@IdEmpresa	,7				,7			,'EGRESOS x TRANSFERENCIAS'		,'-'			,'N'		,'ETR'					,'A'		,1)


INSERT INTO [dbo].[in_movi_inven_tipo]  
		([IdEmpresa],[IdMovi_inven_tipo] ,[Codigo],[tm_descripcion] ,[cm_tipo_movi] ,[cm_interno] ,[cm_descripcionCorta] ,[Estado]	,[IdTipoCbte]	)
values	(@IdEmpresa	,8				,8			,'ANULACION DE INGRESOS'		,'-'			,'N'		,'AING'					,'A'		,1)



INSERT INTO [dbo].[in_movi_inven_tipo]  
		([IdEmpresa],[IdMovi_inven_tipo] ,[Codigo],[tm_descripcion] ,[cm_tipo_movi] ,[cm_interno] ,[cm_descripcionCorta] ,[Estado]	,[IdTipoCbte]	)
values	(@IdEmpresa	,9				,9			,'EGRESO X FACTURA'		,'-'			,'N'		,'AING'					,'A'		,1)




INSERT INTO in_categorias
([IdEmpresa]	,[IdCategoria]	,[ca_Categoria]	,[IdCategoriaPadre]	,[ca_Posicion]	,[ca_indexIcono]	,[Estado]	,[ca_nivel],[IdUsuario]	,[Fecha_Transac],RutaPadre)
values
(@IdEmpresa					,'001'				,'No Disponible',null				,1				,0					,'A'		,1			,'sysadmin'			,GETDATE(),'')




INSERT INTO in_linea
([IdEmpresa]	,[IdCategoria]	,[IdLinea]	,[cod_linea]	,[nom_linea]	,[abreviatura]	,[observacion]	,[Estado]	,[IdUsuario]	,[Fecha_Transac])
values
(@IdEmpresa					,'001'			,'001'		,''				,'No Disponible',''				,''				,'A'		,'sysadmin'		,GETDATE()   )           




INSERT INTO in_grupo
([IdEmpresa]	,[IdCategoria]	,[IdLinea]	,[IdGrupo]	,[cod_grupo]	,[nom_grupo]	,[Estado]	,[abreviatura]	,[observacion]	,[IdUsuario]	,[Fecha_Transac])
values
(@IdEmpresa					,'001'			,'001'		,'001'		,'001'			,'No Disponible','A'		,''				,''				,'sysAdmin'		,GETDATE())


INSERT INTO [dbo].[in_subgrupo]
([IdEmpresa],[IdCategoria],[IdLinea],[IdGrupo],[IdSubgrupo],[abreviatura],[cod_subgrupo],[nom_subgrupo],[observacion],[Estado] ,[IdUsuario] ,[Fecha_Transac])
values
(@IdEmpresa				,'001'			,'001'	,'001'		,'001'		,''			,'001'			,'No Disponible',''			  ,'A'		,'sysadmin'	,GETDATE())
           


INSERT INTO [dbo].[in_Marca]
([IdEmpresa]	,[IdMarca]	,[Descripcion]		,[Estado]	,[IdUsuario]	,[Fecha_Transac])
values
(@IdEmpresa				,1			,'No Disponible'	,'A'		,'sysadmin'		,GETDATE())





INSERT INTO [dbo].[in_Motivo_Inven]
([IdEmpresa]			,[IdMotivo_Inv]	,[Cod_Motivo_Inv]	,[Desc_mov_inv]	,[Genera_Movi_Inven]	,[Genera_CXP]
,[Exigir_Punto_Cargo]	,[estado]		,[Fecha_Transac]	,[IdUsuarioUltMod]
,es_Inven_o_Consumo, Tipo_Ing_Egr)
values
(@IdEmpresa				,1				,1					,'Inventario'	,'N'				,'N'
,'N'					,'A'			,GETDATE()			,'sysadmin'
,'TIC_INVEN'			,'ING'
)


INSERT INTO [dbo].[in_Motivo_Inven]
([IdEmpresa]			,[IdMotivo_Inv]	,[Cod_Motivo_Inv]	,[Desc_mov_inv]	,[Genera_Movi_Inven]	,[Genera_CXP]
,[Exigir_Punto_Cargo]	,[estado]		,[Fecha_Transac]	,[IdUsuarioUltMod]
,es_Inven_o_Consumo, Tipo_Ing_Egr)
values
(@IdEmpresa				,2				,2					,'Inventario'	,'N'				,'N'
,'N'					,'A'			,GETDATE()			,'sysadmin'
,'TIC_INVEN'			,'EGR'
)




INSERT INTO [dbo].[in_presentacion]
([IdEmpresa]	,[IdPresentacion]	,[nom_presentacion]	,[estado])
values
(@IdEmpresa		,1					,'No Disponible'	,'A')



INSERT INTO [dbo].[in_ProductoTipo]
([IdEmpresa]	,[IdProductoTipo]	,[tp_descripcion]	,[tp_EsCombo]	,[tp_ManejaInven]
,[IdUsuario]	,[Fecha_Transac]	,[Estado]			,[EsMateriaPrima],[EsProductoTerminado]
)
values
(@IdEmpresa				,1					,'Bien'				,'N'			,'S'
,'sysadmin'		,GETDATE()			,'A'				,'N'			,'N'
)



INSERT INTO [dbo].[in_ProductoTipo]
([IdEmpresa]	,[IdProductoTipo]	,[tp_descripcion]	,[tp_EsCombo]	,[tp_ManejaInven]
,[IdUsuario]	,[Fecha_Transac]	,[Estado]			,[EsMateriaPrima],[EsProductoTerminado]
)
values
(@IdEmpresa				,2					,'Servicios'				,'N'			,'S'
,'sysadmin'		,GETDATE()			,'A'				,'N'			,'N'
)

/*

INSERT INTO [dbo].[in_parametro]
([IdEmpresa]								,[IdCentroCosto_Padre_a_cargar]			,[LabelCentroCosto]							,[IdMovi_inven_tipo_egresoBodegaOrigen]
,[IdMovi_inven_tipo_ingresoBodegaDestino]	,[Maneja_Stock_Negativo]				,[Usuario_Escoge_Motivo]					,[IdMovi_inven_tipo_egresoAjuste]	
,[IdMovi_inven_tipo_ingresoAjuste]			,[Mostrar_CentroCosto_en_transacciones]	,[Rango_Busqueda_Transacciones]				,[pa_EstadoInicial_Pedido]		
,[IdCtaCble_Inven]							,[IdCtaCble_CostoInven]					,[IdTipoCbte_CostoInven]					,[IdBodegaSuministro]			
,[IdCentro_Costo_Inventario]				,[IdCentro_Costo_Costo]					,[IdTipoCbte_CostoInven_Reverso]			,[IdMovi_Inven_tipo_x_anu_Ing]
,[IdMovi_Inven_tipo_x_anu_Egr]				,[IdMovi_Inven_tipo_Ing_Ajust_fis_x_defa],[IdMovi_Inven_tipo_Egr_Ajust_fis_x_defa]	,[ApruebaAjusteFisicoAuto]
,[IdSucursal_Suministro]					,[IdEstadoAproba_x_Ing]					,[IdEstadoAproba_x_Egr]						,[IdMovi_Inven_tipo_x_Dev_Inv_x_Ing]
,[IdMovi_Inven_tipo_x_Dev_Inv_x_Erg]
)
values
(
1											,null									,''											,1
,1											,'N'									,'S'										,1
,1											,'S'									,
)
*/


----------------------------------------------------------------


----------------------------------------------------------------
--------------------------PARAMETRIZACION CAJA -----------------




insert into caj_parametro 
(IdEmpresa	,IdTipoCbteCble_MoviCaja_Ing,IdTipoCbteCble_MoviCaja_Ing_Anu,IdTipoCbteCble_MoviCaja_Egr,IdTipoCbteCble_MoviCaja_Egr_Anu)
values
(@IdEmpresa	,1							,1								,1							,1)



INSERT INTO [dbo].[caj_Caja]
([IdEmpresa]	,[IdCaja]	,[IdSucursal]	,[ca_Codigo]	,[ca_Descripcion]	,[ca_Moneda]	,[IdUsuario]	,[Fecha_Transac],[Estado])
values
(@IdEmpresa		,1			,1				,'1'			,'CAJA GENERAL'		,'US$ DOLLAR $ ','sysadmin'		,GETDATE(),'A')


INSERT INTO [dbo].[caj_Caja]
([IdEmpresa]	,[IdCaja]	,[IdSucursal]	,[ca_Codigo]	,[ca_Descripcion]	,[ca_Moneda]	,[IdUsuario]	,[Fecha_Transac],[Estado])
values
(@IdEmpresa		,2			,1				,'1'			,'CAJA CHICA'		,'US$ DOLLAR $ ','sysadmin'		,GETDATE(),'A')



------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------

-------------------------------------- COMPRAS ------------------------------------------------------



INSERT INTO [dbo].[com_parametro]
([IdEmpresa]					,[IdEstadoAprobacion_OC]	,[IdMovi_inven_tipo_OC]	,[IdEstadoAnulacion_OC]	,[IdMovi_inven_tipo_dev_compra]	,[IdEstadoAprobacion_SolCompra]
,[IdSucursal_x_Aprob_x_SolComp]	,[IdEstado_cierre])
VALUES
(@IdEmpresa						,'xAPRO'					,1						,'ANULA'				,1								,'PEN_SOL'
,1								,'ABI')



INSERT INTO [dbo].[com_Motivo_Orden_Compra]
([IdEmpresa]	,[IdMotivo]	,[Cod_Motivo]	,[Descripcion]	,[estado]	,[Fecha_Transac]	,[IdUsuarioUltMod])
values
(@IdEmpresa				,1			,1				,'No Disponible','A'		,GETDATE()			,'sysadmin')



------------------------------------------------------------------------------------------------------------

-----------------------------  CUENTAS POR PAGAR ------------------------------------------------

--select * from [cp_parametros]

INSERT INTO [dbo].[cp_parametros]
([IdEmpresa]						,[pa_TipoCbte_OG]				,[pa_TipoCbte_OG_anulacion]		,[pa_ctacble_deudora]				,[pa_ctacble_iva]	
,[pa_ctacble_Proveedores_default]	,[pa_IdTipoCbte_x_Retencion]	,[pa_IdTipoCbte_x_Anu_Retencion],[IdTipoMoviCaja]					,[pa_TipoEgrMoviCaja_Conciliacion]	
,[IdUsuario]						
,[pa_TipoCbte_NC]					,[pa_TipoCbte_NC_anulacion]		,[pa_obligaOC]					,[pa_TipoCbte_ND]					,[pa_TipoCbte_ND_anulacion]
,[pa_xsd_de_atsSRI]					,[pa_Formulario103_104]			
,[pa_TipoCbte_para_conci_x_antcipo]	,[pa_ruta_descarga_xml_fac_elct]	,[pa_ctacble_x_RetIva_default]
,[pa_ctacble_x_RetFte_default]		
)
VALUES
(@IdEmpresa							,7								,8								,NULL								,NULL	
,NULL								,14								,15								,1									,1
,NULL
,9									,13								,'S'							,10									,13
,NULL								,NULL
,1									,'C:\\'							,NULL
,NULL
)




INSERT INTO [dbo].[cp_proveedor_clase]
([IdEmpresa]	,[IdClaseProveedor]	,[cod_clase_proveedor]	,[descripcion_clas_prove]	,[Estado]	,[IdUsuario]	,[FechaTransac])
VALUES
(@IdEmpresa		,1					,1						,'Provedores Locales '      ,'A'		,'sysAdmin'				,GETDATE()
)


INSERT INTO [dbo].[cp_orden_pago_tipo_x_empresa]
([IdEmpresa]	,[IdTipo_op]	,[IdCtaCble]	,[IdCentroCosto]	,[IdTipoCbte_OP]	,[IdTipoCbte_OP_anulacion]	,[IdEstadoAprobacion]	,[Buscar_FactxPagar])
SELECT         
@IdEmpresa		,IdTipo_op		,null			,null				,17					,18							,'APRO'					,'N'
FROM            cp_orden_pago_tipo

UPDATE [cp_orden_pago_tipo_x_empresa] set Buscar_FactxPagar='S'  where [IdEmpresa]=@IdEmpresa and [IdTipo_op]='FACT_PROVEE'

------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------



------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------
---------------------------------------- FACTURACION ------------------------------------




INSERT INTO fa_cliente_tipo
([IdEmpresa]	,[Idtipo_cliente]	,[Cod_cliente_tipo]		,[Descripcion_tip_cliente]	,[estado]	,[IdUsuario]	,[Fecha_Transac])
values
(@IdEmpresa		,1					,'1'					,'Clientes Locales'			,'A'		,'sysIni'		,GETDATE())



INSERT INTO fa_Vendedor
([IdEmpresa]	,[IdVendedor]	,[IdEmpleado]	,[Codigo]	,[Ve_Vendedor]	,[ve_cedula]	,[Ve_Comision],[Estado]
,[IdUsuario]	,[Fecha_Transac])
values
(@IdEmpresa		,1				,0				,1			,'No Disponible','0000000000000',0			,'A'
,'sysAdmin'				,GETDATE() )



INSERT INTO fa_VendedorxSucursal  
([IdEmpresa]	,[IdVendedor]	,[IdSucursal])
values 
(@IdEmpresa		,1				,1)

-- select * from in_movi_inven_tipo
-- SELECT * FROM fa_tiponota
-- select * from ct_cbtecble_tipo

--este insert tiene errores, hay que revisarlo

INSERT INTO fa_parametro
([IdEmpresa]								,[IdMovi_inven_tipo_Factura]				,[pa_porc_max_total_item_x_despa_Guia]	,[IdMovi_inven_tipo_Dev_Vta]	
,[IdMovi_inven_tipo_Factura_Anulacion]		,[IdMovi_inven_tipo_Dev_Vta_Anulacion]		,[Tipo_NC_x_DevVta]						,[IdDepartamento_x_DevVta]
,[IdTipoCbteCble_Factura]					,[IdTipoCbteCble_Factura_Reverso]			,[IdTipoCbteCble_Factura_Costo_VTA]		,[IdTipoCbteCble_Factura_Costo_VTA_Reverso]
,[IdTipoCbteCble_NC]						,[IdTipoCbteCble_NC_Reverso]				,[IdTipoCbteCble_ND]					,[IdTipoCbteCble_ND_Reverso]
,[SeImprimiGuiaRemiAuto]					,[NumeroDeItemFact]							,[TipoCobroDafaultFactu]				,[IdCaja_Default_Factura]
,[IdCtaCble_x_anticipo_cliente]				,[pa_IdTipoNota_NC_x_Anulacion]				,[IdEstadoAprobacion]					,[pa_ruta_descarga_xml_fac_elct]
,[File_Reporte_FacturaDiseño]				,[File_Reporte_Nota_CRED_DEB]				,[IdCtaCble_IVA]						,[IdCtaCble_SubTotal_Vtas_x_Default]
,[IdCtaCble_CXC_Vtas_x_Default]				,[pa_X_Defecto_la_factura_es_cbte_elect]	,[pa_X_Defecto_la_guia_es_cbte_elect]	,[pa_X_Defecto_la_ND_es_cbte_elect]
,[pa_X_Defecto_la_NC_es_cbte_elect])	
VALUES
(@IdEmpresa									,9											,100									,3
,4											,2											,1										,1
,19											,22											,1									    ,22
,20											,22											,21										,22
,'S'										,10											,null									,1
,NULL										,NULL										,NULL									,'C:\\'
,NULL										,NULL										,NULL									,NULL
,NULL										,NULL										,NULL									,NULL
,NULL)




------------------------------------------------------------------------
------------------------------------------------------------------------
----------------- ACTIVO FIJO -----------------------------------------

INSERT INTO [dbo].[Af_Parametros]
([IdEmpresa]					,[IdTipoCbte]				,[IdTipoCbteMejora]			,[IdTipoCbteBaja]				,[IdTipoCbteVenta]				,[IdTipoCbteRetiro]				
,[IdCtaCble_Activo]				,[IdCtaCble_Dep_Acum]		,[IdCtaCble_Gastos_Depre]	,[FormaContabiliza]				,[IdTipoCbteMejora_Anulacion]	,[IdTipoCbteBaja_Anulacion]	
,[IdTipoCbteVenta_Anulacion]	,[IdTipoCbteRetiro_Anulacion],[IdTipoCbteDep_Acum_Anulacion]
)
VALUES
(
@IdEmpresa						,1							,1							,1								,1								,1
,NULL							,NULL						,NULL						,'S'							,1								,1
,1								,1							,1
)


INSERT INTO [dbo].[Af_Activo_fijo_tipo]
([IdEmpresa]	,[IdActijoFijoTipo]	,[CodActivoFijo]	,[Af_Descripcion]		,[Af_Porcentaje_depre]	,[Af_anio_depreciacion]
,[IdUsuario]	,[Fecha_Transac]	,[Estado])
VALUES
(@IdEmpresa				,1					,1					,'VEHICULOS Y CAMIONES'	,20						,5
,'sysadmin'		,GETDATE()			,'A')


INSERT INTO [dbo].[Af_Activo_fijo_tipo]
([IdEmpresa]	,[IdActijoFijoTipo]	,[CodActivoFijo]	,[Af_Descripcion]		,[Af_Porcentaje_depre]	,[Af_anio_depreciacion]
,[IdUsuario]	,[Fecha_Transac]	,[Estado])
VALUES
(@IdEmpresa				,2					,2					,'EDIFICIOS Y TERRENOS'	,4						,25
,'sysadmin'		,GETDATE()			,'A')


INSERT INTO [dbo].[Af_Activo_fijo_tipo]
([IdEmpresa]	,[IdActijoFijoTipo]	,[CodActivoFijo]	,[Af_Descripcion]		,[Af_Porcentaje_depre]	,[Af_anio_depreciacion]
,[IdUsuario]	,[Fecha_Transac]	,[Estado])
VALUES
(@IdEmpresa				,3				,3					,'MUEBLES & ENSERES'	,25					,4
,'sysadmin'		,GETDATE()			,'A')







-----------------------------------------------------------------------
-----------------------------------------------------------------------
-----------------------------------------------------------------------



-------------------------------------------------
/*

INSERT INTO [dbo].[cxc_Parametro]
([IdEmpresa]							,[pa_tipoND_x_CheqProtestado]		,[pa_IdCaja_x_cobros_x_CXC]	,[pa_IdTipoMoviCaja_x_Cobros_x_cliente]	
,[pa_IdTipoCbteCble_CxC]				,[pa_IdTipoCbteCble_CxC_ANU]		
,[pa_IdCaja_x_Default]					,[pa_IdTipoCbte_x_conciliacion]		,[pa_IdCobro_tipo_Comision_TC])
values
(1										,1									,null						,1	
,1										,1									
,1										,1									,1)

*/



INSERT INTO [dbo].[tb_sis_Documento_Tipo_x_Empresa]
([IdEmpresa]		,[codDocumentoTipo]	,[ApareceComboFac_TipoFact]	,[ApareceComboFac_Import]
,[ApareceTalonario]	,[Descripcion]		,[Posicion]					,[ApareceCombo_FileReporte])
Select 
@IdEmpresa 			,codDocumentoTipo	,'S'							,'S'
,'S'				,''					,0								,'S'
from [dbo].[tb_sis_Documento_Tipo]


INSERT [dbo].[ro_Nomina_Tipo] ([IdEmpresa], [IdNomina_Tipo], [Descripcion], [IdUsuario], [IdUsuarioAnu], [MotivoAnu], [IdUsuarioUltModi], [FechaAnu], [FechaTransac], [FechaUltModi], [Estado]) VALUES (@IdEmpresa, 1, N'Mensual', N'admin', NULL, NULL, NULL, NULL, CAST(N'2016-12-08 15:40:49.167' AS Date), NULL, N'A')
INSERT [dbo].[ro_Nomina_Tipo] ([IdEmpresa], [IdNomina_Tipo], [Descripcion], [IdUsuario], [IdUsuarioAnu], [MotivoAnu], [IdUsuarioUltModi], [FechaAnu], [FechaTransac], [FechaUltModi], [Estado]) VALUES (@IdEmpresa, 2, N'Eventuales', N'admin', NULL, N'', N'admin', NULL, CAST(N'2016-09-20 11:54:46.710' AS Date), CAST(N'2016-09-28 12:04:02.593' AS Date), N'A')

INSERT [dbo].[ro_Nomina_Tipoliqui] ([IdEmpresa], [IdNomina_Tipo], [IdNomina_TipoLiqui], [DescripcionProcesoNomina], [IdUsuario], [IdUsuarioAnu], [MotivoAnu], [IdUsuarioUltModi], [FechaAnu], [FechaTransac], [FechaUltModi], [Estado]) VALUES (@IdEmpresa, 1, 1, N'Pago primera quincena', N'admin', NULL, N'', N'admin', NULL, CAST(N'2016-06-20 14:42:25.683' AS Date), CAST(N'2016-10-04 14:11:23.217' AS Date), N'A')
INSERT [dbo].[ro_Nomina_Tipoliqui] ([IdEmpresa], [IdNomina_Tipo], [IdNomina_TipoLiqui], [DescripcionProcesoNomina], [IdUsuario], [IdUsuarioAnu], [MotivoAnu], [IdUsuarioUltModi], [FechaAnu], [FechaTransac], [FechaUltModi], [Estado]) VALUES (@IdEmpresa, 1, 2, N'Pago segunda quincena', N'admin', NULL, N'', N'admin', NULL, CAST(N'2016-06-20 14:42:43.473' AS Date), CAST(N'2016-10-04 14:10:59.367' AS Date), N'A')
INSERT [dbo].[ro_Nomina_Tipoliqui] ([IdEmpresa], [IdNomina_Tipo], [IdNomina_TipoLiqui], [DescripcionProcesoNomina], [IdUsuario], [IdUsuarioAnu], [MotivoAnu], [IdUsuarioUltModi], [FechaAnu], [FechaTransac], [FechaUltModi], [Estado]) VALUES (@IdEmpresa, 1, 3, N'Pago de Variable', N'admin', NULL, N'', N'admin', NULL, CAST(N'2016-09-20 12:16:49.897' AS Date), CAST(N'2016-10-28 17:37:39.553' AS Date), N'A')
INSERT [dbo].[ro_Nomina_Tipoliqui] ([IdEmpresa], [IdNomina_Tipo], [IdNomina_TipoLiqui], [DescripcionProcesoNomina], [IdUsuario], [IdUsuarioAnu], [MotivoAnu], [IdUsuarioUltModi], [FechaAnu], [FechaTransac], [FechaUltModi], [Estado]) VALUES (@IdEmpresa, 1, 4, N'Liquidacion de Fondo reserva', N'admin', NULL, N'', N'admin', NULL, CAST(N'2016-12-01 15:42:55.100' AS Date), CAST(N'2016-12-01 16:56:58.267' AS Date), N'A')
INSERT [dbo].[ro_Nomina_Tipoliqui] ([IdEmpresa], [IdNomina_Tipo], [IdNomina_TipoLiqui], [DescripcionProcesoNomina], [IdUsuario], [IdUsuarioAnu], [MotivoAnu], [IdUsuarioUltModi], [FechaAnu], [FechaTransac], [FechaUltModi], [Estado]) VALUES (@IdEmpresa, 2, 1, N'Pago primera quincena', N'admin', NULL, N'', N'admin', NULL, CAST(N'2016-06-20 14:42:25.683' AS Date), CAST(N'2016-10-04 14:11:23.217' AS Date), N'A')
INSERT [dbo].[ro_Nomina_Tipoliqui] ([IdEmpresa], [IdNomina_Tipo], [IdNomina_TipoLiqui], [DescripcionProcesoNomina], [IdUsuario], [IdUsuarioAnu], [MotivoAnu], [IdUsuarioUltModi], [FechaAnu], [FechaTransac], [FechaUltModi], [Estado]) VALUES (@IdEmpresa, 2, 2, N'Pago segunda quincena', N'admin', NULL, N'', N'admin', NULL, CAST(N'2016-06-20 14:42:43.473' AS Date), CAST(N'2016-11-21 11:28:55.147' AS Date), N'A')
INSERT [dbo].[ro_Nomina_Tipoliqui] ([IdEmpresa], [IdNomina_Tipo], [IdNomina_TipoLiqui], [DescripcionProcesoNomina], [IdUsuario], [IdUsuarioAnu], [MotivoAnu], [IdUsuarioUltModi], [FechaAnu], [FechaTransac], [FechaUltModi], [Estado]) VALUES (@IdEmpresa, 2, 3, N'Pago de Variable', N'admin', NULL, N'', N'admin', NULL, CAST(N'2016-09-20 12:16:49.897' AS Date), CAST(N'2016-11-21 11:10:22.900' AS Date), N'A')


INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 1, 1, N'100', N'DIAS_TRA_MENSUAL_RUBRO([XIV_SUELDO])', 0, N'', CAST(N'2016-10-04 14:11:23.063' AS Date), N'admin', CAST(N'2016-10-04 14:11:23.083' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 1, 2, N'2', N'[DIAS_D14]', 1, N'', CAST(N'2016-10-04 14:11:23.100' AS Date), N'admin', CAST(N'2016-10-04 14:11:23.117' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 1, 3, N'103', N'SUELDO_BASICO()', 1, N'', CAST(N'2016-10-04 14:11:23.133' AS Date), N'admin', CAST(N'2016-10-04 14:11:23.147' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 1, 4, N'294', N'Iif([DIASTRA]>=12,([SUELDO_NETO]*0.4)/15*[DIASTRA]  , 0)', 0, N'', CAST(N'2016-10-04 14:11:23.163' AS Date), N'admin', CAST(N'2016-10-04 14:11:23.177' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 1, 5, N'950', N'[ANT+]', 1, N'', CAST(N'2016-10-04 14:11:23.190' AS Date), N'admin', CAST(N'2016-10-04 14:11:23.203' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 1, N'975', N'SI_EMPLEADO_VACACIONES()', 0, N'', CAST(N'2016-10-04 14:10:58.233' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.253' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 9, N'1', N'OBTENER_NOVEDAD()', 0, N'', CAST(N'2016-10-04 14:10:58.267' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.287' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 10, N'26', N'0.0945', 0, N'', CAST(N'2016-10-04 14:10:58.300' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.320' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 11, N'970', N'0.1115', 0, N'', CAST(N'2016-10-04 14:10:58.333' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.350' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 14, N'963', N'366', 0, N'', CAST(N'2016-10-04 14:10:58.363' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.380' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 15, N'57', N'PERMITE_ACUMULAR([FNDO_RSVA])', 0, N'', CAST(N'2016-10-04 14:10:58.390' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.403' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 16, N'59', N'PERMITE_ACUMULAR([XIV_SUELDO])', 0, N'', CAST(N'2016-10-04 14:10:58.420' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.430' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 17, N'58', N'PERMITE_ACUMULAR([XIII_SUELD])', 0, N'', CAST(N'2016-10-04 14:10:58.447' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.460' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 18, N'102', N'DIAS_ANTIGUEDAD()', 0, N'', CAST(N'2016-10-04 14:10:58.470' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.483' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 19, N'100', N'DIAS_TRA_MENSUAL_RUBRO([XIV_SUELDO])', 0, N'', CAST(N'2016-10-04 14:10:58.500' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.513' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 20, N'101', N'DIAS_TRA_MENSUAL_RUBRO([XIII_SUELD])', 0, N'', CAST(N'2016-10-04 14:10:58.527' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.540' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 22, N'7', N'OBTENER_NOVEDAD()', 0, N'', CAST(N'2016-10-04 14:10:58.553' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.567' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 23, N'8', N'OBTENER_NOVEDAD()', 0, N'', CAST(N'2016-10-04 14:10:58.580' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.590' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 24, N'9', N'OBTENER_NOVEDAD()', 0, N'', CAST(N'2016-10-04 14:10:58.603' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.617' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 25, N'20', N'DIAS_TRABAJADOS()', 0, N'', CAST(N'2016-10-04 14:10:58.630' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.643' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 48, N'980', N'OBTENER_DIAS_PERMISO_VACACIONES()', 0, N'', CAST(N'2016-10-04 14:10:58.657' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.670' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 49, N'976', N'DIAS_EFECTIVOS()', 1, N'', CAST(N'2016-10-04 14:10:58.683' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.697' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 50, N'103', N'SUELDO_BASICO()', 1, N'', CAST(N'2016-10-04 14:10:58.710' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.723' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 51, N'2', N'[DIAS_D14]- [NUM_DIAS_F]', 1, N'', CAST(N'2016-10-04 14:10:58.737' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.750' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 52, N'24', N'(Iif([DIAS_NOMI]>=28, ([SUELDO_NETO]/30)  * [DIASTRA]  , ([SUELDO_NETO]/30) *  [DIASTRA] ))', 1, N'', CAST(N'2016-10-04 14:10:58.763' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.777' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 53, N'296', N'Iif([ACUM_FR]=1 , 0  , (Iif([DIAS_ANT]>=360,[SUELDO]*0.0833  , 0 )) )', 1, N'', CAST(N'2016-10-04 14:10:58.790' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.803' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 56, N'966', N'[H_NOC_25] + [H_SOB_50] + [HSOBRE_100]', 1, N'', CAST(N'2016-10-04 14:10:58.817' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.830' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 58, N'68', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-04 14:10:58.843' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.853' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 59, N'74', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-04 14:10:58.870' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.880' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 102, N'4', N'[SUELDO_BAS]+ [HORAEXTRAS]', 0, N'', CAST(N'2016-10-04 14:10:58.897' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.910' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 107, N'290', N'Iif([ACUM_D13]=1 , 0  , (([SUELDO] /30) * ( [DIASTRA])) / 12 )', 1, N'', CAST(N'2016-10-04 14:10:58.923' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.937' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 108, N'289', N'Iif([ACUM_D14]=1 , 0 , ([SBU]/360) * ([DIAS_D14] - [NUM_DIAS_F]) )', 1, N'', CAST(N'2016-10-04 14:10:58.950' AS Date), N'admin', CAST(N'2016-10-04 14:10:58.967' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 199, N'500', N'[SUELDO] + [FNDO_RSVA] + [XIII_SUELD] + [XIV_SUELDO]+[TRANS+]+[ALIMENT+]', 1, N'', CAST(N'2016-10-04 14:10:58.983' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.000' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 201, N'6', N'[IESS_PERS%] * [SUELDO]', 1, N'', CAST(N'2016-10-04 14:10:59.013' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.030' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 202, N'277', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-04 14:10:59.047' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.060' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 203, N'201', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-04 14:10:59.073' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.087' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 204, N'252', N'IMPUESTO_RENTA()', 1, N'', CAST(N'2016-10-04 14:10:59.100' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.113' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 205, N'214', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-04 14:10:59.127' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.137' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 211, N'973', N'OBTENER_NOVEDAD()', 0, N'', CAST(N'2016-10-04 14:10:59.150' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.167' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 298, N'900', N'[IESS_PERS]  + [PRES_PERS] + [PREST_QR] + [TRMEN] +( [SUELDO_NETO]*0.4)', 1, N'', CAST(N'2016-10-04 14:10:59.180' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.193' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 299, N'950', N'[INGRESOS] - [EGRESOS]', 1, N'', CAST(N'2016-10-04 14:10:59.207' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.220' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 300, N'199', N'Iif([ACUM_D13]=1 ,  ((([SUELDO] /30) * ( [DIASTRA])) / 12)  , 0)', 0, N'', CAST(N'2016-10-04 14:10:59.230' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.243' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 301, N'200', N'Iif([ACUM_D14]=1 ,([SBU]/360) *  [DIASTRA]  , 0 )', 0, N'', CAST(N'2016-10-04 14:10:59.260' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.273' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 302, N'198', N'Iif([ACUM_FR]=1 , (Iif([DIAS_ANT]>=360,[SUELDO]*0.0833  , 0 )) , 0 )', 0, N'', CAST(N'2016-10-04 14:10:59.287' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.300' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 303, N'493', N'[SUELDO] * [IESS_PATR%]', 0, N'', CAST(N'2016-10-04 14:10:59.313' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.327' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 2, 304, N'295', N'[SUELDO] / 24', 0, N'', CAST(N'2016-10-04 14:10:59.340' AS Date), N'admin', CAST(N'2016-10-04 14:10:59.353' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 1, N'975', N'SI_EMPLEADO_VACACIONES()', 0, N'', CAST(N'2016-10-28 17:37:38.447' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.463' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 2, N'963', N'366', 0, N'', CAST(N'2016-10-28 17:37:38.480' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.493' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 3, N'970', N'0.1115', 0, N'', CAST(N'2016-10-28 17:37:38.510' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.523' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 4, N'26', N'0.0945', 0, N'', CAST(N'2016-10-28 17:37:38.537' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.553' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 5, N'57', N'PERMITE_ACUMULAR([FNDO_RSVA])', 0, N'', CAST(N'2016-10-28 17:37:38.567' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.580' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 6, N'59', N'PERMITE_ACUMULAR([XIV_SUELDO])', 0, N'', CAST(N'2016-10-28 17:37:38.593' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.607' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 7, N'58', N'PERMITE_ACUMULAR([XIII_SUELD])', 0, N'', CAST(N'2016-10-28 17:37:38.620' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.633' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 8, N'102', N'DIAS_ANTIGUEDAD()', 0, N'', CAST(N'2016-10-28 17:37:38.647' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.660' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 9, N'100', N'DIAS_TRA_MENSUAL_RUBRO([XIV_SUELDO])', 0, N'', CAST(N'2016-10-28 17:37:38.673' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.690' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 10, N'101', N'DIAS_TRA_MENSUAL_RUBRO([XIII_SUELD])', 0, N'', CAST(N'2016-10-28 17:37:38.703' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.717' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 11, N'20', N'DIAS_TRABAJADOS()', 0, N'', CAST(N'2016-10-28 17:37:38.730' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.743' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 12, N'980', N'OBTENER_DIAS_PERMISO_VACACIONES()', 0, N'', CAST(N'2016-10-28 17:37:38.757' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.770' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 100, N'103', N'SUELDO_BASICO()', 0, N'', CAST(N'2016-10-28 17:37:38.787' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.800' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 101, N'2', N'[DIAS_D14]', 1, N'', CAST(N'2016-10-28 17:37:38.813' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.827' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 102, N'976', N'DIAS_EFECTIVOS()', 1, N'', CAST(N'2016-10-28 17:37:38.840' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.853' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 103, N'24', N'(Iif([DIAS_NOMI]>=28, ([SUELDO_NETO]/30)  * [DIASTRA]  , ([SUELDO_NETO]/30) *  [DIASTRA] ))', 0, N'', CAST(N'2016-10-28 17:37:38.870' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.883' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 104, N'4', N'[SUELDO_BAS]', 0, N'', CAST(N'2016-10-28 17:37:38.897' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.910' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 108, N'289', N'Iif([ACUM_D14]=1 , 0 , ( ([EFE_ENTREG] + [EFE_VOLUM] + [REC_CART]) /360) * ([DIAS_D14] ) )', 1, N'', CAST(N'2016-10-28 17:37:38.927' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.940' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 120, N'983', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-28 17:37:38.953' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.970' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 121, N'984', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-28 17:37:38.983' AS Date), N'admin', CAST(N'2016-10-28 17:37:38.997' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 122, N'982', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-28 17:37:39.010' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.023' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 123, N'985', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-28 17:37:39.040' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.053' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 124, N'991', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-28 17:37:39.067' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.080' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 125, N'987', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-28 17:37:39.093' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.110' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 126, N'990', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-28 17:37:39.123' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.137' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 127, N'989', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-28 17:37:39.150' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.163' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 128, N'988', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-28 17:37:39.180' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.193' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 129, N'986', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-10-28 17:37:39.207' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.223' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 150, N'296', N'Iif([ACUM_FR]=1 , 0  , (Iif([DIAS_ANT]>=360, (  [EFE_ENTREG] + [EFE_VOLUM] + [REC_CART] + [ROT_PERS] + [REV_NOM] + [REN_COMB] + [COST_MANT] + [SERV_CLI] + [MANT] + [AUS_LAB]   )*0.0833  , 0 )) )', 1, N'', CAST(N'2016-10-28 17:37:39.237' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.250' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 151, N'290', N'Iif([ACUM_D13]=1 , 0  , (( (   [EFE_ENTREG] + [EFE_VOLUM] + [REC_CART] + [ROT_PERS] + [REV_NOM] + [REN_COMB] + [COST_MANT] + [SERV_CLI] + [MANT] + [AUS_LAB]   )  /30) * ( [DIASTRA])) / 12 )', 1, N'', CAST(N'2016-10-28 17:37:39.263' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.280' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 199, N'500', N'[EFE_ENTREG] + [EFE_VOLUM] + [REC_CART] + [ROT_PERS] + [REV_NOM] + [REN_COMB] + [COST_MANT] + [SERV_CLI] + [MANT] + [AUS_LAB]', 1, N'', CAST(N'2016-10-28 17:37:39.293' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.307' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 200, N'6', N'[IESS_PERS%] * (  [EFE_ENTREG] + [EFE_VOLUM] + [REC_CART] + [ROT_PERS] + [REV_NOM] + [REN_COMB] + [COST_MANT] + [SERV_CLI] + [MANT] + [AUS_LAB] )', 1, N'', CAST(N'2016-10-28 17:37:39.320' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.337' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 298, N'900', N'[IESS_PERS]', 1, N'', CAST(N'2016-10-28 17:37:39.350' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.363' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 299, N'950', N'[INGRESOS] - [EGRESOS]', 1, N'', CAST(N'2016-10-28 17:37:39.380' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.393' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 303, N'493', N'([EFE_ENTREG] + [EFE_VOLUM] + [REC_CART] + [ROT_PERS] + [REV_NOM] + [REN_COMB] + [COST_MANT] + [SERV_CLI] + [MANT] + [AUS_LAB]) * [IESS_PATR%]', 0, N'', CAST(N'2016-10-28 17:37:39.407' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.420' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 400, N'199', N'Iif([ACUM_D13]=1 ,  (((  (   [EFE_ENTREG] + [EFE_VOLUM] + [REC_CART] + [ROT_PERS] + [REV_NOM] + [REN_COMB] + [COST_MANT] + [SERV_CLI] + [MANT] + [AUS_LAB]   )  /30) * ( [DIASTRA])) / 12)  , 0)', 0, N'', CAST(N'2016-10-28 17:37:39.437' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.450' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 401, N'198', N'Iif([ACUM_FR]=1 , (Iif([DIAS_ANT]>=360, (    [EFE_ENTREG] + [EFE_VOLUM] + [REC_CART] + [ROT_PERS] + [REV_NOM] + [REN_COMB] + [COST_MANT] + [SERV_CLI] + [MANT] + [AUS_LAB]    )*0.0833  , 0 )) , 0 )', 0, N'', CAST(N'2016-10-28 17:37:39.467' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.480' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 402, N'295', N'[SUELDO] / 24', 0, N'', CAST(N'2016-10-28 17:37:39.497' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.510' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 3, 403, N'200', N'Iif([ACUM_D14]=1 ,( ( [EFE_ENTREG] + [EFE_VOLUM] + [REC_CART] + [ROT_PERS] + [REV_NOM] + [REN_COMB] + [COST_MANT] + [SERV_CLI] + [MANT] + [AUS_LAB] ) /360) *  [DIASTRA]  , 0 )', 0, N'', CAST(N'2016-10-28 17:37:39.523' AS Date), N'admin', CAST(N'2016-10-28 17:37:39.540' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 4, 0, N'1021', N'PAGO_FONDO_RESERVA();', 0, N'', CAST(N'2016-12-01 16:56:58.200' AS Date), N'admin', CAST(N'2016-12-01 16:56:58.220' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 1, 4, 1, N'950', N'[PAGO_FDR]', 1, N'', CAST(N'2016-12-01 16:56:58.237' AS Date), N'admin', CAST(N'2016-12-01 16:56:58.253' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 1, 1, N'100', N'DIAS_TRA_MENSUAL_RUBRO([XIV_SUELDO])', 0, N'', CAST(N'2016-10-04 14:11:23.063' AS Date), N'admin', CAST(N'2016-10-04 14:11:23.083' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 1, 2, N'2', N'[DIAS_D14]', 1, N'', CAST(N'2016-10-04 14:11:23.100' AS Date), N'admin', CAST(N'2016-10-04 14:11:23.117' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 1, 3, N'103', N'SUELDO_BASICO()', 1, N'', CAST(N'2016-10-04 14:11:23.133' AS Date), N'admin', CAST(N'2016-10-04 14:11:23.147' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 1, 4, N'294', N'Iif([DIASTRA]>=12,([SUELDO_NETO]*0.4)/15*[DIASTRA]  , 0)', 0, N'', CAST(N'2016-10-04 14:11:23.163' AS Date), N'admin', CAST(N'2016-10-04 14:11:23.177' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 1, 5, N'950', N'[ANT+]', 1, N'', CAST(N'2016-10-04 14:11:23.190' AS Date), N'admin', CAST(N'2016-10-04 14:11:23.203' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 1, N'975', N'SI_EMPLEADO_VACACIONES()', 0, N'', CAST(N'2016-11-21 11:28:53.950' AS Date), N'admin', CAST(N'2016-11-21 11:28:53.980' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 9, N'1', N'OBTENER_NOVEDAD()', 0, N'', CAST(N'2016-11-21 11:28:54.003' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.020' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 10, N'26', N'0.0945', 0, N'', CAST(N'2016-11-21 11:28:54.040' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.057' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 11, N'970', N'0.1115', 0, N'', CAST(N'2016-11-21 11:28:54.070' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.087' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 14, N'963', N'366', 0, N'', CAST(N'2016-11-21 11:28:54.100' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.113' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 15, N'57', N'PERMITE_ACUMULAR([FNDO_RSVA])', 0, N'', CAST(N'2016-11-21 11:28:54.130' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.143' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 16, N'59', N'PERMITE_ACUMULAR([XIV_SUELDO])', 0, N'', CAST(N'2016-11-21 11:28:54.160' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.173' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 17, N'58', N'PERMITE_ACUMULAR([XIII_SUELD])', 0, N'', CAST(N'2016-11-21 11:28:54.187' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.200' AS Date), N'admin')

INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 18, N'102', N'DIAS_ANTIGUEDAD()', 0, N'', CAST(N'2016-11-21 11:28:54.217' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.230' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 19, N'100', N'DIAS_TRA_MENSUAL_RUBRO([XIV_SUELDO])', 0, N'', CAST(N'2016-11-21 11:28:54.247' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.260' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 20, N'101', N'DIAS_TRA_MENSUAL_RUBRO([XIII_SUELD])', 0, N'', CAST(N'2016-11-21 11:28:54.273' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.287' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 22, N'7', N'OBTENER_NOVEDAD()', 0, N'', CAST(N'2016-11-21 11:28:54.300' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.313' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 23, N'8', N'OBTENER_NOVEDAD()', 0, N'', CAST(N'2016-11-21 11:28:54.330' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.343' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 24, N'9', N'OBTENER_NOVEDAD()', 0, N'', CAST(N'2016-11-21 11:28:54.357' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.370' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 25, N'20', N'DIAS_TRABAJADOS()', 0, N'', CAST(N'2016-11-21 11:28:54.383' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.400' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 48, N'980', N'OBTENER_DIAS_PERMISO_VACACIONES()', 0, N'', CAST(N'2016-11-21 11:28:54.413' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.427' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 49, N'976', N'DIAS_EFECTIVOS()', 1, N'', CAST(N'2016-11-21 11:28:54.440' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.453' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 50, N'103', N'SUELDO_BASICO()', 1, N'', CAST(N'2016-11-21 11:28:54.470' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.483' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 51, N'2', N'[DIAS_EFECT]', 1, N'', CAST(N'2016-11-21 11:28:54.497' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.510' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 52, N'24', N'(Iif([DIAS_NOMI]>=28, ([SUELDO_NETO]/30)  * [DIASTRA]  , ([SUELDO_NETO]/30) *  [DIASTRA] ))', 1, N'', CAST(N'2016-11-21 11:28:54.527' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.540' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 53, N'296', N'Iif([ACUM_FR]=1 , 0  , (Iif([DIAS_ANT]>=360,[SUELDO]*0.0833  , 0 )) )', 1, N'', CAST(N'2016-11-21 11:28:54.553' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.567' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 56, N'966', N'[H_NOC_25] + [H_SOB_50] + [HSOBRE_100]', 1, N'', CAST(N'2016-11-21 11:28:54.580' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.597' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 58, N'68', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-11-21 11:28:54.610' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.623' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 59, N'74', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-11-21 11:28:54.637' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.650' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 102, N'4', N'[SUELDO_BAS]+ [HORAEXTRAS]', 0, N'', CAST(N'2016-11-21 11:28:54.667' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.683' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 107, N'290', N'Iif([ACUM_D13]=1 , 0  , (([SUELDO] /30) * ( [DIASTRA])) / 12 )', 1, N'', CAST(N'2016-11-21 11:28:54.697' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.710' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 108, N'289', N'Iif([ACUM_D14]=1 , 0 , ([SBU]/360) * ([DIAS_D14] - [NUM_DIAS_F]) )', 1, N'', CAST(N'2016-11-21 11:28:54.723' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.737' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 199, N'500', N'[SUELDO] + [FNDO_RSVA] + [XIII_SUELD] + [XIV_SUELDO]+[TRANS+]+[ALIMENT+]', 1, N'', CAST(N'2016-11-21 11:28:54.750' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.767' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 201, N'6', N'[IESS_PERS%] * [SUELDO]', 1, N'', CAST(N'2016-11-21 11:28:54.780' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.793' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 202, N'277', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-11-21 11:28:54.807' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.820' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 203, N'201', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-11-21 11:28:54.837' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.850' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 204, N'252', N'IMPUESTO_RENTA()', 1, N'', CAST(N'2016-11-21 11:28:54.863' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.883' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 205, N'214', N'OBTENER_NOVEDAD()', 1, N'', CAST(N'2016-11-21 11:28:54.897' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.910' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 211, N'973', N'OBTENER_NOVEDAD()', 0, N'', CAST(N'2016-11-21 11:28:54.927' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.940' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 298, N'900', N'[IESS_PERS]  + [PRES_PERS] + [PREST_QR] + [TRMEN]', 1, N'', CAST(N'2016-11-21 11:28:54.953' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.967' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 299, N'950', N'[INGRESOS] - [EGRESOS]', 1, N'', CAST(N'2016-11-21 11:28:54.980' AS Date), N'admin', CAST(N'2016-11-21 11:28:54.997' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 300, N'199', N'Iif([ACUM_D13]=1 ,  ((([SUELDO] /30) * ( [DIASTRA])) / 12)  , 0)', 0, N'', CAST(N'2016-11-21 11:28:55.010' AS Date), N'admin', CAST(N'2016-11-21 11:28:55.023' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 301, N'200', N'Iif([ACUM_D14]=1 ,([SBU]/360) *  [DIASTRA]  , 0 )', 0, N'', CAST(N'2016-11-21 11:28:55.037' AS Date), N'admin', CAST(N'2016-11-21 11:28:55.050' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 302, N'198', N'Iif([ACUM_FR]=1 , (Iif([DIAS_ANT]>=360,[SUELDO]*0.0833  , 0 )) , 0 )', 0, N'', CAST(N'2016-11-21 11:28:55.063' AS Date), N'admin', CAST(N'2016-11-21 11:28:55.077' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 303, N'493', N'[SUELDO] * [IESS_PATR%]', 0, N'', CAST(N'2016-11-21 11:28:55.090' AS Date), N'admin', CAST(N'2016-11-21 11:28:55.107' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 2, 304, N'295', N'[SUELDO] / 24', 0, N'', CAST(N'2016-11-21 11:28:55.120' AS Date), N'admin', CAST(N'2016-11-21 11:28:55.133' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 1, N'975', N'SI_EMPLEADO_VACACIONES()', 0, N'', CAST(N'2016-11-21 11:10:21.983' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.007' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 2, N'993', N'DIAS_SABADO_Y_DOMINGOS()', 0, N'', CAST(N'2016-11-21 11:10:22.023' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.037' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 4, N'996', N'VALOR_BONO_CALCULO_VARIABLE()', 1, N'', CAST(N'2016-11-21 11:10:22.050' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.067' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 10, N'26', N'0.0945', 0, N'', CAST(N'2016-11-21 11:10:22.080' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.093' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 11, N'970', N'0.1115', 0, N'', CAST(N'2016-11-21 11:10:22.107' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.123' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 14, N'963', N'366', 0, N'', CAST(N'2016-11-21 11:10:22.137' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.150' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 15, N'57', N'PERMITE_ACUMULAR([FNDO_RSVA])', 0, N'', CAST(N'2016-11-21 11:10:22.167' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.180' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 16, N'59', N'PERMITE_ACUMULAR([XIV_SUELDO])', 0, N'', CAST(N'2016-11-21 11:10:22.193' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.207' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 17, N'58', N'PERMITE_ACUMULAR([XIII_SUELD])', 0, N'', CAST(N'2016-11-21 11:10:22.220' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.233' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 18, N'102', N'DIAS_ANTIGUEDAD()', 0, N'', CAST(N'2016-11-21 11:10:22.250' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.263' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 19, N'100', N'DIAS_TRA_MENSUAL_RUBRO([XIV_SUELDO])', 0, N'', CAST(N'2016-11-21 11:10:22.277' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.290' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 20, N'101', N'DIAS_TRA_MENSUAL_RUBRO([XIII_SUELD])', 0, N'', CAST(N'2016-11-21 11:10:22.303' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.317' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 25, N'20', N'DIAS_TRABAJADOS()', 0, N'', CAST(N'2016-11-21 11:10:22.330' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.343' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 48, N'980', N'OBTENER_DIAS_PERMISO_VACACIONES()', 0, N'', CAST(N'2016-11-21 11:10:22.357' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.370' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 49, N'976', N'DIAS_EFECTIVOS()', 1, N'', CAST(N'2016-11-21 11:10:22.383' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.400' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 50, N'103', N'SUELDO_BASICO()', 1, N'', CAST(N'2016-11-21 11:10:22.410' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.427' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 51, N'2', N'[DIAS_EFECT]', 1, N'', CAST(N'2016-11-21 11:10:22.440' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.453' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 52, N'24', N'(Iif([DIAS_NOMI]>=28, ([SUELDO_NETO]/30)  * [DIASTRA]  , ([SUELDO_NETO]/30) *  [DIASTRA] ))', 1, N'', CAST(N'2016-11-21 11:10:22.467' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.480' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 53, N'296', N'Iif([ACUM_FR]=1 , 0  , (Iif([DIAS_ANT]>=360,[SUELDO]*0.0833  , 0 )) )', 1, N'', CAST(N'2016-11-21 11:10:22.493' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.507' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 54, N'995', N'DIAS_INTEGRALES_MES()', 0, N'', CAST(N'2016-11-21 11:10:22.520' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.533' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 55, N'994', N'([BON_BAS_V] / [DIAS_INTEG]) * [DIAS_EFECT]', 1, N'', CAST(N'2016-11-21 11:10:22.547' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.560' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 102, N'4', N'[SUELDO_BAS]+ [VARIABLE]', 0, N'', CAST(N'2016-11-21 11:10:22.573' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.587' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 107, N'290', N'Iif([ACUM_D13]=1 , 0  , (([SUELDO] /30) * ( [DIASTRA])) / 12 )', 1, N'', CAST(N'2016-11-21 11:10:22.600' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.613' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 108, N'289', N'Iif([ACUM_D14]=1 , 0 , ([SBU]/360) * ( [DIASTRA] ))', 1, N'', CAST(N'2016-11-21 11:10:22.627' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.640' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 199, N'500', N'[SUELDO] + [FNDO_RSVA] + [XIII_SUELD] + [XIV_SUELDO]', 1, N'', CAST(N'2016-11-21 11:10:22.653' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.667' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 201, N'6', N'[IESS_PERS%] * [SUELDO]', 1, N'', CAST(N'2016-11-21 11:10:22.680' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.693' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 298, N'900', N'[IESS_PERS]', 1, N'', CAST(N'2016-11-21 11:10:22.707' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.720' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 299, N'950', N'[INGRESOS] - [EGRESOS]', 1, N'', CAST(N'2016-11-21 11:10:22.733' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.750' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 300, N'199', N'Iif([ACUM_D13]=1 ,  ((([SUELDO] /30) * ( [DIASTRA])) / 12)  , 0)', 0, N'', CAST(N'2016-11-21 11:10:22.763' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.777' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 301, N'200', N'Iif([ACUM_D14]=1 ,([SBU]/360) *  [DIASTRA]  , 0 )', 0, N'', CAST(N'2016-11-21 11:10:22.790' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.803' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 302, N'198', N'Iif([ACUM_FR]=1 , (Iif([DIAS_ANT]>=360,[SUELDO]*0.0833  , 0 )) , 0 )', 0, N'', CAST(N'2016-11-21 11:10:22.817' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.830' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 303, N'493', N'[SUELDO] * [IESS_PATR%]', 0, N'', CAST(N'2016-11-21 11:10:22.843' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.860' AS Date), N'admin')
INSERT [dbo].[ro_nomina_tipo_liqui_orden] ([IdEmpresa], [IdNominaTipo], [IdNominaTipoLiqui], [Orden], [IdRubro], [Formula], [EsVisible], [Descripcion], [FechaIngresa], [UsuarioIngresa], [FechaModifica], [UsuarioModifica]) VALUES (@IdEmpresa, 2, 3, 304, N'295', N'[SUELDO] / 24', 0, N'', CAST(N'2016-11-21 11:10:22.870' AS Date), N'admin', CAST(N'2016-11-21 11:10:22.887' AS Date), N'admin')


INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 1, N'DIBUJANTE', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 2, N'SOLDADOR', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 3, N'AUXILIAR EN EL SECTOR DE METALMECANICA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 4, N'ARMADOR', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 5, N'OPERARIO', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 6, N'AYUDANTE DE TALLER', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 7, N'AUXILIAR DE SERVICIOS EN GENERAL', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 8, N'SOLDADOR', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 9, N'ASISTENTE CONTABLE', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 10, N'ANALISTA  DEL SECTOR DE METALMECANICA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 11, N'SUPERVISOR', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 12, N'OFICINISTA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 13, N'PORTERO-GUARDIA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 14, N'ARMADOR', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 15, N'SECRETARIA GERENCIA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 16, N'AUXILIAR DE SERVICIOS EN GENERAL-GUARDIA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 17, N'TOPOGRAFO', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 18, N'COORDINADORA CTAS X COBRAR', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 19, N'MENSAJERO', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 20, N'JEFE DE SECCION', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 21, N'CONSERJE-GUARDIA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 22, N'DIBUJANTE', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 23, N'OPERADOR DE BODEGA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 24, N'RETROEXCAVADORA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 25, N'ASISTENTE CONTABLE', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 26, N'ASISTENTE FINANCIERO', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 27, N'PINTOR', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 28, N'SECRETARIA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 29, N'CONTADORA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 30, N'COORDINADORA DE SSOMA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 31, N'BODEGUERO', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 32, N'AUXILIAR DEL SECTOR DE METALMECANICA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 33, N'ADMINISTRADOR GENERAL', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 34, N'AUXILIAR ADMINISTRATIVO', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 35, N'CHOFER', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 36, N'COORDINADORA RECURSOS HUMANOS', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 37, N'JEFE DE TALLER', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 38, N'JEFE DPTO TECNICO', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 39, N'OPERADOR GENERAL DE MAQUINARIA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 40, N'AYUDANTE DE BODEGA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 41, N'VENDEDOR DE PEDIDO PROGRAMADO', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 42, N'AYUDANTE DE PEDIDO PROGRAMADO', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 43, N'CHOFER DE GRUA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ro_cargo] ([IdEmpresa], [IdCargo], [ca_descripcion], [Estado], [IdUsuario], [Fecha_Transac], [IdUsuarioUltMod], [Fecha_UltMod], [IdUsuarioUltAnu], [Fecha_UltAnu], [nom_pc], [ip], [MotivoAnulacion]) VALUES (@IdEmpresa, 44, N'CHOFER DE PLATAFORMA', N'A', N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)


INSERT [dbo].[tb_banco_procesos_bancarios_x_empresa] ([IdEmpresa], [IdProceso_bancario_tipo], [IdBanco], [cod_banco], [Codigo_Empresa], [Secuencial_detalle_inicial], [IdTipoNota], [Se_contabiliza]) VALUES (@IdEmpresa, N'PAGO_BANCO_PACIFICO_BPA', 11, N'11', N'SN', NULL, NULL, NULL)
INSERT [dbo].[tb_banco_procesos_bancarios_x_empresa] ([IdEmpresa], [IdProceso_bancario_tipo], [IdBanco], [cod_banco], [Codigo_Empresa], [Secuencial_detalle_inicial], [IdTipoNota], [Se_contabiliza]) VALUES (@IdEmpresa, N'PAGO_PROVEE_MISMO_BANC_BG', 4, N'4', N'BM5', NULL, NULL, NULL)
INSERT [dbo].[tb_banco_procesos_bancarios_x_empresa] ([IdEmpresa], [IdProceso_bancario_tipo], [IdBanco], [cod_banco], [Codigo_Empresa], [Secuencial_detalle_inicial], [IdTipoNota], [Se_contabiliza]) VALUES (@IdEmpresa, N'PAGO_PROVEE_OTROS_BANC_BG', 4, N'4', N'B5M', NULL, NULL, NULL)
INSERT [dbo].[tb_banco_procesos_bancarios_x_empresa] ([IdEmpresa], [IdProceso_bancario_tipo], [IdBanco], [cod_banco], [Codigo_Empresa], [Secuencial_detalle_inicial], [IdTipoNota], [Se_contabiliza]) VALUES (@IdEmpresa, N'PAGO_PROVEEDORES_BOL', 14, N'34', N'763', CAST(138 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[tb_banco_procesos_bancarios_x_empresa] ([IdEmpresa], [IdProceso_bancario_tipo], [IdBanco], [cod_banco], [Codigo_Empresa], [Secuencial_detalle_inicial], [IdTipoNota], [Se_contabiliza]) VALUES (@IdEmpresa, N'PAGO_PROVEEDORES_BP', 3, N'3', N'sn', NULL, NULL, NULL)
INSERT [dbo].[tb_banco_procesos_bancarios_x_empresa] ([IdEmpresa], [IdProceso_bancario_tipo], [IdBanco], [cod_banco], [Codigo_Empresa], [Secuencial_detalle_inicial], [IdTipoNota], [Se_contabiliza]) VALUES (@IdEmpresa, N'PAGO_VENTANILLA_BG', 4, N'4', N'B5M', NULL, NULL, NULL)
INSERT [dbo].[tb_banco_procesos_bancarios_x_empresa] ([IdEmpresa], [IdProceso_bancario_tipo], [IdBanco], [cod_banco], [Codigo_Empresa], [Secuencial_detalle_inicial], [IdTipoNota], [Se_contabiliza]) VALUES (@IdEmpresa, N'PREAVISO_CHEQ', 14, N'34', N'763', NULL, NULL, NULL)
INSERT [dbo].[tb_banco_procesos_bancarios_x_empresa] ([IdEmpresa], [IdProceso_bancario_tipo], [IdBanco], [cod_banco], [Codigo_Empresa], [Secuencial_detalle_inicial], [IdTipoNota], [Se_contabiliza]) VALUES (@IdEmpresa, N'ROL_ELECTRONICO_BG', 4, N'4', N'B5M', NULL, NULL, NULL)
INSERT [dbo].[tb_banco_procesos_bancarios_x_empresa] ([IdEmpresa], [IdProceso_bancario_tipo], [IdBanco], [cod_banco], [Codigo_Empresa], [Secuencial_detalle_inicial], [IdTipoNota], [Se_contabiliza]) VALUES (@IdEmpresa, N'TRANSF_BANCARIA_BP', 3, N'3', N'B5M', NULL, NULL, NULL)
INSERT [dbo].[tb_banco_procesos_bancarios_x_empresa] ([IdEmpresa], [IdProceso_bancario_tipo], [IdBanco], [cod_banco], [Codigo_Empresa], [Secuencial_detalle_inicial], [IdTipoNota], [Se_contabiliza]) VALUES (@IdEmpresa, N'TRANSF_CTA_BG', 4, N'4', N'B5M', NULL, NULL, NULL)
INSERT [dbo].[tb_banco_procesos_bancarios_x_empresa] ([IdEmpresa], [IdProceso_bancario_tipo], [IdBanco], [cod_banco], [Codigo_Empresa], [Secuencial_detalle_inicial], [IdTipoNota], [Se_contabiliza]) VALUES (@IdEmpresa, N'TRANSF_CTA_OTROS_BANCO_BG', 4, N'4', N'B5M', NULL, NULL, NULL)
*/