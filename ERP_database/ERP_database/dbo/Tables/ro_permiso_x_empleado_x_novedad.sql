CREATE TABLE [dbo].[ro_permiso_x_empleado_x_novedad] (
    [IdEmpresa]      INT           NOT NULL,
    [IdNomina_Tipo]  INT           NOT NULL,
    [IdEmpleado]     NUMERIC (18)  NOT NULL,
    [IdPermiso]      NUMERIC (18)  NOT NULL,
    [IdNovedad]      NUMERIC (18)  NOT NULL,
    [IdEmpresa_nov]  INT           NOT NULL,
    [IdEmpleado_nov] NUMERIC (18)  NOT NULL,
    [Observacion]    VARCHAR (500) NULL,
    CONSTRAINT [PK_ro_permiso_x_empleado_x_novedad] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdNomina_Tipo] ASC, [IdEmpleado] ASC, [IdPermiso] ASC, [IdNovedad] ASC),
    CONSTRAINT [FK_ro_permiso_x_empleado_x_novedad_ro_permiso_x_empleado] FOREIGN KEY ([IdEmpresa], [IdNomina_Tipo], [IdEmpleado], [IdPermiso]) REFERENCES [dbo].[ro_permiso_x_empleado] ([IdEmpresa], [IdNomina_Tipo], [IdEmpleado], [IdPermiso])
);



