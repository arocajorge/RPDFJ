CREATE TABLE [dbo].[XXXSTOCK] (
    [pr_codigo]         VARCHAR (100)  NOT NULL,
    [pr_descripcion]    VARCHAR (1000) NOT NULL,
    [pr_costo_promedio] FLOAT (53)     NOT NULL,
    [pr_stock]          FLOAT (53)     NOT NULL,
    [pr_stock_fisico]   FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_XXXSTOCK] PRIMARY KEY CLUSTERED ([pr_codigo] ASC)
);

