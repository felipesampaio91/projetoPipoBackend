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
        public IActionResult Post(List<ClienteBeneficioCadastroModel> listaClienteBeneficio)
        {
            try
            {
                var listaClienteBeneficioResponse = new List<ClienteBeneficio>();
                listaClienteBeneficioResponse = clienteBeneficioAppicationService.Insert(listaClienteBeneficio);

                foreach (var clienteBeneficio in listaClienteBeneficioResponse)
                {
                    var result = new
                    {
                        mensagem = "Cliente-Beneficio cadastrado com sucesso.",
                        clienteBeneficio
                    };

                    return Ok(result);
                }

                return Ok();
                
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
                var clienteBeneficio = new ClienteBeneficioEdicaoModel();
                clienteBeneficio = clienteBeneficioAppicationService.Update(model);

                var result = new
                {
                    mensagem = "Cliente-Beneficio atualizado com sucesso.",
                    clienteBeneficio
                };

                return Ok(result);
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
                    var clienteBeneficio = new ClienteBeneficioConsultaModel();
                    clienteBeneficio = clienteBeneficioAppicationService.GetById(idClienteBeneficio);

                    clienteBeneficioAppicationService.Delete(idClienteBeneficio);

                    var result = new
                    {
                        mensagem = "Cliente-Beneficio excluído com sucesso.",
                        clienteBeneficio
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
