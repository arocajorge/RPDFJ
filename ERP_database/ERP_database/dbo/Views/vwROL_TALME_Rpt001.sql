﻿CREATE VIEW dbo.vwROL_TALME_Rpt001
AS
SELECT        NombreCompleto, Ruc, IdCargo, IdDivision, Empresa, RucEmpresa, IdEmpresa, IdNominaTipo, RubroDescripcion, IdNominaTipoLiqui, IdPeriodo, IdEmpleado, IdRubro, Ingreso, Egreso, Orden, Cargo, Division, 
                         IdSucursal, Sucursal, CodigoEmpleado, IdDepartamento, de_descripcion, RazonSocial, pe_apellido, pe_nombre, FechaPago, pe_FechaIni, pe_FechaFin, ru_tipo, em_status, NombreComercial,
                             (SELECT        Valor
                               FROM            dbo.ro_rol_detalle AS D
                               WHERE        (R.IdNominaTipo = IdNominaTipo) AND (R.IdNominaTipoLiqui = IdNominaTipoLiqui) AND (R.IdPeriodo = IdPeriodo) AND (R.IdEmpleado = IdEmpleado) AND (IdRubro = 2)) AS diastrabajados, 
                         ISNULL
                             ((SELECT        SUM(Num_Horas) AS Expr1
                                 FROM            dbo.ro_empleado_novedad_det AS D
                                 WHERE        (R.IdNominaTipo = IdNomina_tipo) AND (R.IdNominaTipoLiqui = IdNomina_Tipo_Liq) AND (R.IdEmpleado = IdEmpleado) AND (FechaPago BETWEEN R.pe_FechaIni AND R.pe_FechaFin) AND 
                                                          (IdRubro = 7)), 0) AS Horas_al_25, ISNULL
                             ((SELECT        SUM(Num_Horas) AS Expr1
                                 FROM            dbo.ro_empleado_novedad_det AS D
                                 WHERE        (R.IdNominaTipo = IdNomina_tipo) AND (R.IdNominaTipoLiqui = IdNomina_Tipo_Liq) AND (R.IdEmpleado = IdEmpleado) AND (FechaPago BETWEEN R.pe_FechaIni AND R.pe_FechaFin) AND 
                                                          (IdRubro = 8)), 0) AS Horas_al_50, ISNULL
                             ((SELECT        SUM(Num_Horas) AS Expr1
                                 FROM            dbo.ro_empleado_novedad_det AS D
                                 WHERE        (R.IdNominaTipo = IdNomina_tipo) AND (R.IdNominaTipoLiqui = IdNomina_Tipo_Liq) AND (R.IdEmpleado = IdEmpleado) AND (FechaPago BETWEEN R.pe_FechaIni AND R.pe_FechaFin) AND 
                                                          (IdRubro = 9)), 0) AS Horas_al_100
FROM            dbo.vwro_Ro_rol_individual AS R
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwROL_TALME_Rpt001';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[34] 4[5] 2[43] 3) )"
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
               Top = 6
               Left = 38
               Bottom = 136
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
      Begin ColumnWidths = 37
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwROL_TALME_Rpt001';

