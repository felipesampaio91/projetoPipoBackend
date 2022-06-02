using Projeto.Application.Models;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IFuncionarioApplicationService
    {
        Funcionario Insert(FuncionarioCadastroModel model);
        Funcionario Update(FuncionarioEdicaoModel model);
        void Delete(int idFuncionario);

        List<FuncionarioConsultaModel> GetAll();
        FuncionarioConsultaModel GetById(int idFuncionario);
    }
}
