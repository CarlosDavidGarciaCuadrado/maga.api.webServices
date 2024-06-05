using maga.accessData.contracts.entities;
using maga.accessData.contracts.repositories;
using maga.Bussines;

namespace maga.accessData.repositories
{
    public interface IUserRepository: IRepository<UserEntity>
    {
        Task<IEnumerable<UserEntity>> GetAll(ulong idFamily);
        Task<UserEntity?> verifyCredentials(UserLogin userLogin);
    }
}
