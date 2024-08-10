using maga.accesoData.contrato;
using maga.accessData.contracts.entities;
using maga.accessData.entitiesConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace maga.accesoData
{
    public class MagaContext: DbContext, IMagaContext
    {
        public MagaContext() { }

        public MagaContext(DbContextOptions<MagaContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ApiConnection"); //for local use
            }
        }

        public virtual DbSet<FamilyEntity> families { get; set; }
        public virtual DbSet<UserEntity> users { get; set; }
        public virtual DbSet<UserFamilyEntity> userFamilies { get; set; }
        public virtual DbSet<PhotoEntity> photos { get; set; }
        public virtual DbSet<VideoEntity> videos { get; set; }
        public virtual DbSet<VerifyCodeEntity> verifyCodes { get; set; }
        public virtual DbSet<GenericParameterEntity> genericParameters { get; set; }

        public override DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public EntityEntry Update(object entity)
        {
            return base.Update(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FamilyEntityConfig.SetEntityBuilder(modelBuilder.Entity<FamilyEntity>());
            UserEntityConfig.SetEntityBuilder(modelBuilder.Entity<UserEntity>());
            UserFamilyEntityConfig.SetEntityBuilder(modelBuilder.Entity<UserFamilyEntity>());
            PhotoEntityConfig.SetEntityBuilder(modelBuilder.Entity<PhotoEntity>());
            VideoEntityConfig.SetEntityBuilder(modelBuilder.Entity<VideoEntity>());
            VerifyCodeEntityConfig.SetEntityBuilder(modelBuilder.Entity<VerifyCodeEntity>());
            GenericParameterEntityConfig.SetEntityBuilder(modelBuilder.Entity<GenericParameterEntity>());

            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(
                 t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade
             );

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
