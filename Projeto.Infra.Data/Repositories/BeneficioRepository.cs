using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public override List<Beneficio> GetAll()
        {
            return dataContext.Beneficio
                .Include(beneficio => beneficio.Operadora)
                .ToList();
        }

        public override Beneficio GetById(int id)
        {
            return dataContext.Beneficio
                .Include(beneficio => beneficio.Operadora)
                .FirstOrDefault(beneficio => beneficio.IdBeneficio == id);
        }

    }
}
