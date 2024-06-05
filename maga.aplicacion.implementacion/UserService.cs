using maga.accessData.contracts.entities;
using maga.accessData.mappers;
using maga.accessData.repositories;
using maga.aplication.contract;
using maga.aplication.contract.Security;
using maga.Bussines;
using maga.commons.util;

namespace maga.aplication
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccessorData _accessorData;
        public UserService(IUserRepository userRepository, IAccessorData accessorData)
        { 
            _userRepository = userRepository; 
            _accessorData = accessorData;
        }
        public async Task<ResponseAddOrUpdate<UserToShow>> Add(UserToShow user)
        {
            ResponseAddOrUpdate<UserToShow> response = new ResponseAddOrUpdate<UserToShow>();
            UserEntity userEntity = UserMapper.MapperDtoToEntity(user);
            userEntity.updatedDate = DateTime.Now;
            if (user.id > 0 && await _userRepository.Exists(user.id))
            {
                response.created = false;
                response.identity = GetUserToShow(await _userRepository.Update(userEntity));
                return response;
            }
            userEntity.creationDate = DateTime.Now;
            userEntity.state = 1;
            response.identity = GetUserToShow(await _userRepository.Add(userEntity));
            return response;
        }

        public async Task<UserToShow?> DeleteAsync(ulong id)
        {
            return GetUserToShow(await _userRepository.DeleteAsync(id));
        }

        public async Task<UserToShow?> Get(ulong id)
        {
            return UserMapper.MapperEntityToUserToShow(await _userRepository.Get(id));
        }

        public async Task<UserEntity?> GetUserCurrentLogin()
        {
            return await _userRepository.Get(Validations.GetUlongFromString(_accessorData.GetUserId(), 0));
        }

        public UserToShow? GetUserToShow(UserEntity? entity) => UserMapper.MapperEntityToUserToShow(entity);
    }
}
