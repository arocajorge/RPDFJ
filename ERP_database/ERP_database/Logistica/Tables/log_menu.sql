CREATE TABLE [Logistica].[log_menu] (
    [IdMenu]                INT           IDENTITY (1, 1) NOT NULL,
    [IdMenuPadre]           INT           NULL,
    [DescripcionMenu]       VARCHAR (500) NOT NULL,
    [PosicionMenu]          INT           NOT NULL,
    [Estado]                BIT           NOT NULL,
    [Area]                  VARCHAR (50)  NULL,
    [Controlador]           VARCHAR (50)  NULL,
    [Accion]                VARCHAR (50)  NULL,
    [IdUsuario]             VARCHAR (50)  NOT NULL,
    [FechaTransaccion]      DATETIME      NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)  NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)  NULL,
    [FechaAnulacion]        DATETIME      NULL,
    [MotivoAnulacion]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Logistica.lo_menu] PRIMARY KEY CLUSTERED ([IdMenu] ASC)
);

