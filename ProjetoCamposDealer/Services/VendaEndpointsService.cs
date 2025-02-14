using Newtonsoft.Json;
using ProjetoCamposDealer.Services.Interfaces;
using ProjetoDealer.Application.Data.Context;
using ProjetoDealer.Application.Data.Interfaces;
using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.Services
{
    public class VendaEndpointsService : IVendaEndpointsService
    {
        private readonly AppDbContext _context;

        public VendaEndpointsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> ObterDadosAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(url);
                return response;
            }
        }

        public async Task<List<Venda>> DesserializarDadosVendas()
        {
            try
            {
                string cliente = await ObterDadosAsync("https://camposdealer.dev/Sites/TesteAPI/cliente");
                string jsonCliente = JsonConvert.DeserializeObject<string>(cliente);
                List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonCliente);

                string produto = await ObterDadosAsync("https://camposdealer.dev/Sites/TesteAPI/produto");
                string jsonProduto = JsonConvert.DeserializeObject<string>(produto);
                List<Produto> produtos = JsonConvert.DeserializeObject<List<Produto>>(jsonProduto);

                string venda = await ObterDadosAsync("https://camposdealer.dev/Sites/TesteAPI/venda");
                string jsonVenda = JsonConvert.DeserializeObject<string>(venda);

                List<Venda> vendas = JsonConvert.DeserializeObject<List<Venda>>(jsonVenda);

                foreach (var item in vendas)
                {
                    var getListaProduto = produtos.Find(p => p.idProduto == item.idProduto);

                    if (item.idProduto == getListaProduto.idProduto)
                    {
                        item.Produtos = getListaProduto;
                    }

                    var getListaCliente = clientes.Find(p => p.idCliente == item.idCliente);

                    if (item.idCliente == getListaCliente.idCliente)
                    {
                        item.Clientes = getListaCliente;
                    }
                }

                foreach(var item in vendas)
                {
                    item.idCliente = 0;
                    item.idProduto = 0;
                    item.idVenda = 0;
                    item.Clientes.idCliente = 0;
                    item.Produtos.idProduto = 0;
                    item.vlrTotalVenda = item.qtdVenda * item.vlrUnitarioVenda;
                }
                
                return vendas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar informações do endpoint, {ex.Message}");
            }
        }

        public async Task<bool> AddVendasExternasAsync()
        {
            try
            {
                var vendas = await DesserializarDadosVendas();
                
                if(vendas is null) return false;

                _context.AddRange(vendas);

                if(await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}