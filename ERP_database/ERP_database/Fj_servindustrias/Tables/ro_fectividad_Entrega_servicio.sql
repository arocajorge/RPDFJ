CREATE TABLE [Fj_servindustrias].[ro_fectividad_Entrega_servicio] (
    [IdEmpresa]         INT           NOT NULL,
    [IdNivelServicio]   NUMERIC (18)  NOT NULL,
    [IdServicioTipo]    INT           NOT NULL,
    [IdNomina_Tipo]     INT           NOT NULL,
    [IdNomina_tipo_Liq] INT           NOT NULL,
    [IdPeriodo]         INT           NOT NULL,
    [Observacion]       VARCHAR (250) NOT NULL,
    [Estado]            BIT           NOT NULL,
    [IdUsuario]         VARCHAR (20)  NULL,
    [IdUsuarioAnu]      VARCHAR (20)  NULL,
    [MotivoAnu]         VARCHAR (100) NULL,
    [IdUsuarioUltModi]  VARCHAR (20)  NULL,
    [FechaAnu]          DATETIME      NULL,
    [FechaTransac]      DATETIME      NOT NULL,
    [FechaUltModi]      DATETIME      NULL,
    CONSTRAINT [PK_ro_fectividad_Entrega_servicio] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdNivelServicio] ASC),
    CONSTRAINT [FK_ro_fectividad_Entrega_servicio_ro_periodo_x_ro_Nomina_TipoLiqui] FOREIGN KEY ([IdEmpresa], [IdNomina_Tipo], [IdNomina_tipo_Liq], [IdPeriodo]) REFERENCES [dbo].[ro_periodo_x_ro_Nomina_TipoLiqui] ([IdEmpresa], [IdNomina_Tipo], [IdNomina_TipoLiqui], [IdPeriodo])
);

