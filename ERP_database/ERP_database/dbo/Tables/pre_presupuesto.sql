﻿CREATE TABLE [dbo].[pre_presupuesto] (
    [IdEmpresa]         INT           NOT NULL,
    [IdPresupuesto]     NUMERIC (18)  NOT NULL,
    [IdAnio]            VARCHAR (10)  NOT NULL,
    [Secuencia]         INT           NOT NULL,
    [CodigoPresupuesto] VARCHAR (200) NOT NULL,
    [IdCtaCble]         VARCHAR (20)  NOT NULL,
    [IdCentroCosto]     VARCHAR (20)  NULL,
    [IdTipoRubro]       VARCHAR (20)  NOT NULL,
    [CodRubro]          VARCHAR (25)  NULL,
    [NombreRubro]       VARCHAR (50)  NULL,
    [Enero]             FLOAT (53)    NOT NULL,
    [febrero]           FLOAT (53)    NOT NULL,
    [Marzo]             FLOAT (53)    NOT NULL,
    [Abril]             FLOAT (53)    NOT NULL,
    [Mayo]              FLOAT (53)    NOT NULL,
    [Junio]             FLOAT (53)    NOT NULL,
    [Julio]             FLOAT (53)    NOT NULL,
    [Agosto]            FLOAT (53)    NOT NULL,
    [Septiembre]        FLOAT (53)    NOT NULL,
    [Octubre]           FLOAT (53)    NOT NULL,
    [Noviembre]         FLOAT (53)    NOT NULL,
    [Diciembre]         FLOAT (53)    NOT NULL,
    [Total]             FLOAT (53)    NOT NULL,
    CONSTRAINT [PK_pres_presupuesto] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdPresupuesto] ASC, [IdAnio] ASC, [Secuencia] ASC)
);

