using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class BeneficioApplicationService : IBeneficioApplicationService
    {
        private readonly IBeneficioDomainService beneficioDomainService;

        public BeneficioApplicationService(IBeneficioDomainService beneficioDomainService)
        {
            this.beneficioDomainService = beneficioDomainService;
        }

        public void Insert(BeneficioCadastroModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(BeneficioEdicaoModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int idBeneficio)
        {
            throw new NotImplementedException();
        }

        public List<BeneficioConsultaModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BeneficioConsultaModel GetById(int idBeneficio)
        {
            throw new NotImplementedException();
        }
    }
}
