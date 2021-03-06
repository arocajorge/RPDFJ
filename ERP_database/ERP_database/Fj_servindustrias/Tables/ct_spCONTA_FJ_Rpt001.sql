﻿CREATE TABLE [Fj_servindustrias].[ct_spCONTA_FJ_Rpt001] (
    [IdEmpresa]            INT           NOT NULL,
    [IdCtaCble]            NUMERIC (18)  NOT NULL,
    [IdPunto_cargo]        INT           NOT NULL,
    [pc_Cuenta]            VARCHAR (200) NOT NULL,
    [nom_punto_cargo]      VARCHAR (500) NOT NULL,
    [IdNivelCta]           INT           NOT NULL,
    [IdGrupoCble]          VARCHAR (5)   NOT NULL,
    [gc_Orden]             TINYINT       NOT NULL,
    [IdCtaCblePadre]       NUMERIC (18)  NULL,
    [gc_estado_financiero] CHAR (20)     NOT NULL,
    [pc_EsMovimiento]      CHAR (1)      NOT NULL,
    [gc_GrupoCble]         VARCHAR (50)  NOT NULL,
    [bg_saldo_inicial]     FLOAT (53)    NOT NULL,
    [bg_debitos_mes]       FLOAT (53)    NOT NULL,
    [bg_creditos_mes]      FLOAT (53)    NOT NULL,
    [bg_saldo_mes]         FLOAT (53)    NOT NULL,
    [bg_saldo_final]       FLOAT (53)    NOT NULL,
    [IdCtaCble_2]          VARCHAR (20)  NOT NULL,
    [IdCtaCblePadre_2]     VARCHAR (20)  NULL,
    [bg_saldo_inicial_mov] FLOAT (53)    NOT NULL,
    [bg_debitos_mes_mov]   FLOAT (53)    NOT NULL,
    [bg_creditos_mes_mov]  FLOAT (53)    NOT NULL,
    [bg_saldo_mes_mov]     FLOAT (53)    NOT NULL,
    [bg_saldo_final_mov]   FLOAT (53)    NOT NULL,
    CONSTRAINT [PK_ct_spCONTA_FJ_Rpt001] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdCtaCble] ASC, [IdPunto_cargo] ASC)
);





