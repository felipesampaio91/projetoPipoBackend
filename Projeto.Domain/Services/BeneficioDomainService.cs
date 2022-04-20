using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class BeneficioDomainService : BaseDomainService<Beneficio>, IBeneficioDomainService
    {
        private readonly IBeneficioRepository beneficioRepository;

        public BeneficioDomainService(IBeneficioRepository beneficioRepository)
            : base(beneficioRepository)
        {
            this.beneficioRepository = beneficioRepository;
        }


    }
}
