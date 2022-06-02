using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        Funcionario GetByCpf(string cpf);
        List<ClienteBeneficio> GetBeneficioByIdCliente(int idCliente);
    }
}
