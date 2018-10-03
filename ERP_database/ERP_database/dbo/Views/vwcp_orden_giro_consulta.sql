CREATE VIEW dbo.vwcp_orden_giro_consulta
AS
SELECT dbo.cp_orden_giro.IdEmpresa, dbo.cp_orden_giro.IdTipoCbte_Ogiro, dbo.cp_orden_giro.IdCbteCble_Ogiro, dbo.cp_orden_giro.IdProveedor, dbo.tb_persona.pe_nombreCompleto, dbo.cp_orden_giro.co_fechaOg, 
                  dbo.cp_orden_giro.co_factura, dbo.cp_orden_giro.co_FechaFactura, dbo.cp_orden_giro.co_observacion, dbo.cp_orden_giro.co_total, dbo.cp_orden_giro.IdTipoFlujo, ret.NumRetencion, dbo.cp_orden_giro.co_subtotal_iva, 
                  dbo.cp_orden_giro.co_subtotal_siniva, dbo.cp_orden_giro.co_baseImponible, dbo.cp_orden_giro.co_valoriva, ISNULL(ret.re_valor_retencion, 0) AS re_valor_retencion, ISNULL(canc.MontoAplicado, 0) AS MontoAplicado, 
                  ROUND(dbo.cp_orden_giro.co_total - ISNULL(ret.re_valor_retencion, 0) - ISNULL(canc.MontoAplicado, 0), 2) AS saldo, dbo.cp_proveedor.IdClaseProveedor, dbo.cp_proveedor_clase.descripcion_clas_prove, dbo.cp_orden_giro.Estado, 
                  dbo.cp_orden_giro.Num_Autorizacion
FROM     dbo.cp_orden_giro INNER JOIN
                  dbo.cp_proveedor ON dbo.cp_orden_giro.IdEmpresa = dbo.cp_proveedor.IdEmpresa AND dbo.cp_orden_giro.IdProveedor = dbo.cp_proveedor.IdProveedor INNER JOIN
                  dbo.tb_persona ON dbo.cp_proveedor.IdPersona = dbo.tb_persona.IdPersona INNER JOIN
                  dbo.cp_proveedor_clase ON dbo.cp_proveedor.IdEmpresa = dbo.cp_proveedor_clase.IdEmpresa AND dbo.cp_proveedor.IdClaseProveedor = dbo.cp_proveedor_clase.IdClaseProveedor LEFT OUTER JOIN
                      (SELECT cab.IdEmpresa_Ogiro, cab.IdTipoCbte_Ogiro, cab.IdCbteCble_Ogiro, cab.NumRetencion, SUM(det.re_valor_retencion) AS re_valor_retencion
                       FROM      dbo.cp_retencion AS cab INNER JOIN
                                         dbo.cp_retencion_det AS det ON cab.IdEmpresa = det.IdEmpresa AND cab.IdRetencion = det.IdRetencion
                       GROUP BY cab.IdEmpresa_Ogiro, cab.IdTipoCbte_Ogiro, cab.IdCbteCble_Ogiro, cab.NumRetencion) AS ret ON ret.IdEmpresa_Ogiro = dbo.cp_orden_giro.IdEmpresa AND 
                  ret.IdTipoCbte_Ogiro = dbo.cp_orden_giro.IdTipoCbte_Ogiro AND ret.IdCbteCble_Ogiro = dbo.cp_orden_giro.IdCbteCble_Ogiro LEFT OUTER JOIN
                      (SELECT IdEmpresa_cxp, IdTipoCbte_cxp, IdCbteCble_cxp, SUM(MontoAplicado) AS MontoAplicado
                       FROM      dbo.cp_orden_pago_cancelaciones AS f
                       GROUP BY IdEmpresa_cxp, IdTipoCbte_cxp, IdCbteCble_cxp) AS canc ON canc.IdEmpresa_cxp = dbo.cp_orden_giro.IdEmpresa AND canc.IdTipoCbte_cxp = dbo.cp_orden_giro.IdTipoCbte_Ogiro AND 
                  canc.IdCbteCble_cxp = dbo.cp_orden_giro.IdCbteCble_Ogiro
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwcp_orden_giro_consulta';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'Width = 1200
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwcp_orden_giro_consulta';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "cp_orden_giro"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 355
            End
            DisplayFlags = 280
            TopColumn = 58
         End
         Begin Table = "cp_proveedor"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 338
               Right = 322
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tb_persona"
            Begin Extent = 
               Top = 343
               Left = 48
               Bottom = 506
               Right = 322
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cp_proveedor_clase"
            Begin Extent = 
               Top = 511
               Left = 48
               Bottom = 674
               Right = 357
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ret"
            Begin Extent = 
               Top = 679
               Left = 48
               Bottom = 842
               Right = 263
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "canc"
            Begin Extent = 
               Top = 847
               Left = 48
               Bottom = 1010
               Right = 247
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
      Begin ColumnWidths = 23
         Width = 284
         Width = 1200
         ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwcp_orden_giro_consulta';

