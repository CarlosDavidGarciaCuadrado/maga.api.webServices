using maga.accessData.contracts.entities;
using maga.Bussines;

namespace maga.accessData.mappers
{
    public static class VideoMapper
    {
        public static VideoEntity MapperDtoToEntity(VideoDto dto)
        {
            VideoEntity entity = new VideoEntity();
            entity.id = dto.id;
            entity.title = dto.title;
            entity.description = dto.description;
            entity.pathFile = dto.pathFile;
            entity.userCreation = dto.userCreation;
            entity.creationDate = dto.creationDate;
            entity.indexReproduction = dto.indexReproduction;
            entity.videoData = dto.videoData;
            return entity;
        }

        public static VideoDto? MapperEntityToDto(VideoEntity? entity)
        {
            if (entity == null) return null;
            VideoDto dto = new VideoDto();
            dto.id = entity.id;
            dto.title = entity.title;
            dto.description = entity.description;
            dto.pathFile = entity.pathFile;
            dto.userCreation = entity.userCreation;
            dto.creationDate = entity.creationDate;
            dto.indexReproduction = entity.indexReproduction;
            dto.videoData = entity.videoData;
            return dto;
        }
    }
}
