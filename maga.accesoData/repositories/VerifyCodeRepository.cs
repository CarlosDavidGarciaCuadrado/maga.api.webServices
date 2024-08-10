using maga.accesoData.contrato;
using maga.accessData.contracts.entities;
using maga.accessData.contracts.repositories;
using maga.commons.util;

namespace maga.accessData.repositories
{
    public class VerifyCodeRepository : IVerifyCodeRepository
    {
        private readonly IMagaContext _magaContext;
        public VerifyCodeRepository(IMagaContext magaContext) 
        { 
            _magaContext = magaContext;
        }
        public async Task<VerifyCodeEntity> Add(VerifyCodeEntity entity)
        {
            try
            {
                await _magaContext.verifyCodes.AddAsync(entity);
                await _magaContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw GenericExceptionHelper.SqlException(Constant.ADD_ERROR, exception);
            }
            return entity;
        }

        public async Task<VerifyCodeEntity?> DeleteAsync(string email)
        {
            VerifyCodeEntity? entity = await Get(email);
            if (entity != null)
            {
                try
                {
                    _magaContext.verifyCodes.Remove(entity);
                    await _magaContext.SaveChangesAsync();
                }
                catch (Exception exception)
                {
                    throw GenericExceptionHelper.SqlException(Constant.DELETE_ERROR, exception);
                }
            }
            return entity;
        }

        public Task<VerifyCodeEntity?> Get(string email)
        {
            var entity = Task.FromResult(_magaContext.verifyCodes.FirstOrDefault(entity => entity.email == email));
            return entity;
        }
    }
}
