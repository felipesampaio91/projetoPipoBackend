using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Entities;

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
                var beneficio = new Beneficio();
                beneficio = beneficioAppicationService.Insert(model);

                var result = new
                {
                    mensagem = "Benefício cadastrado com sucesso.",
                    beneficio
                };

                return Ok(result);
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
                var beneficio = new BeneficioEdicaoModel();
                beneficio = beneficioAppicationService.Update(model);

                var result = new
                {
                    mensagem = "Benefício atualizado com sucesso.",
                    beneficio
                };

                return Ok(result);
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
                var beneficio = new BeneficioConsultaModel();
                beneficio = beneficioAppicationService.GetById(idBeneficio);

                beneficioAppicationService.Delete(idBeneficio);

                var result = new
                {
                    mensagem = "Benefício excluído com sucesso.",
                    beneficio
                };

                return Ok(result);
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