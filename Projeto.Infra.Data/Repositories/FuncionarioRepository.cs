using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        private readonly DataContext dataContext;

        public FuncionarioRepository(DataContext dataContext)
          : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public Funcionario GetByCpf(string cpf)
        {
            return dataContext.Funcionario.FirstOrDefault(f => f.Cpf.Equals(cpf));
        }

        public override List<Funcionario> GetAll()
        {
            return dataContext.Funcionario
                .Include(funcionario => funcionario.Cliente)
                .ToList();
        }

        public override Funcionario GetById(int id)
        {
            return dataContext.Funcionario
                .Include(funcionario => funcionario.Cliente)
                .FirstOrDefault(funcionario => funcionario.IdFuncionario == id);
        }
    }
}
