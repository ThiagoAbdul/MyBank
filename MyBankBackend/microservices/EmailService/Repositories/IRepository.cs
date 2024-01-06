namespace EmailService.Repositories;

public interface IRepository<T>
{
    Task<T> CreateAsync(T t);
    Task<T?> FindByIdAsync(string id);
}