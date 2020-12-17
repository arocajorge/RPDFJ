CREATE VIEW dbo.View_1
AS
SELECT        efe_det.IdEmpresa, efe_det.IdNomina_Tipo, efe_det.IdNomina_tipo_Liq, efe_det.IdPeriodo, efe_det.IdEmpleado, efe_det.IdRuta, efe_det.Efectividad_Entrega, efe_det.Efectividad_Entrega_aplica, efe_det.Efectividad_Volumen, 
                         efe_det.Efectividad_Volumen_aplica, efe_det.Recuperacion_cartera, efe_det.Recuperacion_cartera_aplica, efec.IdServicioTipo, efe_det.IdEfectividad, Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNomina_Tipo AS Expr1, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNomina_tipo_Liq AS Expr2, Fj_servindustrias.ro_fectividad_Entrega_servicio.IdPeriodo AS Expr3
FROM            Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado AS efec INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado_Det AS efe_det ON efec.IdEmpresa = efe_det.IdEmpresa AND efec.IdNomina_Tipo = efe_det.IdNomina_Tipo AND 
                         efec.IdNomina_tipo_Liq = efe_det.IdNomina_tipo_Liq AND efec.IdPeriodo = efe_det.IdPeriodo AND efec.IdEfectividad = efe_det.IdEfectividad INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_servicio ON Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpresa = Fj_servindustrias.ro_fectividad_Entrega_servicio.IdEmpresa AND 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdNivelServicio = Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNivelServicio ON 
                         efe_det.IdEmpresa = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpresa AND efe_det.IdEmpleado = Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpleado
GROUP BY efe_det.IdEmpresa, efe_det.IdNomina_Tipo, efe_det.IdNomina_tipo_Liq, efe_det.IdPeriodo, efe_det.IdEmpleado, efe_det.IdRuta, efe_det.Efectividad_Entrega, efe_det.Efectividad_Entrega_aplica, efe_det.Efectividad_Volumen, 
                         efe_det.Efectividad_Volumen_aplica, efe_det.Recuperacion_cartera, efe_det.Recuperacion_cartera_aplica, efec.IdServicioTipo, efe_det.IdEfectividad, Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNomina_Tipo, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNomina_tipo_Liq, Fj_servindustrias.ro_fectividad_Entrega_servicio.IdPeriodo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'View_1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1665
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'View_1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[64] 4[5] 2[5] 3) )"
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
         Begin Table = "efe_det"
            Begin Extent = 
               Top = 0
               Left = 159
               Bottom = 382
               Right = 498
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_fectividad_Entrega_servicio_det (Fj_servindustrias)"
            Begin Extent = 
               Top = 33
               Left = 442
               Bottom = 378
               Right = 728
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_fectividad_Entrega_servicio (Fj_servindustrias)"
            Begin Extent = 
               Top = 79
               Left = 825
               Bottom = 305
               Right = 1060
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "efec"
            Begin Extent = 
               Top = 15
               Left = 0
               Bottom = 315
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 18
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'View_1';

