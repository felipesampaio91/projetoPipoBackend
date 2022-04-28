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
    public class OperadoraController : ControllerBase
    {
        private readonly IOperadoraApplicationService operadoraAppicationService;

        public OperadoraController(IOperadoraApplicationService operadoraAppicationService)
        {
            this.operadoraAppicationService = operadoraAppicationService;
        }

        [HttpPost]
        public IActionResult Post(OperadoraCadastroModel model)
        {
            try
            {
                operadoraAppicationService.Insert(model);

                return Ok("Operadora cadastrada com sucesso.");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(OperadoraEdicaoModel model )
        {
            try
            {
                operadoraAppicationService.Update(model);

                return Ok("Operadora atualizada com sucesso.");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idOperadora}")]
        public IActionResult Delete(int idOperadora)
        {
            try
            {
                operadoraAppicationService.Delete(idOperadora);

                return Ok("Operadora deletada com sucesso.");
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
                return Ok(operadoraAppicationService.GetAll());
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idOperadora}")]
        public IActionResult GetById(int idOperadora)
        {
            try
            {
                return Ok(operadoraAppicationService.GetById(idOperadora));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}