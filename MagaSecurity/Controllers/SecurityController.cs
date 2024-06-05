using maga.accessData.contracts.entities;
using maga.aplication.contract;
using maga.aplication.contract.Security;
using maga.Bussines;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Maga.security.Controllers
{
    [Controller]
    [Route("/Autenthicate/")]
    public class SecurityController : ControllerBase
    {
        private readonly ILogin _login;
        private readonly IUserService _userService;
        private readonly IAccessorData _accessorData;
        private readonly IAccessToken _accessToken;
        private readonly int tokenExpTime = 10;

        public SecurityController(ILogin login, IUserService userService, IAccessToken accessToken, IAccessorData accessorData) 
        {
            _login = login;
            _userService = userService;
            _accessorData = accessorData;
            _accessToken = accessToken;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> RefreshTokenLogin(UserLogin dataUser)
        {
            ResponseToken response = new ResponseToken();
            UserEntity? user = await _login.verifyCredentials(dataUser);
            if (user == null)
            {
                return BadRequest("Por favor verifique sus credenciales. Usuario o contraseña incorrecta.");
            }
            var refresToken = _accessToken.CreateRefreshToken();
            user.refresToken = refresToken;
            user.expirationTokenDate = DateTime.Now.AddMinutes(tokenExpTime);
            await _login.UpdateRefreshToken(user);

            var authClaims = _accessorData.SetClaims(user);
            _accessorData.registerClaims(authClaims);
            var token = _accessToken.CreateAccessToken(authClaims, tokenExpTime);

            response.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            response.RefreshToken = refresToken;
            response.userToShow = _userService.GetUserToShow(user);
            return Ok(response);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RequestToken tokenEntity)
        {
            if (tokenEntity is null)
                return BadRequest("Solicitud no válida");

            var mainClaims = _accessToken.GetPrincipalFromExpiredToken(tokenEntity.AccessToken);
            var user = await validateRequestToken(tokenEntity);

            if (mainClaims == null || user == null)
                return BadRequest("Token de acceso no válido");

            var newAccessToken = _accessToken.CreateAccessToken(mainClaims.Claims.ToList(), tokenExpTime);
            string newRefreshToken = _accessToken.CreateRefreshToken();
            user.refresToken = newRefreshToken;
            user.expirationTokenDate = DateTime.Now.AddMinutes(tokenExpTime);
            await _login.UpdateRefreshToken(user);
            RequestToken response = new RequestToken()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };

            return Ok(response);
        }

        private async Task<UserEntity?> validateRequestToken(RequestToken tokenEntity)
        {
            UserEntity? user = await _userService.GetUserCurrentLogin();
            string userRefreshToken = user?.refresToken ?? string.Empty;
            DateTime? userRefreshTokenExpirationDate = user?.expirationTokenDate ?? DateTime.Now;

            if (string.IsNullOrEmpty(userRefreshToken) || !userRefreshToken.Equals(tokenEntity.RefreshToken) || userRefreshTokenExpirationDate <= DateTime.Now)
            {
                return null;
            }
            return user;
        }
    }
}
