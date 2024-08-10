using maga.accessData.contracts.entities;
using maga.aplication.contract;
using maga.aplication.contract.Security;
using maga.Bussines;
using maga.commons.util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Maga.security.Controllers
{ 
    [Route("/Autenthicate/")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ILogin _login;
        private readonly IUserService _userService;
        private readonly IAccessorData _accessorData;
        private readonly IAccessToken _accessToken;
        private readonly ISendEmail _sendEmail;
        private readonly int tokenExpTime = Constant.TOKEN_EXPIRATION_DATE;

        public SecurityController(ILogin login, IUserService userService, IAccessToken accessToken, IAccessorData accessorData, ISendEmail sendEmail) 
        {
            _login = login;
            _userService = userService;
            _accessorData = accessorData;
            _accessToken = accessToken;
            _sendEmail = sendEmail;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin dataUser)
        {

            ResponseToken response = new ResponseToken();
            UserEntity? user = await _login.verifyCredentials(dataUser);
            if (user == null)
            {
                return BadRequest("Por favor verifique sus credenciales. Usuario o contraseña incorrecta.");
            }
            var minutes = await GetMinutesExpiration();
            var refresToken = _accessToken.CreateRefreshToken();
            user.refresToken = refresToken;
            user.expirationTokenDate = DateTime.Now.AddMinutes(minutes);
            await _login.UpdateRefreshToken(user);

            var authClaims = _accessorData.SetClaims(user);
            var token = _accessToken.CreateAccessToken(authClaims, minutes);

            response.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            response.RefreshToken = refresToken;
            response.userToShow = _userService.GetUserToShow(user);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RequestToken tokenEntity)
        {
            if (tokenEntity is null)
                return BadRequest("Solicitud no válida");

            var mainClaims = _accessToken.GetPrincipalFromExpiredToken(tokenEntity.AccessToken);
            UserEntity? userCurrent = await _userService.GetUserCurrentLogin();
            var user = _accessToken.validateRequestToken(tokenEntity, userCurrent);

            if (mainClaims == null || user == null)
                return BadRequest("Token de acceso no válido");
            var minutes = await GetMinutesExpiration();
            var newAccessToken = _accessToken.CreateAccessToken(mainClaims.Claims.ToList(), minutes);
            string newRefreshToken = _accessToken.CreateRefreshToken();
            user.refresToken = newRefreshToken;
            user.expirationTokenDate = DateTime.Now.AddMinutes(minutes);
            await _login.UpdateRefreshToken(user);
            RequestToken response = new RequestToken()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };

            return Ok(response);
        }

        [HttpGet("VerifyEmail")]
        public async Task<ResponseExcecuteMetod<string>> VerifyEmail(string email)
        {
            return await ExecuteMetod.RunMetodAsync(_sendEmail.VerifyEmail(email), Constant.ADD_SUCCESS);
        }

        [HttpPost("SendCodeRecoveryPassword")]
        public async Task<ResponseExcecuteMetod<string>> SendCodeRecoveryPassword(string email)
        {
            return await ExecuteMetod.RunMetodAsync(_userService.SendCoderecoveryPassword(email), Constant.RECOVERY_CODE_PASSWORD_SUCCESS);
        }

        [HttpPost("RecoveryPassword")]
        public async Task<ResponseExcecuteMetod<string>> RecoveryPassword(RequestRecoveryPassword request)
        {
            return await ExecuteMetod.RunMetodAsync(_userService.RecoveryPassword(request), Constant.UPDATE_PASSWORD_SUCCESS);
        }

        private async Task<int> GetMinutesExpiration()
        {
            GenericParameterEntity? tokenExpirationDate = await _accessToken.GetTokenExpirationDate();
            return Convert.ToInt32(tokenExpirationDate != null ? tokenExpirationDate.valueInt : tokenExpTime);
        }
    }
}
