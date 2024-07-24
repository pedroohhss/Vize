# Teste Técnico Desenvolvedor Junior Vize
Este projeto consiste em uma API de produtos desenvolvida em C# para avaliar o conhecimento técnico de candidatos à posição de desenvolvedor backend júnior. A API permite operações básicas de CRUD e autenticação básica.

### Funcionalidades da API
- Leitura por ID: Permite recuperar um produto específico por seu identificador.
- Leitura de Lista: Recupera uma lista de todos os produtos.
- Inserção: Permite adicionar novos produtos.
- Alteração: Permite atualizar as informações de um produto existente.
- Deleção: Permite remover um produto.
- Dashboard: Traz a quantidade e o preço unitário médio segregado por tipo (Material ou Serviço).

### Requisitos Não Funcionais
- A API segue os padrões RESTful.
- Autenticação básica é usada para proteger os endpoints.
- O banco de dados utilizado é o PostgreSQL.
- Foram aplicados princípios SOLID na arquitetura do código.

### Princípios SOLID Utilizados:
1. Single Responsibility Principle (SRP): Cada classe é responsável por uma única tarefa, o que simplifica a manutenção e a compreensão do código. Por exemplo, a classe ProdutoService é responsável apenas pelas operações relacionadas a produtos.
2. Interface Segregation Principle (ISP ): Interfaces específicas foram criadas para cada classe, garantindo que as implementações só precisem lidar com métodos relevantes, evitando a implementação de métodos desnecessários.

### Melhorias de Performance:
1. Caching: Implementar caching para consultas frequentes pode reduzir a carga no banco de dados e melhorar a resposta da API. Isso pode ser feito utilizando, por exemplo, o MemoryCache ou Distributed Cache do ASP.NET Core.
2. Paginação: Ao implementar paginação nas listas de produtos, reduzimos a carga do servidor e melhoramos o tempo de resposta para conjuntos de dados grandes. A paginação pode ser aplicada nos endpoints que retornam listas de produtos.

### Como Instanciar o Banco de Dados

1. Configurar a String de Conexão 
- Abra o arquivo appsettings.Development.json.
- Localize a seção ConnectionStrings e substitua a string de conexão padrão pela string fornecida pelo seu ambiente de desenvolvimento.
```
"ConnectionStrings": {
    "Default": "Host=<Servidor>;Port=<Porta>;Database=<NomeDoBanco>;Username=<Usuario>;Password=<Senha>"
}

```
2. Detalhes da Conexão:
- Servidor: Defina o nome ou IP do servidor onde o PostgreSQL está rodando.
- Porta: Altere para a porta utilizada pelo PostgreSQL (normalmente 5432).
- Usuário e Senha: Forneça credenciais válidas para acessar o banco de dados.
- Banco de Dados: (Opcional) Modifique o nome do banco de dados conforme necessário.

3. Aplicando Migrações
- Após configurar a string de conexão, basta rodar a aplicação. A aplicação automaticamente aplicará as migrações e criará o banco de dados e tabelas necessários.

### Acesso ao Sistema

A API utiliza autenticação básica com usuário e senha para proteger os endpoints. As credenciais padrão são:

- Usuário: admin
- Senha: 12345

#### Alteração de Credenciais

Se desejar alterar o usuário e senha padrão, siga as etapas abaixo:

1. Localize o Arquivo de Autenticação:
- Abra o arquivo BasicAuthentication.cs no projeto.

2. Modificar Credenciais:
- Altere as strings nas linhas 12 e 13 com os novos valores desejados para username e password.

```
    protected readonly string username = "novoUsuario";
    protected readonly string password = "novaSenha";
```

### Considerações Finais

Este projeto visa demonstrar a implementação de uma API RESTful seguindo boas práticas de programação com C# e ASP.NET Core, usando o PostgreSQL como banco de dados e aplicando princípios de design de software.

Caso tenha alguma dúvida ou sugestão, sinta-se à vontade para entrar em contato.
