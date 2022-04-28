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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplicationService clienteAppicationService;

        public ClienteController(IClienteApplicationService clienteAppicationService)
        {
            this.clienteAppicationService = clienteAppicationService;
        }

        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model)
        {
            try
            {
                clienteAppicationService.Insert(model);

                return Ok("Cliente cadastrado com sucesso.");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ClienteEdicaoModel model)
        {
            try
            {
                clienteAppicationService.Update(model);

                return Ok("Cliente atualizado com sucesso.");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idOperadora}")]
        public IActionResult Delete(int idCliente)
        {
            try
            {
                clienteAppicationService.Delete(idCliente);

                return Ok("Cliente deletado com sucesso.");
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
                return Ok(clienteAppicationService.GetAll());
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idCliente}")]
        public IActionResult GetById(int idCliente)
        {
            try
            {
                return Ok(clienteAppicationService.GetById(idCliente));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}