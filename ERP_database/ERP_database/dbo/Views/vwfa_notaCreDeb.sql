

CREATE VIEW [dbo].[vwfa_notaCreDeb]
AS
SELECT d.IdEmpresa, d.IdSucursal, d.IdBodega, CASE CreDeb WHEN 'C' THEN 'NTCR' WHEN 'D' THEN 'NTDB' END AS Tipo, d.IdNota, d.CodNota, d.CreDeb, d.Serie1, d.Serie2, d.NumNota_Impresa, d.NumAutorizacion, d.IdCliente, d.IdVendedor, 
                  d.no_fecha, d.no_fecha_venc, d.no_dev_venta, d.IdTipoNota, d.sc_observacion, d.Estado, d.flete, d.interes, d.valor1, d.valor2, d.IdCaja, d.IdPuntoVta, ISNULL(det.sc_subtotal, 0) AS sc_subtotal, ISNULL(det.sc_iva, 0) AS sc_iva, 
                  ISNULL(det.sc_total, 0) AS sc_total, ISNULL(cobro.valor_pago, 0) AS valor_aplicado, ROUND(ISNULL(det.sc_total, 0) - ISNULL(cobro.valor_pago, 0), 2) AS saldo, LTRIM(RTRIM(per.pe_nombreCompleto)) AS nom_cliente, su.Su_Descripcion, 
                  bo.bo_Descripcion, ve.Ve_Vendedor, d.NaturalezaNota, tn.IdCtaCble,d.Fecha_Autorizacion
FROM     dbo.fa_notaCreDeb AS d LEFT OUTER JOIN
                      (SELECT IdEmpresa, IdSucursal, IdBodega_Cbte, IdCbte_vta_nota, dc_TipoDocumento, SUM(dc_ValorPago) AS valor_pago
                       FROM      dbo.cxc_cobro_det
                       GROUP BY IdEmpresa, IdSucursal, IdBodega_Cbte, IdCbte_vta_nota, dc_TipoDocumento) AS cobro ON cobro.IdEmpresa = d.IdEmpresa AND cobro.IdSucursal = d.IdSucursal AND cobro.IdBodega_Cbte = d.IdBodega AND 
                  cobro.IdCbte_vta_nota = d.IdNota AND cobro.dc_TipoDocumento = CASE CreDeb WHEN 'C' THEN 'NTCR' WHEN 'D' THEN 'NTDB' END LEFT OUTER JOIN
                      (SELECT IdEmpresa, IdSucursal, IdBodega, IdNota, SUM(sc_iva) AS sc_iva, SUM(sc_subtotal) AS sc_subtotal, SUM(sc_total) AS sc_total
                       FROM      dbo.fa_notaCreDeb_det
                       GROUP BY IdEmpresa, IdSucursal, IdBodega, IdNota) AS det ON det.IdEmpresa = d.IdEmpresa AND det.IdSucursal = d.IdSucursal AND det.IdBodega = d.IdBodega AND det.IdNota = d.IdNota INNER JOIN
                  dbo.fa_cliente AS cli ON d.IdEmpresa = cli.IdEmpresa AND cli.IdCliente = d.IdCliente INNER JOIN
                  dbo.tb_persona AS per ON cli.IdPersona = per.IdPersona LEFT OUTER JOIN
                  dbo.tb_bodega AS bo ON d.IdEmpresa = bo.IdEmpresa AND d.IdSucursal = bo.IdSucursal AND d.IdBodega = bo.IdBodega INNER JOIN
                  dbo.tb_sucursal AS su ON bo.IdEmpresa = su.IdEmpresa AND bo.IdSucursal = su.IdSucursal INNER JOIN
                  dbo.fa_Vendedor AS ve ON ve.IdEmpresa = d.IdEmpresa AND ve.IdVendedor = d.IdVendedor LEFT OUTER JOIN
                  dbo.fa_TipoNota_x_Empresa_x_Sucursal AS tn ON d.IdEmpresa = tn.IdEmpresa AND d.IdSucursal = tn.IdSucursal AND d.IdTipoNota = tn.IdTipoNota
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwfa_notaCreDeb';


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
         Begin Table = "fa_notaCreDeb"
            Begin Extent = 
               Top = 18
               Left = 296
               Bottom = 206
               Right = 474
            End
            DisplayFlags = 280
            TopColumn = 29
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
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwfa_notaCreDeb';

