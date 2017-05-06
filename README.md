# connect

CREATE TABLE Funcionario(
	Id INT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(256) NOT NULL,
	Setor VARCHAR(80) NOT NULL,
	Cargo VARCHAR(80) NOT NULL,
	DataAdmissao DATE NOT NULL,
	Salario DECIMAL NOT NULL,
	CONSTRAINT Pk_Funcionario PRIMARY KEY (Id)
);

CREATE TABLE Faltas(
	Id INT IDENTITY(1,1) NOT NULL,
	Data DATE NOT NULL,
	Justificada BIT NOT NULL,
	IdFuncionario INT NOT NULL,
	CONSTRAINT Pk_Faltas PRIMARY KEY (Id),
	CONSTRAINT Fk_Faltas_Funcionario FOREIGN KEY(IdFuncionario)
		REFERENCES Funcionario(Id)
);

CREATE TABLE Ferias(
	Id INT IDENTITY(1,1) NOT NULL,
	Inicio DATE NOT NULL,
	Fim DATE NOT NULL,
	IdFuncionario INT NOT NULL,
	CONSTRAINT Pk_Ferias PRIMARY KEY (Id),
	CONSTRAINT Fk_Ferias_Funcionario FOREIGN KEY(IdFuncionario)
		REFERENCES Funcionario(Id)
);

{
	"nome": "Funcionario 1",
	"Setor" : "Setor 1",
	"Cargo" : "Cargo 1",
	"DataAdmissao" : "01/01/2017",
	"Salario" : 1500.25
}

{
	"Data" : "01/01/2017",
	"Justificada": true,
	"IdFuncionario" : 1
}

{
	"Inicio" : "01/01/2017",
	"Fim": "01/02/2017",
	"IdFuncionario" : 1
}