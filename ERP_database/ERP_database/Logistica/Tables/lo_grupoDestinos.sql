﻿CREATE TABLE [Logistica].[lo_grupoDestinos] (
    [IdGrupoD]              INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]           VARCHAR (500) NOT NULL,
    [Estado]                BIT           NOT NULL,
    [IdUsuario]             VARCHAR (50)  NOT NULL,
    [FechaTransaccion]      DATETIME      NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)  NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)  NULL,
    [FechaAnulacion]        DATETIME      NULL,
    [MotivoAnulacion]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_lo_grupoDestinos] PRIMARY KEY CLUSTERED ([IdGrupoD] ASC)
);

