CREATE VIEW Fj_servindustrias.vwFAC_FJ_Rpt007
AS
SELECT        queryUnidad_maxima.IdEmpresa, queryUnidad_maxima.IdPeriodo, queryUnidad_maxima.IdActivoFijo, queryUnidad_maxima.Valor_Maximo_x_periodo, Query_unidad_inicial_x_periodo.Af_ValorUnidad_Actu, 
                         Query_empleado_af_x_periodo.Af_DescripcionCorta, Query_empleado_af_x_periodo.Centro_costo, Query_empleado_af_x_periodo.SucentroCosto, Query_empleado_af_x_periodo.Total_horas_operadores, 
                         queryUnidad_maxima.Valor_Maximo_x_periodo - Query_unidad_inicial_x_periodo.Af_ValorUnidad_Actu AS Total_Horas_maquina, 
                         Query_empleado_af_x_periodo.Total_horas_operadores - (queryUnidad_maxima.Valor_Maximo_x_periodo - Query_unidad_inicial_x_periodo.Af_ValorUnidad_Actu) AS diferencia, 
                         (queryUnidad_maxima.Valor_Maximo_x_periodo - Query_unidad_inicial_x_periodo.Af_ValorUnidad_Actu) / Query_empleado_af_x_periodo.Total_horas_operadores AS por_horas_ocupada_la_maquina_vx_ho, 
                         Query_empleado_af_x_periodo.IdCentroCosto, Fj_servindustrias.fa_cliente_x_ct_centro_costo.IdCliente_cli, Query_empleado_af_x_periodo.IdCentroCosto_sub_centro_costo
