using DynamicForm.Core.Entities;
using System.Linq.Expressions;

namespace DynamicForm.Core.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        void Delete(T entity);
        Task<T> GetById(int id, Expression<Func<T, bool>>? filter = null, string? navigationProperety = null);
        Task<T> Get(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<IList<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? navigationProperety = null);
        Task SaveContext();
    }
}
