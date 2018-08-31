CREATE TABLE [CG].[in_Ing_Egr_Inven_CG] (
    [IdEmpresa]         INT           NOT NULL,
    [IdSucursal]        INT           NOT NULL,
    [IdMovi_inven_tipo] INT           NOT NULL,
    [IdNumMovi]         NUMERIC (18)  NOT NULL,
    [IdIngreso]         NUMERIC (18)  NOT NULL,
    [IdCuenta]          NUMERIC (18)  NOT NULL,
    [Estado]            CHAR (1)      NOT NULL,
    [MotivoAnulacion]   VARCHAR (100) NULL,
    [IdUsuarioCreacion] VARCHAR (50)  NULL,
    [Fecha_Transac]     DATETIME      NULL,
    [IdUsuarioUltModi]  VARCHAR (50)  NULL,
    [Fecha_UltMod]      DATETIME      NULL,
    [IdusuarioUltAnu]   VARCHAR (50)  NULL,
    [Fecha_UltAnu]      DATETIME      NULL,
    [nom_pc]            VARCHAR (50)  NULL,
    [ip]                VARCHAR (30)  NULL,
    CONSTRAINT [PK_in_Ing_Egr_Inven] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdSucursal] ASC, [IdMovi_inven_tipo] ASC, [IdNumMovi] ASC)
);

