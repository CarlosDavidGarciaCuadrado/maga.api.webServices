
namespace maga.accessData.contracts.repositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Exists(ulong id);
        Task<T?> Get(ulong id);
        Task<T?> DeleteAsync(ulong id);
        Task<T> Update(T element);
        Task<T> Add(T element);
    }
}
