using maga.accessData.contracts.entities;
using maga.Bussines;

namespace maga.aplication.contract
{
    public interface IUserService: IService<UserToShow>
    {
        Task<UserEntity?> GetUserCurrentLogin();
        UserToShow GetUserToShow(UserEntity entity);
    }
}
