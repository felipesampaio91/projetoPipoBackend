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



Considerações: A API realiza um CRUD (POST, PUT, DELETE, GETALL, GETBYID) para todas as entidades. Sendo elas:

Operadora: É a empresa responsável por fonecer o benefício. É possível cadastrar, alterar, listar e apagar todas a operadoras salvas na base de dados. Para esta entidade
os campos Nome e CNPJ foram considerados obrigatórios para inserção e edição.

Cliente: É a empresa que oferece o benefício pertencente à uma operadora. É possível cadastrar, alterar, listar e apagar todas os clientes salvos na base de dados. 
Para esta entidade os campos Nome e CNPJ foram considerados obrigatórios para inserção e edição.

Beneficio: Pertence a uma operadora e é oferecido por um cliente a seus funcionários. É possível cadastrar, alterar, listar e apagar todas os benefícios salvos na base 
de dados. Para esta entidade os campos Nome e IdOperadora (identificador da operadora na base de dados), foram considerados obrigatórios para inserção e edição.

Funcionario: É a entidade a qual se atribui o benefício e pertence a um cliente. É possível cadastrar, alterar, listar e apagar todas os funcionários salvos na base 
de dados. Para esta entidade os campos Nome, CPF e IdCliente (identificador do cliente na base de dados), foram considerados obrigatórios para inserção e edição.

ClienteBeneficio: Entidade responsável por criar o vínculo entre benefício e empresa (cliente) no banco de dados. É possível cadastrar, alterar, listar e apagar todos os 
registros dessa entidade. Sendo obrigatórios os campos idClinete e idBeneficio.

A validação de inclusão de benefícios para funcionários foi implementada na camada Projeto.Presentation da API, na entidade "FuncionarioBeneficioController.cs".

Os campos nome e CPF dos funcionários foram considerados obrigatórios para todos os benefícios oferecidos.

Como parte de uma rastreabilidade em base de dados, foi inserido um parâmetro "DataInclusao" em todas as entidades.
