CREATE TABLE [Logistica].[lo_vehiculo] (
    [IdVehiculo]            INT           IDENTITY (1, 1) NOT NULL,
    [IdChofer]              INT           NULL,
    [Descripcion]           VARCHAR (500) NOT NULL,
    [Placa]                 VARCHAR (50)  NOT NULL,
    [Disco]                 VARCHAR (50)  NOT NULL,
    [Estado]                BIT           NOT NULL,
    [EsVehiculoPropio]      BIT           NOT NULL,
    [CapacidadBines]        INT           NOT NULL,
    [IdUsuario]             VARCHAR (50)  NOT NULL,
    [FechaTransaccion]      DATETIME      NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)  NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)  NULL,
    [FechaAnulacion]        DATETIME      NULL,
    [MotivoAnulacion]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_lo_vehiculo] PRIMARY KEY CLUSTERED ([IdVehiculo] ASC),
    CONSTRAINT [FK_lo_vehiculo_lo_chofer] FOREIGN KEY ([IdChofer]) REFERENCES [Logistica].[lo_chofer] ([IdChofer])
);

