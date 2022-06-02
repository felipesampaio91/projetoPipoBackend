using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class ClienteBeneficioDomainService : BaseDomainService<ClienteBeneficio>, IClienteBeneficioDomainService
    {
        private readonly IClienteBeneficioRepository clienteBeneficioRepository;

        public ClienteBeneficioDomainService(IClienteBeneficioRepository clienteBeneficioRepository)
            : base(clienteBeneficioRepository)
        {
            this.clienteBeneficioRepository = clienteBeneficioRepository;
        }

        public override ClienteBeneficio Insert(ClienteBeneficio obj)
        {
            if (clienteBeneficioRepository.VerificaClienteBeneficio(obj.IdCliente, obj.IdBeneficio) == null)
            {
                clienteBeneficioRepository.Insert(obj);
                return obj;
            }
            else
            {
                return obj;
            }

        }

    }
}
