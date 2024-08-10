using maga.accesoData.contrato;
using maga.accessData.contracts.entities;
using maga.Bussines;
using maga.commons.util;

namespace maga.accessData.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMagaContext _magaContext;
        public UserRepository(IMagaContext magaContext)
        {
            _magaContext = magaContext;
        }
        public async Task<UserEntity> Add(UserEntity user)
        {
            try
            {
                await _magaContext.users.AddAsync(user);
                await _magaContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw GenericExceptionHelper.SqlException(Constant.ADD_ERROR, exception);
            }
            return user;
        }

        public async Task<UserEntity?> DeleteAsync(ulong id)
        {
            UserEntity? user = await Get(id);
            if (user != null)
            {
                try 
                {
                    _magaContext.users.Remove(user);
                    await _magaContext.SaveChangesAsync();
                }
                catch (Exception exception) 
                {
                    throw GenericExceptionHelper.SqlException(Constant.DELETE_ERROR, exception);
                }
            }
            return user;
        }

        public async Task<bool> Exists(ulong id)
        {
            return await Get(id) != null;
        }

        public async Task<bool> ExistsEmail(string email)
        {
            return await GetUserByEmail(email) != null;
        }

        public async Task<UserEntity?> Get(ulong id)
        {
            return await _magaContext.users.FindAsync(id);
        }

        public Task<IEnumerable<UserEntity>> GetAll(ulong idFamily) => 
            Task.FromResult<IEnumerable<UserEntity>>(_magaContext.users.Where(user => user.idFamily == idFamily));

        public async Task<UserEntity> Update(UserEntity user)
        {
            try 
            {
                _magaContext.Update(user);
                await _magaContext.SaveChangesAsync();
            }
            catch(Exception exception) 
            {
                throw GenericExceptionHelper.SqlException(Constant.UPDATE_ERROR, exception);
            }
            return user;
        }

        public Task<UserEntity?> verifyCredentials(UserLogin userLogin)
        {
            return Task.FromResult(_magaContext.users.FirstOrDefault(user => user.email == userLogin.userName && user.state == 1));
        }

        public Task<UserEntity?> GetUserByEmail(string email)
        {
            return Task.FromResult(_magaContext.users.FirstOrDefault(user => user.email == email));
        }
    }
}
