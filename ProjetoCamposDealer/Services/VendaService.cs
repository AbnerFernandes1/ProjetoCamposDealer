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
        private readonly IVendasContext _vendasContext;

        public VendaService(IPersistenceContext persistence,
                            IProdutoContext produtoContext,
                            IVendasContext vendasContext)
        {
            _persistence = persistence;
            _produtoContext = produtoContext;
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
                throw new Exception(ex.Message);
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
            var cliente = await _vendasContext.GetVendaByIdAsync(id);
            return cliente;
        }

        public async Task<Venda[]> GetByPageAndNameAndDescriptionAsync(int page, string name, string descricao)
        {
            var Venda = await _vendasContext.GetVendasByPageByNamesAsync(page, name, descricao);
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
    }
}