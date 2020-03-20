CREATE VIEW Fj_servindustrias.vwROL_Rpt002
AS
SELECT dbo.ro_rol_detalle.IdEmpresa, dbo.ro_rol_detalle.IdNominaTipo, dbo.ro_periodo.pe_anio, dbo.ro_periodo.pe_mes, dbo.tb_persona.pe_cedulaRuc, dbo.tb_persona.pe_apellido + ' ' + dbo.tb_persona.pe_nombre AS Nombres, 
                  dbo.ro_rubro_tipo.ru_descripcion, dbo.ro_cargo.ca_descripcion, Fj_servindustrias.ro_zona.zo_descripcion, Fj_servindustrias.ro_fuerza.fu_descripcion, dbo.ro_rubro_tipo.ru_orden, SUM(dbo.ro_rol_detalle.Valor) AS Expr1, 
                  dbo.ro_rol_detalle.IdEmpleado
FROM     dbo.ro_periodo_x_ro_Nomina_TipoLiqui INNER JOIN
                  dbo.ro_periodo ON dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = dbo.ro_periodo.IdEmpresa AND dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = dbo.ro_periodo.IdPeriodo INNER JOIN
                  dbo.ro_rol_detalle INNER JOIN
                  dbo.ro_empleado ON dbo.ro_rol_detalle.IdEmpresa = dbo.ro_empleado.IdEmpresa AND dbo.ro_rol_detalle.IdEmpleado = dbo.ro_empleado.IdEmpleado ON 
                  dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = dbo.ro_rol_detalle.IdEmpresa AND dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo = dbo.ro_rol_detalle.IdNominaTipo AND 
                  dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui = dbo.ro_rol_detalle.IdNominaTipoLiqui AND dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = dbo.ro_rol_detalle.IdPeriodo INNER JOIN
                  dbo.ro_rubro_tipo ON dbo.ro_rol_detalle.IdEmpresa = dbo.ro_rubro_tipo.IdEmpresa AND dbo.ro_rol_detalle.IdRubro = dbo.ro_rubro_tipo.IdRubro INNER JOIN
                  dbo.ro_cargo ON dbo.ro_empleado.IdEmpresa = dbo.ro_cargo.IdEmpresa AND dbo.ro_empleado.IdCargo = dbo.ro_cargo.IdCargo INNER JOIN
                  Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det ON dbo.ro_empleado.IdEmpresa = Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa AND 
                  dbo.ro_empleado.IdEmpleado = Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpleado AND dbo.ro_empleado.IdEmpresa = Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa AND 
                  dbo.ro_empleado.IdEmpleado = Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpleado AND dbo.ro_empleado.IdEmpresa = Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa AND 
                  dbo.ro_empleado.IdEmpleado = Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpleado INNER JOIN
                  Fj_servindustrias.ro_fuerza ON Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa = Fj_servindustrias.ro_fuerza.IdEmpresa AND 
                  Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdFuerza = Fj_servindustrias.ro_fuerza.IdFuerza AND Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa = Fj_servindustrias.ro_fuerza.IdEmpresa AND 
                  Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdFuerza = Fj_servindustrias.ro_fuerza.IdFuerza AND Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa = Fj_servindustrias.ro_fuerza.IdEmpresa AND 
                  Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdFuerza = Fj_servindustrias.ro_fuerza.IdFuerza AND Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa = Fj_servindustrias.ro_fuerza.IdEmpresa AND 
                  Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdFuerza = Fj_servindustrias.ro_fuerza.IdFuerza AND Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa = Fj_servindustrias.ro_fuerza.IdEmpresa AND 
                  Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdFuerza = Fj_servindustrias.ro_fuerza.IdFuerza INNER JOIN
                  Fj_servindustrias.ro_zona ON Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa = Fj_servindustrias.ro_zona.IdEmpresa AND 
                  Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdZona = Fj_servindustrias.ro_zona.IdZona AND Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa = Fj_servindustrias.ro_zona.IdEmpresa AND 
                  Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdZona = Fj_servindustrias.ro_zona.IdZona AND Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa = Fj_servindustrias.ro_zona.IdEmpresa AND 
                  Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdZona = Fj_servindustrias.ro_zona.IdZona AND Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa = Fj_servindustrias.ro_zona.IdEmpresa AND 
                  Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdZona = Fj_servindustrias.ro_zona.IdZona AND Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdEmpresa = Fj_servindustrias.ro_zona.IdEmpresa AND 
                  Fj_servindustrias.ro_planificacion_x_ruta_x_empleado_det.IdZona = Fj_servindustrias.ro_zona.IdZona INNER JOIN
                  dbo.tb_persona ON dbo.ro_empleado.IdPersona = dbo.tb_persona.IdPersona AND dbo.ro_empleado.IdPersona = dbo.tb_persona.IdPersona AND dbo.ro_empleado.IdPersona = dbo.tb_persona.IdPersona AND 
                  dbo.ro_empleado.IdPersona = dbo.tb_persona.IdPersona AND dbo.ro_empleado.IdPersona = dbo.tb_persona.IdPersona
WHERE  (dbo.ro_rubro_tipo.ru_tipo IN ('I', 'E'))
GROUP BY dbo.ro_rol_detalle.IdEmpresa, dbo.ro_rol_detalle.IdNominaTipo, dbo.ro_periodo.pe_anio, dbo.ro_periodo.pe_mes, dbo.tb_persona.pe_cedulaRuc, dbo.tb_persona.pe_apellido + ' ' + dbo.tb_persona.pe_nombre, 
                  dbo.ro_rubro_tipo.ru_descripcion, dbo.ro_cargo.ca_descripcion, Fj_servindustrias.ro_zona.zo_descripcion, Fj_servindustrias.ro_fuerza.fu_descripcion, dbo.ro_rubro_tipo.ru_orden, dbo.ro_rol_detalle.IdEmpleado
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwROL_Rpt002';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'       Bottom = 1178
               Right = 287
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_fuerza (Fj_servindustrias)"
            Begin Extent = 
               Top = 1183
               Left = 48
               Bottom = 1346
               Right = 281
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_zona (Fj_servindustrias)"
            Begin Extent = 
               Top = 1351
               Left = 48
               Bottom = 1514
               Right = 281
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tb_persona"
            Begin Extent = 
               Top = 1519
               Left = 48
               Bottom = 1682
               Right = 338
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
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwROL_Rpt002';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ro_periodo_x_ro_Nomina_TipoLiqui"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 293
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_periodo"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 338
               Right = 325
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_rol_detalle"
            Begin Extent = 
               Top = 343
               Left = 48
               Bottom = 506
               Right = 373
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_empleado"
            Begin Extent = 
               Top = 511
               Left = 48
               Bottom = 674
               Right = 411
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_rubro_tipo"
            Begin Extent = 
               Top = 679
               Left = 48
               Bottom = 842
               Right = 362
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_cargo"
            Begin Extent = 
               Top = 847
               Left = 48
               Bottom = 1010
               Right = 321
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_planificacion_x_ruta_x_empleado_det (Fj_servindustrias)"
            Begin Extent = 
               Top = 1015
               Left = 48
        ', @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwROL_Rpt002';

