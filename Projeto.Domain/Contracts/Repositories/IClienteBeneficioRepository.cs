using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IClienteBeneficioRepository : IBaseRepository<ClienteBeneficio>
    {
        ClienteBeneficio VerificaClienteBeneficio(int idCliente, int idBeneficio);
    }
}
