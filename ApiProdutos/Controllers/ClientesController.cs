using ApiProdutos.Models;
using ApiProdutos.Models.Entities.Clientes;
using ApiProdutos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProdutos.Controllers
{
    [Route("v1")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository repos;
        public ClientesController(IClientesRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("Clientes")]
        public async Task<IActionResult> GetAsync([FromServices] _DbContext context)
        {
            var clientes = await context
                .clientes
                .AsNoTracking()
                .ToListAsync();

            return Ok(clientes);
        }

        [HttpGet("Clientes/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] _DbContext context,
            [FromRoute] int id)
        {
            var cliente = await context
                .clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return cliente == null
                ? NotFound()
                : Ok(cliente);
        }

        [HttpPost("clientes")]
        public async Task<IActionResult> PostAsync([FromServices] _DbContext context, [FromBody] PostClientes cliente)
        {
            if (repos.Create(cliente))

                try
                {
                    await context.SaveChangesAsync();
                    return Created("v1/clientes/{cliente.Id}", cliente);
                }
                catch (Exception e)
                {

                    return BadRequest();
                }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromServices] _DbContext context, [FromBody] PostClientes model, [FromRoute] int id)
        {
            var cliente = await context
                    .clientes
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
                return NotFound();

            try
            {
                cliente.Nome = model.Nome;

                context.clientes.Update(cliente);
                await context.SaveChangesAsync();

                return Ok("Alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest($"Não Alterado!");
        }

        [HttpDelete("clientes/{id}")]
        public async Task<IActionResult> DeleteAsync(
                [FromServices] _DbContext context,
                [FromRoute] int id)

        {
            var cliente = await context
                .clientes
                .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.clientes.Remove(cliente);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest();
            }
        }
    }
}


