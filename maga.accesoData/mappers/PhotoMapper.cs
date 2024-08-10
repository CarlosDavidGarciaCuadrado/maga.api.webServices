using maga.accessData.contracts.entities;
using maga.Bussines;

namespace maga.accessData.mappers
{
    public static class PhotoMapper
    {
        public static PhotoEntity MapperDtoToEntity(PhotoDto dto)
        {
            PhotoEntity entity = new PhotoEntity();
            entity.id = dto.id;
            entity.title = dto.title;
            entity.description = dto.description;
            entity.pathFile = dto.pathFile;
            entity.userCreation = dto.userCreation;
            entity.creationDate = dto.creationDate;
            return entity;
        }

        public static PhotoDto? MapperEntityToDto(PhotoEntity? entity)
        {
            if (entity == null) return null;
            PhotoDto dto = new PhotoDto();
            dto.id = entity.id;
            dto.title = entity.title;
            dto.description = entity.description;
            dto.pathFile = entity.pathFile;
            dto.userCreation = entity.userCreation;
            dto.creationDate = entity.creationDate;
            return dto;
        }
    }
}
