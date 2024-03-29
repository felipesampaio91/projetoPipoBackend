﻿using Projeto.Application.Models;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IOperadoraApplicationService
    {
        Operadora Insert(OperadoraCadastroModel model);
        OperadoraEdicaoModel Update(OperadoraEdicaoModel model);
        void Delete(int idOperadora);

        List<OperadoraConsultaModel> GetAll();
        OperadoraConsultaModel GetById(int idOperadora);
           
    }
}
