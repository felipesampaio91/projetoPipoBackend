using Projeto.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IBeneficioApplicationService
    {
        void Insert(BeneficioCadastroModel model);
        void Update(BeneficioEdicaoModel model);
        void Delete(int idBeneficio);

        List<BeneficioConsultaModel> GetAll();
        BeneficioConsultaModel GetById(int idBeneficio);
    }
}
