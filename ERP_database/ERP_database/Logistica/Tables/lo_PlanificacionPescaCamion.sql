CREATE TABLE [Logistica].[lo_PlanificacionPescaCamion] (
    [IdPlanificacionC] INT             IDENTITY (1, 1) NOT NULL,
    [IdPlanificacion]  INT             NOT NULL,
    [CapacidadBines]   INT             NOT NULL,
    [CantidadCamiones] NUMERIC (18, 2) NOT NULL,
    CONSTRAINT [PK_lo_PlanificacionPescaCamion] PRIMARY KEY CLUSTERED ([IdPlanificacionC] ASC),
    CONSTRAINT [FK_lo_PlanificacionPescaCamion_lo_PlanificacionPesca] FOREIGN KEY ([IdPlanificacion]) REFERENCES [Logistica].[lo_PlanificacionPesca] ([IdPlanificacion])
);

