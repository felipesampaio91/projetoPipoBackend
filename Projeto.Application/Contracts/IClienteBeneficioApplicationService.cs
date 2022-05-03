using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Application.Models;

namespace Projeto.Application.Contracts
{
    public interface IClienteBeneficioApplicationService
    {
        void Insert(ClienteBeneficioCadastroModel model);
        void Update(ClienteBeneficioEdicaoModel model);
        void Delete(int idClienteBeneficio);

        List<ClienteBeneficioConsultaModel> GetAll();
        ClienteBeneficioConsultaModel GetById(int idClienteBeneficio);
    }
}
