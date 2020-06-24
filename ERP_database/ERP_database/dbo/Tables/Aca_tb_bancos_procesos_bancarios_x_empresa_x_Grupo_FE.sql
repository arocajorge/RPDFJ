CREATE TABLE [dbo].[Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE] (
    [IdEmpresa]               INT          NOT NULL,
    [IdProceso_bancario_tipo] VARCHAR (25) NOT NULL,
    [IdInstitucion]           INT          NOT NULL,
    [IdGrupoFE]               INT          NOT NULL,
    [CodGrupoFE]              VARCHAR (50) NULL,
    [Codigo_establecimiento]  VARCHAR (10) NULL,
    [porcentaje_comision]     FLOAT (53)   NULL,
    [Estado]                  BIT          NULL,
    [Observacion]             VARCHAR (50) NULL,
    CONSTRAINT [PK_Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdProceso_bancario_tipo] ASC, [IdInstitucion] ASC, [IdGrupoFE] ASC),
    CONSTRAINT [FK_Aca_tb_bancos_procesos_bancarios_x_empresa_x_Grupo_FE_Aca_Rubro_Grupo_FE] FOREIGN KEY ([IdInstitucion], [IdGrupoFE]) REFERENCES [dbo].[Aca_Rubro_Grupo_FE] ([IdInstitucion], [IdGrupoFE])
);

