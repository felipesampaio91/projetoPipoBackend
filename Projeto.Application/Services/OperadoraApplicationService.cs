﻿using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class OperadoraApplicationService : IOperadoraApplicationService
    {
        private readonly IOperadoraDomainService operadoraDomainService;

        public OperadoraApplicationService(IOperadoraDomainService operadoraDomainService)
        {
            this.operadoraDomainService = operadoraDomainService;
        }

        public void Insert(OperadoraCadastroModel model)
        {
            var operadora = new Operadora();
            operadora.Nome = model.Nome;
            operadora.Cnpj = model.Nome;

            operadoraDomainService.Insert(operadora);
        }

        public void Update(OperadoraEdicaoModel model)
        {
            var operadora = new Operadora();
            operadora.IdOperadora = model.IdOperadora;
            operadora.Nome = model.Nome;
            operadora.Cnpj = model.Nome;

            operadoraDomainService.Update(operadora);
        }

        public void Delete(int idOperadora)
        {
            var operadora = operadoraDomainService.GetById(idOperadora);

            operadoraDomainService.Delete(operadora);
        }

        public List<OperadoraConsultaModel> GetAll()
        {
            var lista = new List<OperadoraConsultaModel>();

            foreach (var item in operadoraDomainService.GetAll())
            {
                var model = new OperadoraConsultaModel();
                model.IdOperadora = item.IdOperadora;
                model.Nome = item.Nome;
                model.Cnpj = item.Cnpj;

                lista.Add(model);
            }

            return lista;
        }

        public OperadoraConsultaModel GetById(int idOperadora)
        {
            var operadora = operadoraDomainService.GetById(idOperadora);
            
            var model = new OperadoraConsultaModel();
            model.IdOperadora = operadora.IdOperadora;
            model.Nome = operadora.Nome;
            model.Cnpj = operadora.Cnpj;

            return model;
        }
    }
}
