using ProjetoDealer.Domain;

namespace ProjetoDealer.Services.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> AddAsync(Cliente model);
        Task<Cliente> UpdateAsync(int id, Cliente model);
        Task<bool> DeleteAsync(int id);
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente[]> GetByPageAndNameAsync(int page, string name);
    }
}
