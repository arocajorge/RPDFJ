CREATE TABLE [Logistica].[lo_Empacadora] (
    [IdEmpacadora]          INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]           VARCHAR (500) NOT NULL,
    [Direccion]             VARCHAR (500) NOT NULL,
    [IdEmpresa]             INT           NULL,
    [IdCliente]             NUMERIC (18)  NULL,
    [Estado]                BIT           NOT NULL,
    [IdUsuario]             VARCHAR (50)  NOT NULL,
    [FechaTransaccion]      DATETIME      NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)  NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)  NULL,
    [FechaAnulacion]        DATETIME      NULL,
    [MotivoAnulacion]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_lo_Empacadora] PRIMARY KEY CLUSTERED ([IdEmpacadora] ASC),
    CONSTRAINT [FK_lo_Empacadora_fa_cliente] FOREIGN KEY ([IdEmpresa], [IdCliente]) REFERENCES [dbo].[fa_cliente] ([IdEmpresa], [IdCliente])
);

