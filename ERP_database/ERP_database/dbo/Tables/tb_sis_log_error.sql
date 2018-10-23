
CREATE TABLE [dbo].[tb_sis_log_error](
	[IdEmpresa] [int] NOT NULL,
	[IdError] [numeric](18, 0) NOT NULL,
	[DescripcionError] [varchar](max) NOT NULL,
	[Modulo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tb_sis_log_error] PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC,
	[IdError] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


