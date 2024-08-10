using maga.accessData.contracts.entities;
using maga.accessData.contracts.repositories;
using maga.accessData.mappers;
using maga.aplication.contract;
using maga.aplication.contract.Security;
using maga.Bussines;
using maga.commons.util;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace maga.aplication
{
    public class MediaFileService: IMediaFileService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IAccessorData _accessorData;
        private readonly string? _imagePath;

        public MediaFileService(IVideoRepository videoRepository, IPhotoRepository familyRepository, IAccessorData accessorData, IConfiguration configuration)
        {
            _videoRepository = videoRepository;
            _photoRepository = familyRepository;
            _accessorData = accessorData;
            _imagePath = configuration["Media:ImageSavePath"];
            if (!Directory.Exists(_imagePath))
            {
                Directory.CreateDirectory(_imagePath ?? "");
            }
        }

        public async Task<ResponseAddOrUpdate<string>> uploadVideo(FileRequestDto requestFile)
        {
            ResponseAddOrUpdate<string> result = new ResponseAddOrUpdate<string>();
            IFormFile file = requestFile.file;

            if (file == null || file.Length == 0)
            {
                throw GenericExceptionHelper.GenerateException("No file uploaded.");
            }

            VideoDto videoDto = new VideoDto() 
            {
                title = requestFile.title,
                description = requestFile.description,
                pathFile = "",
                creationDate = DateTime.Now,
                userCreation = Validations.GetUlongFromString(_accessorData.GetUserId(), 0),
                videoData = await ConvertFileToBytes(requestFile.file),
                indexReproduction = requestFile.indexReproduction
            };
            var videoResp = await AddVideo(videoDto);
            result.identity = "Video Guardado exitosamente.";
            result.created = videoResp.created;
            return result;
        }

        public async Task<ResponseAddOrUpdate<string>> uploadImage(FileRequestDto requestFile)
        {
            ResponseAddOrUpdate<string> result = new ResponseAddOrUpdate<string>();
            IFormFile file = requestFile.file;

            if (file == null || file.Length == 0)
            {
                throw GenericExceptionHelper.GenerateException("No file uploaded.");
            }
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
            {
                throw GenericExceptionHelper.GenerateException("La imagen debe tener un formato válido: jpg, jpeg, png.");
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_imagePath ?? "", fileName);

            PhotoDto photoDto = new PhotoDto()
            {
                title = requestFile.title,
                description = requestFile.description,
                pathFile = filePath,
                creationDate = DateTime.Now,
                userCreation = Validations.GetUlongFromString(_accessorData.GetUserId(), 0),
            };
            await saveImage(file, filePath);
            var photoResp = await AddPhoto(photoDto);
            result.identity = "Foto Guardada exitosamente.";
            result.created = photoResp.created;
            return result;
        }

        public async Task<ResponseAddOrUpdate<VideoDto>> AddVideo(VideoDto video)
        {
            ResponseAddOrUpdate<VideoDto> response = new ResponseAddOrUpdate<VideoDto>();
            VideoEntity videoEntity = VideoMapper.MapperDtoToEntity(video);
            if (video.id > 0 && await _videoRepository.Exists(video.id))
            {
                response.created = false;
                response.identity = GetVideoToShow(await _videoRepository.Update(videoEntity));
                return response;
            }
            videoEntity.creationDate = DateTime.Now; 
            response.identity = GetVideoToShow(await _videoRepository.Add(videoEntity));
            return response;
        }

        public async Task<VideoDto?> DeleteVideoAsync(ulong id)
        {
            return VideoMapper.MapperEntityToDto(await _videoRepository.DeleteAsync(id));
        }

        public async Task<VideoDto?> GetVideo(ulong id)
        {
            return VideoMapper.MapperEntityToDto(await _videoRepository.Get(id));
        }

        public VideoDto? GetVideoToShow(VideoEntity? video)
        {
            return VideoMapper.MapperEntityToDto(video);
        }

        public async Task<ResponseAddOrUpdate<PhotoDto>> AddPhoto(PhotoDto photo)
        {
            ResponseAddOrUpdate<PhotoDto> response = new ResponseAddOrUpdate<PhotoDto>();
            PhotoEntity photoEntity = PhotoMapper.MapperDtoToEntity(photo);
            if (photo.id > 0 && await _photoRepository.Exists(photo.id))
            {
                response.created = false;
                response.identity = GetPhotoToShow(await _photoRepository.Update(photoEntity));
                return response;
            }
            photoEntity.creationDate = DateTime.Now;
            response.identity = GetPhotoToShow(await _photoRepository.Add(photoEntity));
            return response;
        }

        public async Task<PhotoDto?> DeletePhotoAsync(ulong id)
        {
            return PhotoMapper.MapperEntityToDto(await _photoRepository.DeleteAsync(id));
        }

        public async Task<PhotoDto?> GetPhoto(ulong id)
        {
            return PhotoMapper.MapperEntityToDto(await _photoRepository.Get(id));
        }

        private PhotoDto? GetPhotoToShow(PhotoEntity? entity)
        {
            return PhotoMapper.MapperEntityToDto(entity);
        }

        private async Task<byte[]> ConvertFileToBytes(IFormFile file)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        private async Task saveImage(IFormFile file, string filePath)
        {
            try
            {
                var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);
            }
            catch (Exception ex)
            {
                throw GenericExceptionHelper.GenerateException("Hubo un error al guardar la imagen. " + ex.Message);
            }
        }
    }
}
