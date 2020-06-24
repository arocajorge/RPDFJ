CREATE TABLE [Fj_servindustrias].[ro_fectividad_Entrega_tipoServicio] (
    [IdEmpresa]         INT           NOT NULL,
    [IdServicio]        INT           NOT NULL,
    [ts_Descripcion]    VARCHAR (MAX) NOT NULL,
    [ts_codigo]         VARCHAR (50)  NOT NULL,
    [Porcentaje]        FLOAT (53)    NOT NULL,
    [Estado]            BIT           NOT NULL,
    [IdUsuario]         VARCHAR (50)  NULL,
    [Fecha_Transaccion] DATETIME      NULL,
    [IdUsuarioUltModi]  VARCHAR (50)  NULL,
    [Fecha_UltMod]      DATETIME      NULL,
    [IdUsuarioUltAnu]   VARCHAR (50)  NULL,
    [Fecha_UltAnu]      DATETIME      NULL,
    CONSTRAINT [PK_ro_fectividad_Entrega_tipoServicio] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdServicio] ASC)
);

