CREATE TABLE [Fj_servindustrias].[ro_empleado_extension_salud] (
    [IdEmpresa]   INT           NOT NULL,
    [IdEmpleado]  NUMERIC (18)  NOT NULL,
    [Observacion] VARCHAR (MAX) NULL,
    [IdNomina]    INT           NULL,
    CONSTRAINT [PK_ro_empleado_extension_salud] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdEmpleado] ASC)
);

