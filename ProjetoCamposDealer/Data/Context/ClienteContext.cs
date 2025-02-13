using Microsoft.EntityFrameworkCore;
using ProjetoDealer.Application.Constantes;
using ProjetoDealer.Application.Data.Interfaces;
using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Context
{
    public class ClienteContext : IClienteContext
    {
        private readonly AppDbContext _context;

        public ClienteContext(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente[]> GetClientesAsync()
        {
            var Clientes = await _context.Clientes.AsNoTracking().ToArrayAsync();
            return Clientes;
        }

        public async Task<Cliente[]> GetClientesAsync(int page, string name)
        {
            if(page <= 0 || string.IsNullOrEmpty(name) == false)
            {
                page = 1;
            }

            IQueryable<Cliente> query = _context.Clientes.AsNoTracking();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.nmCliente.ToUpper().Contains(name.ToUpper()));
            }

            query = query.Skip((page - 1) * Paginacao.LIMITE_PESQUISA_POR_PAGINA)
                .Take(Paginacao.LIMITE_PESQUISA_POR_PAGINA);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            var cliente = _context.Clientes.AsNoTracking();

            return await cliente.FirstOrDefaultAsync(c => c.idCliente == id);
        }

        public async Task<int> GetCountClientesAsync(string name)
        {
            IQueryable<Venda> query = _context.Vendas
                .Include(v => v.Produtos)
                .Include(v => v.Clientes);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Produtos.dscProduto
                    .ToUpper().Contains(name.ToUpper()));
            }

            return await _context.Clientes.CountAsync();
        }
    }
}
