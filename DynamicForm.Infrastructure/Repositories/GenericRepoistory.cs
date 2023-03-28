using DynamicForm.Core.Entities;
using DynamicForm.Core.Interfaces.Repositories;
using DynamicForm.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DynamicForm.Infrastructure.Repositories
{
    public class GenericRepoistory<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> dbSet;
        public GenericRepoistory(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<T> GetById(int id, Expression<Func<T, bool>>? filter = null, string? navigationProperety = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            if (navigationProperety != null)
                query = query.Include(navigationProperety);

            if (filter != null)
                query = query.Where(filter);            

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> Get(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            IncludeProperties(ref query, includeProperties);

            var entity = await query.FirstOrDefaultAsync(filter);

            return entity;
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? navigationProperety = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            if (navigationProperety != null)
                query = query.Include(navigationProperety);

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task SaveContext()
        {
           await _context.SaveChangesAsync();
        }

        public static void IncludeProperties(ref IQueryable<T> query, string? includeProperties)
        {
            if (includeProperties != null)
            {
                var Properties = includeProperties.Split(',');

                foreach (var property in Properties)
                    query.Include(property);
            }
        }
    }
}
