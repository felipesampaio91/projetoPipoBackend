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

    }
}
