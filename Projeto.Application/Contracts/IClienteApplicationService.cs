using Projeto.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IClienteApplicationService
    {
        void Insert(ClienteCadastroModel model);
        void Update(ClienteEdicaoModel model);
        void Delete(int idCliente);

        List<ClienteConsultaModel> GetAll();
        ClienteConsultaModel GetById(int idCliente);
    }
}
