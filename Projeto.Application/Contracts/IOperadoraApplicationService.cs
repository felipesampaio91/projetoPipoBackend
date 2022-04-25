using Projeto.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IOperadoraApplicationService
    {
        void Insert(OperadoraCadastroModel model);
        void Update(OperadoraEdicaoModel model);
        void Delete(int idOperadora);

        List<OperadoraConsultaModel> GetAll();
        OperadoraConsultaModel GetById(int idOperadora);
           
    }
}
