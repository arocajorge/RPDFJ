/* WHERE  (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = 201605)*/
CREATE VIEW Fj_servindustrias.vwROLES_Rpt004
AS
SELECT        dbo.ro_empleado.IdEmpresa, dbo.ro_empleado.IdEmpleado, dbo.ro_Departamento.IdDepartamento, dbo.ro_cargo.IdCargo, dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo, 
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui, dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo, dbo.tb_persona.pe_apellido, dbo.tb_persona.pe_nombre, dbo.tb_persona.pe_nombreCompleto, 
                         dbo.tb_persona.pe_cedulaRuc, dbo.ro_cargo.ca_descripcion, dbo.ro_Departamento.de_descripcion, Fj_servindustrias.vwROLES_Rpt003.hora_extra25, Fj_servindustrias.vwROLES_Rpt003.hora_extra50, 
                         Fj_servindustrias.vwROLES_Rpt003.hora_extra100, Fj_servindustrias.vwROLES_Rpt003.TotalHorasExtras, Fj_servindustrias.vwROLES_Rpt003.hora_trabajada, Fj_servindustrias.vwROLES_Rpt003.Dias_Efectivos,
                             (SELECT        Valor
                               FROM            dbo.ro_rol_detalle
                               WHERE        (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = IdEmpresa) AND (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo = IdNominaTipo) AND 
                                                         (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui = IdNominaTipoLiqui) AND (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = IdPeriodo) AND (dbo.ro_empleado.IdEmpleado = IdEmpleado) AND 
                                                         (IdRubro = 103)) AS Sueldo,
                             (SELECT        Valor
                               FROM            dbo.ro_rol_detalle AS ro_rol_detalle_3
                               WHERE        (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = IdEmpresa) AND (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo = IdNominaTipo) AND 
                                                         (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui = IdNominaTipoLiqui) AND (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = IdPeriodo) AND (dbo.ro_empleado.IdEmpleado = IdEmpleado) AND 
                                                         (IdRubro = 7)) AS Valor_Hora_25,
                             (SELECT        Valor
                               FROM            dbo.ro_rol_detalle AS ro_rol_detalle_2
                               WHERE        (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = IdEmpresa) AND (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo = IdNominaTipo) AND 
                                                         (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui = IdNominaTipoLiqui) AND (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = IdPeriodo) AND (dbo.ro_empleado.IdEmpleado = IdEmpleado) AND 
                                                         (IdRubro = 8)) AS Valor_Hora_250,
                             (SELECT        Valor
                               FROM            dbo.ro_rol_detalle AS ro_rol_detalle_1
                               WHERE        (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = IdEmpresa) AND (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo = IdNominaTipo) AND 
                                                         (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui = IdNominaTipoLiqui) AND (dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = IdPeriodo) AND (dbo.ro_empleado.IdEmpleado = IdEmpleado) AND 
                                                         (IdRubro = 9)) AS Valor_Hora_100, Fj_servindustrias.vwROLES_Rpt003.Calculo_Horas_extras_Sobre, dbo.ct_centro_costo_sub_centro_costo.Centro_costo
FROM            Fj_servindustrias.ro_empleado_x_Activo_Fijo INNER JOIN
                         dbo.ro_empleado INNER JOIN
                         dbo.ro_Departamento ON dbo.ro_empleado.IdEmpresa = dbo.ro_Departamento.IdEmpresa AND dbo.ro_empleado.IdDepartamento = dbo.ro_Departamento.IdDepartamento INNER JOIN
                         dbo.ro_cargo ON dbo.ro_empleado.IdEmpresa = dbo.ro_cargo.IdEmpresa AND dbo.ro_empleado.IdCargo = dbo.ro_cargo.IdCargo INNER JOIN
                         dbo.tb_persona ON dbo.ro_empleado.IdPersona = dbo.tb_persona.IdPersona ON Fj_servindustrias.ro_empleado_x_Activo_Fijo.IdEmpresa = dbo.ro_empleado.IdEmpresa AND 
                         Fj_servindustrias.ro_empleado_x_Activo_Fijo.IdEmpleado = dbo.ro_empleado.IdEmpleado INNER JOIN
                         dbo.Af_Activo_fijo ON Fj_servindustrias.ro_empleado_x_Activo_Fijo.IdEmpresa = dbo.Af_Activo_fijo.IdEmpresa AND Fj_servindustrias.ro_empleado_x_Activo_Fijo.IdActivo_fijo = dbo.Af_Activo_fijo.IdActivoFijo INNER JOIN
                         dbo.ct_centro_costo_sub_centro_costo ON dbo.Af_Activo_fijo.IdEmpresa = dbo.ct_centro_costo_sub_centro_costo.IdEmpresa AND 
                         dbo.Af_Activo_fijo.IdCentroCosto_sub_centro_costo = dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto_sub_centro_costo AND 
                         dbo.Af_Activo_fijo.IdCentroCosto = dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto LEFT OUTER JOIN
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui INNER JOIN
                         dbo.ro_Nomina_Tipo ON dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = dbo.ro_Nomina_Tipo.IdEmpresa AND 
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo = dbo.ro_Nomina_Tipo.IdNomina_Tipo LEFT OUTER JOIN
                         Fj_servindustrias.vwROLES_Rpt003 ON dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo = Fj_servindustrias.vwROLES_Rpt003.IdNominaTipo AND 
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui = Fj_servindustrias.vwROLES_Rpt003.IdNominaTipoLiqui AND dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = Fj_servindustrias.vwROLES_Rpt003.IdPeriodo ON
                          dbo.ro_empleado.IdEmpresa = Fj_servindustrias.vwROLES_Rpt003.IdEmpresa AND dbo.ro_empleado.IdEmpleado = Fj_servindustrias.vwROLES_Rpt003.IdEmpleado
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwROLES_Rpt004';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' 624
               Right = 935
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ro_empleado_x_Activo_Fijo (Fj_servindustrias)"
            Begin Extent = 
               Top = 294
               Left = 413
               Bottom = 472
               Right = 597
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Af_Activo_fijo"
            Begin Extent = 
               Top = 339
               Left = 505
               Bottom = 649
               Right = 768
            End
            DisplayFlags = 280
            TopColumn = 67
         End
         Begin Table = "ct_centro_costo_sub_centro_costo"
            Begin Extent = 
               Top = 371
               Left = 919
               Bottom = 573
               Right = 1183
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
      Begin ColumnWidths = 25
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
', @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwROLES_Rpt004';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[84] 4[5] 2[5] 3) )"
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
         Top = -227
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tb_persona"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 400
               Right = 270
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_Departamento"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_empleado"
            Begin Extent = 
               Top = 423
               Left = 60
               Bottom = 645
               Right = 349
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_cargo"
            Begin Extent = 
               Top = 82
               Left = 638
               Bottom = 212
               Right = 819
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_periodo_x_ro_Nomina_TipoLiqui"
            Begin Extent = 
               Top = 478
               Left = 951
               Bottom = 608
               Right = 1364
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_Nomina_Tipo"
            Begin Extent = 
               Top = 292
               Left = 1005
               Bottom = 422
               Right = 1187
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vwROLES_Rpt003 (Fj_servindustrias)"
            Begin Extent = 
               Top = 330
               Left = 700
               Bottom =', @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwROLES_Rpt004';



