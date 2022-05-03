using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;

namespace Projeto.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficioController : ControllerBase
    {
        private readonly IBeneficioApplicationService beneficioAppicationService;

        public BeneficioController(IBeneficioApplicationService beneficioAppicationService)
        {
            this.beneficioAppicationService = beneficioAppicationService;
        }

        [HttpPost]
        public IActionResult Post(BeneficioCadastroModel model)
        {
            try
            {
                beneficioAppicationService.Insert(model);

                return Ok("Benefício cadastrado com sucesso.");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(BeneficioEdicaoModel model)
        {
            try
            {
                beneficioAppicationService.Update(model);

                return Ok("Benefício atualizado com sucesso.");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idBeneficio}")]
        public IActionResult Delete(int idBeneficio)
        {
            try
            {
                beneficioAppicationService.Delete(idBeneficio);

                return Ok("Benefício deletado com sucesso.");
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
                return Ok(beneficioAppicationService.GetAll());
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idBeneficio}")]
        public IActionResult GetById(int idBeneficio)
        {
            try
            {
                return Ok(beneficioAppicationService.GetById(idBeneficio));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}