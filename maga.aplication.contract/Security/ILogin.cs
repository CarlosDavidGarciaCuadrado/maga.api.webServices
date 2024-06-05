using maga.accessData.contracts.entities;
using maga.Bussines;

namespace maga.aplication.contract.Security
{
    public interface ILogin
    {
        Task<UserEntity?> verifyCredentials(UserLogin user);
        Task<bool> UpdateRefreshToken(UserEntity user);
    }
}
