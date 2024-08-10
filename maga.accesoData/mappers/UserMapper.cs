using maga.accessData.contracts.entities;
using maga.Bussines;

namespace maga.accessData.mappers
{
    public static class UserMapper
    {
        public static UserEntity MapperDtoToEntity(UserToAdd dto)
        {
            UserEntity entity = new UserEntity();
            entity.id = dto.id;
            entity.name = dto.name;
            entity.lastName = dto.lastName;
            entity.birthDate = dto.birthDate;
            entity.familyNickName = dto.familyNickName;
            entity.phone = dto.phone;
            entity.isAdmin = dto.isAdmin;
            entity.email = dto.email;
            entity.password = dto.password;
            entity.idFamily = dto.idFamily;
            return entity;
        }

        public static UserEntity MapperDtoToEntity(UserEntity? entity, UserToShow dto)
        {
            entity = entity ?? new UserEntity();
            entity.id = dto.id;
            entity.name = dto.name;
            entity.lastName = dto.lastName;
            entity.birthDate = dto.birthDate;
            entity.familyNickName = dto.familyNickName;
            entity.phone = dto.phone;
            entity.state = dto.state;
            entity.isAdmin = dto.isAdmin;
            entity.email = dto.email;
            entity.idFamily = dto.idFamily;
            return entity;
        }

        public static UserDto MapperEntityToDto(UserEntity entity)
        {
            UserDto dto = new UserDto();
            dto.id = entity.id;
            dto.name = entity.name;
            dto.lastName = entity.lastName;
            dto.birthDate = entity.birthDate;
            dto.familyNickName = entity.familyNickName;
            dto.phone = entity.phone;
            dto.state = entity.state;
            dto.isAdmin = entity.isAdmin;
            dto.email = entity.email;
            dto.password = entity.password;
            dto.creationDate = entity.creationDate;
            dto.updatedDate = entity.updatedDate;
            dto.idFamily = entity.idFamily;
            return dto;
        }

        public static UserToShow? MapperEntityToUserToShow(UserEntity? entity)
        {
            if (entity == null) return null;
            UserToShow dto = new UserToShow();
            dto.id = entity.id;
            dto.name = entity.name;
            dto.lastName = entity.lastName;
            dto.birthDate = entity.birthDate;
            dto.familyNickName = entity.familyNickName;
            dto.phone = entity.phone;
            dto.state = entity.state;
            dto.isAdmin = entity.isAdmin;
            dto.email = entity.email;
            dto.idFamily = entity.idFamily;
            return dto;
        }
    }
}
