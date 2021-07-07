CREATE TABLE [Logistica].[lo_planificacionPescaHistorico] (
    [IdHistorico]     INT           IDENTITY (1, 1) NOT NULL,
    [IdPlanificacion] INT           NOT NULL,
    [Fecha]           DATETIME      NOT NULL,
    [IdUsuario]       VARCHAR (200) NOT NULL,
    [Observacion]     VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_lo_planificacionPescaHistorico] PRIMARY KEY CLUSTERED ([IdHistorico] ASC)
);

