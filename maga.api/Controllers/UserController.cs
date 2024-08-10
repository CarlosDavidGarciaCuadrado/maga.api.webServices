using maga.aplication.contract;
using maga.Bussines;
using maga.commons.util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace maga.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Maga/User/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetById")]
        public async Task<ResponseExcecuteMetod<UserToShow?>> Get(ulong id)
        {
            return await ExecuteMetod.RunMetodAsync(_userService.Get(id), Constant.GET_SUCCESS);
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<ResponseExcecuteMetod<UserToShow?>> Add(UserToAdd user)
        {
            return await ExecuteMetod.RunMetodAsync(_userService.Add(user), Constant.ADD_SUCCESS);
        }

        [HttpPost("Update")]
        public async Task<ResponseExcecuteMetod<UserToShow?>> Update(UserToShow user)
        {
            return await ExecuteMetod.RunMetodAsync(_userService.Update(user), Constant.UPDATE_SUCCESS);
        }

        [HttpPost("UpdatePassword")]
        public async Task<ResponseExcecuteMetod<UserToShow?>> UpdatePassword(RequestUpdatePassword request)
        {
            return await ExecuteMetod.RunMetodAsync(_userService.UpdatePassword(request), Constant.UPDATE_PASSWORD_SUCCESS);
        }

        [HttpDelete("DeleteById")]
        public async Task<ResponseExcecuteMetod<UserToShow?>> Delete(ulong id)
        {
            return await ExecuteMetod.RunMetodAsync(_userService.DeleteAsync(id), Constant.DELETE_SUCCESS);
        }
    } 
}
