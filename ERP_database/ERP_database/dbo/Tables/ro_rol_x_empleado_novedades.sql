CREATE TABLE [dbo].[ro_rol_x_empleado_novedades] (
    [IdEmpresa_nov]     INT           NOT NULL,
    [IdEmpleado]        NUMERIC (18)  NOT NULL,
    [IdNovedad]         NUMERIC (18)  NOT NULL,
    [Secuencia_nov]     INT           NOT NULL,
    [IdEmpresa]         INT           NOT NULL,
    [IdNominaTipo]      INT           NOT NULL,
    [IdNominaTipoLiqui] INT           NOT NULL,
    [IdPeriodo]         INT           NOT NULL,
    [Observacion]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_ro_rol_x_empleado_novedades_1] PRIMARY KEY CLUSTERED ([Secuencia_nov] ASC, [IdEmpresa_nov] ASC, [IdNovedad] ASC, [IdEmpleado] ASC)
);

