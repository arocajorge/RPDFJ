CREATE VIEW Fj_servindustrias.vwro_fectividad_Entrega_servicio
AS
SELECT        Fj_servindustrias.ro_fectividad_Entrega_servicio.IdEmpresa, Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNivelServicio, Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNomina_Tipo, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNomina_tipo_Liq, Fj_servindustrias.ro_fectividad_Entrega_servicio.IdPeriodo, Fj_servindustrias.ro_fectividad_Entrega_servicio.Observacion, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio.Estado, Fj_servindustrias.ro_fectividad_Entrega_servicio.IdUsuario, dbo.ro_Nomina_Tipoliqui.DescripcionProcesoNomina, dbo.ro_Nomina_Tipo.Descripcion, 
                         dbo.ro_periodo.pe_FechaIni, dbo.ro_periodo.pe_FechaFin, Fj_servindustrias.ro_fectividad_Entrega_servicio.IdServicioTipo
FROM            dbo.ro_Nomina_Tipoliqui INNER JOIN
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui ON dbo.ro_Nomina_Tipoliqui.IdEmpresa = dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa AND 
                         dbo.ro_Nomina_Tipoliqui.IdNomina_Tipo = dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo AND dbo.ro_Nomina_Tipoliqui.IdNomina_TipoLiqui = dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui INNER JOIN
                         dbo.ro_Nomina_Tipo ON dbo.ro_Nomina_Tipoliqui.IdEmpresa = dbo.ro_Nomina_Tipo.IdEmpresa AND dbo.ro_Nomina_Tipoliqui.IdNomina_Tipo = dbo.ro_Nomina_Tipo.IdNomina_Tipo INNER JOIN
                         dbo.ro_periodo ON dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = dbo.ro_periodo.IdEmpresa AND dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = dbo.ro_periodo.IdPeriodo RIGHT OUTER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_servicio ON dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = Fj_servindustrias.ro_fectividad_Entrega_servicio.IdEmpresa AND 
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo = Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNomina_Tipo AND 
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui = Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNomina_tipo_Liq AND 
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = Fj_servindustrias.ro_fectividad_Entrega_servicio.IdPeriodo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwro_fectividad_Entrega_servicio';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwro_fectividad_Entrega_servicio';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[83] 4[5] 2[5] 3) )"
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
         Begin Table = "ro_Nomina_Tipoliqui"
            Begin Extent = 
               Top = 38
               Left = 694
               Bottom = 256
               Right = 930
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_periodo_x_ro_Nomina_TipoLiqui"
            Begin Extent = 
               Top = 31
               Left = 400
               Bottom = 312
               Right = 597
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_Nomina_Tipo"
            Begin Extent = 
               Top = 105
               Left = 960
               Bottom = 235
               Right = 1142
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_periodo"
            Begin Extent = 
               Top = 204
               Left = 640
               Bottom = 446
               Right = 861
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_fectividad_Entrega_servicio (Fj_servindustrias)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 412
               Right = 350
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
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy', @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwro_fectividad_Entrega_servicio';

