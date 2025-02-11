using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<Cliente[]> GetClientesAsync(int page, string name)
        {
            int pageNumber = page <= 0 ? 1 : page;

            IQueryable<Cliente> query = _context.Clientes.AsNoTracking();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.nmCliente.ToUpper().Contains(name.ToUpper()));
            }

            query = query.Skip((pageNumber - 1) * Paginacao.LIMITE_PESQUISA_POR_PAGINA)
                .Take(Paginacao.LIMITE_PESQUISA_POR_PAGINA);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            var cliente = _context.Clientes.AsNoTracking();

            return await cliente.FirstOrDefaultAsync(c => c.idCliente == id);
        }
    }
}
