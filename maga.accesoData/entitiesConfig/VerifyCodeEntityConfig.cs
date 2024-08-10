using maga.accessData.contracts.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace maga.accessData.entitiesConfig
{
    public class VerifyCodeEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<VerifyCodeEntity> entityBuilder)
        {
            entityBuilder.ToTable("TB_VERIFICACION_CORREO");
            entityBuilder.HasKey(p => p.code).HasName("PK_VERIFY_EMAIL");
            entityBuilder.Property(p => p.code).IsRequired(true).HasColumnName("codigo");
            entityBuilder.Property(p => p.email).IsRequired(true).HasColumnName("email");
            entityBuilder.Property(p => p.expirationDate).IsRequired(true).HasColumnName("fecha_expiracion");
        }
    }
}
