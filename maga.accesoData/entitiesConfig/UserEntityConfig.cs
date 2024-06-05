using maga.accessData.contracts.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace maga.accessData.entitiesConfig
{
    public static class UserEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.ToTable("TB_USUARIO");
            entityBuilder.HasKey(p => p.id).HasName("PK_USUARIO");
            entityBuilder.Property(p => p.id).IsRequired(true).HasColumnName("id");
            entityBuilder.Property(p => p.name).IsRequired(true).HasMaxLength(20).HasColumnName("nombre");
            entityBuilder.Property(p => p.lastName).IsRequired(true).HasColumnName("apellido");
            entityBuilder.Property(p => p.birthDate).IsRequired(true).HasColumnName("fecha_nacimiento");  
            entityBuilder.Property(p => p.familyNickName).HasMaxLength(200).HasColumnName("apodo_familiar").HasDefaultValue(null);
            entityBuilder.Property(p => p.phone).IsRequired(true).HasColumnName("telefono");
            entityBuilder.Property(p => p.email).IsRequired(true).HasMaxLength(200).HasColumnName("correo");
            entityBuilder.Property(p => p.state).IsRequired(true).HasColumnName("estado");
            entityBuilder.Property(p => p.isAdmin).IsRequired(true).HasColumnName("es_admin");
            entityBuilder.Property(p => p.idFamily).IsRequired(true).HasColumnName("id_familia");
            entityBuilder.Property(p => p.password).IsRequired(true).HasColumnName("contrasena");
            entityBuilder.Property(p => p.creationDate).IsRequired(true).HasColumnName("fecha_creacion");
            entityBuilder.Property(p => p.updatedDate).IsRequired(true).HasColumnName("fecha_actualizacion");
            entityBuilder.Property(p => p.token).HasColumnName("token").HasDefaultValue(null);
            entityBuilder.Property(p => p.expirationTokenDate).HasColumnName("fecha_exp_token").HasDefaultValue(null);
            entityBuilder.Property(p => p.refresToken).HasColumnName("refresh_token").HasDefaultValue(null);
        }
    }
}
