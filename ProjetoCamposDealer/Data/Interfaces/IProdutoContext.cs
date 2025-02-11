using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Interfaces
{
    public interface IProdutoContext
    {
        Task<Produto> GetProdutoByIdAsync(int id);
        Task<Produto[]> GetProdutosAsync(int page, string descricao);
    }
}
