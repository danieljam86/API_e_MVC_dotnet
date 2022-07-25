CREATE TABLE [dbo].[Cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[cpf] [varchar](11) NULL,
	[nome] [varchar](50) NULL,
	[rg] [varchar](15) NULL,
	[dt_expedicao] [datetime] NULL,
	[orgaoExpedicao] [varchar](10) NULL,
	[UF] [varchar](10) NULL,
	[dt_nascimento] [datetime] NULL,
	[sexo] [char](1) NULL,
	[estadoCivil] [varchar](50) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnderecoCliente]    Script Date: 25/07/2022 08:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnderecoCliente](
	[id_endereco] [int] IDENTITY(1,1) NOT NULL,
	[cep] [varchar](20) NULL,
	[logradouro] [varchar](50) NULL,
	[numero] [varchar](10) NULL,
	[complemento] [varchar](50) NULL,
	[bairro] [varchar](50) NULL,
	[cidade] [varchar](50) NULL,
	[UF] [varchar](10) NULL,
	[Cliente_id_cliente] [int] NULL,
 CONSTRAINT [PK_EnderecoCliente] PRIMARY KEY CLUSTERED 
(
	[id_endereco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EnderecoCliente]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoCliente_id_cliente] FOREIGN KEY([Cliente_id_cliente])
REFERENCES [dbo].[Cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[EnderecoCliente] CHECK CONSTRAINT [FK_EnderecoCliente_id_cliente]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [CH_Cliente] CHECK  (([sexo]='M' OR [sexo]='F'))
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [CH_Cliente]
GO
USE [master]
GO
ALTER DATABASE [testeGTISolution] SET  READ_WRITE 
GO
