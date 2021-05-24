CREATE TABLE [Logistica].[lo_Camaronera] (
    [IdCamaronera]          INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]           VARCHAR (500) NOT NULL,
    [Direccion]             VARCHAR (500) NOT NULL,
    [IdEmpresa]             INT           NOT NULL,
    [IdCliente]             NUMERIC (18)  NOT NULL,
    [Estado]                BIT           NOT NULL,
    [IdUsuario]             VARCHAR (50)  NOT NULL,
    [FechaTransaccion]      DATETIME      NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)  NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)  NULL,
    [FechaAnulacion]        DATETIME      NULL,
    [MotivoAnulacion]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_lo_Camaronera] PRIMARY KEY CLUSTERED ([IdCamaronera] ASC),
    CONSTRAINT [FK_lo_Camaronera_fa_cliente] FOREIGN KEY ([IdEmpresa], [IdCliente]) REFERENCES [dbo].[fa_cliente] ([IdEmpresa], [IdCliente])
);

