using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Projeto.Application.Models;
using Projeto.Domain.Entities;
using Projeto.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Projeto.Testes
{
    public class FuncionarioTest
    {
        private readonly HttpClient httpClient;

        public FuncionarioTest()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var testServer = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Startup>());

            httpClient = testServer.CreateClient();
        }

        [Fact]
        public async Task CadastrarFuncionario()
        {
            //cadastrando cliente
            var modelCliente = new ClienteCadastroModel();
            modelCliente.Nome = "Cliente Teste Funcionário";
            modelCliente.Cnpj = "93467207000151";
            modelCliente.DataInclusao = DateTime.UtcNow;

            var requestCliente = new StringContent(JsonConvert.SerializeObject(modelCliente),
                Encoding.UTF8, "application/json");

            var resultCliente = await httpClient.PostAsync("api/Cliente", requestCliente);

            var contentCliente = string.Empty;
            using (var httpContent = resultCliente.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCliente += r.Result;
            }

            var responseCliente = JsonConvert.DeserializeObject<ResponseCliente>(contentCliente);

            //cadastrando funcionario
            var modelFuncionario = new FuncionarioCadastroModel();
            modelFuncionario.Nome = "Funcionario Teste";
            modelFuncionario.Cpf = "23020433088";
            modelFuncionario.DataAdmissao = DateTime.Parse("22/02/1992");
            modelFuncionario.Endereco = "Endereço teste";
            modelFuncionario.Email = "teste@email.com";
            modelFuncionario.Peso = 90.5M;
            modelFuncionario.Altura = 1.95M;
            modelFuncionario.HorasMeditadas = 5;
            modelFuncionario.IdCliente = responseCliente.cliente.IdCliente;
            modelFuncionario.DataInclusao = DateTime.UtcNow;

            var requestFuncionarioCadastro = new StringContent(JsonConvert.SerializeObject(modelFuncionario),
                Encoding.UTF8, "application/json");

            var resultFuncionarioCadastro = await httpClient.PostAsync("api/Funcionario", requestFuncionarioCadastro);

            var contentFuncionarioCadastro = string.Empty;
            using (var httpContent = resultFuncionarioCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentFuncionarioCadastro += r.Result;
            }

            var responseFuncionarioCadastro = JsonConvert.DeserializeObject<ResponseFuncionario>(contentFuncionarioCadastro);

            resultFuncionarioCadastro.StatusCode.Should().Be(HttpStatusCode.OK);
            responseFuncionarioCadastro.mensagem.Should().Contain("Funcionário cadastrado com sucesso.");
        }

        [Fact]
        public async Task AtualizarFuncionario()
        {
            //cadastrando cliente
            var modelCliente = new ClienteCadastroModel();
            modelCliente.Nome = "Cliente Teste Funcionário";
            modelCliente.Cnpj = "93467207000151";
            modelCliente.DataInclusao = DateTime.UtcNow;

            var requestCliente = new StringContent(JsonConvert.SerializeObject(modelCliente),
                Encoding.UTF8, "application/json");

            var resultCliente = await httpClient.PostAsync("api/Cliente", requestCliente);

            var contentCliente = string.Empty;
            using (var httpContent = resultCliente.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCliente += r.Result;
            }

            var responseCliente = JsonConvert.DeserializeObject<ResponseCliente>(contentCliente);

            //cadastrando funcionario
            var modelFuncionario = new FuncionarioCadastroModel();
            modelFuncionario.Nome = "Funcionario Teste";
            modelFuncionario.Cpf = "55115299070";
            modelFuncionario.DataAdmissao = DateTime.Parse("20/01/1992");
            modelFuncionario.Endereco = "Endereço teste";
            modelFuncionario.Email = "teste@email.com";
            modelFuncionario.Peso = 85.5M;
            modelFuncionario.Altura = 1.80M;
            modelFuncionario.HorasMeditadas = 5;
            modelFuncionario.IdCliente = responseCliente.cliente.IdCliente;
            modelFuncionario.DataInclusao = DateTime.UtcNow;

            var requestFuncionarioCadastro = new StringContent(JsonConvert.SerializeObject(modelFuncionario),
                Encoding.UTF8, "application/json");

            var resultFuncionarioCadastro = await httpClient.PostAsync("api/Funcionario", requestFuncionarioCadastro);

            var contentFuncionarioCadastro = string.Empty;
            using (var httpContent = resultFuncionarioCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentFuncionarioCadastro += r.Result;
            }

            var responseFuncionarioCadastro = JsonConvert.DeserializeObject<ResponseFuncionario>(contentFuncionarioCadastro);

            //atualizando funcionario
            var modelFuncionarioEdicao = new FuncionarioEdicaoModel();
            modelFuncionarioEdicao.IdFuncionario = responseFuncionarioCadastro.funcionario.IdFuncionario;
            modelFuncionarioEdicao.Nome = "Funcionario Teste Edição";
            modelFuncionarioEdicao.Cpf = "47843604090";
            modelFuncionarioEdicao.DataAdmissao = DateTime.Parse("20/01/1992");
            modelFuncionarioEdicao.Endereco = "Endereço teste";
            modelFuncionarioEdicao.Email = "teste@email.com";
            modelFuncionarioEdicao.Peso = 90.5M;
            modelFuncionarioEdicao.Altura = 1.85M;
            modelFuncionarioEdicao.HorasMeditadas = 5;
            modelFuncionarioEdicao.IdCliente = responseCliente.cliente.IdCliente;

            var requestFuncionarioEdicao = new StringContent(JsonConvert.SerializeObject(modelFuncionarioEdicao),
                Encoding.UTF8, "application/json");

            var resultFuncionarioEdicao = await httpClient.PutAsync("api/Funcionario", requestFuncionarioEdicao);

            var contentFuncionarioEdicao = string.Empty;
            using (var httpContent = resultFuncionarioEdicao.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentFuncionarioEdicao += r.Result;
            }

            var responseFuncionarioEdicao = JsonConvert.DeserializeObject<ResponseFuncionario>(contentFuncionarioEdicao);

            resultFuncionarioEdicao.StatusCode.Should().Be(HttpStatusCode.OK);
            responseFuncionarioEdicao.mensagem.Should().Contain("Funcionário atualizado com sucesso.");
        }

        [Fact]
        public async Task ExcluirFuncionario()
        {
            //cadastrando cliente
            var modelCliente = new ClienteCadastroModel();
            modelCliente.Nome = "Cliente Teste Funcionário";
            modelCliente.Cnpj = "37370074000120";
            modelCliente.DataInclusao = DateTime.UtcNow;

            var requestCliente = new StringContent(JsonConvert.SerializeObject(modelCliente),
                Encoding.UTF8, "application/json");

            var resultCliente = await httpClient.PostAsync("api/Cliente", requestCliente);

            var contentCliente = string.Empty;
            using (var httpContent = resultCliente.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCliente += r.Result;
            }

            var responseCliente = JsonConvert.DeserializeObject<ResponseCliente>(contentCliente);

            //cadastrando funcionario
            var modelFuncionario = new FuncionarioCadastroModel();
            modelFuncionario.Nome = "Funcionario Teste";
            modelFuncionario.Cpf = "43800585065";
            modelFuncionario.DataAdmissao = DateTime.Parse("20/01/1992");
            modelFuncionario.Endereco = "Endereço teste";
            modelFuncionario.Email = "teste@email.com";
            modelFuncionario.Peso = 85.5M;
            modelFuncionario.Altura = 1.80M;
            modelFuncionario.HorasMeditadas = 5;
            modelFuncionario.IdCliente = responseCliente.cliente.IdCliente;
            modelFuncionario.DataInclusao = DateTime.UtcNow;

            var requestFuncionarioCadastro = new StringContent(JsonConvert.SerializeObject(modelFuncionario),
                Encoding.UTF8, "application/json");

            var resultFuncionarioCadastro = await httpClient.PostAsync("api/Funcionario", requestFuncionarioCadastro);

            var contentFuncionarioCadastro = string.Empty;
            using (var httpContent = resultFuncionarioCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentFuncionarioCadastro += r.Result;
            }

            var responseFuncionarioCadastro = JsonConvert.DeserializeObject<ResponseFuncionario>(contentFuncionarioCadastro);

            //Excluindo funcionario
            var resultExclusao = await httpClient.DeleteAsync("api/Funcionario/" + responseFuncionarioCadastro.funcionario.IdFuncionario);

            var contentExclusao = string.Empty;
            using (var httpContent = resultExclusao.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentExclusao += r.Result;
            }

            var responseExclusao = JsonConvert.DeserializeObject<ResponseFuncionario>(contentExclusao);

            resultExclusao.StatusCode.Should().Be(HttpStatusCode.OK);
            responseExclusao.mensagem.Should().Contain("Funcionário excluído com sucesso.");
        }

        [Fact]
        public async Task ConsultarFuncionario()
        {
            //cadastrando cliente
            var modelCliente = new ClienteCadastroModel();
            modelCliente.Nome = "Cliente Teste Funcionário";
            modelCliente.Cnpj = "51443122000193";
            modelCliente.DataInclusao = DateTime.UtcNow;

            var requestCliente = new StringContent(JsonConvert.SerializeObject(modelCliente),
                Encoding.UTF8, "application/json");

            var resultCliente = await httpClient.PostAsync("api/Cliente", requestCliente);

            var contentCliente = string.Empty;
            using (var httpContent = resultCliente.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCliente += r.Result;
            }

            var responseCliente = JsonConvert.DeserializeObject<ResponseCliente>(contentCliente);

            //cadastrando funcionario
            var modelFuncionario = new FuncionarioCadastroModel();
            modelFuncionario.Nome = "Funcionario Teste";
            modelFuncionario.Cpf = "65085485068";
            modelFuncionario.DataAdmissao = DateTime.Parse("20/01/1992");
            modelFuncionario.Endereco = "Endereço teste";
            modelFuncionario.Email = "teste@email.com";
            modelFuncionario.Peso = 85.5M;
            modelFuncionario.Altura = 1.80M;
            modelFuncionario.HorasMeditadas = 5;
            modelFuncionario.IdCliente = responseCliente.cliente.IdCliente;
            modelFuncionario.DataInclusao = DateTime.UtcNow;

            var requestFuncionarioCadastro = new StringContent(JsonConvert.SerializeObject(modelFuncionario),
                Encoding.UTF8, "application/json");

            var resultFuncionarioCadastro = await httpClient.PostAsync("api/Funcionario", requestFuncionarioCadastro);

            var contentFuncionarioCadastro = string.Empty;
            using (var httpContent = resultFuncionarioCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentFuncionarioCadastro += r.Result;
            }

            var responseFuncionarioCadastro = JsonConvert.DeserializeObject<ResponseFuncionario>(contentFuncionarioCadastro);

            //Consultando o funcionario cadastrado
            var resultConsulta = await httpClient.GetAsync("api/Funcionario");

            var contentConsulta = string.Empty;
            using (var httpContent = resultConsulta.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentConsulta += r.Result;
            }

            var responseConsulta = JsonConvert.DeserializeObject<List<FuncionarioConsultaModel>>(contentConsulta);

            resultConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
            responseConsulta.Count().Should().BeGreaterThan(0);
            responseConsulta.FirstOrDefault(p => p.IdFuncionario == responseFuncionarioCadastro.funcionario.IdFuncionario)
                .Should()
                .NotBeNull();
        }

        [Fact]
        public async Task ConsultarFuncionarioPorId()
        {
            //cadastrando cliente
            var modelCliente = new ClienteCadastroModel();
            modelCliente.Nome = "Cliente Teste Funcionário";
            modelCliente.Cnpj = "86920681000121";
            modelCliente.DataInclusao = DateTime.UtcNow;

            var requestCliente = new StringContent(JsonConvert.SerializeObject(modelCliente),
                Encoding.UTF8, "application/json");

            var resultCliente = await httpClient.PostAsync("api/Cliente", requestCliente);

            var contentCliente = string.Empty;
            using (var httpContent = resultCliente.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCliente += r.Result;
            }

            var responseCliente = JsonConvert.DeserializeObject<ResponseCliente>(contentCliente);

            //cadastrando funcionario
            var modelFuncionario = new FuncionarioCadastroModel();
            modelFuncionario.Nome = "Funcionario Teste";
            modelFuncionario.Cpf = "69262615043";
            modelFuncionario.DataAdmissao = DateTime.Parse("20/01/1992");
            modelFuncionario.Endereco = "Endereço teste";
            modelFuncionario.Email = "teste@email.com";
            modelFuncionario.Peso = 85.5M;
            modelFuncionario.Altura = 1.80M;
            modelFuncionario.HorasMeditadas = 5;
            modelFuncionario.IdCliente = responseCliente.cliente.IdCliente;
            modelFuncionario.DataInclusao = DateTime.UtcNow;

            var requestFuncionarioCadastro = new StringContent(JsonConvert.SerializeObject(modelFuncionario),
                Encoding.UTF8, "application/json");

            var resultFuncionarioCadastro = await httpClient.PostAsync("api/Funcionario", requestFuncionarioCadastro);

            var contentFuncionarioCadastro = string.Empty;
            using (var httpContent = resultFuncionarioCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentFuncionarioCadastro += r.Result;
            }

            var responseFuncionarioCadastro = JsonConvert.DeserializeObject<ResponseFuncionario>(contentFuncionarioCadastro);

            //Consultando o funcionario cadastrado
            var resultConsulta = await httpClient.GetAsync("api/Funcionario/" + responseFuncionarioCadastro.funcionario.IdFuncionario);

            var contentConsulta = string.Empty;
            using (var httpContent = resultConsulta.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentConsulta += r.Result;
            }

            var responseConsulta = JsonConvert.DeserializeObject<FuncionarioConsultaModel>(contentConsulta);

            resultConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
            responseConsulta.Should().NotBeNull();
            responseConsulta.IdFuncionario.Should().Be(responseFuncionarioCadastro.funcionario.IdFuncionario);
            responseConsulta.Nome.Should().Be(responseFuncionarioCadastro.funcionario.Nome);
            responseConsulta.Cpf.Should().Be(responseFuncionarioCadastro.funcionario.Cpf);
            responseConsulta.DataAdmissao.Should().Be(responseFuncionarioCadastro.funcionario.DataAdmissao);
            responseConsulta.Endereco.Should().Be(responseFuncionarioCadastro.funcionario.Endereco);
            responseConsulta.Email.Should().Be(responseFuncionarioCadastro.funcionario.Email);
            responseConsulta.Peso.Should().Be(responseFuncionarioCadastro.funcionario.Peso);
            responseConsulta.Altura.Should().Be(responseFuncionarioCadastro.funcionario.Altura);
            responseConsulta.HorasMeditadas.Should().Be(responseFuncionarioCadastro.funcionario.HorasMeditadas);
            responseConsulta.DataInclusao.Should().Be(responseFuncionarioCadastro.funcionario.DataInclusao);
        }
        public class ResponseFuncionario
        {
            public string mensagem { get; set; }
            public Funcionario funcionario { get; set; }
        }
    }
}
