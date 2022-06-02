using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class FuncionarioBeneficioApplicationService : IFuncionarioBeneficioApplicationService
    {
        private readonly IFuncionarioBeneficioDomainService funcionarioBeneficioDomainService;

        public FuncionarioBeneficioApplicationService(IFuncionarioBeneficioDomainService funcionarioBeneficioDomainService)
        {
            this.funcionarioBeneficioDomainService = funcionarioBeneficioDomainService;
        }

        public FuncionarioBeneficio Insert(FuncionarioBeneficioCadastroModel model)
        {
            var funcionarioBeneficio = new FuncionarioBeneficio();
            funcionarioBeneficio.IdFuncionario = model.IdFuncionario;
            funcionarioBeneficio.IdBeneficio = model.IdBeneficio;
            funcionarioBeneficio.DataInclusao = DateTime.UtcNow;

            funcionarioBeneficioDomainService.Insert(funcionarioBeneficio);

            return funcionarioBeneficio;
        }

        public FuncionarioBeneficioEdicaoModel Update(FuncionarioBeneficioEdicaoModel model)
        {
            var funcionarioBeneficio = new FuncionarioBeneficio();
            funcionarioBeneficio.IdFuncionarioBeneficio = model.IdFuncionarioBeneficio;
            funcionarioBeneficio.IdFuncionario = model.IdFuncionario;
            funcionarioBeneficio.IdBeneficio = model.IdBeneficio;

            funcionarioBeneficioDomainService.Update(funcionarioBeneficio);

            return model;
        }

        public void Delete(int idFuncionarioBeneficio)
        {
            var funcionarioBeneficio = funcionarioBeneficioDomainService.GetById(idFuncionarioBeneficio);

            funcionarioBeneficioDomainService.Delete(funcionarioBeneficio);
        }

        public List<FuncionarioBeneficioConsultaModel> GetAll()
        {
            var lista = new List<FuncionarioBeneficioConsultaModel>();

            foreach (var item in funcionarioBeneficioDomainService.GetAll())
            {
                var model = new FuncionarioBeneficioConsultaModel();
                model.IdFuncionario = item.IdFuncionario;
                model.IdBeneficio = item.IdBeneficio;
                model.DataInclusao = item.DataInclusao;

                lista.Add(model);

            }

            return lista;
        }

        public FuncionarioBeneficioConsultaModel GetById(int idFuncionarioBeneficio)
        {
            var clienteBeneficio = funcionarioBeneficioDomainService.GetById(idFuncionarioBeneficio);

            var model = new FuncionarioBeneficioConsultaModel();
            model.IdFuncionario = clienteBeneficio.IdFuncionario;
            model.IdBeneficio = clienteBeneficio.IdBeneficio;
            model.DataInclusao = clienteBeneficio.DataInclusao;

            return model;
        }
    }
}
