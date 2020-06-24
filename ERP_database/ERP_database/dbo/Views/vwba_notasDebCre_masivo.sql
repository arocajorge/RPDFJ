﻿CREATE VIEW [dbo].[vwba_notasDebCre_masivo]
AS
SELECT     dbo.ba_notasDebCre_masivo.IdEmpresa, dbo.ba_notasDebCre_masivo.IdTransaccion, dbo.ba_notasDebCre_masivo.Deb_Cred AS tm_tipo, 
                      dbo.ba_Cbte_Ban.IdBanco AS tm_IdBanco, dbo.ba_notasDebCre_masivo.fecha AS tm_fecha, dbo.ba_notasDebCre_masivo.Observacion AS tm_observacion, 
                      dbo.ba_notasDebCre_masivo.IdUsuario AS tm_IdUsuario, dbo.ba_Cbte_Ban.cb_Valor, dbo.ba_Cbte_Ban.cb_Observacion, dbo.ba_Cbte_Ban.cb_Fecha, 
                      dbo.ba_Cbte_Ban.IdCbteCble AS cb_IdCbteCble, dbo.ba_Cbte_Ban.IdTipocbte AS cb_IdTipoCte, dbo.ba_tipo_nota.IdTipoNota, 
                      dbo.ba_tipo_nota.Descripcion AS tn_descripcion, dbo.ba_tipo_nota.Tipo AS tn_tipo, dbo.ba_tipo_nota.IdCtaCble AS tn_IdCtaCble, 
                      dbo.ba_tipo_nota.IdCentroCosto AS tn_IdCentroCosto
FROM         dbo.ba_notasDebCre_masivo INNER JOIN
                      dbo.ba_Cbte_Ban ON dbo.ba_notasDebCre_masivo.IdCbteCble_cb = dbo.ba_Cbte_Ban.IdCbteCble AND 
                      dbo.ba_notasDebCre_masivo.IdTipocbte_cb = dbo.ba_Cbte_Ban.IdTipocbte AND 
                      dbo.ba_notasDebCre_masivo.IdEmpresa_cb = dbo.ba_Cbte_Ban.IdEmpresa INNER JOIN
                      dbo.ba_tipo_nota ON dbo.ba_Cbte_Ban.IdEmpresa = dbo.ba_tipo_nota.IdEmpresa AND dbo.ba_Cbte_Ban.IdTipoNota = dbo.ba_tipo_nota.IdTipoNota
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwba_notasDebCre_masivo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwba_notasDebCre_masivo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[29] 4[44] 2[5] 3) )"
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
         Begin Table = "ba_Cbte_Ban"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 364
               Right = 431
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ba_tipo_nota"
            Begin Extent = 
               Top = 23
               Left = 566
               Bottom = 189
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ba_notasDebCre_masivo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 206
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 19
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
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1680
         Table = 2025
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
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwba_notasDebCre_masivo';

