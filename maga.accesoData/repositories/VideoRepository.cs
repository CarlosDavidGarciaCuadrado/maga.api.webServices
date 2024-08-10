using maga.accesoData.contrato;
using maga.accessData.contracts.entities;
using maga.accessData.contracts.repositories;

namespace maga.accessData.repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly IMagaContext _magaContext;
        public VideoRepository(IMagaContext magaContext) 
        {
            _magaContext = magaContext;
        }
        public async Task<VideoEntity> Add(VideoEntity video)
        {
            await _magaContext.videos.AddAsync(video);
            await _magaContext.SaveChangesAsync();
            return video;
        }

        public async Task<VideoEntity?> DeleteAsync(ulong id)
        {
            VideoEntity? video = await Get(id);
            if (video != null)
            {
                _magaContext.videos.Remove(video);
                await _magaContext.SaveChangesAsync();
            }
            return video;
        }

        public async Task<bool> Exists(ulong id)
        {
            return await Get(id) != null;
        }

        public async Task<VideoEntity?> Get(ulong id)
        {
            return await _magaContext.videos.FindAsync(id);
        }

        public async Task<VideoEntity> Update(VideoEntity video)
        {
            _magaContext.videos.Update(video);
            await _magaContext.SaveChangesAsync();
            return video;
        }
    }
}
