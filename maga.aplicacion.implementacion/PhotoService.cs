using maga.accessData.contracts.entities;
using maga.accessData.contracts.repositories;
using maga.accessData.mappers;
using maga.aplication.contract;
using maga.Bussines;

namespace maga.aplication
{
    public class PhotoService: IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        public PhotoService(IPhotoRepository familyRepository)
        {
            _photoRepository = familyRepository;
        }

        public async Task<ResponseAddOrUpdate<PhotoDto>> Add(PhotoDto photo)
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

        public async Task<PhotoDto?> DeleteAsync(ulong id)
        {
            return PhotoMapper.MapperEntityToDto(await _photoRepository.DeleteAsync(id));
        }

        public async Task<PhotoDto?> Get(ulong id)
        {
            return PhotoMapper.MapperEntityToDto(await _photoRepository.Get(id));
        }

        public PhotoDto? GetPhotoToShow(PhotoEntity? entity)
        {
            return PhotoMapper.MapperEntityToDto(entity);
        }
    }
}
