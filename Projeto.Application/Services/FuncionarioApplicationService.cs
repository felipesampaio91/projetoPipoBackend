using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class FuncionarioApplicationService : IFuncionarioApplicationService
    {
        private readonly IFuncionarioDomainService funcionarioDomainService;

        public FuncionarioApplicationService(IFuncionarioDomainService funcionarioDomainService)
        {
            this.funcionarioDomainService = funcionarioDomainService;
        }

        public void Insert(FuncionarioCadastroModel model)
        {
            var funcionario = new Funcionario();
            funcionario.Nome = model.Nome;
            funcionario.Cpf = model.Cpf;
            funcionario.DataAdmissao = model.DataAdmissao;
            funcionario.Endereco = model.Endereco;
            funcionario.IdCliente = model.IdCliente;
            funcionario.DataInclusao = DateTime.UtcNow;

            funcionarioDomainService.Insert(funcionario);
        }

        public void Update(FuncionarioEdicaoModel model)
        {
            var funcionario = new Funcionario();
            funcionario.IdFuncionario = model.IdFuncionario;
            funcionario.Nome = model.Nome;
            funcionario.Cpf = model.Cpf;
            funcionario.DataAdmissao = model.DataAdmissao;
            funcionario.Endereco = model.Endereco;
            funcionario.IdCliente = model.IdCliente;

            funcionarioDomainService.Update(funcionario);
        }

        public void Delete(int idFuncionario)
        {
            var funcionario = funcionarioDomainService.GetById(idFuncionario);

            funcionarioDomainService.Delete(funcionario);
        }

        public List<FuncionarioConsultaModel> GetAll()
        {
            var lista = new List<FuncionarioConsultaModel>();

            foreach (var item in funcionarioDomainService.GetAll())
            {
                var model = new FuncionarioConsultaModel();
                model.IdFuncionario = item.IdFuncionario;
                model.Nome = item.Nome;
                model.Cpf = item.Cpf;
                model.DataAdmissao = item.DataAdmissao;
                model.Endereco = item.Endereco;
                model.Email = item.Email;
                model.Peso = item.Peso;
                model.Altura = item.Altura;
                model.DataInclusao = item.DataInclusao;

                model.Cliente = new ClienteConsultaModel();
                model.Cliente.IdCliente = item.Cliente.IdCliente;
                model.Cliente.Nome = item.Cliente.Nome;
                model.Cliente.Cnpj = item.Cliente.Cnpj;
                model.Cliente.DataInclusao = item.Cliente.DataInclusao;


                lista.Add(model);

            }

            return lista;
        }

        public FuncionarioConsultaModel GetById(int idFuncionario)
        {
            var funcionario = funcionarioDomainService.GetById(idFuncionario);

            var model = new FuncionarioConsultaModel();
            model.IdFuncionario = funcionario.IdFuncionario;
            model.Nome = funcionario.Nome;
            model.Cpf = funcionario.Cpf;
            model.DataAdmissao = funcionario.DataAdmissao;
            model.Endereco = funcionario.Endereco;
            model.Email = funcionario.Email;
            model.Peso = funcionario.Peso;
            model.Altura = funcionario.Altura;
            model.DataInclusao = funcionario.DataInclusao;

            model.Cliente = new ClienteConsultaModel();
            model.Cliente.IdCliente = funcionario.Cliente.IdCliente;
            model.Cliente.Nome = funcionario.Cliente.Nome;
            model.Cliente.Cnpj = funcionario.Cliente.Cnpj;
            model.Cliente.DataInclusao = funcionario.Cliente.DataInclusao;

            return model;
        }
    }
}
