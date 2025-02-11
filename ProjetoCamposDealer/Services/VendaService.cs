using ProjetoCamposDealer.Models;
using ProjetoCamposDealer.Services.Interfaces;
using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.Services
{
    public class VendaService : IVendaService
    {
        public Task<Venda> AddAsync(VendaViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Venda> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Venda[]> GetByPageAndNameAndDescriptionAsync(int page, string name, string descricao)
        {
            throw new NotImplementedException();
        }

        public Task<Venda> UpdateAsync(int id, VendaViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}