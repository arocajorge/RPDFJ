CREATE TABLE [CG].[in_categoria_CG] (
    [IdEmpresa]       INT           NOT NULL,
    [IdCategoria]     VARCHAR (25)  NOT NULL,
    [sw_medicamento]  BIT           NULL,
    [sw_vende]        BIT           NULL,
    [sw_insumos]      BIT           NULL,
    [sw_formulacion]  BIT           NULL,
    [Estado]          CHAR (1)      NOT NULL,
    [IdUsuario]       VARCHAR (50)  NULL,
    [Fecha_Transac]   DATETIME      NULL,
    [nom_pc]          VARCHAR (50)  NULL,
    [ip]              VARCHAR (25)  NULL,
    [MotiAnula]       VARCHAR (200) NULL,
    [IdUsuarioUltMod] VARCHAR (50)  NULL,
    [Fecha_UltMod]    DATETIME      NULL,
    [IdUsuarioUltAnu] VARCHAR (50)  NULL,
    [Fecha_UltAnu]    DATETIME      NULL,
    CONSTRAINT [PK_in_categorias_CG] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdCategoria] ASC)
);

