using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class ClienteBeneficioRepository : BaseRepository<ClienteBeneficio>, IClienteBeneficioRepository
    {
        private readonly DataContext dataContext;

        public ClienteBeneficioRepository(DataContext dataContext)
          : base(dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
