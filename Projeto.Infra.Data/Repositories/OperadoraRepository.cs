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
    public class OperadoraRepository : BaseRepository<Operadora>, IOperadoraRepository
    {
        private readonly DataContext dataContext;

        public OperadoraRepository(DataContext dataContext)
          : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public Operadora GetByCnpj(string cnpj)
        {
            return dataContext.Operadora.FirstOrDefault(f => f.CNPJ.Equals(cnpj));
        }
    }
}
