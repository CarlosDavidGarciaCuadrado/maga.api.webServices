using maga.aplication.contract;
using maga.Bussines;
using maga.commons.util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace maga.api.Controllers
{
    [ApiController]
    [Route("api/Maga/User/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("GetById")]
        public async Task<ResponseExcecuteMetod<UserToShow?>> Get(ulong id)
        {
            return await ExecuteMetod.RunMetodAsync(_userService.Get(id), Constant.GET_SUCCESS);
        }

        [HttpPost("CreateOrUpdate")]
        public async Task<ResponseExcecuteMetod<UserToShow>> Add(UserToShow user)
        {
            ResponseExcecuteMetod<UserToShow> response = new ResponseExcecuteMetod<UserToShow>();
            try
            {
                var responseUser = await _userService.Add(user);
                response.data = responseUser.identity;
                response.SetState(responseUser.created ? Constant.ADD_SUCCESS : Constant.UPDATE_SUCCESS);
            }
            catch(Exception exception)
            {
                response.LogError(exception);
            }
            return response;
        }

        [Authorize]
        [HttpDelete("DeleteById")]
        public async Task<ResponseExcecuteMetod<UserToShow?>> Delete(ulong id)
        {
            return await ExecuteMetod.RunMetodAsync(_userService.DeleteAsync(id), Constant.DELETE_SUCCESS);
        }
    } 
}
