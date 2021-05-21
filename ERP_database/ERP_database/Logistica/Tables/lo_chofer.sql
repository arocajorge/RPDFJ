CREATE TABLE [Logistica].[lo_chofer] (
    [IdChofer]                   INT             IDENTITY (1, 1) NOT NULL,
    [IdCatalogoClase]            INT             NOT NULL,
    [PorcentajeComision]         NUMERIC (18, 2) NULL,
    [pe_cedulaRuc]               VARCHAR (50)    NOT NULL,
    [pe_nombre]                  VARCHAR (100)   NOT NULL,
    [pe_apellido]                VARCHAR (100)   NOT NULL,
    [pe_razonSocial]             VARCHAR (150)   NULL,
    [pe_nombreCompleto]          VARCHAR (200)   NOT NULL,
    [IdTipoDocumento]            VARCHAR (25)    NOT NULL,
    [Telefono]                   VARCHAR (500)   NULL,
    [Celular]                    VARCHAR (500)   NULL,
    [Correo]                     VARCHAR (500)   NULL,
    [Estado]                     BIT             NULL,
    [IdUsuario]                  VARCHAR (50)    NOT NULL,
    [FechaTransaccion]           DATETIME        NOT NULL,
    [IdUsuarioModificacion]      VARCHAR (50)    NULL,
    [FechaModificacion]          DATETIME        NULL,
    [IdUsuarioAnulacion]         VARCHAR (50)    NULL,
    [FechaAnulacion]             DATETIME        NULL,
    [MotivoAnulacion]            VARCHAR (MAX)   NULL,
    [IdTipoCta_acreditacion_cat] VARCHAR (25)    NULL,
    [num_cta_acreditacion]       VARCHAR (50)    NULL,
    [IdBanco_acreditacion]       INT             NULL,
    [FechaIngreso]               DATE            NULL,
    CONSTRAINT [PK_lo_chofer] PRIMARY KEY CLUSTERED ([IdChofer] ASC),
    CONSTRAINT [FK_lo_chofer_lo_catalogo] FOREIGN KEY ([IdCatalogoClase]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo])
);







