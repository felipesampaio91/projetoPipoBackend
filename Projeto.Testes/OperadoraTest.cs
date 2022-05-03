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
            model.Nome = "Operadora Teste10";
            model.Cnpj = "16939900000139";
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
            var modelCadastro = new OperadoraCadastroModel();
            modelCadastro.Nome = "Operadora Teste9";
            modelCadastro.Cnpj = "18859243000145";
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


            var modelEdicao = new OperadoraEdicaoModel();
            modelEdicao.IdOperadora = responseCadastro.operadora.IdOperadora;
            modelEdicao.Nome = "Operadora Edição Teste1";
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

        [Fact(Skip = "Não implementado")]
        public void ExcluirOperadora()
        {

        }

        [Fact(Skip = "Não implementado")]
        public void ConsultarOperadora()
        {

        }

        [Fact(Skip = "Não implementado")]
        public void ConsultarOperadoraPorId()
        {

        }
    }

    public class ResponseOperadora
    {
        public string mensagem { get; set; }
        public Operadora operadora { get; set; }
    }
}
