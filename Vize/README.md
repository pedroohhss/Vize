### Princ�pios SOLID Utilizados:
1. Single Responsibility Principle (SRP): Cada classe tem uma �nica responsabilidade, tornando o c�digo mais f�cil de entender e manter.
2. Interface Segregation Principle (ISP ): Foram criadas interfaces espec�ficas para cada classe, sendo assim utilizado apenas o necess�rio e evitando que sejam implementadas m�todos desnecess�rios ao utilizar uma interface gen�rica.

### Melhorias de Performance:
1. Caching: Implementar caching para consultas frequentes pode reduzir a carga no banco de dados e melhorar a resposta da API.
2. Pagina��o: Ao implementar pagina��o nas listas de produtos, podemos reduzir a carga do servidor e melhorar o tempo de resposta para conjuntos de dados grandes.

### Como Instanciar o Banco de Dados

1. Pegue a string de conex�o que ser� utilizado e adicione a mesma no arquivo `appsettings.Development.json` em `ConnectionStrings | Default`
 1.1. Altere o nome do `Server` para o servidor escolhido a ser utilizado. Coloque a `Port` do servidor tamb�m.
 1.2. Altere o `user` e o `password` para a aplica��o ter acesso ao servidor.
 1.3. (Opcional) Altere o nome do banco de dados na propriedade `Database`
2. Ap�s isso � s� rodar a aplica��o que a pr�pria aplica��o ira criar o banco de dados no servidor para voc�, junto �s tabelas.

### Acesso ao Sistema

Foi utilizado uma autentica��o simples de usu�rio e senha para conseguir ter acesso a Aplica��o e poder utilizar os endpoints, o usu�rio e senha que est�o configurados de padr�o s�o o seguinte:

Usu�rio: admin
Senha: 12345

Caso queira alterar o usu�rio e senha, siga os passos:

1. V� ao arquivo `BasicAuthentication.cs`
2. Altere a string da linha `12` e `13` com os respectivos nomes `username` e `password`