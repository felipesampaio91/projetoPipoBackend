using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class FuncionarioDomainService : BaseDomainService<Funcionario>, IFuncionarioDomainService
    {
        private readonly IFuncionarioRepository funcionarioRepository;

        public FuncionarioDomainService(IFuncionarioRepository funcionarioRepository)
           : base(funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }

        public override void Insert(Funcionario obj)
        {
            if (funcionarioRepository.GetByCpf(obj.CPF) == null)
            {
                funcionarioRepository.Insert(obj);
            }
            else
            {
                throw new Exception("CPF já cadastrado!");
            }
        }

    }
}
