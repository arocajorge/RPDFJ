CREATE VIEW dbo.vwAca_Contrato_x_Estudiante_Det_x_Rubro_x_fa_descuento
AS
SELECT row_number() over (order by contdet.FechaCreacion desc) as id,contdet.IdInstitucion, contdet.IdContrato, contdet.IdRubro, rubper.Valor AS ValorRubro, rubper.Valor * dbo.fa_descuento.de_porcentaje / 100 AS Valor_Descuento, contdet.IdInstitucion_Per, contdet.IdAnioLectivo_Per, 
                  contdet.IdPeriodo_Per, rubdesc.IdEmpresa_fadesc, rubdesc.IdDescuento, dbo.fa_descuento.de_porcentaje, contdet.FechaCreacion AS FechaCreacionContDet, rubdesc.Estado AS estado_rubro_x_fa_descuento, 
                  (CASE WHEN rubdesc.IdDescuento IS NULL THEN 0 ELSE 1 END) AS tiene_descuento
FROM     dbo.Aca_Rubro_x_Aca_Periodo_Lectivo AS rubper INNER JOIN
                  dbo.Aca_Contrato_x_Estudiante_det AS contdet ON rubper.IdInstitucion_rub = contdet.IdInstitucion AND rubper.IdRubro = contdet.IdRubro AND rubper.IdInstitucion_per = contdet.IdInstitucion_Per AND 
                  rubper.IdAnioLectivo = contdet.IdAnioLectivo_Per AND rubper.IdPeriodo = contdet.IdPeriodo_Per LEFT OUTER JOIN
                  dbo.fa_descuento INNER JOIN
                      (SELECT IdInstitucion_rub, IdRubro, IdEmpresa_fadesc, IdDescuento, Estado
                       FROM      dbo.Aca_Rubro_x_fa_descuento
                       GROUP BY IdInstitucion_rub, IdRubro, IdEmpresa_fadesc, IdDescuento, Estado) AS rubdesc ON dbo.fa_descuento.IdDescuento = rubdesc.IdDescuento AND 
                  dbo.fa_descuento.IdEmpresa = rubdesc.IdEmpresa_fadesc ON contdet.IdInstitucion = rubdesc.IdInstitucion_rub AND contdet.IdRubro = rubdesc.IdRubro
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwAca_Contrato_x_Estudiante_Det_x_Rubro_x_fa_descuento';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 3288
         Table = 2868
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwAca_Contrato_x_Estudiante_Det_x_Rubro_x_fa_descuento';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[33] 4[23] 2[19] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
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
         Configuration = "(H (1[41] 2) )"
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
         Begin Table = "contdet"
            Begin Extent = 
               Top = 0
               Left = 349
               Bottom = 375
               Right = 593
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "rubdesc"
            Begin Extent = 
               Top = 0
               Left = 664
               Bottom = 267
               Right = 908
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fa_descuento"
            Begin Extent = 
               Top = 0
               Left = 1027
               Bottom = 283
               Right = 1271
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rubper"
            Begin Extent = 
               Top = 0
               Left = 0
               Bottom = 260
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
      Begin ColumnWidths = 31
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1548
         Width = 1200
         Width = 1464
         Width = 2388
         Width = 1200
         Width = 1200
         Width = 1524
         Width = 2616
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwAca_Contrato_x_Estudiante_Det_x_Rubro_x_fa_descuento';

