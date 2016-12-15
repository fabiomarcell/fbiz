create database fbiz;
use fbiz;
create table produto(
	produtoID int primary key identity(1,1),
	categoriaID int,
	nome nvarchar(200),
	descricao nvarchar(max),
	dataCadastro datetime,
	ativo bit
);

create table categoria(
	categoriaID int primary key identity(1,1),
	nome nvarchar(200),
	dataCadastro datetime,
	ativo bit
);

create table comentario(
	comentarioID int primary key identity(1,1),
	produtoID int,
	nome nvarchar(200),
	titulo nvarchar(200),
	descricao nvarchar(max),
	dataCadastro datetime,
	ativo bit
);

ALTER TABLE produto
ADD FOREIGN KEY (categoriaID)
REFERENCES categoria(categoriaID);

ALTER TABLE comentario
ADD FOREIGN KEY (produtoID)
REFERENCES produto(produtoID);