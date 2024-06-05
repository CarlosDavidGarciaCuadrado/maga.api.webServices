using maga.accesoData.contrato;
using maga.accessData.contracts.entities;
using maga.accessData.contracts.repositories;

namespace maga.accessData.repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IMagaContext _magaContext;
        public PhotoRepository(IMagaContext magaContext) 
        { 
            _magaContext = magaContext;
        }
        public async Task<PhotoEntity> Add(PhotoEntity photo)
        {
            await _magaContext.photos.AddAsync(photo);
            await _magaContext.SaveChangesAsync();
            return photo;
        }

        public async Task<PhotoEntity?> DeleteAsync(ulong id)
        {
            PhotoEntity? photo = await Get(id);
            if (photo != null)
            {
                _magaContext.photos.Remove(photo);
                await _magaContext.SaveChangesAsync();
            }
            return photo;
        }

        public async Task<bool> Exists(ulong id)
        {
            return await Get(id) != null;
        }

        public async Task<PhotoEntity?> Get(ulong id)
        {
            return await _magaContext.photos.FindAsync(id);
        }

        public Task<IEnumerable<PhotoEntity>> GetAll(ulong idUser) =>
            Task.FromResult<IEnumerable<PhotoEntity>>(_magaContext.photos.Where(photo => photo.userCreation == idUser));

        public async Task<PhotoEntity> Update(PhotoEntity photo)
        {
            _magaContext.photos.Update(photo);
            await _magaContext.SaveChangesAsync();
            return photo;
        }
    }
}
