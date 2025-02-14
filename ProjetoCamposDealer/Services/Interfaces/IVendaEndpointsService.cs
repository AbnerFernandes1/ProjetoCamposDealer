using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.Services.Interfaces
{
    public interface IVendaEndpointsService
    {
        Task<string> ObterDadosAsync(string url);
        Task<List<Venda>> DesserializarDadosVendas();
        Task<bool> AddVendasExternasAsync();
    }
}