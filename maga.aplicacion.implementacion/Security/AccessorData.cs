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
        private ClaimsIdentity? claimsIdentity { get; set; }
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

        public void registerClaims(List<Claim> Claims)
        {
            var identity = new ClaimsIdentity(Claims);
            var principal = new ClaimsPrincipal(identity);
            _httpContextAccessor.HttpContext.User = principal;
            claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        }

        public string GetUserName()
        {
            string response = string.Empty;
            var identity = claimsIdentity;
            int userName = (int)enumClaimTypes.EnumUserName;

            if (identity != null)
            {
                var claim = identity.Claims.FirstOrDefault(x => x.Type.Equals(userName.ToString()));
                response = (claim != null) ? claim.Value : string.Empty;
            }
            return response;
        }

        public string GetUserId()
        {
            string response = string.Empty;
            var identity = claimsIdentity;
            int userId = (int)enumClaimTypes.EnumUserId;

            if (identity != null)
            {
                var claim = identity.Claims.FirstOrDefault(x => x.Type.Equals(userId.ToString()));
                response = (claim != null) ? claim.Value : string.Empty;
            }
            return response;
        }
    }
}
