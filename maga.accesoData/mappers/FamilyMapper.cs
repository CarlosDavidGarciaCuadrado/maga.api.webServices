using maga.accessData.contracts.entities;
using maga.negocio;

namespace maga.accessData.mappers
{
    public static class FamilyMapper
    {
        public static FamilyEntity MapperDtoToEntity(FamilyDto dto)
        {
            FamilyEntity entity = new FamilyEntity();
            entity.id = dto.id;
            entity.lastName = dto.lastName;
            entity.description = dto.description;
            entity.password = dto.password;
            return entity;
        }

        public static FamilyDto? MapperEntityToDto(FamilyEntity? entity)
        {
            if (entity == null) return null;
            FamilyDto dto = new FamilyDto();
            dto.id = entity.id;
            dto.lastName = entity.lastName;
            dto.description = entity.description;
            dto.password = entity.password;
            return dto;
        }
    }
}
