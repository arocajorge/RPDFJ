CREATE TABLE [Talento_humano].[tlh_evaluacion_opciones_preguntas_respuesta_det] (
    [IdEmpresa]    INT           NOT NULL,
    [IdCalendario] INT           NOT NULL,
    [IdPregunta]   INT           NOT NULL,
    [IdEmpleado]   NUMERIC (18)  NOT NULL,
    [secuencia]    INT           NOT NULL,
    [Observacion]  VARCHAR (500) NULL,
    [Respueta]     BIT           NOT NULL,
    CONSTRAINT [PK_tlh_evaluacion_opciones_preguntas_respuesta_det] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdCalendario] ASC, [IdPregunta] ASC, [IdEmpleado] ASC),
    CONSTRAINT [FK_tlh_evaluacion_opciones_preguntas_respuesta_det_ro_empleado] FOREIGN KEY ([IdEmpresa], [IdEmpleado]) REFERENCES [dbo].[ro_empleado] ([IdEmpresa], [IdEmpleado]),
    CONSTRAINT [FK_tlh_evaluacion_opciones_preguntas_respuesta_det_tlh_evaluacion_opciones_preguntas_det] FOREIGN KEY ([IdEmpresa], [IdPregunta], [secuencia]) REFERENCES [Talento_humano].[tlh_evaluacion_opciones_preguntas_det] ([IdEmpresa], [IdPregunta], [secuencia]),
    CONSTRAINT [FK_tlh_evaluacion_opciones_preguntas_respuesta_det_tlh_evaluacion_opciones_preguntas_respuesta] FOREIGN KEY ([IdEmpresa], [IdCalendario]) REFERENCES [Talento_humano].[tlh_evaluacion_opciones_preguntas_respuesta] ([IdEmpresa], [IdCalendario])
);



