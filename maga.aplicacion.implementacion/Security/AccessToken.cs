using maga.accessData.contracts.entities;
using maga.accessData.contracts.repositories;
using maga.aplication.contract.Security;
using maga.Bussines;
using maga.commons.util;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace maga.aplication.Security
{
    public class AccessToken: IAccessToken
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericParemeterRepository _genericParameterRepository;

        public AccessToken(IConfiguration configuration, IGenericParemeterRepository genericParameterRepository)
        {
            _configuration = configuration;
            _genericParameterRepository = genericParameterRepository;
        }

        public JwtSecurityToken CreateAccessToken(List<Claim> authClaims, int tokenExpTime)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? ""));
            return new JwtSecurityToken(
                            expires: DateTime.Now.AddMinutes(tokenExpTime),
                            claims: authClaims,
                            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );
        }

        public string CreateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? "")),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Token no válido");

            return principal;
        }

        public UserEntity? validateRequestToken(RequestToken tokenEntity, UserEntity? user)
        {
            string userRefreshToken = user?.refresToken ?? string.Empty;
            DateTime? userRefreshTokenExpirationDate = user?.expirationTokenDate ?? DateTime.Now;

            if (string.IsNullOrEmpty(userRefreshToken) || !userRefreshToken.Equals(tokenEntity.RefreshToken) || userRefreshTokenExpirationDate <= DateTime.Now)
            {
                return null;
            }
            return user;
        }

        public async Task<GenericParameterEntity?> GetTokenExpirationDate()
        {
            return await _genericParameterRepository.GetParamByCodeAndLabel(Constant.CODE_GENERIC_PARAM, Constant.EXPIRATION_TOKEN_GENERIC_PARAM);
        }
    }
}
