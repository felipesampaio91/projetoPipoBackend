using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Application.Models;
using Projeto.Domain.Entities;

namespace Projeto.Application.Contracts
{
    public interface IClienteBeneficioApplicationService
    {
        List<ClienteBeneficio> Insert(List<ClienteBeneficioCadastroModel> listaClienteBeneficio);
        ClienteBeneficioEdicaoModel Update(ClienteBeneficioEdicaoModel model);
        void Delete(int idClienteBeneficio);

        List<ClienteBeneficioConsultaModel> GetAll();
        ClienteBeneficioConsultaModel GetById(int idClienteBeneficio);
    }
}
