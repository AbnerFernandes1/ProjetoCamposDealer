using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.Services.Interfaces
{
    public interface IClienteService
    {
        Task<int> GetCountClientesAsync(string name);
        Task<Cliente> AddAsync(Cliente model);
        Task<Cliente> UpdateAsync(int id, Cliente model);
        Task<bool> DeleteAsync(int id);
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente[]> GetByPageAndNameAsync(int page, string name);
    }
}
