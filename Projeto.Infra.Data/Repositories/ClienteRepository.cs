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
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly DataContext dataContext;

        public ClienteRepository(DataContext dataContext)
           : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public Cliente GetByCnpj(string cnpj)
        {
            return dataContext.Cliente.FirstOrDefault(f => f.Cnpj.Equals(cnpj));
        }
    }
}
