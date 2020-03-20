CREATE VIEW dbo.vwAca_Contrato_x_Estudiante_Detalle_a_Prefacturar
AS
SELECT Cont_Det.IdInstitucion, Cont_Det.IdContrato, Cont_Det.IdRubro, Rub_x_Period.IdInstitucion_per, Rub_x_Period.IdAnioLectivo, Rub_x_Period.IdPeriodo, R.IdGrupoFE, R.IdProducto_inv, R.Descripcion_rubro, 
                  fam_x_estud.IdEstudiante, fam_x_estud.IdFamiliar, fam_x_estud.IdParentesco_cat, dbo.Aca_Contrato_x_Estudiante.IdSede
FROM     dbo.Aca_Rubro AS R INNER JOIN
                  dbo.Aca_Rubro_x_Aca_Periodo_Lectivo AS Rub_x_Period ON R.IdRubro = Rub_x_Period.IdRubro AND R.IdInstitucion = Rub_x_Period.IdInstitucion_rub INNER JOIN
                  dbo.Aca_Contrato_x_Estudiante_det AS Cont_Det ON Rub_x_Period.IdInstitucion_rub = Cont_Det.IdInstitucion AND Rub_x_Period.IdRubro = Cont_Det.IdRubro AND 
                  Rub_x_Period.IdInstitucion_per = Cont_Det.IdInstitucion_Per AND Rub_x_Period.IdAnioLectivo = Cont_Det.IdAnioLectivo_Per AND Rub_x_Period.IdPeriodo = Cont_Det.IdPeriodo_Per INNER JOIN
                  dbo.Aca_Contrato_x_Estudiante ON Cont_Det.IdInstitucion = dbo.Aca_Contrato_x_Estudiante.IdInstitucion AND Cont_Det.IdContrato = dbo.Aca_Contrato_x_Estudiante.IdContrato INNER JOIN
                  dbo.Aca_matricula AS Matricula ON dbo.Aca_Contrato_x_Estudiante.IdInstitucion = Matricula.IdInstitucion AND dbo.Aca_Contrato_x_Estudiante.IdMatricula = Matricula.IdMatricula AND 
                  dbo.Aca_Contrato_x_Estudiante.IdEstudiante = Matricula.IdEstudiante INNER JOIN
                  dbo.Aca_estudiante ON Matricula.IdInstitucion = dbo.Aca_estudiante.IdInstitucion AND Matricula.IdEstudiante = dbo.Aca_estudiante.IdEstudiante INNER JOIN
                  dbo.Aca_Familiar_x_Estudiante AS fam_x_estud ON dbo.Aca_estudiante.IdInstitucion = fam_x_estud.IdInstitucion AND dbo.Aca_estudiante.IdEstudiante = fam_x_estud.IdEstudiante AND 
                  (fam_x_estud.IdParentesco_cat = 'REP_ECO' OR
                  fam_x_estud.IdParentesco_cat = 'REP_ECO_DUAL') AND Cont_Det.estado = 1 AND dbo.Aca_Contrato_x_Estudiante.estado = 1
WHERE  (NOT EXISTS
                      (SELECT IdInstitucion
                       FROM      dbo.Aca_Pre_Facturacion_det AS pf2
                       WHERE   (Cont_Det.IdInstitucion = IdInstitucion) AND (Cont_Det.IdInstitucion_Per = IdInstitucion_Per) AND (Cont_Det.IdAnioLectivo_Per = IdAnioLectivo_Per) AND (Cont_Det.IdContrato = IdContrato) AND 
                                         (Cont_Det.IdPeriodo_Per = IdPeriodo_Per) AND (Cont_Det.IdRubro = IdRubro)))
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwAca_Contrato_x_Estudiante_Detalle_a_Prefacturar';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'          DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 22
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 2088
         Width = 2100
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
         Width = 1200
         Width = 1200
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
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwAca_Contrato_x_Estudiante_Detalle_a_Prefacturar';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[18] 2[21] 3) )"
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
         Begin Table = "R"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 292
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Rub_x_Period"
            Begin Extent = 
               Top = 7
               Left = 340
               Bottom = 170
               Right = 584
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Cont_Det"
            Begin Extent = 
               Top = 7
               Left = 632
               Bottom = 170
               Right = 876
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Aca_Contrato_x_Estudiante"
            Begin Extent = 
               Top = 4
               Left = 990
               Bottom = 283
               Right = 1319
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Matricula"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 338
               Right = 315
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Aca_estudiante"
            Begin Extent = 
               Top = 175
               Left = 363
               Bottom = 338
               Right = 607
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fam_x_estud"
            Begin Extent = 
               Top = 175
               Left = 655
               Bottom = 338
               Right = 966
            End
  ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwAca_Contrato_x_Estudiante_Detalle_a_Prefacturar';

