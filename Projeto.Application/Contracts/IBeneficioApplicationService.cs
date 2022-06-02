using Projeto.Application.Models;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IBeneficioApplicationService
    {
        Beneficio Insert(BeneficioCadastroModel model);
        BeneficioEdicaoModel Update(BeneficioEdicaoModel model);
        void Delete(int idBeneficio);

        List<BeneficioConsultaModel> GetAll();
        BeneficioConsultaModel GetById(int idBeneficio);
    }
}
