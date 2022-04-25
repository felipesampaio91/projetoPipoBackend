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
            throw new NotImplementedException();
        }

        public List<ClienteConsultaModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClienteConsultaModel GetById(int idCliente)
        {
            throw new NotImplementedException();
        }
    }
}
