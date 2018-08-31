CREATE TABLE [Talento_humano].[tlh_evaluacion_opciones_preguntas_det] (
    [IdEmpresa]          INT           NOT NULL,
    [IdPregunta]         INT           NOT NULL,
    [secuencia]          INT           NOT NULL,
    [Descripcion_opcion] VARCHAR (500) NULL,
    CONSTRAINT [PK_tlh_preguntas_det_1] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdPregunta] ASC, [secuencia] ASC),
    CONSTRAINT [FK_tlh_evaluacion_opciones_preguntas_det_tlh_evaluacion_opciones_preguntas] FOREIGN KEY ([IdEmpresa], [IdPregunta]) REFERENCES [Talento_humano].[tlh_evaluacion_opciones_preguntas] ([IdEmpresa], [IdPregunta])
);

