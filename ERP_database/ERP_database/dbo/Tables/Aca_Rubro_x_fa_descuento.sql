CREATE TABLE [dbo].[Aca_Rubro_x_fa_descuento] (
    [IdInstitucion_rub] INT           NOT NULL,
    [IdRubro]           INT           NOT NULL,
    [IdEmpresa_fadesc]  INT           NOT NULL,
    [IdDescuento]       NUMERIC (18)  NOT NULL,
    [Estado]            BIT           NOT NULL,
    [IdUsuarioCreacion] NVARCHAR (50) NULL,
    [FechaCreacion]     DATETIME      NULL,
    [IdUsuarioUltMod]   VARCHAR (50)  NULL,
    [FechaUltMod]       DATETIME      NULL,
    [IdUsuarioUltAnu]   NVARCHAR (50) NULL,
    [FechaUltAnu]       DATETIME      NULL,
    [MotivoAnulacion]   VARCHAR (100) NULL,
    [nom_pc]            VARCHAR (25)  NULL,
    [ip]                VARCHAR (25)  NULL,
    CONSTRAINT [PK_Aca_Rubro_x_fa_descuento] PRIMARY KEY CLUSTERED ([IdInstitucion_rub] ASC, [IdRubro] ASC, [IdEmpresa_fadesc] ASC, [IdDescuento] ASC),
    CONSTRAINT [FK_Aca_Rubro_x_fa_descuento_Aca_Rubro] FOREIGN KEY ([IdInstitucion_rub], [IdRubro]) REFERENCES [dbo].[Aca_Rubro] ([IdInstitucion], [IdRubro]),
    CONSTRAINT [FK_Aca_Rubro_x_fa_descuento_fa_descuento] FOREIGN KEY ([IdEmpresa_fadesc], [IdDescuento]) REFERENCES [dbo].[fa_descuento] ([IdEmpresa], [IdDescuento])
);

