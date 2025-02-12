using ProjetoCamposDealer.Models;
using ProjetoCamposDealer.Services.Interfaces;
using ProjetoDealer.Application.Data.Interfaces;
using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.Services
{
    public class VendaService : IVendaService
    {
        private readonly IPersistenceContext _persistence;
        private readonly IProdutoContext _produtoContext;
        private readonly IClienteContext _clienteContext;
        private readonly IVendaContext _vendasContext;

        public VendaService(IPersistenceContext persistence,
                            IProdutoContext produtoContext,
                            IClienteContext clienteContext,
                            IVendaContext vendasContext)
        {
            _persistence = persistence;
            _produtoContext = produtoContext;
            _clienteContext = clienteContext;
            _vendasContext = vendasContext;
        }

        public async Task<Venda> AddAsync(VendaViewModel model)
        {
            try
            {
                var produto = await _produtoContext.GetProdutoByIdAsync(model.idProduto);

                var venda = new Venda
                {
                    idCliente = model.idCliente,
                    idProduto = model.idProduto,
                    qtdVenda = model.qtdVenda,
                    vlrTotalVenda = produto.vlrUnitario.Value * model.qtdVenda,
                    vlrUnitarioVenda = produto.vlrUnitario.Value,
                };

                _persistence.Add(venda);

                if(await _persistence.SaveChangesAsync())
                {
                    return venda;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public async Task<Venda> UpdateAsync(int id, Venda model)
        {
            try
            {
                if (model.idVenda != id) return null;

                var venda = await _vendasContext.GetVendaByIdAsync(id);

                if (venda is null) return null;

                _persistence.Update(model);

                if (await _persistence.SaveChangesAsync())
                {
                    return model;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Venda> GetByIdAsync(int id)
        {
            var venda = await _vendasContext.GetVendaByIdAsync(id);
            return venda;
        }

        public async Task<Venda[]> GetByPageAndNameAndDescriptionAsync(int page, string name, string description)
        {
            var Venda = await _vendasContext.GetVendasByPageByNamesAsync(page, name, description);
            return Venda;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var venda = await _vendasContext.GetVendaByIdAsync(id);

                if (venda is null) return false;

                _persistence.Delete(venda);

                if (await _persistence.SaveChangesAsync())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VendaViewModel> GetViewModelVendaAsync(int id = 0)
        {
            var viewModel = new VendaViewModel();

            if(id > 0)
            {
                var venda = await _vendasContext.GetVendaByIdAsync(id);
                var produtos = await _produtoContext.GetProdutoByIdAsync(venda.idProduto);
                var clientes = await _clienteContext.GetClienteByIdAsync(venda.idCliente);

                viewModel = new VendaViewModel
                {
                    ClientesLista = await _clienteContext.GetClientesAsync(),
                    ProdutosLista = await _produtoContext.GetProdutosAsync(),
                    idVenda = venda.idVenda,
                    idProduto = venda.idProduto,
                    idCliente = venda.idCliente,
                    vlrTotalVenda = venda.vlrTotalVenda,
                    vlrUnitarioVenda = venda.vlrUnitarioVenda,
                    qtdVenda = venda.qtdVenda,
                    Produtos = produtos,
                    Clientes = clientes,
                };
            }
            else
            {
                viewModel = new VendaViewModel
                {
                    ClientesLista = await _clienteContext.GetClientesAsync(),
                    ProdutosLista = await _produtoContext.GetProdutosAsync(),
                };
            }

            return viewModel;
        }
    }
}