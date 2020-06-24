CREATE TABLE [Fj_servindustrias].[ro_marcaciones_no_aplica_sobretiempo] (
    [IdEmpresa]         INT           NOT NULL,
    [IdEmpleado]        NUMERIC (18)  NOT NULL,
    [IdRegistro]        VARCHAR (50)  NOT NULL,
    [es_fecha_registro] DATETIME      NOT NULL,
    [Observacion]       VARCHAR (500) NULL,
    CONSTRAINT [PK_ro_marcaciones_no_aplica_sobretiempo] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdEmpleado] ASC, [IdRegistro] ASC)
);

