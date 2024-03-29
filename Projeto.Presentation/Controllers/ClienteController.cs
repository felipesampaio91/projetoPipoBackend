﻿using System;
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
                var cliente = new Cliente();
                cliente = clienteAppicationService.Insert(model);

                var result = new
                {
                    mensagem = "Cliente cadastrado com sucesso.",
                    cliente
                };

                return Ok(result);
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
                var cliente = new ClienteEdicaoModel();
                cliente = clienteAppicationService.Update(model);

                var result = new
                {
                    mensagem = "Cliente atualizado com sucesso.",
                    cliente
                };

                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idCliente}")]
        public IActionResult Delete(int idCliente)
        {
            try
            {
                var cliente = new ClienteConsultaModel();
                cliente = clienteAppicationService.GetById(idCliente);

                clienteAppicationService.Delete(idCliente);

                var result = new
                {
                    mensagem = "Cliente excluído com sucesso.",
                    cliente
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