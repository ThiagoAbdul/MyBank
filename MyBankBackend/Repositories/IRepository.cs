using MyBank.Models;

namespace MyBank.Repositories
{
    public interface IRepository<T> where T: EntityBase
    {
        Task CommitAsync();
        Task<IEnumerable<T>> FindAll();
        Task<T?> FindById(Guid id);
        Task<T> Create(T t);
        Task Delete(Guid id);
    }
}