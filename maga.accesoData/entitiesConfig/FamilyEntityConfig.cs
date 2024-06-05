using maga.accessData.contracts.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace maga.accessData.entitiesConfig
{
    public static class FamilyEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<FamilyEntity> entityBuilder)
        {
            entityBuilder.ToTable("TB_FAMILIA");
            entityBuilder.HasKey(p => p.id).HasName("PK_FAMILIA");
            entityBuilder.Property(p => p.id).IsRequired(true).HasColumnName("id");
            entityBuilder.Property(p => p.lastName).IsRequired(true).HasMaxLength(20).HasColumnName("apellido");
            entityBuilder.Property(p => p.description).HasMaxLength(200).HasColumnName("descripcion").HasDefaultValue(null);
            entityBuilder.Property(p => p.password).IsRequired(true).HasColumnName("contrasena");
            entityBuilder.Property(p => p.state).IsRequired(true).HasColumnName("estado");
            entityBuilder.Property(p => p.idUserCreation).HasColumnName("id_usuario_creacion");
            entityBuilder.Property(p => p.creationDate).HasColumnName("fecha_creacion").HasDefaultValue(null);
            entityBuilder.Property(p => p.updatedDate).HasColumnName("fecha_actualizacion").HasDefaultValue(null);
        }
    }
}
