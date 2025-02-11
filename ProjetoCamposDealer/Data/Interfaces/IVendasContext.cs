using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Interfaces
{
    public interface IVendasContext
    {
        Task<Venda> GetVendaByIdAsync(int id);
        Task<Venda[]> GetVendasAsync(int pageNumber);
        Task<Venda[]> GetVendasByNameAsync(string descriptionProduto, string nameCliente);
    }
}
