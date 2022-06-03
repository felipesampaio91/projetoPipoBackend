using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class ClienteBeneficioApplicationService : IClienteBeneficioApplicationService
    {
        private readonly IClienteBeneficioDomainService clienteBeneficioDomainService;

        public ClienteBeneficioApplicationService(IClienteBeneficioDomainService clienteBeneficioDomainService)
        {
            this.clienteBeneficioDomainService = clienteBeneficioDomainService;
        }

        public List<ClienteBeneficio> Insert(List<ClienteBeneficioCadastroModel> listaClienteBeneficio)
        {

            var listaClienteBeneficioResponse = new List<ClienteBeneficio>();

            foreach (var item in listaClienteBeneficio)
            {
                var clienteBeneficio = new ClienteBeneficio();
                clienteBeneficio.IdCliente = item.IdCliente;
                clienteBeneficio.IdBeneficio = item.IdBeneficio;
                clienteBeneficio.DataInclusao = DateTime.UtcNow;

                clienteBeneficioDomainService.Insert(clienteBeneficio);

                listaClienteBeneficioResponse.Add(clienteBeneficio);
            }

            return listaClienteBeneficioResponse;
        }

        public ClienteBeneficioEdicaoModel Update(ClienteBeneficioEdicaoModel model)
        {
            var clienteBeneficio = clienteBeneficioDomainService.GetById(model.IdClienteBeneficio);
            clienteBeneficio.IdClienteBeneficio = model.IdClienteBeneficio;
            clienteBeneficio.IdCliente = model.IdCliente;
            clienteBeneficio.IdBeneficio = model.IdBeneficio;

            clienteBeneficioDomainService.Update(clienteBeneficio);

            return model;
        }

        public void Delete(int idClienteBeneficio)
        {
            var clienteBeneficio = clienteBeneficioDomainService.GetById(idClienteBeneficio);
            
            clienteBeneficioDomainService.Delete(clienteBeneficio);
        }

        public List<ClienteBeneficioConsultaModel> GetAll()
        {
            var lista = new List<ClienteBeneficioConsultaModel>();

            foreach (var item in clienteBeneficioDomainService.GetAll())
            {
                var model = new ClienteBeneficioConsultaModel();
                model.IdClienteBeneficio = item.IdClienteBeneficio;
                model.IdCliente = item.IdCliente;
                model.IdBeneficio = item.IdBeneficio;
                model.DataInclusao = item.DataInclusao;

                lista.Add(model);

            }

            return lista;
        }

        public ClienteBeneficioConsultaModel GetById(int idClienteBeneficio)
        {
            var clienteBeneficio = clienteBeneficioDomainService.GetById(idClienteBeneficio);

            var model = new ClienteBeneficioConsultaModel();
            model.IdClienteBeneficio = clienteBeneficio.IdClienteBeneficio;
            model.IdCliente = clienteBeneficio.IdCliente;
            model.IdBeneficio = clienteBeneficio.IdBeneficio;
            model.DataInclusao = clienteBeneficio.DataInclusao;

            return model;
        }
    }
}
