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

        public async Task<Produto[]> GetProdutosAsync()
        {
            var produtos = await _context.Produtos.AsNoTracking().ToArrayAsync();
            return produtos;
        }

        public async Task<Produto[]> GetProdutosAsync(int page, string descricao)
        {
            if(page <= 0 || string.IsNullOrEmpty(descricao) == false)
            {
                page = 1;
            }
            IQueryable<Produto> query = _context.Produtos.AsNoTracking();

            if (!string.IsNullOrEmpty(descricao))
            {
                query = query.Where(c => c.dscProduto.ToUpper().Contains(descricao.ToUpper()));
            }

            query = query.Skip((page - 1) * Paginacao.LIMITE_PESQUISA_POR_PAGINA)
                .Take(Paginacao.LIMITE_PESQUISA_POR_PAGINA);

            return await query.ToArrayAsync();
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            var produto = _context.Produtos.AsNoTracking();

            return await produto.FirstOrDefaultAsync(p => p.idProduto == id);
        }

        public async Task<int> GetCountProdutosAsync(string descricao)
        {
            IQueryable<Venda> query = _context.Vendas
                .Include(v => v.Produtos)
                .Include(v => v.Clientes);

            if (!string.IsNullOrEmpty(descricao))
            {
                query = query.Where(p => p.Produtos.dscProduto
                    .ToUpper().Contains(descricao.ToUpper()));
            }

            return await _context.Produtos.CountAsync();
        }
    }
}
