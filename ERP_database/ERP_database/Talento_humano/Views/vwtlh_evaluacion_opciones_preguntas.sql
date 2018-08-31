CREATE VIEW Talento_humano.vwtlh_evaluacion_opciones_preguntas
AS
SELECT        Talento_humano.tlh_evaluacion_opciones_preguntas.IdEmpresa, Talento_humano.tlh_evaluacion_opciones_preguntas.IdPregunta, Talento_humano.tlh_evaluacion_opciones_preguntas.IdOpciones, 
                         Talento_humano.tlh_evaluacion_opciones_preguntas.Numero_opciones, Talento_humano.tlh_evaluacion_opciones_preguntas.Descripcion, 
                         Talento_humano.tlh_evaluacion_opciones_preguntas_respuesta_det.IdCalendario
FROM            Talento_humano.tlh_evaluacion_opciones INNER JOIN
                         Talento_humano.tlh_evaluacion_opciones_preguntas ON Talento_humano.tlh_evaluacion_opciones.IdEmpresa = Talento_humano.tlh_evaluacion_opciones_preguntas.IdEmpresa AND 
                         Talento_humano.tlh_evaluacion_opciones.IdOpciones = Talento_humano.tlh_evaluacion_opciones_preguntas.IdOpciones INNER JOIN
                         Talento_humano.tlh_evaluacion_opciones_preguntas_det ON Talento_humano.tlh_evaluacion_opciones_preguntas.IdEmpresa = Talento_humano.tlh_evaluacion_opciones_preguntas_det.IdEmpresa AND 
                         Talento_humano.tlh_evaluacion_opciones_preguntas.IdPregunta = Talento_humano.tlh_evaluacion_opciones_preguntas_det.IdPregunta INNER JOIN
                         Talento_humano.tlh_evaluacion_opciones_preguntas_respuesta_det ON 
                         Talento_humano.tlh_evaluacion_opciones_preguntas_det.IdEmpresa = Talento_humano.tlh_evaluacion_opciones_preguntas_respuesta_det.IdEmpresa AND 
                         Talento_humano.tlh_evaluacion_opciones_preguntas_det.IdPregunta = Talento_humano.tlh_evaluacion_opciones_preguntas_respuesta_det.IdPregunta AND 
                         Talento_humano.tlh_evaluacion_opciones_preguntas_det.secuencia = Talento_humano.tlh_evaluacion_opciones_preguntas_respuesta_det.secuencia
GROUP BY Talento_humano.tlh_evaluacion_opciones_preguntas.IdEmpresa, Talento_humano.tlh_evaluacion_opciones_preguntas.IdPregunta, Talento_humano.tlh_evaluacion_opciones_preguntas.IdOpciones, 
                         Talento_humano.tlh_evaluacion_opciones_preguntas.Numero_opciones, Talento_humano.tlh_evaluacion_opciones_preguntas.Descripcion, Talento_humano.tlh_evaluacion_opciones_preguntas_respuesta_det.IdCalendario
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'Talento_humano', @level1type = N'VIEW', @level1name = N'vwtlh_evaluacion_opciones_preguntas';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'170
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
', @level0type = N'SCHEMA', @level0name = N'Talento_humano', @level1type = N'VIEW', @level1name = N'vwtlh_evaluacion_opciones_preguntas';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[58] 4[5] 2[5] 3) )"
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
         Begin Table = "tlh_evaluacion_opciones (Talento_humano)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 238
               Right = 266
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tlh_evaluacion_opciones_preguntas (Talento_humano)"
            Begin Extent = 
               Top = 21
               Left = 283
               Bottom = 231
               Right = 642
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tlh_evaluacion_opciones_preguntas_respuesta_det (Talento_humano)"
            Begin Extent = 
               Top = 28
               Left = 1002
               Bottom = 271
               Right = 1392
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tlh_evaluacion_opciones_preguntas_det (Talento_humano)"
            Begin Extent = 
               Top = 13
               Left = 588
               Bottom = 235
               Right = 953
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
         Width = 3015
         Width = 1995
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
         NewValue = 1', @level0type = N'SCHEMA', @level0name = N'Talento_humano', @level1type = N'VIEW', @level1name = N'vwtlh_evaluacion_opciones_preguntas';

