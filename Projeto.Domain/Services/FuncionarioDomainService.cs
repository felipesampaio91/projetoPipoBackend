﻿using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class FuncionarioDomainService : BaseDomainService<Funcionario>, IFuncionarioDomainService
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IBeneficioRepository beneficioRepository;

        public FuncionarioDomainService(IFuncionarioRepository funcionarioRepository, 
            IBeneficioRepository beneficioRepository)
           : base(funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
            this.beneficioRepository = beneficioRepository;
        }

        public override Funcionario Insert(Funcionario obj)
        {

            if (funcionarioRepository.GetByCpf(obj.Cpf) == null)
            {
                //pegando a relacao de beneficios oferecida pelo cliente
                var benficiosCliente = funcionarioRepository.GetBeneficioByIdCliente(obj.IdCliente);

                if (benficiosCliente.Count != 0)
                {
                    foreach (var beneficioCliente in benficiosCliente)
                    {
                        //verificando cada beneficio e os parametros exigidos com base no beneficio
                        var beneficio = new Beneficio();
                        beneficio = beneficioRepository.GetById(beneficioCliente.IdBeneficio);

                        var beneficioNome = beneficio.Nome;
                        
                        //validacao dos dados do funcionario com base no beneficio oferecido pela empresa
                        switch (beneficioNome.ToLower())
                        {
                            case "plano de saúde norte europa":
                                if (obj.DataAdmissao == null || obj.Email == "")
                                {
                                    throw new Exception("Para este benefício os campos 'Data de admissão' e 'e-mail' devem estar preenchidos no cadastro do funcionário.");
                                }
                                break;

                            case "plano de saúde pampulha intermédica":
                                if (obj.DataAdmissao == null || obj.Endereco == "")
                                {
                                    throw new Exception("Para este benefício os campos 'Data de admissão' e 'endereço' devem estar preenchidos no cadastro do funcionário.");
                                }
                                break;

                            case "plano odontológico dental sorriso":
                                if (obj.Peso == 0 || obj.Peso == null || obj.Altura == 0 || obj.Altura == null)
                                {
                                    throw new Exception("Para este benefício os campos 'peso' e 'altura' devem estar preenchidos no cadastro do funcionário.");
                                }
                                break;

                            case "plano de saúde mental mente sã, corpo são":
                                if (obj.HorasMeditadas == null)
                                {
                                    throw new Exception("Para este benefício o campo 'horas meditadas' deve estar preenchido no cadastro do funcionário.");
                                }
                                break;
                        }

                    }
                }

                funcionarioRepository.Insert(obj);
                
                return obj;
            }
            else
            {
                throw new Exception("CPF já cadastrado!");
            }

        }

    }
}
