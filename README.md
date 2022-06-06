Esta API foi implementada utilizando o padrão DDD em C#.NET CORE 3.1 em conjunto com o o framework de documentação de API's Swagger. 
A API utiliza o ORM EntityFramework para gerar e mapear as tabelas do banco de dados. A IDE utilizada para desenvolvimento é o Visual Studio 2019 Community.

Instruções para executar o projeto:
Após o download do projeto, localize o arquivo "ProjetoPipo.sln" na pasta do projeto e abra=o utilizando o Visual Studio conforme a imagem a seguir

![image](https://user-images.githubusercontent.com/54118555/172031028-298e141c-603a-40fe-8940-cdf5ea8b6f8b.png)

Após o projeto ter sido aberto, devemos proceder com a instalação das bibliotecas utilizadas no projeto. Para isso localize o "Projeto.Presentation" no Gerenciador de Soluções do Visual Studio como mostrado a seguir:

![image](https://user-images.githubusercontent.com/54118555/172030992-bb1160e5-b448-4a4b-a499-a4ed1379b4b5.png)

Clique com o botão direito do mouse sobre o meso e selecione a opção "Gerenciar de Pacotes do Nuget".

![image](https://user-images.githubusercontent.com/54118555/172031144-f8f34e3b-4c6a-4eb9-a119-5f422070bf36.png)

Na aba procurar pesquise por "Swashbuckle.AspNetCore" e instale na versão 6.3.0 indicada na imagem abaixo:

![image](https://user-images.githubusercontent.com/54118555/172031388-48014d6d-3bb1-4972-9364-d0be86488297.png)

Após a instalação, feche a aba do NuGet e procure "Projeto.Infra.Data" no Gerenciador de Soluções do Visual Studio.

![image](https://user-images.githubusercontent.com/54118555/172031580-7165c91b-5012-45a5-b00e-1471abef8943.png)

Repita o passo anterior e clicando com o botão direito do mouse sobre "Projeto.Infra.Data" e selecionando "Gerenciar Pacotes do Nuget". Procure e instale os 5 itens a seguir na versão 3.1.8: 

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.Extensions.Configuration.Json

![image](https://user-images.githubusercontent.com/54118555/172031748-f8225596-5f5e-4676-8446-e3c3dd53be66.png)


Após a instalação, feche a aba do NuGet e procure "Projeto.Testes" no Gerenciador de Soluções do Visual Studio.

![image](https://user-images.githubusercontent.com/54118555/172175082-fb572d5a-38a4-4b8c-a54b-2eaf0fc7d182.png)

Repita o passo anterior e clicando com o botão direito do mouse sobre "Projeto.Testes" e selecionando "Gerenciar Pacotes do Nuget".
Procure e instale as seguintes bibliotecas:
- xunit 2.4.0
- FluentAssertions 3.0.107

![image](https://user-images.githubusercontent.com/54118555/172177265-be0048d4-8a72-4c39-824a-98579f9150f7.png)

![image](https://user-images.githubusercontent.com/54118555/172177424-04385dc9-cd1f-4807-ab84-c73af0ae9140.png)

Feche a aba do NuGet e salve todas as alterações.


Instruções para criação da base de dados:

No menu "Exibir" no Visual Studio, selecione a opção "SQL Server Object Explorer". Expanda a base de dados local e clique com o botão direito do mouse sobre a pasta "Databases". Selecione a opção Add New Database.

![image](https://user-images.githubusercontent.com/54118555/172065202-31dc175e-b6cc-40aa-9cd2-d997eaf67648.png)

Dê um nome para a base de dados e finalize a criação clicando em "OK".

![image](https://user-images.githubusercontent.com/54118555/172065300-bde41f05-e678-49ff-9d89-a8e5b284e671.png)

Após a criação da base de dados, clique com o botão direito do mouse sobre a mesma e selecione a opção "Properties".

![image](https://user-images.githubusercontent.com/54118555/172065371-acb9f671-62e8-49a0-9fd4-7136238247ca.png)

Na janela que se abrirá, selecione e copie a propriedade "Connection string", que deve ser semelhante a "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetoPipo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

![image](https://user-images.githubusercontent.com/54118555/172065464-4cd224b5-1145-4388-9058-fe016fe86cd2.png)

Após ter copiado a connection string, localize o arquivo "appsettings.json" dentro de "Projeto.Infra.Data", no Gerenciador de Soluções do Visual Studio. Cole a connection string no local onde estão os 3 pontos dentro das aspas duplas conforme a imagem abaixo:

![image](https://user-images.githubusercontent.com/54118555/172065668-41a71d00-d322-4356-beff-c1ccf168c1a4.png)

![image](https://user-images.githubusercontent.com/54118555/172065757-2e6b81bf-32a5-4f6d-b7c8-5f88172230e6.png)
 
Salve todas as alterações.

Gerando as tabelas no banco de dados através do Entity Framework Core:

No menu exibir, selecione a opção "Console do Gerenciador de Pacotes"

![image](https://user-images.githubusercontent.com/54118555/172170294-f2446d89-6b3f-479c-8f63-4e7378c9c04d.png)

No console que será exibido, altere o projeto padrão conforme a imagem a seguir:

![image](https://user-images.githubusercontent.com/54118555/172171556-53783d62-0931-4f4b-a8c1-ff0a09da55b4.png)

Altere também o projeto de inicialização, selecionando a caixa de diálogo como na imagem a seguir:

![image](https://user-images.githubusercontent.com/54118555/172172055-c9d92726-adf8-4995-8694-00ea38aded81.png)

Ou clicando com o botão direito do mouse sobre "Projeto.Infra.Data" no Gerenciador de Soluções do Visual Studio e selecionando a opção "Definir como projeto de inicialização".

![image](https://user-images.githubusercontent.com/54118555/172172545-49f04f86-5aed-4c3e-b242-4eedef37e0f4.png)

Após isso execute os seguintes comandos:
- Add-Migration Initial
- Update-Database Initial

"Initial" é o nome dado ao migration e pode ser qualquer diferente do exposto acima.

Após a execução dos comandos será possível visualizar as tabelas criadas na base de dados através do "SQL Server Object Explorer" conforme a seguir:

![image](https://user-images.githubusercontent.com/54118555/172173712-6071dbad-4cdf-4602-a5f9-10a8681d9a3c.png)

Altere o projeto de inicialização para "Projeto.Presentation"  seguindo as instruções anteriores.

![image](https://user-images.githubusercontent.com/54118555/172178259-1db2f265-ff4e-4e62-a614-637a491bf612.png)

Execute o projeto clicando no botão "IIS Express".

![image](https://user-images.githubusercontent.com/54118555/172178682-accfbd71-979f-4a67-b295-36f0fb82ec93.png)

Uma nova janela do seu navegador padrão será aberta com a seguinte exibição:

![image](https://user-images.githubusercontent.com/54118555/172179433-94822c21-258b-4311-9778-af45bf56e11a.png)

Nessa janela é possível visualizar e testar as operações de CRUD para todas as entidades que compõem o projeto. Sendo elas:

Operadora: É a empresa responsável por fonecer o benefício. É possível cadastrar, alterar, listar e apagar todas a operadoras salvas na base de dados. Para esta entidade
os campos Nome e CNPJ foram considerados obrigatórios para inserção e edição.

Cliente: É a empresa que oferece o benefício pertencente à uma operadora. É possível cadastrar, alterar, listar e apagar todas os clientes salvos na base de dados. 
Para esta entidade os campos Nome e CNPJ foram considerados obrigatórios para inserção e edição.

Beneficio: Pertence a uma operadora e é oferecido por um cliente a seus funcionários. É possível cadastrar, alterar, listar e apagar todas os benefícios salvos na base 
de dados. Para esta entidade os campos Nome e IdOperadora (identificador da operadora na base de dados), foram considerados obrigatórios para inserção e edição.

Funcionario: É a entidade a qual se atribui o benefício e pertence a um cliente. É possível cadastrar, alterar, listar e apagar todas os funcionários salvos na base 
de dados. Para esta entidade os campos Nome, CPF e IdCliente (identificador do cliente na base de dados), foram considerados obrigatórios para inserção e edição.

ClienteBeneficio: Entidade responsável por criar o vínculo entre benefício e empresa (cliente) no banco de dados. É possível cadastrar, alterar, listar e apagar todos os registros dessa entidade. Sendo obrigatórios os campos idClinete e idBeneficio.


Considerações: A API realiza um CRUD (POST, PUT, DELETE, GETALL, GETBYID) para todas as entidades. Sendo elas:



A validação de inclusão de benefícios para funcionários foi implementada na camada Projeto.Presentation da API, na entidade "FuncionarioBeneficioController.cs".

Os campos nome e CPF dos funcionários foram considerados obrigatórios para todos os benefícios oferecidos.

Como parte de uma rastreabilidade em base de dados, foi inserido um parâmetro "DataInclusao" em todas as entidades.
