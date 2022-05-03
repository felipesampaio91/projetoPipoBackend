using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Entities;
using Projeto.Application.Services;

namespace Projeto.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteBeneficioController : ControllerBase
    {
        private readonly IClienteBeneficioApplicationService clienteBeneficioAppicationService;

        public ClienteBeneficioController(IClienteBeneficioApplicationService clienteBeneficioAppicationService)
        {
            this.clienteBeneficioAppicationService = clienteBeneficioAppicationService;
        }

        [HttpPost]
        public IActionResult Post(ClienteBeneficioCadastroModel model)
        {
            try
            {
                clienteBeneficioAppicationService.Insert(model);

                var clienteBebeficio = new ClienteBeneficio();

                clienteBebeficio.IdCliente = model.IdCliente;
                clienteBebeficio.IdBeneficio = model.IdBeneficio;

                var result = new
                {
                    mensagem = "Cliente-Bebefício cadastrado com sucesso.",
                    clienteBebeficio
                };

                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ClienteBeneficioEdicaoModel model)
        {
            try
            {
                clienteBeneficioAppicationService.Update(model);

                return Ok("Cliente-Bebefício atualizado com sucesso.");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idClienteBeneficio}")]
        public IActionResult Delete(int idClienteBeneficio)
        {
            try
            {
                clienteBeneficioAppicationService.Delete(idClienteBeneficio);

                return Ok("Cliente-Bebefício deletado com sucesso.");
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
                return Ok(clienteBeneficioAppicationService.GetAll());
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idClienteBeneficio}")]
        public IActionResult GetById(int idClienteBeneficio)
        {
            try
            {
                return Ok(clienteBeneficioAppicationService.GetById(idClienteBeneficio));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
