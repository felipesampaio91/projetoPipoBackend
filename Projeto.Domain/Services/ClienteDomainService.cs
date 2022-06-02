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

        //public override Cliente Insert(Cliente obj)
        //{
        //    if (clienteRepository.GetByCnpj(obj.Cnpj) == null)
        //    {
        //        clienteRepository.Insert(obj);
        //        return obj;
        //    }
        //    else
        //    {
        //        throw new Exception("CNPJ já cadastrado!");
        //    }
        //}
    }
}
