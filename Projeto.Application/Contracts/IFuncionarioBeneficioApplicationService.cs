using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Application.Models;
using Projeto.Domain.Entities;

namespace Projeto.Application.Contracts
{
    public interface IFuncionarioBeneficioApplicationService
    {
        FuncionarioBeneficio Insert(FuncionarioBeneficioCadastroModel model);
        FuncionarioBeneficioEdicaoModel Update(FuncionarioBeneficioEdicaoModel model);
        void Delete(int idFuncionarioBeneficio);

        List<FuncionarioBeneficioConsultaModel> GetAll();
        FuncionarioBeneficioConsultaModel GetById(int idFuncionarioBeneficio);
    }
}
