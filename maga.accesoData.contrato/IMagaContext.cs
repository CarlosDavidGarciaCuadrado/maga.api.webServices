using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using maga.accessData.contracts.entities;

namespace maga.accesoData.contrato
{
    public interface IMagaContext
    {
        DbSet<FamilyEntity> families { get; set; }
        DbSet<UserEntity> users { get; set; }
        DbSet<UserFamilyEntity> userFamilies { get; set; }
        DbSet<PhotoEntity> photos { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        EntityEntry Update(object entity);
        void RemoveRange(IEnumerable<object> entities);
    }
}
