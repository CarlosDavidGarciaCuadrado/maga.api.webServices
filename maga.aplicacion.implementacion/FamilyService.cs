using maga.accessData.contracts.entities;
using maga.accessData.contracts.repositories;
using maga.accessData.mappers;
using maga.aplication.contract;
using maga.Bussines;
using maga.negocio;

namespace maga.aplicacion
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;
        public FamilyService(IFamilyRepository familyRepository) 
        {
            _familyRepository = familyRepository;
        }

        public async Task<ResponseAddOrUpdate<FamilyDto>> Add(FamilyDto family)
        {
            ResponseAddOrUpdate<FamilyDto> response = new ResponseAddOrUpdate<FamilyDto>();
            FamilyEntity familyEntity = FamilyMapper.MapperDtoToEntity(family);
            familyEntity.updatedDate = DateTime.Now;
            if (family.id > 0 && await _familyRepository.Exists(family.id))
            {
                response.created = false;
                response.identity = GetFamilyToShow(await _familyRepository.Update(familyEntity));
                return response;
            }
            familyEntity.creationDate = DateTime.Now;
            familyEntity.state = 1;
            response.identity = GetFamilyToShow(await _familyRepository.Add(familyEntity));
            return response;
        }

        public async Task<FamilyDto?> DeleteAsync(ulong id)
        {
            return FamilyMapper.MapperEntityToDto(await _familyRepository.DeleteAsync(id));
        }

        public async Task<FamilyDto?> Get(ulong id)
        {
            return FamilyMapper.MapperEntityToDto(await _familyRepository.Get(id));
        }

        public FamilyDto? GetFamilyToShow(FamilyEntity entity)
        {
            return FamilyMapper.MapperEntityToDto(entity);
        }
    }
}
