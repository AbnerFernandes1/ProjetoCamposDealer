using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Interfaces
{
    public interface IProdutoContext
    {
        Task<int> GetCountProdutosAsync();
        Task<Produto[]> GetProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int id);
        Task<Produto[]> GetProdutosAsync(int page, string descricao);
    }
}
