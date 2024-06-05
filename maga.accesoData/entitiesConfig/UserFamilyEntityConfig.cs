using maga.accessData.contracts.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace maga.accessData.entitiesConfig
{
    public static class UserFamilyEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<UserFamilyEntity> entityBuilder)
        {
            entityBuilder.ToTable("TB_USUARIO_FAMILIA");
            entityBuilder.HasKey(p => p.id).HasName("PK_USUARIO_FAMILIA");
            entityBuilder.Property(p => p.id).IsRequired(true).HasColumnName("id");
            entityBuilder.Property(p => p.idUser).IsRequired(true).HasColumnName("id_usuario").HasDefaultValue(null);
            entityBuilder.Property(p => p.idFamily).IsRequired(true).HasColumnName("id_familia").HasDefaultValue(null);
            entityBuilder.HasOne(p => p.users).WithMany(p => p.userFamily).HasForeignKey(p => p.idUser).HasConstraintName("FK_USUARIOFAMILIA_USUARIO ").IsRequired();
            entityBuilder.HasOne(p => p.families).WithMany(p => p.userFamily).HasForeignKey(p => p.idFamily).HasConstraintName("FK_USUARIOFAMILIA_FAMILIA ").IsRequired();
        }
    }
}
