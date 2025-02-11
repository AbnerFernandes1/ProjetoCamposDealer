using Microsoft.EntityFrameworkCore;
using ProjetoDealer.Application.Constantes;
using ProjetoDealer.Application.Data.Interfaces;
using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Context
{
    public class ProdutoContext : IProdutoContext
    {
        private readonly AppDbContext _context;

        public ProdutoContext(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto[]> GetProdutosAsync(int page, string descricao)
        {
            int pageNumber = page <= 0 ? 1 : page;

            IQueryable<Produto> query = _context.Produtos.AsNoTracking();

            if (!string.IsNullOrEmpty(descricao))
            {
                query = query.Where(c => c.dscProduto.ToUpper().Contains(descricao.ToUpper()));
            }

            query = query.Skip((pageNumber - 1) * Paginacao.LIMITE_PESQUISA_POR_PAGINA)
                .Take(Paginacao.LIMITE_PESQUISA_POR_PAGINA);

            return await query.ToArrayAsync();
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            var produto = _context.Produtos.AsNoTracking();

            return await produto.FirstOrDefaultAsync(p => p.idProduto == id);
        }
    }
}
