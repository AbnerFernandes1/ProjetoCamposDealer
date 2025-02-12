using Microsoft.EntityFrameworkCore;
using ProjetoDealer.Application.Constantes;
using ProjetoDealer.Application.Data.Interfaces;
using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Context
{
    public class VendaContext : IVendaContext
    {
        private readonly AppDbContext _context;

        public VendaContext(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Venda> GetVendaByIdAsync(int id)
        {
            var venda = _context.Vendas.AsNoTracking()
                .Include(v => v.Clientes)
                .Include(v => v.Produtos);

            return await venda.FirstOrDefaultAsync(v => v.idVenda == id);

        }

        public async Task<Venda[]> GetVendasByPageByNamesAsync(int page, string nameCliente, string descriptionProduto)
        {
            int pageNumber = page <= 0 ? 1 : page;

            IQueryable<Venda> query = _context.Vendas
                .Include(v => v.Produtos)
                .Include(v => v.Clientes);

            if (!string.IsNullOrEmpty(descriptionProduto))
            {
                query = query.Where(p => p.Produtos.dscProduto
                    .ToUpper().Contains(descriptionProduto.ToUpper()));
            }

            if (!string.IsNullOrEmpty(nameCliente))
            {
                query = query.Where(p => p.Clientes.nmCliente
                    .ToUpper().Contains(nameCliente.ToUpper()));
            }

            query = query.Skip((pageNumber - 1) * Paginacao.LIMITE_PESQUISA_POR_PAGINA)
                .Include(v => v.Produtos)
                .Include(v => v.Clientes)
                .Take(Paginacao.LIMITE_PESQUISA_POR_PAGINA);

            return await query.ToArrayAsync();
        }
    }
}
