CREATE TABLE [dbo].[ro_rol_x_prestamo_detalle] (
    [IdEmpresa]         INT           NOT NULL,
    [IdPrestamo]        NUMERIC (18)  NOT NULL,
    [NumCuota]          INT           NOT NULL,
    [IdEmpleado]        NUMERIC (18)  NOT NULL,
    [IdNominaTipo]      INT           NOT NULL,
    [IdNominaTipoLiqui] INT           NOT NULL,
    [IdPeriodo]         INT           NOT NULL,
    [Observacion]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_ro_rol_x_prestamo_detalle] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdPrestamo] ASC, [NumCuota] ASC, [IdEmpleado] ASC)
);

