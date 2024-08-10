using maga.accessData.contracts.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maga.accessData.entitiesConfig
{
    public class VideoEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<VideoEntity> entityBuilder)
        {
            entityBuilder.ToTable("TB_VIDEO");
            entityBuilder.HasKey(p => p.id).HasName("PK_VIDEO");
            entityBuilder.Property(p => p.id).IsRequired(true).HasColumnName("id");
            entityBuilder.Property(p => p.title).HasMaxLength(20).HasColumnName("titulo").HasDefaultValue(null);
            entityBuilder.Property(p => p.description).HasMaxLength(200).HasColumnName("descripcion").HasDefaultValue(null);
            entityBuilder.Property(p => p.pathFile).IsRequired(true).HasMaxLength(100).HasColumnName("ruta");
            entityBuilder.Property(p => p.creationDate).IsRequired(true).HasColumnName("fecha_creacion");
            entityBuilder.Property(p => p.userCreation).IsRequired(true).HasColumnName("usuario_creacion");
            entityBuilder.Property(p => p.indexReproduction).IsRequired(true).HasColumnName("index_reproduccion");
            entityBuilder.Property(p => p.videoData).IsRequired(true).HasColumnName("data_video");
            entityBuilder.HasOne(e => e.User).WithMany(e => e.videos).HasForeignKey(e => e.userCreation).HasConstraintName("FK_USUARIO_VIDEO ").IsRequired();
        }
    }
}
