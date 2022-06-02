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
    public class ClienteTest
    {
        private readonly HttpClient httpClient;

        public ClienteTest()
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
        public async Task CadastrarCliente()
        {
            var model = new ClienteCadastroModel();
            model.Nome = "Cliente Teste2";
            model.Cnpj = "55197450000108";
            model.DataInclusao = DateTime.UtcNow;

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var result = await httpClient.PostAsync("api/Cliente", request);

            var content = string.Empty;
            using (var httpContent = result.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                content += r.Result;
            }

            var response = JsonConvert.DeserializeObject<ResponseCliente>(content);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            response.mensagem.Should().Contain("Cliente cadastrado com sucesso.");
        }

        [Fact]
        public async Task AtualizarCliente()
        {
            //Criando objeto que será atualizado
            var modelCadastro = new ClienteCadastroModel();
            modelCadastro.Nome = "Cliente Edição2";
            modelCadastro.Cnpj = "18067149000153";
            modelCadastro.DataInclusao = DateTime.UtcNow;

            var requestCadastro = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            var resultCadastro = await httpClient.PostAsync("api/Cliente", requestCadastro);

            var contentCadastro = string.Empty;
            using (var httpContent = resultCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCadastro += r.Result;
            }

            var responseCadastro = JsonConvert.DeserializeObject<ResponseCliente>(contentCadastro);

            //Atualizando o objeto cadastrado
            var modelEdicao = new ClienteEdicaoModel();
            modelEdicao.IdCliente = responseCadastro.cliente.IdCliente;
            modelEdicao.Nome = "Cliente Edição Atualizada";
            modelEdicao.Cnpj = "18067149000153";

            var requestEdicao = new StringContent(JsonConvert.SerializeObject(modelEdicao),
                Encoding.UTF8, "application/json");

            var resultEdicao = await httpClient.PutAsync("api/Cliente", requestEdicao);

            var contentEdicao = string.Empty;
            using (var httpContent = resultEdicao.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentEdicao += r.Result;
            }

            var responseEdicao = JsonConvert.DeserializeObject<ResponseCliente>(contentEdicao);

            resultEdicao.StatusCode.Should().Be(HttpStatusCode.OK);
            responseEdicao.mensagem.Should().Contain("Cliente atualizado com sucesso.");
        }

        [Fact]
        public async Task ExcluirCliente()
        {
            //Criando objeto que será excluído
            var modelCadastro = new ClienteCadastroModel();
            modelCadastro.Nome = "Cliente Teste3";
            modelCadastro.Cnpj = "10633982000102";
            modelCadastro.DataInclusao = DateTime.UtcNow;

            var requestCadastro = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            var resultCadastro = await httpClient.PostAsync("api/Cliente", requestCadastro);

            var contentCadastro = string.Empty;
            using (var httpContent = resultCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCadastro += r.Result;
            }

            var responseCadastro = JsonConvert.DeserializeObject<ResponseCliente>(contentCadastro);

            //Excluindo o objeto cadastrado
            var resultExclusao = await httpClient.DeleteAsync("api/Cliente/" + responseCadastro.cliente.IdCliente);

            var contentExclusao = string.Empty;
            using (var httpContent = resultExclusao.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentExclusao += r.Result;
            }

            var responseExclusao = JsonConvert.DeserializeObject<ResponseCliente>(contentExclusao);

            resultExclusao.StatusCode.Should().Be(HttpStatusCode.OK);
            responseExclusao.mensagem.Should().Contain("Cliente excluído com sucesso.");
        }

        [Fact]
        public async Task ConsultarCliente()
        {
            //Criando objeto que será consultado
            var modelCadastro = new ClienteCadastroModel();
            modelCadastro.Nome = "Cliente Teste4";
            modelCadastro.Cnpj = "48059039000100";
            modelCadastro.DataInclusao = DateTime.UtcNow;

            var requestCadastro = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            var resultCadastro = await httpClient.PostAsync("api/Cliente", requestCadastro);

            var contentCadastro = string.Empty;
            using (var httpContent = resultCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCadastro += r.Result;
            }

            var responseCadastro = JsonConvert.DeserializeObject<ResponseCliente>(contentCadastro);

            //Consultando o objeto cadastrado
            var resultConsulta = await httpClient.GetAsync("api/Cliente");

            var contentConsulta = string.Empty;
            using (var httpContent = resultConsulta.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentConsulta += r.Result;
            }

            var responseConsulta = JsonConvert.DeserializeObject<List<ClienteConsultaModel>>(contentConsulta);

            resultConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
            responseConsulta.Count().Should().BeGreaterThan(0);
            responseConsulta.FirstOrDefault(p => p.IdCliente == responseCadastro.cliente.IdCliente)
                .Should()
                .NotBeNull();
        }

        [Fact]
        public async Task ConsultarClientePorId()
        {
            //Criando objeto que será consultado
            var modelCadastro = new ClienteCadastroModel();
            modelCadastro.Nome = "Operadora Teste5";
            modelCadastro.Cnpj = "27529697000149";
            modelCadastro.DataInclusao = DateTime.UtcNow;

            var requestCadastro = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            var resultCadastro = await httpClient.PostAsync("api/Cliente", requestCadastro);

            var contentCadastro = string.Empty;
            using (var httpContent = resultCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCadastro += r.Result;
            }

            var responseCadastro = JsonConvert.DeserializeObject<ResponseCliente>(contentCadastro);

            //Consultando o objeto cadastrado
            var resultConsulta = await httpClient.GetAsync("api/Cliente/" + responseCadastro.cliente.IdCliente);

            var contentConsulta = string.Empty;
            using (var httpContent = resultConsulta.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentConsulta += r.Result;
            }

            var responseConsulta = JsonConvert.DeserializeObject<ClienteConsultaModel>(contentConsulta);

            resultConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
            responseConsulta.Should().NotBeNull();
            responseConsulta.IdCliente.Should().Be(responseCadastro.cliente.IdCliente);
            responseConsulta.Nome.Should().Be(responseCadastro.cliente.Nome);
            responseConsulta.Cnpj.Should().Be(responseCadastro.cliente.Cnpj);
            responseConsulta.DataInclusao.Should().Be(responseCadastro.cliente.DataInclusao);
        }
    }

    public class ResponseCliente
    {
        public string mensagem { get; set; }
        public Cliente cliente { get; set; }
    }

}
