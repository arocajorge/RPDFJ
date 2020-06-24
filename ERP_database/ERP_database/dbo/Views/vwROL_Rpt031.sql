CREATE view vwROL_Rpt031 as
SELECT        dbo.ro_nomina_x_horas_extras.IdEmpresa, dbo.ro_nomina_x_horas_extras.IdEmpleado, dbo.ro_nomina_x_horas_extras.IdNominaTipo, dbo.ro_nomina_x_horas_extras.IdNominaTipoLiqui, 
                         dbo.ro_nomina_x_horas_extras.IdPeriodo, dbo.ro_nomina_x_horas_extras.FechaRegistro,cast( dbo.ro_nomina_x_horas_extras.hora_extra25 as numeric(8,2))hora_extra25, 
						 cast(dbo.ro_nomina_x_horas_extras.hora_extra50 as numeric(8,2))hora_extra50, 
                        CAST( dbo.ro_nomina_x_horas_extras.hora_extra100 as numeric(8,2))hora_extra100,
						  dbo.ro_nomina_x_horas_extras.FechaIngresa, dbo.ro_nomina_x_horas_extras.UsuarioIngresa, dbo.ro_nomina_x_horas_extras.FechaModifica, 
                         dbo.ro_nomina_x_horas_extras.UsuarioModifica, dbo.vwro_empleadoXdepXcargo.cargo, dbo.vwro_empleadoXdepXcargo.departamento, dbo.vwro_empleadoXdepXcargo.em_estado AS EstadoEmpleado, 
                         dbo.vwro_empleadoXdepXcargo.NomCompleto AS NombreCompleto, dbo.vwro_empleadoXdepXcargo.Apellido, dbo.vwro_empleadoXdepXcargo.pe_cedulaRuc AS CedulaRuc, 
                         dbo.vwro_empleadoXdepXcargo.em_status AS StatusEmpleado, dbo.ro_nomina_x_horas_extras.IdCalendario, dbo.ro_nomina_x_horas_extras.hora_atraso, dbo.ro_nomina_x_horas_extras.hora_temprano, 
                         dbo.ro_nomina_x_horas_extras.time_entrada1, dbo.ro_nomina_x_horas_extras.time_entrada2, dbo.ro_nomina_x_horas_extras.time_salida1, dbo.ro_nomina_x_horas_extras.time_salida2, 
                        cast( dbo.ro_nomina_x_horas_extras.hora_trabajada as numeric(8,2))hora_trabajada , dbo.ro_nomina_x_horas_extras.IdTurno, dbo.ro_nomina_x_horas_extras.IdHorario, dbo.ro_horario.Descripcion AS DescripcionHorario, 
                         dbo.vwro_empleadoXdepXcargo.IdDivision, dbo.ro_Division.Descripcion AS DescripcionDivision, dbo.ct_centro_costo.Centro_costo AS DescripcionCentroCosto, dbo.ro_empleado_x_centro_costo.IdCentroCosto, 
                         dbo.ro_Nomina_Tipoliqui.DescripcionProcesoNomina AS DescripcionNominaTipoLiqui, dbo.ro_Nomina_Tipo.Descripcion AS DescripcionNominaTipo, dbo.ro_periodo.pe_FechaIni AS FechaInicial, 
                         dbo.ro_periodo.pe_FechaFin AS FechaFinal, dbo.vwro_empleadoXdepXcargo.em_codigo AS CodigoEmpleado, dbo.vwro_empleadoXdepXcargo.Nombre, dbo.vwro_empleadoXdepXcargo.IdEmpresa AS Expr1, 
                         dbo.vwro_empleadoXdepXcargo.IdDepartamento
FROM            dbo.ro_Nomina_Tipoliqui INNER JOIN
                         dbo.ro_Nomina_Tipo ON dbo.ro_Nomina_Tipoliqui.IdEmpresa = dbo.ro_Nomina_Tipo.IdEmpresa AND dbo.ro_Nomina_Tipoliqui.IdNomina_Tipo = dbo.ro_Nomina_Tipo.IdNomina_Tipo INNER JOIN
                         dbo.vwro_empleadoXdepXcargo INNER JOIN
                         dbo.ro_nomina_x_horas_extras ON dbo.vwro_empleadoXdepXcargo.IdEmpresa = dbo.ro_nomina_x_horas_extras.IdEmpresa AND 
                         dbo.vwro_empleadoXdepXcargo.IdEmpleado = dbo.ro_nomina_x_horas_extras.IdEmpleado INNER JOIN
                         dbo.ro_horario ON dbo.ro_nomina_x_horas_extras.IdEmpresa = dbo.ro_horario.IdEmpresa AND dbo.ro_nomina_x_horas_extras.IdHorario = dbo.ro_horario.IdHorario INNER JOIN
                         dbo.ro_Division ON dbo.vwro_empleadoXdepXcargo.IdEmpresa = dbo.ro_Division.IdEmpresa AND dbo.vwro_empleadoXdepXcargo.IdDivision = dbo.ro_Division.IdDivision INNER JOIN
                         dbo.ro_empleado_x_centro_costo ON dbo.vwro_empleadoXdepXcargo.IdEmpresa = dbo.ro_empleado_x_centro_costo.IdEmpresa AND 
                         dbo.vwro_empleadoXdepXcargo.IdEmpleado = dbo.ro_empleado_x_centro_costo.IdEmpleado INNER JOIN
                         dbo.ct_centro_costo ON dbo.ro_empleado_x_centro_costo.IdEmpresa = dbo.ct_centro_costo.IdEmpresa AND dbo.ro_empleado_x_centro_costo.IdCentroCosto = dbo.ct_centro_costo.IdCentroCosto ON 
                         dbo.ro_Nomina_Tipoliqui.IdEmpresa = dbo.ro_nomina_x_horas_extras.IdEmpresa AND dbo.ro_Nomina_Tipoliqui.IdNomina_Tipo = dbo.ro_nomina_x_horas_extras.IdNominaTipo AND 
                         dbo.ro_Nomina_Tipoliqui.IdNomina_TipoLiqui = dbo.ro_nomina_x_horas_extras.IdNominaTipoLiqui INNER JOIN
                         dbo.ro_periodo ON dbo.ro_nomina_x_horas_extras.IdEmpresa = dbo.ro_periodo.IdEmpresa AND dbo.ro_nomina_x_horas_extras.IdPeriodo = dbo.ro_periodo.IdPeriodo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwROL_Rpt031';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'               Right = 744
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ct_centro_costo"
            Begin Extent = 
               Top = 138
               Left = 782
               Bottom = 268
               Right = 978
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_periodo"
            Begin Extent = 
               Top = 138
               Left = 1016
               Bottom = 268
               Right = 1237
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwROL_Rpt031';


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
         Begin Table = "ro_Nomina_Tipoliqui"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_Nomina_Tipo"
            Begin Extent = 
               Top = 6
               Left = 312
               Bottom = 136
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vwro_empleadoXdepXcargo"
            Begin Extent = 
               Top = 6
               Left = 532
               Bottom = 136
               Right = 821
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_nomina_x_horas_extras"
            Begin Extent = 
               Top = 6
               Left = 859
               Bottom = 136
               Right = 1087
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_horario"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 226
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_Division"
            Begin Extent = 
               Top = 138
               Left = 264
               Bottom = 268
               Right = 443
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_empleado_x_centro_costo"
            Begin Extent = 
               Top = 138
               Left = 481
               Bottom = 268
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwROL_Rpt031';

