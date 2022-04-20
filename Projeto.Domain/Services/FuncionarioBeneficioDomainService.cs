using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class FuncionarioBeneficioDomainService : BaseDomainService<FuncionarioBeneficio>, IFuncionarioBeneficioDomainService
    {
        private readonly IFuncionarioBeneficioRepository funcionarioBeneficioRepository;

        public FuncionarioBeneficioDomainService(IFuncionarioBeneficioRepository funcionarioBeneficioRepository)
            : base(funcionarioBeneficioRepository)
        {
            this.funcionarioBeneficioRepository = funcionarioBeneficioRepository;
        }

    }
}
