using maga.accessData.contracts.entities;
using maga.Bussines;

namespace maga.aplication.contract
{
    public interface IUserService
    {
        Task<UserEntity?> GetUserCurrentLogin();
        UserToShow? GetUserToShow(UserEntity entity);
        Task<UserToShow?> Add(UserToAdd user);
        Task<UserToShow?> Update(UserToShow user);
        Task<UserToShow?> Get(ulong id);
        Task<UserToShow?> DeleteAsync(ulong id);
        Task<UserToShow?> UpdatePassword(RequestUpdatePassword request);
        Task<string> SendCoderecoveryPassword(string email);
        Task<string> RecoveryPassword(RequestRecoveryPassword request);
    }
}
