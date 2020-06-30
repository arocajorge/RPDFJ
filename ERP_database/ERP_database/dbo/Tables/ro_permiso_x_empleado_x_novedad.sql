CREATE TABLE [dbo].[ro_permiso_x_empleado_x_novedad] (
    [IdEmpresa]      INT           NOT NULL,
    [IdNomina_Tipo]  INT           NOT NULL,
    [IdEmpleado]     NUMERIC (18)  NOT NULL,
    [IdPermiso]      NUMERIC (18)  NOT NULL,
    [IdEmpresa_nov]  INT           NOT NULL,
    [IdNovedad]      NUMERIC (18)  NOT NULL,
    [IdEmpleado_nov] NUMERIC (18)  NOT NULL,
    [Observacion]    VARCHAR (500) NULL,
    CONSTRAINT [PK_ro_permiso_x_empleado_x_novedad] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdNomina_Tipo] ASC, [IdEmpleado] ASC, [IdPermiso] ASC),
    CONSTRAINT [FK_ro_permiso_x_empleado_x_novedad_ro_empleado_Novedad] FOREIGN KEY ([IdEmpresa_nov], [IdNovedad], [IdEmpleado]) REFERENCES [dbo].[ro_empleado_Novedad] ([IdEmpresa], [IdNovedad], [IdEmpleado]),
    CONSTRAINT [FK_ro_permiso_x_empleado_x_novedad_ro_permiso_x_empleado] FOREIGN KEY ([IdEmpresa], [IdNomina_Tipo], [IdEmpleado], [IdPermiso]) REFERENCES [dbo].[ro_permiso_x_empleado] ([IdEmpresa], [IdNomina_Tipo], [IdEmpleado], [IdPermiso])
);

