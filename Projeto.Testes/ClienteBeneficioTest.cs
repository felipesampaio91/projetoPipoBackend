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
    public class ClienteBeneficioTest
    {
        private readonly HttpClient httpClient;

        public ClienteBeneficioTest()
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
        public async Task CadastrarClienteBeneficio()
        {
            //cadastrando cliente
            var modelCliente = new ClienteCadastroModel();
            modelCliente.Nome = "Cliente Teste2";
            modelCliente.Cnpj = "31286091000105";
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

            //Cadastrando uma operadora que será responsável pelo benefício
            var modelOperadora = new OperadoraCadastroModel();
            modelOperadora.Nome = "Operadora Benefício1";
            modelOperadora.Cnpj = "72655486000107";
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
            modelBeneficio.Nome = "Beneficio Teste2";
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
            
            //cadastrando cliente-beneficio
            var modelClienteBeneficio = new ClienteBeneficioCadastroModel();
            modelClienteBeneficio.IdCliente = responseCliente.cliente.IdCliente;
            modelClienteBeneficio.IdBeneficio = responseBeneficio.beneficio.IdBeneficio;
            modelClienteBeneficio.DataInclusao = DateTime.UtcNow;

            var listaClienteBeneficio = new List<ClienteBeneficioCadastroModel>();

            listaClienteBeneficio.Add(modelClienteBeneficio);


            var requestClienteBeneficio = new StringContent(JsonConvert.SerializeObject(listaClienteBeneficio),
                Encoding.UTF8, "application/json");

            var resultClienteBeneficio = await httpClient.PostAsync("api/ClienteBeneficio", requestClienteBeneficio);

            var contentClienteBeneficio = string.Empty;
            using (var httpContent = resultClienteBeneficio.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentClienteBeneficio += r.Result;
            }

            var responseClienteBeneficio = JsonConvert.DeserializeObject<ResponseClienteBeneficio>(contentClienteBeneficio);

            resultClienteBeneficio.StatusCode.Should().Be(HttpStatusCode.OK);
            responseClienteBeneficio.mensagem.Should().Contain("Cliente-Beneficio cadastrado com sucesso.");
        }

        [Fact]
        public async Task AtualizarClienteBeneficio()
        {
            //cadastrando cliente
            var modelCliente = new ClienteCadastroModel();
            modelCliente.Nome = "Cliente Teste2";
            modelCliente.Cnpj = "87746647000145";
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

            //Cadastrando uma operadora que será responsável pelo benefício
            var modelOperadora = new OperadoraCadastroModel();
            modelOperadora.Nome = "Operadora Benefício1";
            modelOperadora.Cnpj = "66473981000100";
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
            modelBeneficio.Nome = "Beneficio Teste2";
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

            //cadastrando cliente-beneficio
            var modelClienteBeneficio = new ClienteBeneficioCadastroModel();
            modelClienteBeneficio.IdCliente = responseCliente.cliente.IdCliente;
            modelClienteBeneficio.IdBeneficio = responseBeneficio.beneficio.IdBeneficio;
            modelClienteBeneficio.DataInclusao = DateTime.UtcNow;

            var listaClienteBeneficio = new List<ClienteBeneficioCadastroModel>();

            listaClienteBeneficio.Add(modelClienteBeneficio);

            var requestClienteBeneficio = new StringContent(JsonConvert.SerializeObject(listaClienteBeneficio),
                Encoding.UTF8, "application/json");

            var resultClienteBeneficio = await httpClient.PostAsync("api/ClienteBeneficio", requestClienteBeneficio);

            var contentClienteBeneficio = string.Empty;
            using (var httpContent = resultClienteBeneficio.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentClienteBeneficio += r.Result;
            }

            var responseClienteBeneficio = JsonConvert.DeserializeObject<ResponseClienteBeneficio>(contentClienteBeneficio);

            //Atualizando o objeto cadastrado
            var modelEdicao = new ClienteBeneficioEdicaoModel();
            modelEdicao.IdClienteBeneficio = responseClienteBeneficio.clienteBeneficio.IdClienteBeneficio;
            modelEdicao.IdCliente = responseCliente.cliente.IdCliente; 
            modelEdicao.IdBeneficio = responseBeneficio.beneficio.IdBeneficio;

            var requestEdicao = new StringContent(JsonConvert.SerializeObject(modelEdicao),
                Encoding.UTF8, "application/json");

            var resultEdicao = await httpClient.PutAsync("api/ClienteBeneficio", requestEdicao);

            var contentEdicao = string.Empty;
            using (var httpContent = resultEdicao.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentEdicao += r.Result;
            }

            var responseEdicao = JsonConvert.DeserializeObject<ResponseClienteBeneficio>(contentEdicao);

            resultEdicao.StatusCode.Should().Be(HttpStatusCode.OK);
            responseEdicao.mensagem.Should().Contain("Cliente-Beneficio atualizado com sucesso.");
        }

        [Fact]
        public async Task ExcluirClienteBeneficio()
        {
            //cadastrando cliente
            var modelCliente = new ClienteCadastroModel();
            modelCliente.Nome = "Cliente Teste2";
            modelCliente.Cnpj = "70784106000109";
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

            //Cadastrando uma operadora que será responsável pelo benefício
            var modelOperadora = new OperadoraCadastroModel();
            modelOperadora.Nome = "Operadora Benefício1";
            modelOperadora.Cnpj = "19646379000130";
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
            modelBeneficio.Nome = "Beneficio Teste2";
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

            //cadastrando cliente-beneficio
            var modelClienteBeneficio = new ClienteBeneficioCadastroModel();
            modelClienteBeneficio.IdCliente = responseCliente.cliente.IdCliente;
            modelClienteBeneficio.IdBeneficio = responseBeneficio.beneficio.IdBeneficio;
            modelClienteBeneficio.DataInclusao = DateTime.UtcNow;

            var listaClienteBeneficio = new List<ClienteBeneficioCadastroModel>();

            listaClienteBeneficio.Add(modelClienteBeneficio);

            var requestClienteBeneficio = new StringContent(JsonConvert.SerializeObject(listaClienteBeneficio),
                Encoding.UTF8, "application/json");

            var resultClienteBeneficio = await httpClient.PostAsync("api/ClienteBeneficio", requestClienteBeneficio);

            var contentClienteBeneficio = string.Empty;
            using (var httpContent = resultClienteBeneficio.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentClienteBeneficio += r.Result;
            }

            var responseClienteBeneficio = JsonConvert.DeserializeObject<ResponseClienteBeneficio>(contentClienteBeneficio);

            //Excluindo o objeto cadastrado
            var resultExclusao = await httpClient.DeleteAsync("api/ClienteBeneficio/" + responseClienteBeneficio.clienteBeneficio.IdClienteBeneficio);

            var contentExclusao = string.Empty;
            using (var httpContent = resultExclusao.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentExclusao += r.Result;
            }

            var responseExclusao = JsonConvert.DeserializeObject<ResponseClienteBeneficio>(contentExclusao);

            resultExclusao.StatusCode.Should().Be(HttpStatusCode.OK);
            responseExclusao.mensagem.Should().Contain("Cliente-Beneficio excluído com sucesso.");
        }

        [Fact]
        public async Task ConsultarClienteBeneficio()
        {
            //cadastrando cliente
            var modelCliente = new ClienteCadastroModel();
            modelCliente.Nome = "Cliente Teste2";
            modelCliente.Cnpj = "74503279000162";
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

            //Cadastrando uma operadora que será responsável pelo benefício
            var modelOperadora = new OperadoraCadastroModel();
            modelOperadora.Nome = "Operadora Benefício1";
            modelOperadora.Cnpj = "26440103000166";
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
            modelBeneficio.Nome = "Beneficio Teste2";
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

            //cadastrando cliente-beneficio
            var modelClienteBeneficio = new ClienteBeneficioCadastroModel();
            modelClienteBeneficio.IdCliente = responseCliente.cliente.IdCliente;
            modelClienteBeneficio.IdBeneficio = responseBeneficio.beneficio.IdBeneficio;
            modelClienteBeneficio.DataInclusao = DateTime.UtcNow;

            var listaClienteBeneficio = new List<ClienteBeneficioCadastroModel>();

            listaClienteBeneficio.Add(modelClienteBeneficio);

            var requestClienteBeneficio = new StringContent(JsonConvert.SerializeObject(listaClienteBeneficio),
                Encoding.UTF8, "application/json");

            var resultClienteBeneficio = await httpClient.PostAsync("api/ClienteBeneficio", requestClienteBeneficio);

            var contentClienteBeneficio = string.Empty;
            using (var httpContent = resultClienteBeneficio.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentClienteBeneficio += r.Result;
            }

            var responseClienteBeneficio = JsonConvert.DeserializeObject<ResponseClienteBeneficio>(contentClienteBeneficio);

            //Consultando o objeto cadastrado
            var resultConsulta = await httpClient.GetAsync("api/ClienteBeneficio");

            var contentConsulta = string.Empty;
            using (var httpContent = resultConsulta.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentConsulta += r.Result;
            }

            var responseConsulta = JsonConvert.DeserializeObject<List<ClienteBeneficioConsultaModel>>(contentConsulta);

            resultConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
            responseConsulta.Count().Should().BeGreaterThan(0);
            responseConsulta.FirstOrDefault(p => p.IdClienteBeneficio == responseClienteBeneficio.clienteBeneficio.IdClienteBeneficio)
                .Should()
                .NotBeNull();
        }

        [Fact]
        public async Task ConsultarClienteBeneficioPorId()
        {
            //cadastrando cliente
            var modelCliente = new ClienteCadastroModel();
            modelCliente.Nome = "Cliente Teste2";
            modelCliente.Cnpj = "73068616000178";
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

            //Cadastrando uma operadora que será responsável pelo benefício
            var modelOperadora = new OperadoraCadastroModel();
            modelOperadora.Nome = "Operadora Benefício1";
            modelOperadora.Cnpj = "12035435000150";
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
            modelBeneficio.Nome = "Beneficio Teste2";
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

            //cadastrando cliente-beneficio
            var modelClienteBeneficio = new ClienteBeneficioCadastroModel();
            modelClienteBeneficio.IdCliente = responseCliente.cliente.IdCliente;
            modelClienteBeneficio.IdBeneficio = responseBeneficio.beneficio.IdBeneficio;
            modelClienteBeneficio.DataInclusao = DateTime.UtcNow;

            var listaClienteBeneficio = new List<ClienteBeneficioCadastroModel>();

            listaClienteBeneficio.Add(modelClienteBeneficio);

            var requestClienteBeneficio = new StringContent(JsonConvert.SerializeObject(listaClienteBeneficio),
                Encoding.UTF8, "application/json");

            var resultClienteBeneficio = await httpClient.PostAsync("api/ClienteBeneficio", requestClienteBeneficio);

            var contentClienteBeneficio = string.Empty;
            using (var httpContent = resultClienteBeneficio.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentClienteBeneficio += r.Result;
            }

            var responseClienteBeneficio = JsonConvert.DeserializeObject<ResponseClienteBeneficio>(contentClienteBeneficio);

            //Consultando o objeto cadastrado
            var resultConsulta = await httpClient.GetAsync("api/ClienteBeneficio/" + responseClienteBeneficio.clienteBeneficio.IdClienteBeneficio);

            var contentConsulta = string.Empty;
            using (var httpContent = resultConsulta.Content)
            {
                Task<string> r = httpContent.ReadAsStringAsync();
                contentConsulta += r.Result;
            }

            var responseConsulta = JsonConvert.DeserializeObject<ClienteBeneficioConsultaModel>(contentConsulta);

            resultConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
            responseConsulta.Should().NotBeNull();
            responseConsulta.IdCliente.Should().Be(responseClienteBeneficio.clienteBeneficio.IdCliente);
            responseConsulta.IdBeneficio.Should().Be(responseClienteBeneficio.clienteBeneficio.IdBeneficio);
            responseConsulta.DataInclusao.Should().Be(responseClienteBeneficio.clienteBeneficio.DataInclusao);
        }


        public class ResponseClienteBeneficio
        {
            public string mensagem { get; set; }
            public ClienteBeneficio clienteBeneficio { get; set; }
        }
    }
}
