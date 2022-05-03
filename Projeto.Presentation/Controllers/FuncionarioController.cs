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
                funcionarioAppicationService.Insert(model);

                return Ok("Funcionário cadastrado com sucesso.");
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
                funcionarioAppicationService.Update(model);

                return Ok("Funcionário atualizado com sucesso.");
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
                funcionarioAppicationService.Delete(idFuncionario);

                return Ok("Funcionário deletado com sucesso.");
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