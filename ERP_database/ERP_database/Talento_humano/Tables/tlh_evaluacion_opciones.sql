CREATE TABLE [Talento_humano].[tlh_evaluacion_opciones] (
    [IdEmpresa]       INT          NOT NULL,
    [IdOpciones]      INT          NOT NULL,
    [Numero_opciones] INT          NOT NULL,
    [Observacion]     VARCHAR (50) NULL,
    [estado]          BIT          NOT NULL,
    CONSTRAINT [PK_th_numero_opciones_x_preguntas_1] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdOpciones] ASC)
);

