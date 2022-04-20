using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class BeneficioRepository : BaseRepository<Beneficio>, IBeneficioRepository
    {
        private readonly DataContext dataContext;

        public BeneficioRepository(DataContext dataContext)
           : base(dataContext)
        {
            this.dataContext = dataContext;
        }

    }
}
