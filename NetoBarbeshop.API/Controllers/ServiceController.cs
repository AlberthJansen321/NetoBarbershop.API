using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetoBarbershop.Application.Interfaces;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace NetoBarbershop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceApplication _serviceApplication;
        public ServiceController(IServiceApplication serviceApplication,IGeralRepository IGeralRepository)
        {
            _serviceApplication = serviceApplication;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var resultado = await _serviceApplication.GetAllServicesAsync(true);
                if (resultado == null) return NotFound("Nenhum serviço foi encontrado");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao retorna os serviços. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var resultado = await _serviceApplication.GetServiceByIdAsync(id,true);
                if (resultado == null) return NotFound("Nenhum serviço foi encontrado");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao retorna os serviços. Erro: {ex.Message}");
            }
        }
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GetByNome(string nome)
        {
            
            try
            {
                var resultado = await _serviceApplication.GetServiceByNomeAsync(nome, true);
                if (resultado == null) return NotFound("Nenhum serviço foi encontrado");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao retorna os serviços. Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post(Service model)
        {
            try
            {
                var resultado = await _serviceApplication.AddService(model);
                if (resultado == null) return BadRequest("Não foi possivél cadastrar o serviço");

                return Ok(resultado);
                  
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao cadastrar o serviço. Erro: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,Service model)
        {
            try
            {
                var resultado = await _serviceApplication.UpdateService(id,model);
                if (resultado == null)  return BadRequest("Não foi possivel alterar o serviço");
           
                
                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao alterar o serviço. Erro: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return await _serviceApplication.DeleteService(id) ? Ok("Deletado") : BadRequest("Não foi possivel deletar o serviço");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar o serviço. Erro: {ex.Message}");
            }
        }
    }
}
