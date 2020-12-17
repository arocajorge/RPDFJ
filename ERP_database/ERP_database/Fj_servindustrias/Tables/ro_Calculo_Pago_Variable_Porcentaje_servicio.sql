CREATE TABLE [Fj_servindustrias].[ro_Calculo_Pago_Variable_Porcentaje_servicio] (
    [IdEmpresa]      INT        NOT NULL,
    [IdEfectividad]  INT        NOT NULL,
    [IdTipo_Nomina]  INT        NOT NULL,
    [IdTipoServicio] INT        NOT NULL,
    [Efec_desde]     FLOAT (53) NOT NULL,
    [Efec_hasta]     FLOAT (53) NOT NULL,
    [Efec_aplica]    FLOAT (53) NOT NULL,
    CONSTRAINT [PK_ro_Calculo_Pago_Variable_Porcentaje_servicio] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdEfectividad] ASC)
);

