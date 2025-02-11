using ProjetoDealer.Application.Data.Interfaces;
using ProjetoDealer.Domain;
using ProjetoDealer.Services.Interfaces;

namespace ProjetoDealer.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IPersistenceContext _persistence;
        private readonly IProdutoContext _context;

        public ProdutoService(IPersistenceContext persistence, IProdutoContext context)
        {
            _persistence = persistence;
            _context = context;
        }

        public async Task<Produto> AddAsync(Produto model)
        {
            try
            {
                _persistence.Add(model);

                if(await _persistence.SaveChangesAsync())
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

        public async Task<Produto> UpdateAsync(int id, Produto model)
        {
            try
            {
                if (model.idProduto != id) return null;

                var produto = await _context.GetProdutoByIdAsync(id);

                if (produto is null) return null;

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

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var produto = await _context.GetProdutoByIdAsync(id);

                if (produto is null) return false;

                _persistence.Delete(produto);

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

        public async Task<Produto> GetByIdAsync(int id)
        {
            var produto = await _context.GetProdutoByIdAsync(id);
            return produto;
        }

        public async Task<Produto[]> GetByPageAndNameAsync(int page, string name)
        {
            var cliente = await _context.GetProdutosAsync(page, name);
            return cliente;
        }
    }
}
