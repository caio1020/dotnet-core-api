using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteApiCaio.Data;
using TesteApiCaio.Models;

namespace TesteApiCaio.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private AppDbContext _appDbContext;

        public ProdutoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
           List<Produto> produtos = await _appDbContext.Produtos.ToListAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            Produto produto = await _appDbContext.Produtos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null) 
                return BadRequest($"O produto para o ID: {id} não foi encontrado!");

            return Ok(produto);
        }

        [HttpPost()]
        public async Task<IActionResult> Cadastrar([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest($"O produto precisa ser informado!");

            Produto buscaProdutoPorNome = await _appDbContext.Produtos
                .FirstOrDefaultAsync(x => x.Nome.ToLower() == produto.Nome.ToLower());

            if (buscaProdutoPorNome != null)
                return BadRequest($"O produto {buscaProdutoPorNome.Nome} já esta cadastrado na base de dados!");

            produto.DataCadastro = DateTime.Now;
            await _appDbContext.Produtos.AddAsync(produto);
            await _appDbContext.SaveChangesAsync();

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(int id, [FromBody] Produto produto)
        {
            Produto produtoDB = await _appDbContext.Produtos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (produtoDB == null)
                return BadRequest($"O produto para o ID: {id} não foi encontrado!");

            Produto buscaProdutoPorNome = await _appDbContext.Produtos
                .FirstOrDefaultAsync(x => x.Nome.ToLower() == produto.Nome.ToLower());

            if (buscaProdutoPorNome != null && buscaProdutoPorNome.Id != id)
                return BadRequest($"O produto {buscaProdutoPorNome.Nome} já esta cadastrado na base de dados!");

            produtoDB.Nome = produto.Nome;
            produtoDB.Preco = produto.Preco;
            produtoDB.Quantidade = produto.Quantidade;
            produtoDB.DataAlteracao = DateTime.Now;

             _appDbContext.Produtos.Update(produtoDB);
             _appDbContext.SaveChanges();

            return Ok(produtoDB);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            Produto produto = await _appDbContext.Produtos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null)
                return BadRequest($"O produto para o ID: {id} não foi encontrado!");

            _appDbContext.Produtos.Remove(produto);
            _appDbContext.SaveChanges();

            return Ok(produto);
        }
    }
}
