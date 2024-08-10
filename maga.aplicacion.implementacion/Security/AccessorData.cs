using maga.accessData.contracts.entities;
using maga.aplication.contract.Security;
using maga.Bussines;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace maga.commons.util
{
    public class AccessorData: IAccessorData
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccessorData(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Claim> SetClaims(UserEntity user)
        {
            int id = (int)enumClaimTypes.EnumUserId;
            int userName = (int)enumClaimTypes.EnumUserName;

            return new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(id.ToString(), user.id.ToString() ?? ""),
                            new Claim(userName.ToString(), user.email ?? "")
                        };
        }

        public string GetUserName()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(((int)enumClaimTypes.EnumUserName).ToString())?.Value ?? string.Empty;
        }

        public string GetUserId()
        { 
            return _httpContextAccessor.HttpContext?.User?.FindFirst(((int)enumClaimTypes.EnumUserId).ToString())?.Value ?? string.Empty;
        }
    }
}
