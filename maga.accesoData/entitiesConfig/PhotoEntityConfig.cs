using maga.accessData.contracts.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace maga.accessData.entitiesConfig
{
    public static class PhotoEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PhotoEntity> entityBuilder)
        {
            entityBuilder.ToTable("TB_FOTO");
            entityBuilder.HasKey(p => p.id).HasName("PK_FOTO");
            entityBuilder.Property(p => p.id).IsRequired(true).HasColumnName("id");
            entityBuilder.Property(p => p.title).HasMaxLength(20).HasColumnName("titulo").HasDefaultValue(null);
            entityBuilder.Property(p => p.description).HasMaxLength(200).HasColumnName("descripcion").HasDefaultValue(null);
            entityBuilder.Property(p => p.pathFile).IsRequired(true).HasMaxLength(100).HasColumnName("ruta");
            entityBuilder.Property(p => p.creationDate).IsRequired(true).HasColumnName("fecha_creacion");
            entityBuilder.Property(p => p.userCreation).IsRequired(true).HasColumnName("usuario_creacion");
            entityBuilder.HasOne(e => e.User).WithMany(e => e.photos).HasForeignKey(e => e.userCreation).HasConstraintName("FK_USUARIO_FOTO ").IsRequired();
        }
    }
}
