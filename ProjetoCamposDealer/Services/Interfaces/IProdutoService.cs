using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> AddAsync(Produto model);
        Task<Produto> UpdateAsync(int id, Produto model);
        Task<bool> DeleteAsync(int id);
        Task<Produto> GetByIdAsync(int id);
        Task<Produto[]> GetByPageAndNameAsync(int page, string name);
    }
}
