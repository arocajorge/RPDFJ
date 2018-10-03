CREATE VIEW dbo.vwro_empleadoXdepXcargo
AS
SELECT        dbo.ro_cargo.ca_descripcion AS cargo, dbo.ro_Departamento.de_descripcion AS departamento, dbo.ro_empleado.IdEmpresa, dbo.ro_empleado.IdEmpleado, dbo.ro_empleado.IdEmpleado_Supervisor, 
                         dbo.ro_empleado.IdPersona, dbo.ro_empleado.IdTipoEmpleado, dbo.ro_empleado.em_codigo, dbo.ro_empleado.em_lugarNacimiento, dbo.ro_empleado.em_CarnetIees, dbo.ro_empleado.em_cedulaMil, 
                         dbo.ro_empleado.em_fecha_ingreso, dbo.ro_empleado.em_fechaSalida, dbo.ro_empleado.em_fechaTerminoContra, dbo.ro_empleado.em_fechaIngaRol, dbo.ro_empleado.em_SeAcreditaBanco, dbo.ro_empleado.em_tipoCta, 
                         dbo.ro_empleado.em_NumCta, dbo.ro_empleado.em_SepagaBeneficios, dbo.ro_empleado.em_SePagaConTablaSec, dbo.ro_empleado.em_estado, dbo.ro_empleado.em_sueldoBasicoMen, 
                         dbo.ro_empleado.em_SueldoExtraMen, dbo.ro_empleado.em_MovilizacionQuincenal, dbo.ro_empleado.em_foto, dbo.ro_empleado.em_empEspecial, dbo.ro_empleado.em_pagoFdoRsv, dbo.ro_empleado.em_huella, 
                         dbo.ro_empleado.IdCodSectorial, dbo.ro_empleado.IdDepartamento, dbo.ro_empleado.IdTipoSangre, dbo.ro_empleado.IdCargo, dbo.ro_empleado.IdCtaCble_Emplea, dbo.ro_empleado.IdCiudad AS IdUbicacion, 
                         dbo.ro_empleado.em_mail, dbo.tb_persona.CodPersona, dbo.tb_persona.pe_Naturaleza, dbo.tb_persona.pe_nombreCompleto AS NomCompleto, dbo.tb_persona.pe_razonSocial, dbo.tb_persona.pe_apellido AS Apellido, 
                         dbo.tb_persona.pe_nombre AS Nombre, dbo.tb_persona.IdTipoPersona, dbo.tb_persona.IdTipoDocumento, dbo.tb_persona.pe_cedulaRuc, dbo.tb_persona.pe_direccion, dbo.tb_persona.pe_telefonoCasa, 
                         dbo.tb_persona.pe_telefonoOfic, dbo.tb_persona.pe_telefonoInter, dbo.tb_persona.pe_telfono_Contacto, dbo.tb_persona.pe_celular, dbo.tb_persona.pe_correo, dbo.tb_persona.pe_fax, dbo.tb_persona.pe_casilla, 
                         dbo.tb_persona.pe_sexo, dbo.tb_persona.IdEstadoCivil, dbo.tb_persona.pe_fechaNacimiento, dbo.tb_persona.pe_estado, dbo.tb_persona.pe_fechaCreacion, dbo.tb_persona.pe_fechaModificacion, 
                         dbo.tb_sucursal.Su_Descripcion AS Sucursal, dbo.ro_empleado.IdSucursal, dbo.tb_sucursal.IdEmpresa AS Expr1, dbo.ro_empleado.IdTipoLicencia, dbo.ro_empleado.IdCentroCosto, dbo.ro_empleado.IdBanco, 
                         dbo.ro_empleado.Archivo, dbo.ro_empleado.NombreArchivo, dbo.ro_empleado.Codigo_Biometrico, dbo.ro_empleado.IdArea, dbo.ro_empleado.IdDivision, dbo.ro_empleado.IdCentroCosto_sub_centro_costo, 
                         dbo.ro_empleado.por_discapacidad, dbo.ro_empleado.carnet_conadis, dbo.ro_empleado.recibi_uniforme, dbo.ro_empleado.talla_pant, dbo.ro_empleado.talla_camisa, dbo.ro_empleado.talla_zapato, 
                         dbo.ro_empleado.em_status, dbo.ro_empleado.IdCondicionDiscapacidadSRI, dbo.ro_empleado.IdTipoIdentDiscapacitadoSustitutoSRI, dbo.ro_empleado.IdentDiscapacitadoSustitutoSRI, 
                         dbo.ro_empleado.IdAplicaConvenioDobleImposicionSRI, dbo.ro_empleado.IdTipoResidenciaSRI, dbo.ro_empleado.IdTipoSistemaSalarioNetoSRI, dbo.ro_empleado.es_AcreditaHorasExtras, dbo.ro_empleado.IdTipoAnticipo, 
                         dbo.ro_empleado.em_AnticipoSueldo, dbo.ro_empleado.CodigoSectorial AS CodigoSectorialIESS, dbo.ro_empleado.es_TruncarDecimalAnticipo, dbo.tb_pais.IdPais, dbo.tb_provincia.IdProvincia, dbo.tb_ciudad.IdCiudad, 
                         dbo.ro_empleado.MotivoAnulacion, dbo.ro_empleado.IdGrupo, dbo.ro_empleado.Marca_Biometrico, dbo.tb_provincia.Cod_Region, dbo.ro_Nomina_Tipo.IdNomina_Tipo, dbo.ro_cargo.considera_pago_utilidad, 
                         dbo.ro_Nomina_Tipo.Descripcion
