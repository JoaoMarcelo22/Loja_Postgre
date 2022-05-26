using Loja.Models;

namespace Loja.Repository
{
    public interface IProdutoRepository
    {
         Task<IEnumerable<Produto>> BuscaProdutos();
         Task<Produto> BuscarProduto(int id);
         void AdicionaProduto(Produto produto);
         void AtualizarProduto(Produto produto);
         void DeletaProduto(Produto produto);
         Task<bool> SaveChangesAsync();
    }
}