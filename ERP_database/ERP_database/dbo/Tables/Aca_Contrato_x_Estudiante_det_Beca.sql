CREATE TABLE [dbo].[Aca_Contrato_x_Estudiante_det_Beca] (
    [IdInstitucion]     INT            NOT NULL,
    [IdContrato]        NUMERIC (18)   NOT NULL,
    [IdRubro]           NUMERIC (18)   NOT NULL,
    [IdInstitucion_Per] INT            NOT NULL,
    [IdAnioLectivo_Per] INT            NOT NULL,
    [IdPeriodo_Per]     INT            NOT NULL,
    [IdBeca]            INT            NOT NULL,
    [valor_beca]        FLOAT (53)     NOT NULL,
    [porc_beca]         FLOAT (53)     NOT NULL,
    [IdEmpresa]         INT            NULL,
    [IdDescuento]       NUMERIC (18)   NULL,
    [estado]            BIT            NULL,
    [IdUsuarioCreacion] NVARCHAR (50)  NULL,
    [FechaCreacion]     DATETIME       NULL,
    [IdUsuarioUltMod]   NVARCHAR (50)  NULL,
    [FechaModificacion] DATETIME       NULL,
    [IdUsuarioUltAnulo] NVARCHAR (50)  NULL,
    [FechaAnulacion]    DATETIME       NULL,
    [MotivoAnula]       NVARCHAR (200) NULL,
    CONSTRAINT [PK_Aca_Contrato_x_Estudiante_det_Beca] PRIMARY KEY CLUSTERED ([IdInstitucion] ASC, [IdContrato] ASC, [IdRubro] ASC, [IdInstitucion_Per] ASC, [IdAnioLectivo_Per] ASC, [IdPeriodo_Per] ASC, [IdBeca] ASC),
    CONSTRAINT [FK_Aca_Contrato_x_Estudiante_det_Beca_fa_descuento] FOREIGN KEY ([IdEmpresa], [IdDescuento]) REFERENCES [dbo].[fa_descuento] ([IdEmpresa], [IdDescuento])
);

