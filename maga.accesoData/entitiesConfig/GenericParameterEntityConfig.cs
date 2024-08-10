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
    public class GenericParameterEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<GenericParameterEntity> entityBuilder)
        {
            entityBuilder.ToTable("TB_PARAMETRO_GENERAL");
            entityBuilder.HasKey(p => p.id).HasName("PK_GENERIC_PARAMETER");
            entityBuilder.Property(p => p.id).IsRequired(true).HasColumnName("id");
            entityBuilder.Property(p => p.code).IsRequired(true).HasColumnName("codigo");
            entityBuilder.Property(p => p.label).IsRequired(true).HasColumnName("etiqueta");
            entityBuilder.Property(p => p.valueString).HasColumnName("valor_cadena").HasDefaultValue(null);
            entityBuilder.Property(p => p.valueInt).HasColumnName("valor_entero").HasDefaultValue(null);
        }
    }
}
