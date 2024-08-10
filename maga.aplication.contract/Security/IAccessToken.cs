using maga.accessData.contracts.entities;
using maga.Bussines;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace maga.aplication.contract.Security
{
    public interface IAccessToken
    {
        JwtSecurityToken CreateAccessToken(List<Claim> authClaims, int tokenExpTime);
        string CreateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string? token);
        UserEntity? validateRequestToken(RequestToken tokenEntity, UserEntity? user);
        Task<GenericParameterEntity?> GetTokenExpirationDate();
    }
}
