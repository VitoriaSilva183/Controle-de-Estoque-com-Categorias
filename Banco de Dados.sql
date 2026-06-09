CREATE DATABASE controle_estoque;
USE controle_estoque;

CREATE TABLE categorias (
categoria_id INT AUTO_INCREMENT PRIMARY KEY,
nome VARCHAR (200) NOT NULL,
descricao VARCHAR (200) NOT NULL
);

CREATE TABLE produtos (
id INT AUTO_INCREMENT PRIMARY KEY,
nome VARCHAR (200) NOT NULL,
preco DECIMAL (10,2) NOT NULL,
quantidade INT NOT NULL DEFAULT 0,
categoria_id INT,
FOREIGN KEY (categoria_id) REFERENCES categorias (categoria_id)
);