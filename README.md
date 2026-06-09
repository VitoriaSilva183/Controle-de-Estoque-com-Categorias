[README (1).md](https://github.com/user-attachments/files/28730931/README.1.md)
# 📦 Controle de Estoque com Categorias

Sistema de gerenciamento de estoque desenvolvido em C# com MySQL, utilizando o padrão Repository.

---

## 🛠️ Tecnologias Utilizadas

- **C# / .NET** — Linguagem e plataforma principal
- **MySQL** — Banco de dados relacional
- **MySqlConnector** — Pacote para conexão com o MySQL

---

## 📁 Estrutura do Projeto

```
EstoqueDB/
├── Models/
│   ├── Categoria.cs        # Classe modelo da Categoria
│   └── Produto.cs          # Classe modelo do Produto
├── Database/
│   └── ConexaoBanco.cs     # Classe de conexão com o MySQL
├── Repositories/
│   ├── CategoriaRepository.cs  # Operações de banco para Categoria
│   └── ProdutoRepository.cs    # Operações de banco para Produto
└── Program.cs              # Menu principal do sistema
```

---

## 🗄️ Banco de Dados

### Criação do Banco

```sql
CREATE DATABASE controle_estoque;
USE controle_estoque;

CREATE TABLE categorias (
    categoria_id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(200) NOT NULL,
    descricao VARCHAR(200) NOT NULL
);

CREATE TABLE produtos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(200) NOT NULL,
    preco DECIMAL(10,2) NOT NULL,
    quantidade INT NOT NULL DEFAULT 0,
    categoria_id INT,
    FOREIGN KEY (categoria_id) REFERENCES categorias(categoria_id)
);
```

### Relacionamento entre Tabelas

```
categorias (1) ──→ (N) produtos
```

Uma categoria pode ter vários produtos. Um produto pertence a uma categoria.

---

## ▶️ Como Executar

### Pré-requisitos

- .NET SDK instalado
- MySQL instalado e em execução

### Passos

1. Clone o repositório:
```
git clone https://github.com/VitoriaSilva183/Controle-de-Estoque-com-Categorias
```

2. Entre na pasta do projeto:
```
cd EstoqueDB
```

3. Instale o pacote MySqlConnector:
```
dotnet add package MySqlConnector
```

4. Configure a string de conexão em `Database/ConexaoBanco.cs`:
```csharp
private const string _stringConexao = "Server=localhost;Database=controle_estoque;User=root;Password=;";
```

5. Crie o banco de dados executando o SQL acima no MySQL

6. Execute o projeto:
```
dotnet run
```

---

## 📋 Funcionalidades

| Opção | Funcionalidade |
|-------|----------------|
| 1 | Cadastrar Categoria |
| 2 | Listar todas as Categorias |
| 3 | Cadastrar Produto |
| 4 | Listar todos os Produtos |
| 5 | Buscar Produto por ID |
| 6 | Remover Produto |
| 0 | Sair |

---

## 🧩 Modelagem das Classes

### Categoria
| Propriedade | Tipo | Descrição |
|-------------|------|-----------|
| Id | int | Chave primária |
| Nome | string | Nome da categoria |
| Descricao | string | Descrição da categoria |

### Produto
| Propriedade | Tipo | Descrição |
|-------------|------|-----------|
| Id | int | Chave primária |
| Nome | string | Nome do produto |
| Preco | decimal | Preço do produto |
| Quantidade | int | Quantidade em estoque |
| CategoriaId | int | Chave estrangeira |
| Categoria | Categoria | Objeto da categoria |

---

## 🏗️ Padrão Utilizado

O projeto utiliza o padrão **Repository**, separando as responsabilidades em camadas:

- **Models** — Representam os dados (apenas propriedades)
- **Repositories** — Contêm toda a lógica de acesso ao banco de dados
- **Program.cs** — Interface com o usuário via console

---

## 👩‍💻 Autores

- **Vitoria Silva** — Classes, Repositories e Program.cs
- **Thales Rodrigues** — Banco de Dados (MySQL)
