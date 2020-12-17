CREATE VIEW dbo.vwro_permiso_x_empleado_x_novedad
AS
SELECT        dbo.ro_permiso_x_empleado_x_novedad.IdEmpresa, dbo.ro_permiso_x_empleado_x_novedad.IdNomina_Tipo, dbo.ro_permiso_x_empleado_x_novedad.IdEmpleado, dbo.ro_permiso_x_empleado_x_novedad.IdPermiso, 
                         dbo.ro_empleado_novedad_det.IdNomina_Tipo_Liq, dbo.ro_empleado_novedad_det.IdRol, dbo.ro_empleado_novedad_det.IdRubro, dbo.ro_empleado_novedad_det.FechaPago, dbo.ro_empleado_novedad_det.Valor, 
                         dbo.ro_empleado_novedad_det.Secuencia, dbo.ro_empleado_novedad_det.EstadoCobro, dbo.ro_empleado_novedad_det.Num_Horas
FROM            dbo.ro_permiso_x_empleado_x_novedad INNER JOIN
                         dbo.ro_empleado_novedad_det INNER JOIN
                         dbo.ro_empleado_Novedad ON dbo.ro_empleado_novedad_det.IdEmpresa = dbo.ro_empleado_Novedad.IdEmpresa AND dbo.ro_empleado_novedad_det.IdNovedad = dbo.ro_empleado_Novedad.IdNovedad AND 
                         dbo.ro_empleado_novedad_det.IdEmpleado = dbo.ro_empleado_Novedad.IdEmpleado ON dbo.ro_permiso_x_empleado_x_novedad.IdEmpresa_nov = dbo.ro_empleado_Novedad.IdEmpresa AND 
                         dbo.ro_permiso_x_empleado_x_novedad.IdNovedad = dbo.ro_empleado_Novedad.IdNovedad AND dbo.ro_permiso_x_empleado_x_novedad.IdEmpleado = dbo.ro_empleado_Novedad.IdEmpleado
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwro_permiso_x_empleado_x_novedad';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[69] 4[5] 2[9] 3) )"
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
         Begin Table = "ro_permiso_x_empleado_x_novedad"
            Begin Extent = 
               Top = 5
               Left = 0
               Bottom = 279
               Right = 239
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_empleado_novedad_det"
            Begin Extent = 
               Top = 48
               Left = 654
               Bottom = 337
               Right = 943
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ro_empleado_Novedad"
            Begin Extent = 
               Top = 37
               Left = 331
               Bottom = 279
               Right = 559
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
      Begin ColumnWidths = 12
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwro_permiso_x_empleado_x_novedad';



