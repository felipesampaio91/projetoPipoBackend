using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class BeneficioApplicationService : IBeneficioApplicationService
    {
        private readonly IBeneficioDomainService beneficioDomainService;

        public BeneficioApplicationService(IBeneficioDomainService beneficioDomainService)
        {
            this.beneficioDomainService = beneficioDomainService;
        }

        public Beneficio Insert(BeneficioCadastroModel model)
        {
            var beneficio = new Beneficio();
            beneficio.Nome = model.Nome;
            beneficio.IdOperadora = model.IdOperadora;
            beneficio.DataInclusao = DateTime.UtcNow;

            beneficioDomainService.Insert(beneficio);

            return beneficio;
        }

        public BeneficioEdicaoModel Update(BeneficioEdicaoModel model)
        {
            var beneficio = beneficioDomainService.GetById(model.IdBeneficio);
            beneficio.IdBeneficio = model.IdBeneficio;
            beneficio.Nome = model.Nome;

            beneficioDomainService.Update(beneficio);

            return model;
        }

        public void Delete(int idBeneficio)
        {
            var beneficio = beneficioDomainService.GetById(idBeneficio);

            beneficioDomainService.Delete(beneficio);
        }

        public List<BeneficioConsultaModel> GetAll()
        {
            var lista = new List<BeneficioConsultaModel>();

            foreach (var item in beneficioDomainService.GetAll())
            {
                var model = new BeneficioConsultaModel();
                model.IdBeneficio = item.IdBeneficio;
                model.Nome = item.Nome;
                model.IdOperadora = item.IdOperadora;
                model.DataInclusao = item.DataInclusao;

                model.Operadora = new OperadoraConsultaModel();
                model.Operadora.IdOperadora = item.Operadora.IdOperadora;
                model.Operadora.Nome = item.Operadora.Nome;
                model.Operadora.Cnpj = item.Operadora.Cnpj;
                model.Operadora.DataInclusao = item.Operadora.DataInclusao;

                lista.Add(model);

            }

            return lista;
        }

        public BeneficioConsultaModel GetById(int idBeneficio)
        {
            var beneficio = beneficioDomainService.GetById(idBeneficio);

            var model = new BeneficioConsultaModel();
            model.IdBeneficio = beneficio.IdBeneficio;
            model.Nome = beneficio.Nome;
            model.IdOperadora = beneficio.IdOperadora;
            model.DataInclusao = beneficio.DataInclusao;

            model.Operadora = new OperadoraConsultaModel();
            model.Operadora.IdOperadora = beneficio.Operadora.IdOperadora;
            model.Operadora.Nome = beneficio.Operadora.Nome;
            model.Operadora.Cnpj = beneficio.Operadora.Cnpj;
            model.Operadora.DataInclusao = beneficio.Operadora.DataInclusao;

            return model;
        }
    }
}
