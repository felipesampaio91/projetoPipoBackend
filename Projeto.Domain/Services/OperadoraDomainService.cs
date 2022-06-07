using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class OperadoraDomainService : BaseDomainService<Operadora>, IOperadoraDomainService
    {

        private readonly IOperadoraRepository operadoraRepository;
        public OperadoraDomainService(IOperadoraRepository operadoraRepository)
             : base(operadoraRepository)
        {
            this.operadoraRepository = operadoraRepository;
        }

        public override Operadora Insert(Operadora obj)
        {
            if (operadoraRepository.GetByCnpj(obj.Cnpj) == null)
            {
                operadoraRepository.Insert(obj);
                return obj;
            }
            else
            {
                throw new Exception("cnpj já cadastrado!");
            }
        }
    }
}
