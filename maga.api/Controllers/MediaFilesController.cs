using maga.aplication.contract;
using maga.Bussines;
using maga.commons.util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace maga.api.Controllers
{
    [Authorize]
    [Route("api/MediaFile")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaFileService _mediaFileService;

        public MediaController(IMediaFileService mediaFileService)
        {
            _mediaFileService = mediaFileService;
        }

        [HttpPost("uploadImage")]
        public async Task<ResponseExcecuteMetod<string>> UploadImage(FileRequestDto requestFile)
        {
            ResponseExcecuteMetod<string> response = new ResponseExcecuteMetod<string>();
            try
            {
                var responseMedia = await _mediaFileService.uploadImage(requestFile);
                response.data = responseMedia.identity;
                response.SetState(responseMedia.created ? Constant.ADD_SUCCESS : Constant.UPDATE_SUCCESS);
            }
            catch (Exception exception)
            {
                response.LogError(exception);
            }
            return response;
        }

        [HttpPost("uploadVideo")]
        public async Task<ResponseExcecuteMetod<string>> UploadVideo(FileRequestDto requestFile)
        {
            ResponseExcecuteMetod<string> response = new ResponseExcecuteMetod<string>();
            try
            {
                var responseMedia = await _mediaFileService.uploadVideo(requestFile);
                response.data = responseMedia.identity;
                response.SetState(responseMedia.created ? Constant.ADD_SUCCESS : Constant.UPDATE_SUCCESS);
            }
            catch (Exception exception)
            {
                response.LogError(exception);
            }
            return response;
        }
    }
}

