

using maga.Bussines;

namespace maga.aplication.contract
{
    public interface IService<T> where T : class
    {
        Task<T?> Get(ulong id);
        Task<T?> DeleteAsync(ulong id);
        Task<ResponseAddOrUpdate<T>> Add(T element);
    }
}
