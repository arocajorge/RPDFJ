CREATE TABLE [Talento_humano].[tlh_evaluacion_opciones_preguntas] (
    [IdEmpresa]       INT           NOT NULL,
    [IdPregunta]      INT           NOT NULL,
    [IdOpciones]      INT           NOT NULL,
    [Numero_opciones] INT           NOT NULL,
    [Descripcion]     VARCHAR (500) NULL,
    [estado]          BIT           NOT NULL,
    CONSTRAINT [PK_tlh_preguntas_1] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdPregunta] ASC),
    CONSTRAINT [FK_tlh_evaluacion_opciones_preguntas_tlh_evaluacion_opciones] FOREIGN KEY ([IdEmpresa], [IdOpciones]) REFERENCES [Talento_humano].[tlh_evaluacion_opciones] ([IdEmpresa], [IdOpciones])
);