FROM            dbo.tb_persona INNER JOIN
                         dbo.ro_empleado ON dbo.tb_persona.IdPersona = dbo.ro_empleado.IdPersona INNER JOIN
                         dbo.tb_ciudad ON dbo.ro_empleado.IdCiudad = dbo.tb_ciudad.IdCiudad INNER JOIN
                         dbo.tb_provincia ON dbo.tb_ciudad.IdProvincia = dbo.tb_provincia.IdProvincia INNER JOIN
                         dbo.tb_pais ON dbo.tb_provincia.IdPais = dbo.tb_pais.IdPais INNER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON dbo.ro_empleado.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND dbo.ro_empleado.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado INNER JOIN
                         dbo.ro_Nomina_Tipo ON dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa = dbo.ro_Nomina_Tipo.IdEmpresa AND dbo.ro_empleado_x_ro_tipoNomina.IdTipoNomina = dbo.ro_Nomina_Tipo.IdNomina_Tipo LEFT OUTER JOIN
                         dbo.tb_sucursal ON dbo.ro_empleado.IdEmpresa = dbo.tb_sucursal.IdEmpresa AND dbo.ro_empleado.IdSucursal = dbo.tb_sucursal.IdSucursal LEFT OUTER JOIN
                         dbo.ro_Departamento ON dbo.ro_empleado.IdEmpresa = dbo.ro_Departamento.IdEmpresa AND dbo.ro_empleado.IdDepartamento = dbo.ro_Departamento.IdDepartamento LEFT OUTER JOIN
                         dbo.ro_cargo ON dbo.ro_empleado.IdEmpresa = dbo.ro_cargo.IdEmpresa AND dbo.ro_empleado.IdCargo = dbo.ro_cargo.IdCargo


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwro_empleadoXdepXcargo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'       End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tb_sucursal"
            Begin Extent = 
               Top = 666
               Left = 38
               Bottom = 796
               Right = 268
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_Departamento"
            Begin Extent = 
               Top = 534
               Left = 258
               Bottom = 664
               Right = 463
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_cargo"
            Begin Extent = 
               Top = 798
               Left = 38
               Bottom = 928
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwro_empleadoXdepXcargo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[5] 2[5] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -384
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tb_persona"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 270
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_empleado"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 327
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tb_ciudad"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 400
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tb_provincia"
            Begin Extent = 
               Top = 270
               Left = 270
               Bottom = 400
               Right = 450
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tb_pais"
            Begin Extent = 
               Top = 402
               Left = 38
               Bottom = 532
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_empleado_x_ro_tipoNomina"
            Begin Extent = 
               Top = 402
               Left = 255
               Bottom = 532
               Right = 425
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_Nomina_Tipo"
            Begin Extent = 
               Top = 418
               Left = 690
               Bottom = 704
               Right = 872
     ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwro_empleadoXdepXcargo';

