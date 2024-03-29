# Gerenciamento de Fornecedores e Produtos

Este é um projeto de exemplo que demonstra como criar uma API para gerenciar fornecedores e produtos usando ASP.NET Core.

## Funcionalidades

### Fornecedores

- **Criar Fornecedor**: Endpoint para criar um novo fornecedor.
- **Atualizar Fornecedor**: Endpoint para atualizar os detalhes de um fornecedor existente.
- **Listar Fornecedores**: Endpoint para listar todos os fornecedores cadastrados.
- **Buscar Fornecedor por ID**: Endpoint para obter os detalhes de um fornecedor específico com base no ID.
- **Excluir Fornecedor**: Endpoint para excluir um fornecedor existente.

### Produtos

- **Criar Produto**: Endpoint para cadastrar um novo produto oferecido por um fornecedor.
- **Atualizar Produto**: Endpoint para atualizar os detalhes de um produto existente.
- **Listar Produtos**: Endpoint para listar todos os produtos cadastrados.
- **Buscar Produto por ID**: Endpoint para obter os detalhes de um produto específico com base no ID.
- **Excluir Produto**: Endpoint para excluir um produto existente.

## Acessando o Swagger

O Swagger é uma ferramenta de documentação interativa para APIs RESTful. Este projeto está configurado para fornecer uma interface Swagger para explorar e testar as diferentes rotas da API.

Para acessar o Swagger, siga estas etapas:

1. Certifique-se de que o projeto está em execução localmente.
2. Abra um navegador da web e navegue para o seguinte URL: `http://localhost:54352/swagger` 
3. Isso abrirá a interface Swagger, onde você pode ver a lista de endpoints da API, seus parâmetros e modelos de dados esperados.

## Aplicando Migrações ao Banco de Dados do Usuário

Antes de executar o projeto, você precisa garantir que as migrações estejam aplicadas ao banco de dados que você vai utilizar. Siga os passos abaixo para aplicar as migrações:

Abra um terminal na raiz do projeto.

Execute o seguinte comando para aplicar as migrações ao banco de dados:

`dotnet ef database update`

Este comando aplicará todas as migrações pendentes ao banco de dados configurado na string de conexão do projeto.

Observação:
Certifique-se de que a string de conexão do banco de dados esteja configurada corretamente no arquivo appsettings.json ou appsettings.Development.json, dependendo do ambiente.

## Executando o Projeto

Para executar o projeto localmente, siga estas etapas:

1. Certifique-se de ter o SDK .NET Core instalado em sua máquina.
2. Clone o repositório para sua máquina local.
3. Navegue até o diretório do projeto no terminal.
4. Execute o comando `dotnet run` para iniciar o projeto.
5. O projeto será executado localmente e estará disponível em `https://localhost:54352` 

Isso é tudo! Agora você pode começar a explorar e interagir com a API.

