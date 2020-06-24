CREATE VIEW dbo.vwAca_Rubro_x_fa_descuento
AS
SELECT dbo.Aca_Rubro_x_fa_descuento.IdInstitucion_rub, dbo.Aca_Rubro_x_fa_descuento.IdRubro, dbo.Aca_Rubro_x_fa_descuento.IdEmpresa_fadesc, dbo.Aca_Rubro_x_fa_descuento.IdDescuento, 
                  dbo.Aca_Sede.Descripcion_sede AS sede, dbo.Aca_Rubro.Descripcion_rubro AS rubro, dbo.fa_descuento.de_nombre AS descuento, dbo.fa_descuento.de_porcentaje AS porcentaje_descuento, 
                  dbo.Aca_Rubro_x_fa_descuento.Estado
FROM     dbo.Aca_Rubro INNER JOIN
                  dbo.Aca_Rubro_x_fa_descuento ON dbo.Aca_Rubro.IdInstitucion = dbo.Aca_Rubro_x_fa_descuento.IdInstitucion_rub AND dbo.Aca_Rubro.IdRubro = dbo.Aca_Rubro_x_fa_descuento.IdRubro INNER JOIN
                  dbo.fa_descuento ON dbo.Aca_Rubro_x_fa_descuento.IdEmpresa_fadesc = dbo.fa_descuento.IdEmpresa AND dbo.Aca_Rubro_x_fa_descuento.IdDescuento = dbo.fa_descuento.IdDescuento INNER JOIN
                  dbo.Aca_Sede ON dbo.Aca_Rubro.IdSede = dbo.Aca_Sede.IdSede
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwAca_Rubro_x_fa_descuento';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'     Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwAca_Rubro_x_fa_descuento';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[37] 2[4] 3) )"
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
         Begin Table = "Aca_Rubro"
            Begin Extent = 
               Top = 0
               Left = 305
               Bottom = 300
               Right = 549
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Aca_Rubro_x_fa_descuento"
            Begin Extent = 
               Top = 0
               Left = 637
               Bottom = 305
               Right = 920
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fa_descuento"
            Begin Extent = 
               Top = 0
               Left = 1111
               Bottom = 305
               Right = 1355
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Aca_Sede"
            Begin Extent = 
               Top = 0
               Left = 0
               Bottom = 284
               Right = 244
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
         Width = 1788
         Width = 1200
         Width = 1200
         Width = 1836
         Width = 1608
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 2124
         Width = 1200
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
    ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwAca_Rubro_x_fa_descuento';

