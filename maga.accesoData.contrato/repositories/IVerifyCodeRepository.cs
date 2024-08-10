using maga.accessData.contracts.entities;

namespace maga.accessData.contracts.repositories
{
    public interface IVerifyCodeRepository
    {
        Task<VerifyCodeEntity> Add(VerifyCodeEntity entity);
        Task<VerifyCodeEntity?> DeleteAsync(string email);
        Task<VerifyCodeEntity?> Get(string email);
    }
}
