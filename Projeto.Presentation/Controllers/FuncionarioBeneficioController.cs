using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioBeneficioController : ControllerBase
    {
        private readonly IFuncionarioBeneficioApplicationService funcionarioBeneficioAppicationService;
        private readonly IBeneficioApplicationService beneficioAppicationService;
        private readonly IFuncionarioApplicationService funcionarioAppicationService;

        public FuncionarioBeneficioController(
            IFuncionarioBeneficioApplicationService funcionarioBeneficioAppicationService,
            IBeneficioApplicationService beneficioAppicationService,
            IFuncionarioApplicationService funcionarioAppicationService)

        {
            this.funcionarioBeneficioAppicationService = funcionarioBeneficioAppicationService;
            this.beneficioAppicationService = beneficioAppicationService;
            this.funcionarioAppicationService = funcionarioAppicationService;
        }

       

        [HttpPost]
        public IActionResult Post(FuncionarioBeneficioCadastroModel model)
        {
            try
            {
                var benefico = beneficioAppicationService.GetById(model.IdBeneficio);
                var funcionario = funcionarioAppicationService.GetById(model.IdFuncionario);

                switch (benefico.Nome)
                {
                    case "Plano de Saúde NorteEuropa":
                        if(funcionario.DataAdmissao == null || funcionario.Email == null)
                        {
                            throw new Exception("Para este benefício os campos Data de admissão e e-mail devem estar preenchidos no cadastro do funcionário.");
                        }
                        break;

                    case "Plano de saúde Pampulha Intermédica":
                        if (funcionario.DataAdmissao == null || funcionario.Endereco == null)
                        {
                            throw new Exception("Para este benefício os campos Data de admissão e endereço devem estar preenchidos no cadastro do funcionário.");
                        }
                        break;

                    case "Plano odontológico Dental Sorriso":
                        if (funcionario.Peso == 0 || funcionario.Altura == 0)
                        {
                            throw new Exception("Para este benefício os campos peso e altura devem estar preenchidos no cadastro do funcionário.");
                        }
                        break;

                    case "Plano de saúde mental Mente Sã, Corpo São":
                        if (funcionario.HorasMeditadas == null)
                        {
                            throw new Exception("Para este benefício o campo horas meditadas deve estar preenchido no cadastro do funcionário.");
                        }
                        break;
                }



                //if(benefico.Nome == "Plano de Saúde NorteEuropa")
                //{
                //    var funcionario = funcionarioAppicationService.GetById(model.IdFuncionario);


                //}





                funcionarioBeneficioAppicationService.Insert(model);

                var funcionarioBeneficio = new FuncionarioBeneficio();

                funcionarioBeneficio.IdFuncionario = model.IdFuncionario;
                funcionarioBeneficio.IdBeneficio = model.IdBeneficio;

                var result = new
                {
                    mensagem = "Funcionário-Bebefício cadastrado com sucesso.",
                    funcionarioBeneficio
                };

                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(FuncionarioBeneficioEdicaoModel model)
        {
            try
            {
                funcionarioBeneficioAppicationService.Update(model);

                return Ok("Funcionário-Bebefício atualizado com sucesso.");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idFuncionarioBeneficio}")]
        public IActionResult Delete(int idFuncionarioBeneficio)
        {
            try
            {
                funcionarioBeneficioAppicationService.Delete(idFuncionarioBeneficio);

                return Ok("Funcionário-Bebefício deletado com sucesso.");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(funcionarioBeneficioAppicationService.GetAll());
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idFuncionarioBeneficio}")]
        public IActionResult GetById(int idFuncionarioBeneficio)
        {
            try
            {
                return Ok(funcionarioBeneficioAppicationService.GetById(idFuncionarioBeneficio));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
