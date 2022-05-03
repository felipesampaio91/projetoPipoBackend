using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Application.Models;

namespace Projeto.Application.Contracts
{
    public interface IFuncionarioBeneficioApplicationService
    {
        void Insert(FuncionarioBeneficioCadastroModel model);
        void Update(FuncionarioBeneficioEdicaoModel model);
        void Delete(int idFuncionarioBeneficio);

        List<FuncionarioBeneficioConsultaModel> GetAll();
        FuncionarioBeneficioConsultaModel GetById(int idFuncionarioBeneficio);
    }
}
