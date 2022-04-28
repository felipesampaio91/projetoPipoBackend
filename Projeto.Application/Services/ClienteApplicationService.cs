using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private readonly IClienteDomainService clienteDomainService;

        public ClienteApplicationService(IClienteDomainService clienteDomainService)
        {
            this.clienteDomainService = clienteDomainService;
        }

        public void Insert(ClienteCadastroModel model)
        {
            var cliente = new Cliente();
            cliente.Nome = model.Nome;
            cliente.Cnpj = model.Nome;
            cliente.DataInclusao = DateTime.UtcNow;

            clienteDomainService.Insert(cliente);
        }

        public void Update(ClienteEdicaoModel model)
        {
            var cliente = new Cliente();
            cliente.IdCliente = model.IdCliente;
            cliente.Nome = model.Nome;
            cliente.Cnpj = model.Cnpj;

            clienteDomainService.Update(cliente);
        }

        public void Delete(int idCliente)
        {
            var cliente = clienteDomainService.GetById(idCliente);

            clienteDomainService.Delete(cliente);
        }

        public List<ClienteConsultaModel> GetAll()
        {
            var lista = new List<ClienteConsultaModel>();

            foreach (var item in clienteDomainService.GetAll())
            {
                var model = new ClienteConsultaModel();
                model.IdCliente = item.IdCliente;
                model.Nome = item.Nome;
                model.Cnpj = item.Cnpj;
                model.DataInclusao = item.DataInclusao;

                lista.Add(model);

            }

            return lista;
        }

        public ClienteConsultaModel GetById(int idCliente)
        {
            var cliente = clienteDomainService.GetById(idCliente);

            var model = new ClienteConsultaModel();
            model.IdCliente = cliente.IdCliente;
            model.Nome = cliente.Nome;
            model.Cnpj = cliente.Cnpj;
            model.DataInclusao = cliente.DataInclusao;

            return model;
        }
    }
}
