CREATE TABLE [Logistica].[lo_novedad] (
    [IdNovedad]             INT             IDENTITY (1, 1) NOT NULL,
    [IdRubro]               INT             NOT NULL,
    [IdChofer]              INT             NOT NULL,
    [Descripcion]           VARCHAR (MAX)   NOT NULL,
    [Fecha]                 DATE            NOT NULL,
    [Valor]                 NUMERIC (18, 2) NOT NULL,
    [IdArchivo]             INT             NULL,
    [Estado]                BIT             NOT NULL,
    [IdUsuario]             VARCHAR (50)    NOT NULL,
    [FechaTransaccion]      DATETIME        NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)    NULL,
    [FechaModificacion]     DATETIME        NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)    NULL,
    [FechaAnulacion]        DATETIME        NULL,
    [MotivoAnulacion]       VARCHAR (MAX)   NULL,
    CONSTRAINT [PK_lo_novedad] PRIMARY KEY CLUSTERED ([IdNovedad] ASC),
    CONSTRAINT [FK_lo_novedad_lo_chofer] FOREIGN KEY ([IdChofer]) REFERENCES [Logistica].[lo_chofer] ([IdChofer]),
    CONSTRAINT [FK_lo_novedad_lo_rubro] FOREIGN KEY ([IdRubro]) REFERENCES [Logistica].[lo_rubro] ([IdRubro])
);



