using ProjetoCamposDealer.Services.Interfaces;
using ProjetoDealer.Application.Data.Interfaces;
using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IPersistenceContext _persistence;
        private readonly IClienteContext _context;

        public ClienteService(IPersistenceContext persistence, IClienteContext context)
        {
            _persistence = persistence;
            _context = context;
        }

        public async Task<Cliente> AddAsync(Cliente model)
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

        public async Task<Cliente> UpdateAsync(int id, Cliente model)
        {
            try
            {
                if (model.idCliente != id) return null;

                var cliente = await _context.GetClienteByIdAsync(id);

                if (cliente is null) return null;

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
                var cliente = await _context.GetClienteByIdAsync(id);

                if (cliente is null) return false;

                _persistence.Delete(cliente);

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

        public async Task<Cliente> GetByIdAsync(int id)
        {
            var cliente = await _context.GetClienteByIdAsync(id);
            return cliente;
        }

        public async Task<Cliente[]> GetByPageAndNameAsync(int page, string name)
        {
            var cliente = await _context.GetClientesAsync(page, name);
            return cliente;
        }

        public async Task<int> GetCountClientesAsync(string name)
        {
            return await _context.GetCountClientesAsync(name);
        }
    }
}
