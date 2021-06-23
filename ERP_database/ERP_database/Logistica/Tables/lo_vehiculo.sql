CREATE TABLE [Logistica].[lo_vehiculo] (
    [IdVehiculo]            INT             IDENTITY (1, 1) NOT NULL,
    [IdChofer]              INT             NOT NULL,
    [Descripcion]           VARCHAR (500)   NOT NULL,
    [Placa]                 VARCHAR (50)    NOT NULL,
    [Chasis]                VARCHAR (500)   NULL,
    [Motor]                 VARCHAR (500)   NULL,
    [Anio]                  INT             NULL,
    [Disco]                 VARCHAR (50)    NULL,
    [Tonelaje]              INT             NULL,
    [Ejes]                  INT             NULL,
    [Cilindraje]            INT             NULL,
    [IdCatalogoColor]       INT             NULL,
    [Estado]                BIT             NOT NULL,
    [EsVehiculoPropio]      BIT             NOT NULL,
    [CapacidadBines]        INT             NOT NULL,
    [CapacidadPorBin]       NUMERIC (18, 2) NOT NULL,
    [IdUsuario]             VARCHAR (50)    NOT NULL,
    [FechaTransaccion]      DATETIME        NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)    NULL,
    [FechaModificacion]     DATETIME        NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)    NULL,
    [FechaAnulacion]        DATETIME        NULL,
    [MotivoAnulacion]       VARCHAR (MAX)   NULL,
    CONSTRAINT [PK_lo_vehiculo] PRIMARY KEY CLUSTERED ([IdVehiculo] ASC),
    CONSTRAINT [FK_lo_vehiculo_lo_catalogo] FOREIGN KEY ([IdCatalogoColor]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo]),
    CONSTRAINT [FK_lo_vehiculo_lo_chofer] FOREIGN KEY ([IdChofer]) REFERENCES [Logistica].[lo_chofer] ([IdChofer])
);









