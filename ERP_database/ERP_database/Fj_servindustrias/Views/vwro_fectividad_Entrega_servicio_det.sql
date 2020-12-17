CREATE VIEW Fj_servindustrias.vwro_fectividad_Entrega_servicio_det
AS
SELECT        Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpresa, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdNivelServicio, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Secuencia, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdRuta, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpleado, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_car_bebi, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_car_bebi_apl, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_vol_bebi, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_vol_bebi_apl, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_ent_bebi, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_ent_bebi_apl, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_car_alim, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_car_alim_ap, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_vol_alim, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_vol_alim_apl, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_ent_alim, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_ent_alim_apl, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_serv, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Efe_ser_apl, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Nivel_servicio, Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Valor_volumen, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.Valor_servicio, dbo.tb_persona.pe_nombreCompleto, Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNomina_Tipo, 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNomina_tipo_Liq, Fj_servindustrias.ro_fectividad_Entrega_servicio.IdPeriodo
FROM            Fj_servindustrias.ro_fectividad_Entrega_servicio_det INNER JOIN
                         dbo.ro_empleado ON Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpresa = dbo.ro_empleado.IdEmpresa AND 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpleado = dbo.ro_empleado.IdEmpleado INNER JOIN
                         dbo.tb_persona ON dbo.ro_empleado.IdPersona = dbo.tb_persona.IdPersona INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_servicio ON Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdEmpresa = Fj_servindustrias.ro_fectividad_Entrega_servicio.IdEmpresa AND 
                         Fj_servindustrias.ro_fectividad_Entrega_servicio_det.IdNivelServicio = Fj_servindustrias.ro_fectividad_Entrega_servicio.IdNivelServicio
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwro_fectividad_Entrega_servicio_det';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[86] 4[5] 2[5] 3) )"
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
         Begin Table = "ro_fectividad_Entrega_servicio_det (Fj_servindustrias)"
            Begin Extent = 
               Top = 31
               Left = 237
               Bottom = 353
               Right = 465
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_empleado"
            Begin Extent = 
               Top = 34
               Left = 513
               Bottom = 325
               Right = 802
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tb_persona"
            Begin Extent = 
               Top = 26
               Left = 844
               Bottom = 328
               Right = 1076
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_fectividad_Entrega_servicio (Fj_servindustrias)"
            Begin Extent = 
               Top = 32
               Left = 14
               Bottom = 337
               Right = 203
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
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwro_fectividad_Entrega_servicio_det';

