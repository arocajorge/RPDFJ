CREATE TABLE [Logistica].[lo_GuiaDetCodigo] (
    [IdCodigo]  INT           IDENTITY (1, 1) NOT NULL,
    [IdGuiaDet] INT           NOT NULL,
    [Codigo]    VARCHAR (MAX) NOT NULL,
    [Fecha]     DATETIME      NOT NULL,
    [IdUsuario] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_lo_GuiaDetCodigo] PRIMARY KEY CLUSTERED ([IdCodigo] ASC),
    CONSTRAINT [FK_lo_GuiaDetCodigo_lo_GuiaDet] FOREIGN KEY ([IdGuiaDet]) REFERENCES [Logistica].[lo_GuiaDet] ([IdGuiaDet])
);

