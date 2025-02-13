using ProjetoDealer.Application.Data.Interfaces;

namespace ProjetoDealer.Application.Data.Context
{
    public class PersistenceContext : IPersistenceContext
    {
        private readonly AppDbContext _context;

        public PersistenceContext(AppDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void AddRange<T>(T entity) where T : class
        {
            _context.AddRange(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
