using maga.accessData.contracts.entities;

namespace maga.accessData.contracts.repositories
{
    public interface IFamilyRepository: IRepository<FamilyEntity>
    {
        Task<IEnumerable<FamilyEntity>> GetAll();
    }
}
