using Loja.Data;
using Loja.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoDbContext _context;
        public ProdutoRepository(ProdutoDbContext context)
        {
            _context = context;
        }
        
        public void AdicionaProduto(Produto produto)
        {
            _context.Add(produto);
        }

        public async Task<IEnumerable<Produto>> BuscaProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> BuscarProduto(int id)
        {
            return await _context.Produtos.
                    Where(x => x.Id == id).
                    FirstOrDefaultAsync();
        }

        public void AtualizarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void DeletaProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}