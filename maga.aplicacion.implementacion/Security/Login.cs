using maga.accessData.contracts.entities;
using maga.accessData.repositories;
using maga.aplication.contract.Security;
using maga.Bussines;

namespace maga.aplication.Security
{
    public class Login: ILogin
    {
        private readonly IUserRepository _userRepository;
        public Login(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<UserEntity?> verifyCredentials (UserLogin user)
        {
            return await _userRepository.verifyCredentials(user);
        }

        public async Task<bool> UpdateRefreshToken(UserEntity user)
        {
            return await _userRepository.Update(user) != null;
        }
    }
}
