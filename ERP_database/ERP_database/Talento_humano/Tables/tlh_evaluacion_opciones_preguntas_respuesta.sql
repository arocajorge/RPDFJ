CREATE TABLE [Talento_humano].[tlh_evaluacion_opciones_preguntas_respuesta] (
    [IdEmpresa]        INT           NOT NULL,
    [IdCalendario]     INT           NOT NULL,
    [Fecha_evaluacion] DATE          NOT NULL,
    [Numero_preguntas] INT           NOT NULL,
    [Observacion]      VARCHAR (500) NOT NULL,
    [estado]           BIT           NOT NULL,
    CONSTRAINT [PK_tlh_evaluacion] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdCalendario] ASC)
);

