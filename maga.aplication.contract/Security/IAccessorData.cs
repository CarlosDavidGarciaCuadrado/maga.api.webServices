
using maga.accessData.contracts.entities;
using maga.Bussines;
using System.Security.Claims;

namespace maga.aplication.contract.Security
{
    public interface IAccessorData
    {
        List<Claim> SetClaims(UserEntity user);
        void registerClaims(List<Claim> Claims);
        string GetUserName();
        string GetUserId();
    }
}
