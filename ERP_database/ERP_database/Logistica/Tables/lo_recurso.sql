CREATE TABLE [Logistica].[lo_recurso] (
    [IdRecurso]             INT           IDENTITY (1, 1) NOT NULL,
    [NomRecurso]            VARCHAR (500) NOT NULL,
    [ControlaSerie]         BIT           NOT NULL,
    [ControlaKardex]        BIT           NOT NULL,
    [IdUnidadMedida]        VARCHAR (25)  NOT NULL,
    [Estado]                BIT           NOT NULL,
    [IdUsuario]             VARCHAR (50)  NOT NULL,
    [FechaTransaccion]      DATETIME      NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)  NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)  NULL,
    [FechaAnulacion]        DATETIME      NULL,
    [MotivoAnulacion]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_lo_recurso] PRIMARY KEY CLUSTERED ([IdRecurso] ASC),
    CONSTRAINT [FK_lo_recurso_in_UnidadMedida] FOREIGN KEY ([IdUnidadMedida]) REFERENCES [dbo].[in_UnidadMedida] ([IdUnidadMedida])
);

