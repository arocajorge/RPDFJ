CREATE TABLE [Logistica].[lo_PlanificacionPesca] (
    [IdPlanificacion]          INT             IDENTITY (1, 1) NOT NULL,
    [IdCamaronera]             INT             NOT NULL,
    [IdEmpacadora]             INT             NOT NULL,
    [LibrasProgramadas]        NUMERIC (18, 2) NOT NULL,
    [FechaDesde]               DATETIME        NOT NULL,
    [FechaHasta]               DATETIME        NOT NULL,
    [IdCatalogoTipoTransporte] INT             NOT NULL,
    [Gramaje]                  INT             NULL,
    [Piscina]                  VARCHAR (50)    NULL,
    [CantidadCamiones]         INT             NOT NULL,
    [Fecha]                    DATE            NOT NULL,
    [IdCatalogoOrigen]         INT             NOT NULL,
    [IdCatalogoDestino]        INT             NOT NULL,
    [NumeroDeOrdenServicio]    VARCHAR (50)    NULL,
    [ValorFlete]               NUMERIC (18, 2) NULL,
    [ValorPorLibra]            NUMERIC (18, 2) NOT NULL,
    [ValorAFacturar]           NUMERIC (18, 2) NOT NULL,
    [Estado]                   BIT             NOT NULL,
    [IdUsuario]                VARCHAR (50)    NOT NULL,
    [FechaTransaccion]         DATETIME        NOT NULL,
    [IdUsuarioModificacion]    VARCHAR (50)    NULL,
    [FechaModificacion]        DATETIME        NULL,
    [IdUsuarioAnulacion]       VARCHAR (50)    NULL,
    [FechaAnulacion]           DATETIME        NULL,
    [MotivoAnulacion]          VARCHAR (MAX)   NULL,
    CONSTRAINT [PK_lo_PlanificacionPesca] PRIMARY KEY CLUSTERED ([IdPlanificacion] ASC),
    CONSTRAINT [FK_lo_PlanificacionPesca_lo_Camaronera] FOREIGN KEY ([IdCamaronera]) REFERENCES [Logistica].[lo_Camaronera] ([IdCamaronera]),
    CONSTRAINT [FK_lo_PlanificacionPesca_lo_catalogo] FOREIGN KEY ([IdCatalogoTipoTransporte]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo]),
    CONSTRAINT [FK_lo_PlanificacionPesca_lo_Empacadora1] FOREIGN KEY ([IdEmpacadora]) REFERENCES [Logistica].[lo_Empacadora] ([IdEmpacadora])
);









