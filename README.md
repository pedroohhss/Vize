# Teste Técnico Desenvolvedor Junior Vize

### Princípios SOLID Utilizados:
1. Single Responsibility Principle (SRP): Cada classe tem uma única responsabilidade, tornando o código mais fácil de entender e manter.
2. Interface Segregation Principle (ISP ): Foram criadas interfaces específicas para cada classe, sendo assim utilizado apenas o necessário e evitando que sejam implementadas métodos desnecessários ao utilizar uma interface genérica.

### Melhorias de Performance:
1. Caching: Implementar caching para consultas frequentes pode reduzir a carga no banco de dados e melhorar a resposta da API.
2. Paginação: Ao implementar paginação nas listas de produtos, podemos reduzir a carga do servidor e melhorar o tempo de resposta para conjuntos de dados grandes.

### Como Instanciar o Banco de Dados

1. Pegue a string de conexão que será utilizado e adicione a mesma no arquivo `appsettings.Development.json` em `ConnectionStrings | Default`
 1.1. Altere o nome do `Server` para o servidor escolhido a ser utilizado. Coloque a `Port` do servidor também.
 1.2. Altere o `user` e o `password` para a aplicação ter acesso ao servidor.
 1.3. (Opcional) Altere o nome do banco de dados na propriedade `Database`
2. Após isso é só rodar a aplicação que a própria aplicação ira criar o banco de dados no servidor para você, junto às tabelas.

### Acesso ao Sistema

Foi utilizado uma autenticação simples de usuário e senha para conseguir ter acesso a Aplicação e poder utilizar os endpoints, o usuário e senha que estão configurados de padrão são o seguinte:

Usuário: admin
Senha: 12345

Caso queira alterar o usuário e senha, siga os passos:

1. Vá ao arquivo `BasicAuthentication.cs`
2. Altere a string da linha `12` e `13` com os respectivos nomes `username` e `password`
