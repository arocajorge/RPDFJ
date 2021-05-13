CREATE TABLE [Logistica].[log_menuPorUsuario] (
    [IdEmpresa] INT          NOT NULL,
    [IdMenu]    INT          NOT NULL,
    [IdUsuario] VARCHAR (50) NOT NULL,
    [Nuevo]     BIT          NOT NULL,
    [Modificar] BIT          NOT NULL,
    [Anular]    BIT          NOT NULL,
    CONSTRAINT [PK_lo_menuPorUsuario] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdMenu] ASC, [IdUsuario] ASC),
    CONSTRAINT [FK_lo_menuPorUsuario_Logistica.lo_menu] FOREIGN KEY ([IdMenu]) REFERENCES [Logistica].[log_menu] ([IdMenu]),
    CONSTRAINT [FK_lo_menuPorUsuario_seg_usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[seg_usuario] ([IdUsuario]),
    CONSTRAINT [FK_lo_menuPorUsuario_tb_empresa] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[tb_empresa] ([IdEmpresa])
);

