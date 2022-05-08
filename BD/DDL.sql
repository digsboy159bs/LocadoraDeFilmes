CREATE DATABASE LocadoraDefilmes;

USE LocadoraDefilmes;

CREATE TABLE Usuarios(
IdUser			INT PRIMARY KEY IDENTITY,
Nome			VARCHAR(100),
Idade			INT,
Email			VARCHAR(255),
Senha			VARCHAR(20),
IdTipo			INT FOREIGN KEY REFERENCES TipoUsuario(IdTipo)
);

CREATE TABLE Generos(
IdGenero		INT PRIMARY KEY IDENTITY,
NomeGenero			VARCHAR(20)
);

CREATE TABLE TipoUsuario(
IdTipo			INT PRIMARY KEY IDENTITY,
Tipo			VARCHAR(15)
);

CREATE TABLE Clientes(
IdCliente		INT PRIMARy KEY IDENTITY,
Nome			VARCHAR(100),
Email			VARCHAR(255)
);

CREATE TABLE Filmes(
IdFilme			INT PRIMARY KEY IDENTITY,
Nome			VARCHAR(255),
AnoLancamento	DATE,
Resumo			TEXT,
IdGenero		INT FOREIGN KEY REFERENCES Generos(IdGenero)
);

CREATE TABLE Locacao(
IdLocacao		INT PRIMARY KEY IDENTITY,
DataRetirada	DATE,
PrazoDevolucao	DATE,
IdCliente		INT FOREIGN KEY REFERENCES Clientes(IdCliente),
IdFilme			INT FOREIGN KEY REFERENCES Filmes(IdFilme)
);

SELECT * FROM Filmes;
SELECT * FROM Locacao;
SELECT * FROM Clientes;
SELECT * FROM Usuarios;
SELECT * FROM TipoUsuario;
SELECT * FROM Generos;

INSERT INTO TipoUsuario(Tipo)
VALUES('Administrador'), ('Comum');

INSERT INTO Usuarios(Nome, Idade, Email, Senha, IdTipo)
VALUES('Diego Barreto', 21, 'diego@gmail.com', '123', 1);

INSERT INTO Filmes(Nome, AnoLancamento, Resumo, IdGenero)
VALUES('Doutor Estranho no multiverso da loucura', '2022/05/05', 'Um filme incrivel sobre o doutor estranho e a wanda em diferentes multiversos', 2);

INSERT INTO Clientes(Nome, Email)
VALUES('Vannon', 'Vannon@email.com');

INSERT INTO Locacao(DataRetirada, PrazoDevolucao, IdCliente, IdFilme)
VALUES('2022/05/08', '2022/05/13', 1, 3);

DELETE FROM Filmes
WHERE IdFilme = 2;

DROP TABLE Locacao;
DROP TABLE Filmes;
DROP TABLE Generos;