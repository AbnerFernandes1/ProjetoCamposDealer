using ProjetoCamposDealer.Models;
using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.Services.Interfaces
{
    public interface IVendaService
    {
        Task<Venda> AddAsync(VendaViewModel model);
        Task<Venda> UpdateAsync(int id, VendaViewModel model);
        Task<bool> DeleteAsync(int id);
        Task<Venda> GetByIdAsync(int id);
        Task<Venda[]> GetByPageAndNameAndDescriptionAsync(int page, string name, string descricao);
    }
}