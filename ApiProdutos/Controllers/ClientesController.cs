using ApiProdutos.Models.Entities.Clientes;
using ApiProdutos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
            private readonly IClientesRepository repos;
            public ClientesController(IClientesRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(PostClientes cliente)
        {
            if(repos.Create(cliente))
            return Ok("Adicionado com Sucesso!");

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

    }
}
