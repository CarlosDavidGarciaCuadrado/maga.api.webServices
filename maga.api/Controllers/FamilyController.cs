using maga.aplication.contract;
using maga.Bussines;
using maga.commons.util;
using maga.negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace maga.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Maga/Family/")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _familyService;
        public FamilyController(IFamilyService familyService)
        {
            _familyService = familyService;
        }

        [HttpGet("GetById")]
        public async Task<ResponseExcecuteMetod<FamilyDto?>> Get(ulong id) 
        {
            return await ExecuteMetod.RunMetodAsync(_familyService.Get(id), Constant.GET_SUCCESS);
        }


        [HttpPost("CreateOrUpdate")]
        public async Task<ResponseExcecuteMetod<FamilyDto>> Add(FamilyDto family)
        {
            ResponseExcecuteMetod<FamilyDto> response = new ResponseExcecuteMetod<FamilyDto>();
            try
            {
                var responseUser = await _familyService.Add(family);
                response.data = responseUser.identity;
                response.SetState(responseUser.created ? Constant.ADD_SUCCESS : Constant.UPDATE_SUCCESS);
            }
            catch (Exception exception)
            {
                response.LogError(exception);
            }
            return response;
        }

        [HttpDelete("DeleteById")]
        public async Task<ResponseExcecuteMetod<FamilyDto?>> Delete(ulong id)
        {
            return await ExecuteMetod.RunMetodAsync(_familyService.DeleteAsync(id), Constant.DELETE_SUCCESS);
        }
    }
}
