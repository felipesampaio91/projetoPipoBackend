using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Projeto.Presentation;
using Projeto.Application.Models;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.Net;
using Projeto.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Testes
{
    public class OperadoraTest
    {
        private readonly HttpClient httpClient;

        public OperadoraTest()
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
        public async Task CadastrarOperadora()
        {
            var model = new OperadoraCadastroModel();
            model.Nome = "Operadora Teste12";
            model.Cnpj = "94631763000184";
            model.DataInclusao = DateTime.UtcNow;

            var request = new StringContent(JsonConvert.SerializeObject(model), 
                Encoding.UTF8, "application/json");

            var result = await httpClient.PostAsync("api/Operadora", request);

            var content = string.Empty;
            using (var httpContent = result.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                content += r.Result;
            }

            var response = JsonConvert.DeserializeObject<ResponseOperadora>(content);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            response.mensagem.Should().Contain("Operadora cadastrada com sucesso.");
        }

        [Fact]
        public async Task AtualizarOperadora()
        {
            //Criando objeto que ser� atualizado
            var modelCadastro = new OperadoraCadastroModel();
            modelCadastro.Nome = "Operadora Edi��o";
            modelCadastro.Cnpj = "50891368000165";
            modelCadastro.DataInclusao = DateTime.UtcNow;

            var requestCadastro = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            var resultCadastro = await httpClient.PostAsync("api/Operadora", requestCadastro);

            var contentCadastro = string.Empty;
            using (var httpContent = resultCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCadastro += r.Result;
            }

            var responseCadastro = JsonConvert.DeserializeObject<ResponseOperadora>(contentCadastro);

            //Atualizando o objeto cadastrado
            var modelEdicao = new OperadoraEdicaoModel();
            modelEdicao.IdOperadora = responseCadastro.operadora.IdOperadora;
            modelEdicao.Nome = "Operadora Edi��o Atualizada";
            modelEdicao.Cnpj = "04599113000106";

            var requestEdicao = new StringContent(JsonConvert.SerializeObject(modelEdicao),
                Encoding.UTF8, "application/json");

            var resultEdicao = await httpClient.PutAsync("api/Operadora", requestEdicao);

            var contentEdicao = string.Empty;
            using (var httpContent = resultEdicao.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentEdicao += r.Result;
            }

            var responseEdicao = JsonConvert.DeserializeObject<ResponseOperadora>(contentEdicao);
            
            resultEdicao.StatusCode.Should().Be(HttpStatusCode.OK);
            responseEdicao.mensagem.Should().Contain("Operadora atualizada com sucesso.");
        }

        [Fact]
        public async Task ExcluirOperadora()
        {
            //Criando objeto que ser� exclu�do
            var modelCadastro = new OperadoraCadastroModel();
            modelCadastro.Nome = "Operadora Teste12";
            modelCadastro.Cnpj = "10633982000102";
            modelCadastro.DataInclusao = DateTime.UtcNow;

            var requestCadastro = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            var resultCadastro = await httpClient.PostAsync("api/Operadora", requestCadastro);

            var contentCadastro = string.Empty;
            using (var httpContent = resultCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCadastro += r.Result;
            }

            var responseCadastro = JsonConvert.DeserializeObject<ResponseOperadora>(contentCadastro);

            //Excluindo o objeto cadastrado
            var resultExclusao = await httpClient.DeleteAsync("api/Operadora/" + responseCadastro.operadora.IdOperadora);

            var contentExclusao = string.Empty;
            using (var httpContent = resultExclusao.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentExclusao += r.Result;
            }

            var responseExclusao = JsonConvert.DeserializeObject<ResponseOperadora>(contentExclusao);

            resultExclusao.StatusCode.Should().Be(HttpStatusCode.OK);
            responseExclusao.mensagem.Should().Contain("Operadora exclu�da com sucesso.");
        }

        [Fact]
        public async Task ConsultarOperadora()
        {
            //Criando objeto que ser� consultado
            var modelCadastro = new OperadoraCadastroModel();
            modelCadastro.Nome = "Operadora Teste12";
            modelCadastro.Cnpj = "09274753000160";
            modelCadastro.DataInclusao = DateTime.UtcNow;

            var requestCadastro = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            var resultCadastro = await httpClient.PostAsync("api/Operadora", requestCadastro);

            var contentCadastro = string.Empty;
            using (var httpContent = resultCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCadastro += r.Result;
            }

            var responseCadastro = JsonConvert.DeserializeObject<ResponseOperadora>(contentCadastro);

            //Consultando o objeto cadastrado
            var resultConsulta = await httpClient.GetAsync("api/Operadora");

            var contentConsulta = string.Empty;
            using (var httpContent = resultConsulta.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentConsulta += r.Result;
            }

            var responseConsulta = JsonConvert.DeserializeObject<List<OperadoraConsultaModel>>(contentConsulta);

            resultConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
            responseConsulta.Count().Should().BeGreaterThan(0);
            responseConsulta.FirstOrDefault(p => p.IdOperadora == responseCadastro.operadora.IdOperadora)
                .Should()
                .NotBeNull();
        }

        [Fact]
        public async Task ConsultarOperadoraPorId()
        {
            //Criando objeto que ser� consultado
            var modelCadastro = new OperadoraCadastroModel();
            modelCadastro.Nome = "Operadora Teste12";
            modelCadastro.Cnpj = "31782231000128";
            modelCadastro.DataInclusao = DateTime.UtcNow;

            var requestCadastro = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            var resultCadastro = await httpClient.PostAsync("api/Operadora", requestCadastro);

            var contentCadastro = string.Empty;
            using (var httpContent = resultCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentCadastro += r.Result;
            }

            var responseCadastro = JsonConvert.DeserializeObject<ResponseOperadora>(contentCadastro);

            //Consultando o objeto cadastrado
            var resultConsulta = await httpClient.GetAsync("api/Operadora/" + responseCadastro.operadora.IdOperadora);

            var contentConsulta = string.Empty;
            using (var httpContent = resultConsulta.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentConsulta += r.Result;
            }

            var responseConsulta = JsonConvert.DeserializeObject<OperadoraConsultaModel>(contentConsulta);

            resultConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
            responseConsulta.Should().NotBeNull();
            responseConsulta.IdOperadora.Should().Be(responseCadastro.operadora.IdOperadora);
            responseConsulta.Nome.Should().Be(responseCadastro.operadora.Nome);
            responseConsulta.Cnpj.Should().Be(responseCadastro.operadora.Cnpj);
            responseConsulta.DataInclusao.Should().Be(responseCadastro.operadora.DataInclusao);
        }
    }

    public class ResponseOperadora
    {
        public string mensagem { get; set; }
        public Operadora operadora { get; set; }
    }
}
