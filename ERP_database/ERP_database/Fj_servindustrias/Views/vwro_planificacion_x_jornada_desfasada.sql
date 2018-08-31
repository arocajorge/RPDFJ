CREATE VIEW Fj_servindustrias.vwro_planificacion_x_jornada_desfasada
AS
SELECT        Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdEmpresa, Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdPeriodo, Fj_servindustrias.ro_planificacion_x_jornada_desfasada.Observación, 
                         Fj_servindustrias.ro_planificacion_x_jornada_desfasada.Esta_Proceso, Fj_servindustrias.ro_planificacion_x_jornada_desfasada.Estado, dbo.ro_periodo.pe_FechaIni, dbo.ro_periodo.pe_FechaFin, 
                         Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdNomina_Tipo, Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdDivision, dbo.ro_Division.Descripcion, 
                         Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdPlanificacion
FROM            dbo.ro_periodo INNER JOIN
                         Fj_servindustrias.ro_planificacion_x_jornada_desfasada ON dbo.ro_periodo.IdEmpresa = Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdEmpresa AND 
                         dbo.ro_periodo.IdPeriodo = Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdPeriodo LEFT OUTER JOIN
                         dbo.ro_Division ON Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdEmpresa = dbo.ro_Division.IdEmpresa AND 
                         Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdDivision = dbo.ro_Division.IdDivision
GROUP BY Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdEmpresa, Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdPeriodo, Fj_servindustrias.ro_planificacion_x_jornada_desfasada.Observación, 
                         Fj_servindustrias.ro_planificacion_x_jornada_desfasada.Esta_Proceso, Fj_servindustrias.ro_planificacion_x_jornada_desfasada.Estado, dbo.ro_periodo.pe_FechaIni, dbo.ro_periodo.pe_FechaFin, 
                         Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdNomina_Tipo, Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdDivision, dbo.ro_Division.Descripcion, 
                         Fj_servindustrias.ro_planificacion_x_jornada_desfasada.IdPlanificacion
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwro_planificacion_x_jornada_desfasada';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[55] 4[4] 2[5] 3) )"
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
         Begin Table = "ro_periodo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 295
               Right = 275
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_planificacion_x_jornada_desfasada (Fj_servindustrias)"
            Begin Extent = 
               Top = 21
               Left = 516
               Bottom = 352
               Right = 711
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "ro_Division"
            Begin Extent = 
               Top = 8
               Left = 853
               Bottom = 266
               Right = 1048
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
      Begin ColumnWidths = 11
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
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
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
', @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwro_planificacion_x_jornada_desfasada';

