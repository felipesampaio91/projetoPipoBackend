Esta API foi implementada utilizando o padrão DDD em C#.NET CORE 3.1 em conjunto com o o framework de documentação de API's Swagger. 
O TDD foi iniciado, mas não foi finalizado. A API utiliza o ORM EntityFramework para gerar e mapear as tabelas do banco de dados. 

Considerações: A API realiza um CRUD (POST, PUT, DELETE, GETALL, GETBYID) para todas as entidades. Sendo elas:

Operadora: É a empresa responsável por fonecer o benefício. É possível cadastrar, alterar, listar e apagar todas a operadoras salvas na base de dados. Para esta entidade
os campos Nome e CNPJ foram considerados obrigatórios para inserção e edição.

Cliente: É a empresa que oferece o benefício pertencente à uma operadora. É possível cadastrar, alterar, listar e apagar todas os clientes salvos na base de dados. 
Para esta entidade os campos Nome e CNPJ foram considerados obrigatórios para inserção e edição.

Beneficio: Pertence a uma operadora e é oferecido por um cliente a seus funcionários. É possível cadastrar, alterar, listar e apagar todas os benefícios salvos na base 
de dados. Para esta entidade os campos Nome e IdOperadora (identificador da operadora na base de dados), foram considerados obrigatórios para inserção e edição.

Funcionario: É a entidade a qual se atribui o benefício e pertence a um cliente. É possível cadastrar, alterar, listar e apagar todas os funcionários salvos na base 
de dados. Para esta entidade os campos Nome, CPF e IdCliente (identificador do cliente na base de dados), foram considerados obrigatórios para inserção e edição.

FuncionarioBeneficio: Entidade responsável por criar o vínculo entre funcionário e benefício no banco de dados. É possível cadastrar, alterar, listar e apagar todos os 
registros dessa entidade. Sendo obrigatórios os campos idFuncionario e idBeneficio.

ClienteBeneficio: Entidade responsável por criar o vínculo entre benefício e empresa (cliente) no banco de dados. É possível cadastrar, alterar, listar e apagar todos os 
registros dessa entidade. Sendo obrigatórios os campos idClinete e idBeneficio.

A validação de inclusão de benefícios para funcionários foi implementada na camada Projeto.Presentation da API, na entidade "FuncionarioBeneficioController.cs".

Os campos nome e CPF dos funcionários foram considerados obrigatórios para todos os benefícios oferecidos.

Como parte de uma rastreabilidade em base de dados, foi inserido um parâmetro "DataInclusao" em todas as entidades.
