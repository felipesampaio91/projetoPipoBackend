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
    public  class BeneficioTest
    {
        private readonly HttpClient httpClient;

        public BeneficioTest()
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
        public async Task CadastrarBeneficio()
        {
            //Cadastrando uma operadora que será responsável pelo benefício
            var modelOperadora = new OperadoraCadastroModel();
            modelOperadora.Nome = "Operadora Benefício";
            modelOperadora.Cnpj = "58587393000161";
            modelOperadora.DataInclusao = DateTime.UtcNow;

            var requestOperadora = new StringContent(JsonConvert.SerializeObject(modelOperadora),
                Encoding.UTF8, "application/json");

            var resultOperadora = await httpClient.PostAsync("api/Operadora", requestOperadora);

            var contentOperadora = string.Empty;
            using (var httpContent = resultOperadora.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentOperadora += r.Result;
            }

            var responseOperadora = JsonConvert.DeserializeObject<ResponseOperadora>(contentOperadora);

            //cadastrando beneficio
            var modelBeneficio = new BeneficioCadastroModel();
            modelBeneficio.Nome = "Beneficio Teste";
            modelBeneficio.IdOperadora = responseOperadora.operadora.IdOperadora;
            modelBeneficio.DataInclusao = DateTime.UtcNow;

            var requestBeneficio = new StringContent(JsonConvert.SerializeObject(modelBeneficio),
                Encoding.UTF8, "application/json");

            var resultBeneficio = await httpClient.PostAsync("api/Beneficio", requestBeneficio);

            var contentBeneficio = string.Empty;
            using (var httpContent = resultBeneficio.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentBeneficio += r.Result;
            }

            var responseBeneficio = JsonConvert.DeserializeObject<ResponseBeneficio>(contentBeneficio);

            resultBeneficio.StatusCode.Should().Be(HttpStatusCode.OK);
            responseBeneficio.mensagem.Should().Contain("Benefício cadastrado com sucesso.");
        }

        [Fact]
        public async Task AtualizarBeneficio()
        {
            //Cadastrando uma operadora que será responsável pelo benefício
            var modelOperadora = new OperadoraCadastroModel();
            modelOperadora.Nome = "Operadora Benefício1";
            modelOperadora.Cnpj = "26005296000127";
            modelOperadora.DataInclusao = DateTime.UtcNow;

            var requestOperadora = new StringContent(JsonConvert.SerializeObject(modelOperadora),
                Encoding.UTF8, "application/json");

            var resultOperadora = await httpClient.PostAsync("api/Operadora", requestOperadora);

            var contentOperadora = string.Empty;
            using (var httpContent = resultOperadora.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentOperadora += r.Result;
            }

            var responseOperadora = JsonConvert.DeserializeObject<ResponseOperadora>(contentOperadora);

            //Criando objeto que será atualizado
            var modelBeneficioCadastro = new BeneficioCadastroModel();
            modelBeneficioCadastro.Nome = "Beneficio Edição2";
            modelBeneficioCadastro.IdOperadora = responseOperadora.operadora.IdOperadora;
            modelBeneficioCadastro.DataInclusao = DateTime.UtcNow;

            var requestBeneficioCadastro = new StringContent(JsonConvert.SerializeObject(modelBeneficioCadastro),
                Encoding.UTF8, "application/json");

            var resultBeneficioCadastro = await httpClient.PostAsync("api/Beneficio", requestBeneficioCadastro);

            var contentBeneficioCadastro = string.Empty;
            using (var httpContent = resultBeneficioCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentBeneficioCadastro += r.Result;
            }

            var responseBeneficioCadastro = JsonConvert.DeserializeObject<ResponseBeneficio>(contentBeneficioCadastro);

            //Atualizando o objeto cadastrado
            var modelEdicao = new BeneficioEdicaoModel();
            modelEdicao.IdBeneficio = responseBeneficioCadastro.beneficio.IdBeneficio;
            modelEdicao.Nome = "Benefício Edição Atualizada";

            var requestEdicao = new StringContent(JsonConvert.SerializeObject(modelEdicao),
                Encoding.UTF8, "application/json");

            var resultEdicao = await httpClient.PutAsync("api/Beneficio", requestEdicao);

            var contentEdicao = string.Empty;
            using (var httpContent = resultEdicao.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentEdicao += r.Result;
            }

            var responseEdicao = JsonConvert.DeserializeObject<ResponseBeneficio>(contentEdicao);

            resultEdicao.StatusCode.Should().Be(HttpStatusCode.OK);
            responseEdicao.mensagem.Should().Contain("Benefício atualizado com sucesso.");
        }

        [Fact]
        public async Task ExcluirBeneficio()
        {
            //Cadastrando uma operadora que será responsável pelo benefício
            var modelOperadora = new OperadoraCadastroModel();
            modelOperadora.Nome = "Operadora Benefício1";
            modelOperadora.Cnpj = "16612920000109";
            modelOperadora.DataInclusao = DateTime.UtcNow;

            var requestOperadora = new StringContent(JsonConvert.SerializeObject(modelOperadora),
                Encoding.UTF8, "application/json");

            var resultOperadora = await httpClient.PostAsync("api/Operadora", requestOperadora);

            var contentOperadora = string.Empty;
            using (var httpContent = resultOperadora.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentOperadora += r.Result;
            }

            var responseOperadora = JsonConvert.DeserializeObject<ResponseOperadora>(contentOperadora);

            //Criando objeto que será atualizado
            var modelBeneficioCadastro = new BeneficioCadastroModel();
            modelBeneficioCadastro.Nome = "Beneficio Edição2";
            modelBeneficioCadastro.IdOperadora = responseOperadora.operadora.IdOperadora;
            modelBeneficioCadastro.DataInclusao = DateTime.UtcNow;

            var requestBeneficioCadastro = new StringContent(JsonConvert.SerializeObject(modelBeneficioCadastro),
                Encoding.UTF8, "application/json");

            var resultBeneficioCadastro = await httpClient.PostAsync("api/Beneficio", requestBeneficioCadastro);

            var contentBeneficioCadastro = string.Empty;
            using (var httpContent = resultBeneficioCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentBeneficioCadastro += r.Result;
            }

            var responseBeneficioCadastro = JsonConvert.DeserializeObject<ResponseBeneficio>(contentBeneficioCadastro);

            //Excluindo o objeto cadastrado
            var resultExclusao = await httpClient.DeleteAsync("api/Beneficio/" + responseBeneficioCadastro.beneficio.IdBeneficio);

            var contentExclusao = string.Empty;
            using (var httpContent = resultExclusao.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentExclusao += r.Result;
            }

            var responseExclusao = JsonConvert.DeserializeObject<ResponseBeneficio>(contentExclusao);

            resultExclusao.StatusCode.Should().Be(HttpStatusCode.OK);
            responseExclusao.mensagem.Should().Contain("Benefício excluído com sucesso.");
        }

        [Fact]
        public async Task ConsultarBeneficio()
        {
            //Cadastrando uma operadora que será responsável pelo benefício
            var modelOperadora = new OperadoraCadastroModel();
            modelOperadora.Nome = "Operadora Benefício1";
            modelOperadora.Cnpj = "65806111000135";
            modelOperadora.DataInclusao = DateTime.UtcNow;

            var requestOperadora = new StringContent(JsonConvert.SerializeObject(modelOperadora),
                Encoding.UTF8, "application/json");

            var resultOperadora = await httpClient.PostAsync("api/Operadora", requestOperadora);

            var contentOperadora = string.Empty;
            using (var httpContent = resultOperadora.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentOperadora += r.Result;
            }

            var responseOperadora = JsonConvert.DeserializeObject<ResponseOperadora>(contentOperadora);

            //Criando objeto que será atualizado
            var modelBeneficioCadastro = new BeneficioCadastroModel();
            modelBeneficioCadastro.Nome = "Beneficio Edição2";
            modelBeneficioCadastro.IdOperadora = responseOperadora.operadora.IdOperadora;
            modelBeneficioCadastro.DataInclusao = DateTime.UtcNow;

            var requestBeneficioCadastro = new StringContent(JsonConvert.SerializeObject(modelBeneficioCadastro),
                Encoding.UTF8, "application/json");

            var resultBeneficioCadastro = await httpClient.PostAsync("api/Beneficio", requestBeneficioCadastro);

            var contentBeneficioCadastro = string.Empty;
            using (var httpContent = resultBeneficioCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentBeneficioCadastro += r.Result;
            }

            var responseBeneficioCadastro = JsonConvert.DeserializeObject<ResponseBeneficio>(contentBeneficioCadastro);

            //Consultando o objeto cadastrado
            var resultConsulta = await httpClient.GetAsync("api/Beneficio");

            var contentConsulta = string.Empty;
            using (var httpContent = resultConsulta.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentConsulta += r.Result;
            }

            var responseConsulta = JsonConvert.DeserializeObject<List<BeneficioConsultaModel>>(contentConsulta);

            resultConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
            responseConsulta.Count().Should().BeGreaterThan(0);
            responseConsulta.FirstOrDefault(p => p.IdBeneficio == responseBeneficioCadastro.beneficio.IdBeneficio)
                .Should()
                .NotBeNull();
        }

        [Fact]
        public async Task ConsultarBeneficioPorId()
        {
            //Cadastrando uma operadora que será responsável pelo benefício
            var modelOperadora = new OperadoraCadastroModel();
            modelOperadora.Nome = "Operadora Benefício1";
            modelOperadora.Cnpj = "09297156000150";
            modelOperadora.DataInclusao = DateTime.UtcNow;

            var requestOperadora = new StringContent(JsonConvert.SerializeObject(modelOperadora),
                Encoding.UTF8, "application/json");

            var resultOperadora = await httpClient.PostAsync("api/Operadora", requestOperadora);

            var contentOperadora = string.Empty;
            using (var httpContent = resultOperadora.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentOperadora += r.Result;
            }

            var responseOperadora = JsonConvert.DeserializeObject<ResponseOperadora>(contentOperadora);

            //Criando objeto que será atualizado
            var modelBeneficioCadastro = new BeneficioCadastroModel();
            modelBeneficioCadastro.Nome = "Beneficio Edição2";
            modelBeneficioCadastro.IdOperadora = responseOperadora.operadora.IdOperadora;
            modelBeneficioCadastro.DataInclusao = DateTime.UtcNow;

            var requestBeneficioCadastro = new StringContent(JsonConvert.SerializeObject(modelBeneficioCadastro),
                Encoding.UTF8, "application/json");

            var resultBeneficioCadastro = await httpClient.PostAsync("api/Beneficio", requestBeneficioCadastro);

            var contentBeneficioCadastro = string.Empty;
            using (var httpContent = resultBeneficioCadastro.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentBeneficioCadastro += r.Result;
            }

            var responseBeneficioCadastro = JsonConvert.DeserializeObject<ResponseBeneficio>(contentBeneficioCadastro);

            //Consultando o objeto cadastrado
            var resultConsulta = await httpClient.GetAsync("api/Beneficio/" + responseBeneficioCadastro.beneficio.IdBeneficio);

            var contentConsulta = string.Empty;
            using (var httpContent = resultConsulta.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentConsulta += r.Result;
            }

            var responseConsulta = JsonConvert.DeserializeObject<BeneficioConsultaModel>(contentConsulta);

            resultConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
            responseConsulta.Should().NotBeNull();
            responseConsulta.IdBeneficio.Should().Be(responseBeneficioCadastro.beneficio.IdBeneficio);
            responseConsulta.Nome.Should().Be(responseBeneficioCadastro.beneficio.Nome);
            responseConsulta.DataInclusao.Should().Be(responseBeneficioCadastro.beneficio.DataInclusao);
        }
    }

    public class ResponseBeneficio
    {
        public string mensagem { get; set; }
        public Beneficio beneficio { get; set; }
    }
}
