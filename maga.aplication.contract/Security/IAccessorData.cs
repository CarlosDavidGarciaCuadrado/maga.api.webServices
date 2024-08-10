
using maga.accessData.contracts.entities;
using maga.Bussines;
using System.Security.Claims;

namespace maga.aplication.contract.Security
{
    public interface IAccessorData
    {
        List<Claim> SetClaims(UserEntity user);
        string GetUserName();
        string GetUserId();
    }
}
