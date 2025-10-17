using Microsoft.EntityFrameworkCore;

namespace Sprint4.CSharp.WebApi.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _ctx;
        private readonly DbSet<T> _set;
        public EfRepository(DbContext ctx){ _ctx = ctx; _set = _ctx.Set<T>(); }

        public async Task<IEnumerable<T>> GetAllAsync() => await _set.ToListAsync();
        public async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);
        public async Task<IEnumerable<T>> FindAsync(System.Linq.Expressions.Expression<Func<T,bool>> p)
            => await _set.Where(p).ToListAsync();
        public async Task<T> AddAsync(T e){ _set.Add(e); await _ctx.SaveChangesAsync(); return e; }
        public async Task<T> UpdateAsync(T e){ _ctx.Entry(e).State = EntityState.Modified; await _ctx.SaveChangesAsync(); return e; }
        public async Task<bool> DeleteAsync(int id){ var e = await _set.FindAsync(id); if(e==null) return false; _set.Remove(e); await _ctx.SaveChangesAsync(); return true; }
    }
}
