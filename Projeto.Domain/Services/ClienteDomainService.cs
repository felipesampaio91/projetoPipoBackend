using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class ClienteDomainService : BaseDomainService<Cliente>, IClienteDomainService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository)
           : base(clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public override void Insert(Cliente obj)
        {
            if (clienteRepository.GetByCnpj(obj.CNPJ) == null)
            {
                clienteRepository.Insert(obj);
            }
            else
            {
                throw new Exception("CNPJ já cadastrado!");
            }
        }
    }
}
