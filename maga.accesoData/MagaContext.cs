using maga.accesoData.contrato;
using maga.accessData.contracts.entities;
using maga.accessData.entitiesConfig;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FamilyEntityConfig.SetEntityBuilder(modelBuilder.Entity<FamilyEntity>());
            UserEntityConfig.SetEntityBuilder(modelBuilder.Entity<UserEntity>());
            UserFamilyEntityConfig.SetEntityBuilder(modelBuilder.Entity<UserFamilyEntity>());
            PhotoEntityConfig.SetEntityBuilder(modelBuilder.Entity<PhotoEntity>());

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
