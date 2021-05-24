CREATE TABLE [Logistica].[lo_GuiaDet] (
    [IdGuiaDet] INT             IDENTITY (1, 1) NOT NULL,
    [IdGuia]    INT             NOT NULL,
    [IdRecurso] INT             NOT NULL,
    [Cantidad]  NUMERIC (18, 2) NOT NULL,
    CONSTRAINT [PK_lo_GuiaDet] PRIMARY KEY CLUSTERED ([IdGuiaDet] ASC),
    CONSTRAINT [FK_lo_GuiaDet_lo_Guia] FOREIGN KEY ([IdGuia]) REFERENCES [Logistica].[lo_Guia] ([IdGuia]),
    CONSTRAINT [FK_lo_GuiaDet_lo_recurso] FOREIGN KEY ([IdRecurso]) REFERENCES [Logistica].[lo_recurso] ([IdRecurso])
);

