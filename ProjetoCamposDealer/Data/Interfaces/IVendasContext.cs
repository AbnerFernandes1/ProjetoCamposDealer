using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Interfaces
{
    public interface IVendasContext
    {
        Task<Venda> GetVendaByIdAsync(int id);
        Task<Venda[]> GetVendasByPageByNamesAsync(int page, string nameCliente, string descriptionProduto);
    }
}
