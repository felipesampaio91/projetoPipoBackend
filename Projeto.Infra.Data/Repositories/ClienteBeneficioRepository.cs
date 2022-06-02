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
    public class ClienteBeneficioRepository : BaseRepository<ClienteBeneficio>, IClienteBeneficioRepository
    {
        private readonly DataContext dataContext;

        public ClienteBeneficioRepository(DataContext dataContext)
          : base(dataContext)
        {
            this.dataContext = dataContext;
        }
        //verifica se o beneficio ja esta associado ao cliente
        public ClienteBeneficio VerificaClienteBeneficio(int idCliente, int idBeneficio)
        {
            return dataContext.ClienteBeneficio
                .Where(clienteBeneficio => clienteBeneficio.IdCliente == idCliente)
                .FirstOrDefault(clienteBeneficio => clienteBeneficio.IdBeneficio == idBeneficio);
        }
    }
}
