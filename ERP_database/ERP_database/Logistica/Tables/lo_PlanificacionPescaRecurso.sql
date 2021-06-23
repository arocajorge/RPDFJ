CREATE TABLE [Logistica].[lo_PlanificacionPescaRecurso] (
    [IdPlanRecurso]   INT             IDENTITY (1, 1) NOT NULL,
    [IdPlanificacion] INT             NOT NULL,
    [IdRecurso]       INT             NOT NULL,
    [Cantidad]        NUMERIC (18, 2) NOT NULL,
    CONSTRAINT [PK_lo_PlanificacionPescaRecurso] PRIMARY KEY CLUSTERED ([IdPlanRecurso] ASC),
    CONSTRAINT [FK_lo_PlanificacionPescaRecurso_lo_PlanificacionPesca1] FOREIGN KEY ([IdPlanificacion]) REFERENCES [Logistica].[lo_PlanificacionPesca] ([IdPlanificacion]),
    CONSTRAINT [FK_lo_PlanificacionPescaRecurso_lo_recurso] FOREIGN KEY ([IdRecurso]) REFERENCES [Logistica].[lo_recurso] ([IdRecurso])
);



