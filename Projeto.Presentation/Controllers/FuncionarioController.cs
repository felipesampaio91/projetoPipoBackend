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
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioApplicationService funcionarioAppicationService;

        public FuncionarioController(IFuncionarioApplicationService funcionarioAppicationService)
        {
            this.funcionarioAppicationService = funcionarioAppicationService;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioCadastroModel model)
        {
            try
            {
                var funcionario = new Funcionario();
                funcionario = funcionarioAppicationService.Insert(model);

                var result = new
                {
                    mensagem = "Funcionário cadastrado com sucesso.",
                    funcionario
                };

                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(FuncionarioEdicaoModel model)
        {
            try
            {
                var funcionario = funcionarioAppicationService.Update(model);

                var result = new
                {
                    mensagem = "Funcionário atualizado com sucesso.",
                    funcionario
                };

                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idFuncionario}")]
        public IActionResult Delete(int idFuncionario)
        {
            try
            {
                var funcionario = funcionarioAppicationService.GetById(idFuncionario);

                funcionarioAppicationService.Delete(idFuncionario);

                var result = new
                {
                    mensagem = "Funcionário excluído com sucesso.",
                    funcionario
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
                return Ok(funcionarioAppicationService.GetAll());
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idFuncionario}")]
        public IActionResult GetById(int idFuncionario)
        {
            try
            {
                return Ok(funcionarioAppicationService.GetById(idFuncionario));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}