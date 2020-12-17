CREATE TABLE [Digitalizacion].[cxc_XML_DocumentoDet] (
    [IdEmpresa]               INT             NOT NULL,
    [IdDocumento]             NUMERIC (18)    NOT NULL,
    [Secuencia]               INT             NOT NULL,
    [TipoRetencion]           VARCHAR (10)    NOT NULL,
    [CodigoRetencion]         VARCHAR (10)    NOT NULL,
    [BaseImponible]           NUMERIC (18, 2) NOT NULL,
    [PorcentajeRetencion]     NUMERIC (18, 2) NOT NULL,
    [ValorRetenido]           NUMERIC (18, 2) NOT NULL,
    [CodDocSustento]          VARCHAR (10)    NOT NULL,
    [NumDocSustento]          VARCHAR (200)   NOT NULL,
    [FechaEmisionDocSustento] DATE            NOT NULL,
    [IdSucursal]              INT             NULL,
    [IdCobro]                 NUMERIC (18)    NULL,
    [dc_TipoDocumento]        VARCHAR (20)    NULL,
    [IdBodega_Cbte]           INT             NULL,
    [IdCbte_vta_nota]         NUMERIC (18)    NULL,
    [IdCobro_tipo]            VARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_cxc_XML_DocumentoDet] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdDocumento] ASC, [Secuencia] ASC),
    CONSTRAINT [FK_cxc_XML_DocumentoDet_cxc_cobro] FOREIGN KEY ([IdEmpresa], [IdSucursal], [IdCobro]) REFERENCES [dbo].[cxc_cobro] ([IdEmpresa], [IdSucursal], [IdCobro]),
    CONSTRAINT [FK_cxc_XML_DocumentoDet_cxc_XML_Documento] FOREIGN KEY ([IdEmpresa], [IdDocumento]) REFERENCES [Digitalizacion].[cxc_XML_Documento] ([IdEmpresa], [IdDocumento])
);



