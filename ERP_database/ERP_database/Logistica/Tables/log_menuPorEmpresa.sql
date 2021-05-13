CREATE TABLE [Logistica].[log_menuPorEmpresa] (
    [IdMenu]    INT NOT NULL,
    [IdEmpresa] INT NOT NULL,
    CONSTRAINT [PK_lo_menuPorEmpresa] PRIMARY KEY CLUSTERED ([IdMenu] ASC, [IdEmpresa] ASC),
    CONSTRAINT [FK_lo_menuPorEmpresa_Logistica.lo_menu] FOREIGN KEY ([IdMenu]) REFERENCES [Logistica].[log_menu] ([IdMenu]),
    CONSTRAINT [FK_lo_menuPorEmpresa_tb_empresa] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[tb_empresa] ([IdEmpresa])
);

