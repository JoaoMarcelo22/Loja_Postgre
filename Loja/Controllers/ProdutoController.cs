using Loja.Models;
using Loja.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repository;
        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            _repository.AdicionaProduto(produto);
            return await _repository.SaveChangesAsync()
                    ? Ok("Produto adicionado com sucesso")
                    : BadRequest("Erro ao salvar produto");
        } 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _repository.BuscaProdutos();
            return produtos.Any()
                    ? Ok(produtos)
                    :NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _repository.BuscarProduto(id);
            return produto != null
                    ? Ok(produto)
                    :NotFound("Usuario não encontrado");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Produto produto)
        {
            var produtoBanco = await _repository.BuscarProduto(id);
            if(produtoBanco == null) return NotFound("Produto não encontrado");

            produtoBanco.Nome = produto.Nome ?? produtoBanco.Nome;
            
            _repository.AtualizarProduto(produtoBanco);

            return await _repository.SaveChangesAsync()
                            ? Ok("Produto atualizado com sucesso")
                            : BadRequest("Erro ao atualizar produto");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id , Produto produto)
        {
            var produtoBanco = await _repository.BuscarProduto(id);
            if ( produtoBanco == null) return NotFound ("Produto não encontrado");

            _repository.DeletaProduto(produtoBanco);

            return await _repository.SaveChangesAsync()
                                    ? Ok("Produto deletado com sucesso")
                                    : BadRequest("Erro ao deletar produto");
        }
    }
}