FROM            (SELECT        IdEmpresa, IdActivoFijo, IdPeriodo, MAX(ISNULL(Valor, 0)) AS Valor_Maximo_x_periodo
                          FROM            Fj_servindustrias.fa_registro_unidades_x_equipo_det
                          GROUP BY IdEmpresa, IdActivoFijo, IdPeriodo) AS queryUnidad_maxima INNER JOIN
                             (SELECT        nomina_x_he.IdEmpresa, nomina_x_he.IdNominaTipo, nomina_x_he.IdNominaTipoLiqui, nomina_x_he.IdPeriodo, pre_fact_mo.IdActivoFijo, cc.Centro_costo, sub.Centro_costo AS SucentroCosto, 
                                                         af.Af_DescripcionCorta, SUM(CAST(nomina_x_he.hora_trabajada AS numeric(8, 2))) AS Total_horas_operadores, cc.IdCentroCosto, pre_fact_mo.IdCentroCosto_sub_centro_costo
                               FROM            dbo.ro_nomina_x_horas_extras AS nomina_x_he INNER JOIN
                                                         Fj_servindustrias.fa_pre_facturacion_mano_obra_servindustria AS pre_fact_mo ON nomina_x_he.IdEmpresa = pre_fact_mo.IdEmpresa AND nomina_x_he.IdEmpleado = pre_fact_mo.IdEmpleado AND 
                                                         nomina_x_he.IdPeriodo = pre_fact_mo.IdPeriodo INNER JOIN
                                                         dbo.ct_centro_costo AS cc ON pre_fact_mo.IdEmpresa = cc.IdEmpresa AND pre_fact_mo.IdCentroCosto = cc.IdCentroCosto INNER JOIN
                                                         dbo.ct_centro_costo_sub_centro_costo AS sub ON pre_fact_mo.IdEmpresa = sub.IdEmpresa AND pre_fact_mo.IdCentroCosto = sub.IdCentroCosto AND 
                                                         pre_fact_mo.IdCentroCosto_sub_centro_costo = sub.IdCentroCosto_sub_centro_costo INNER JOIN
                                                         dbo.ro_empleado AS emplea ON nomina_x_he.IdEmpresa = emplea.IdEmpresa AND nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND 
                                                         nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND 
                                                         nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND 
                                                         nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND nomina_x_he.IdEmpleado = emplea.IdEmpleado INNER JOIN
                                                         dbo.tb_persona AS persona ON emplea.IdPersona = persona.IdPersona AND emplea.IdPersona = persona.IdPersona INNER JOIN
                                                         dbo.Af_Activo_fijo AS af ON pre_fact_mo.IdEmpresa = af.IdEmpresa AND pre_fact_mo.IdActivoFijo = af.IdActivoFijo AND pre_fact_mo.IdEmpresa = af.IdEmpresa AND pre_fact_mo.IdActivoFijo = af.IdActivoFijo AND 
                                                         pre_fact_mo.IdEmpresa = af.IdEmpresa AND pre_fact_mo.IdActivoFijo = af.IdActivoFijo AND pre_fact_mo.IdEmpresa = af.IdEmpresa AND pre_fact_mo.IdActivoFijo = af.IdActivoFijo AND 
                                                         pre_fact_mo.IdEmpresa = af.IdEmpresa AND pre_fact_mo.IdActivoFijo = af.IdActivoFijo
                               GROUP BY nomina_x_he.IdEmpresa, nomina_x_he.IdNominaTipo, nomina_x_he.IdNominaTipoLiqui, nomina_x_he.IdPeriodo, af.Af_DescripcionCorta, pre_fact_mo.IdActivoFijo, cc.Centro_costo, sub.Centro_costo, 
                                                         cc.IdCentroCosto, pre_fact_mo.IdCentroCosto_sub_centro_costo) AS Query_empleado_af_x_periodo ON queryUnidad_maxima.IdEmpresa = Query_empleado_af_x_periodo.IdEmpresa AND 
                         queryUnidad_maxima.IdPeriodo = Query_empleado_af_x_periodo.IdPeriodo AND queryUnidad_maxima.IdActivoFijo = Query_empleado_af_x_periodo.IdActivoFijo INNER JOIN
                             (SELECT        cab.IdEmpresa, det.IdActivoFijo, cab.IdPeriodo, det.Af_ValorUnidad_Actu
                               FROM            Fj_servindustrias.fa_registro_unidades_x_equipo_det_ini_x_Af AS det INNER JOIN
                                                         Fj_servindustrias.fa_registro_unidades_x_equipo AS cab ON det.IdEmpresa = cab.IdEmpresa AND det.IdRegistro = cab.IdRegistro) AS Query_unidad_inicial_x_periodo ON 
                         Query_empleado_af_x_periodo.IdEmpresa = Query_unidad_inicial_x_periodo.IdEmpresa AND Query_empleado_af_x_periodo.IdPeriodo = Query_unidad_inicial_x_periodo.IdPeriodo AND 
                         Query_empleado_af_x_periodo.IdActivoFijo = Query_unidad_inicial_x_periodo.IdActivoFijo INNER JOIN
                         Fj_servindustrias.fa_cliente_x_ct_centro_costo ON Query_empleado_af_x_periodo.IdEmpresa = Fj_servindustrias.fa_cliente_x_ct_centro_costo.IdEmpresa_cli AND 
                         Query_empleado_af_x_periodo.IdCentroCosto = Fj_servindustrias.fa_cliente_x_ct_centro_costo.IdCentroCosto_cc

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwFAC_FJ_Rpt007';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' 720
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
', @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwFAC_FJ_Rpt007';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[29] 4[5] 2[5] 3) )"
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
         Begin Table = "Query_unidad_inicial_x_periodo"
            Begin Extent = 
               Top = 0
               Left = 977
               Bottom = 172
               Right = 1178
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "queryUnidad_maxima"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fa_cliente_x_ct_centro_costo (Fj_servindustrias)"
            Begin Extent = 
               Top = 93
               Left = 747
               Bottom = 223
               Right = 930
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Query_empleado_af_x_periodo"
            Begin Extent = 
               Top = 6
               Left = 296
               Bottom = 136
               Right = 559
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
      Begin ColumnWidths = 15
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
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output =', @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwFAC_FJ_Rpt007';

