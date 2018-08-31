CREATE VIEW Fj_servindustrias.vwROLES_Rpt003
AS
SELECT        dbo.ro_nomina_x_horas_extras.IdEmpresa, dbo.ro_nomina_x_horas_extras.IdEmpleado, dbo.ro_nomina_x_horas_extras.IdNominaTipo, dbo.ro_nomina_x_horas_extras.IdNominaTipoLiqui, 
                         dbo.ro_nomina_x_horas_extras.IdPeriodo, SUM(dbo.ro_nomina_x_horas_extras.hora_extra25) AS hora_extra25, SUM(dbo.ro_nomina_x_horas_extras.hora_extra50) AS hora_extra50, 
                         SUM(dbo.ro_nomina_x_horas_extras.hora_extra100) AS hora_extra100, SUM(dbo.ro_nomina_x_horas_extras.hora_extra25 + dbo.ro_nomina_x_horas_extras.hora_extra50 + dbo.ro_nomina_x_horas_extras.hora_extra100) 
                         AS TotalHorasExtras, SUM(dbo.ro_nomina_x_horas_extras.hora_trabajada) AS hora_trabajada,
                             (SELECT        COUNT(DISTINCT es_fechaRegistro) AS Expr1
                               FROM            dbo.ro_marcaciones_x_empleado
                               WHERE        (dbo.ro_nomina_x_horas_extras.IdEmpresa = IdEmpresa) AND (dbo.ro_nomina_x_horas_extras.IdEmpleado = IdEmpleado) AND (dbo.ro_nomina_x_horas_extras.IdPeriodo = IdPeriodo)) AS Dias_Efectivos, 
                         dbo.tb_persona.pe_cedulaRuc, dbo.tb_persona.pe_nombre, dbo.tb_persona.pe_apellido, dbo.tb_persona.pe_nombreCompleto, Fj_servindustrias.ro_Grupo_empleado.Calculo_Horas_extras_Sobre
FROM            dbo.ro_nomina_x_horas_extras INNER JOIN
                         dbo.ro_empleado ON dbo.ro_nomina_x_horas_extras.IdEmpresa = dbo.ro_empleado.IdEmpresa AND dbo.ro_nomina_x_horas_extras.IdEmpleado = dbo.ro_empleado.IdEmpleado INNER JOIN
                         dbo.tb_persona ON dbo.ro_empleado.IdPersona = dbo.tb_persona.IdPersona INNER JOIN
                         Fj_servindustrias.ro_Grupo_empleado ON dbo.ro_nomina_x_horas_extras.IdEmpresa = Fj_servindustrias.ro_Grupo_empleado.IdEmpresa AND dbo.ro_empleado.IdGrupo = Fj_servindustrias.ro_Grupo_empleado.IdGrupo
GROUP BY dbo.ro_nomina_x_horas_extras.IdEmpresa, dbo.ro_nomina_x_horas_extras.IdEmpleado, dbo.ro_nomina_x_horas_extras.IdNominaTipo, dbo.ro_nomina_x_horas_extras.IdNominaTipoLiqui, 
                         dbo.ro_nomina_x_horas_extras.IdPeriodo, dbo.tb_persona.pe_cedulaRuc, dbo.tb_persona.pe_nombre, dbo.tb_persona.pe_apellido, dbo.tb_persona.pe_nombreCompleto, 
                         Fj_servindustrias.ro_Grupo_empleado.Calculo_Horas_extras_Sobre
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwROLES_Rpt003';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[85] 4[5] 2[5] 3) )"
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
         Begin Table = "ro_nomina_x_horas_extras"
            Begin Extent = 
               Top = 87
               Left = 41
               Bottom = 217
               Right = 285
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_empleado"
            Begin Extent = 
               Top = 36
               Left = 255
               Bottom = 166
               Right = 560
            End
            DisplayFlags = 280
            TopColumn = 71
         End
         Begin Table = "tb_persona"
            Begin Extent = 
               Top = 155
               Left = 590
               Bottom = 434
               Right = 838
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ro_Grupo_empleado (Fj_servindustrias)"
            Begin Extent = 
               Top = 6
               Left = 936
               Bottom = 273
               Right = 1187
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
      Begin ColumnWidths = 12
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
', @level0type = N'SCHEMA', @level0name = N'Fj_servindustrias', @level1type = N'VIEW', @level1name = N'vwROLES_Rpt003';

