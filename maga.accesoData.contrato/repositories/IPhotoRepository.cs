using maga.accessData.contracts.entities;

namespace maga.accessData.contracts.repositories
{
    public interface IPhotoRepository: IRepository<PhotoEntity>
    {
        Task<IEnumerable<PhotoEntity>> GetAll(ulong idUser);
    }
}
