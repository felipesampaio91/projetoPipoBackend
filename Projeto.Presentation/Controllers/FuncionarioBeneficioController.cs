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

        public FuncionarioBeneficioController(IFuncionarioBeneficioApplicationService funcionarioBeneficioAppicationService)
        {
            this.funcionarioBeneficioAppicationService = funcionarioBeneficioAppicationService;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioBeneficioCadastroModel model)
        {
            try
            {
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
