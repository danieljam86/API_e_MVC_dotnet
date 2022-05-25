CREATE TABLE Cliente (
	id_cliente INT IDENTITY(1,1),
	cpf VARCHAR (11),
	nome VARCHAR (50),
	rg VARCHAR (15),
	dt_expedicao DateTime,
	orgaoExpedicao VARCHAR (10),
	UF VARCHAR (10),
	dt_nascimento DateTime,
	sexo char (1),
	estadoCivil VARCHAR (50),

	CONSTRAINT PK_Cliente PRIMARY KEY (id_cliente),
	CONSTRAINT CH_Cliente CHECK (sexo IN('F', 'M'))
)
CREATE TABLE EnderecoCliente (
id_endereco INT IDENTITY(1,1) NOT NULL,
cep VARCHAR (20),
logradouro VARCHAR (50),
numero VARCHAR (10),
complemento VARCHAR (50),
bairro VARCHAR (50),
cidade VARCHAR (50),
UF VARCHAR (10),
Cliente_id_cliente INT NULL,

CONSTRAINT PK_EnderecoCliente PRIMARY KEY (id_endereco),
  CONSTRAINT FK_EnderecoCliente_id_cliente FOREIGN KEY (Cliente_id_cliente)
          REFERENCES Cliente (id_cliente)
)
GO