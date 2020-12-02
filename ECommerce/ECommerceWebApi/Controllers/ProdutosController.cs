using ECommerceWebApi.Context;
using ECommerceWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebApi.Controllers
{
    [Route("v1/Produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] ECommerceContext contexto)
        {
            /*.Include(d => d.Departamento)*/
            var produtos = await contexto.Produtos.ToListAsync();
            return produtos;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Produto>> GetById([FromServices] ECommerceContext contexto, int codigo)
        {
            var produto = await contexto.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Codigo == codigo);
            return produto;
        }

        [HttpGet]
        [Route("GetByDepartamentos")]
        public async Task<ActionResult<List<Produto>>> GetByDepartamentos([FromServices] ECommerceContext contexto, int codigo)
        {
            var produtos = await contexto.Produtos
                .AsNoTracking()
                .Where(d => d.CodDepartamento == codigo)
                .ToListAsync();
            return produtos;
        }

        [HttpPost]
        [Route("GravarProduto")]
        public async Task<ActionResult<Produto>> GravarProduto(
            [FromServices] ECommerceContext contexto,
            [FromBody] Produto modelo)
        {
            if (ModelState.IsValid)
            {
                contexto.Produtos.Add(modelo);
                await contexto.SaveChangesAsync();
                return modelo;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("ExcluirProduto")]
        public async Task<IActionResult> ExcluirProduto(
            [FromServices] ECommerceContext contexto,
            int codigo)
        {

            var produto = await contexto.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Codigo == codigo);

            if (produto == null)
            {
                return NotFound();
            }

            contexto.Produtos.Remove(produto);
            await contexto.SaveChangesAsync();

            return NoContent();
        }
    }
}