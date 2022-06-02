using Projeto.Application.Models;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IClienteApplicationService
    {
        Cliente Insert(ClienteCadastroModel model);
        ClienteEdicaoModel Update(ClienteEdicaoModel model);
        void Delete(int idCliente);

        List<ClienteConsultaModel> GetAll();
        ClienteConsultaModel GetById(int idCliente);
    }
}
