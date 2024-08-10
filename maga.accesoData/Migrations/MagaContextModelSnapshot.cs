﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using maga.accesoData;

#nullable disable

namespace maga.accessData.Migrations
{
    [DbContext(typeof(MagaContext))]
    partial class MagaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("maga.accessData.contracts.entities.FamilyEntity", b =>
                {
                    b.Property<decimal>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("id"));

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_creacion");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("descripcion");

                    b.Property<decimal>("idUserCreation")
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("id_usuario_creacion");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("apellido");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contrasena");

                    b.Property<byte>("state")
                        .HasColumnType("tinyint")
                        .HasColumnName("estado");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_actualizacion");

                    b.HasKey("id")
                        .HasName("PK_FAMILIA");

                    b.ToTable("TB_FAMILIA", (string)null);
                });

            modelBuilder.Entity("maga.accessData.contracts.entities.GenericParameterEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("codigo");

                    b.Property<string>("label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("etiqueta");

                    b.Property<long>("valueInt")
                        .HasColumnType("bigint")
                        .HasColumnName("valor_entero");

                    b.Property<string>("valueString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("valor_cadena");

                    b.HasKey("id")
                        .HasName("PK_GENERIC_PARAMETER");

                    b.ToTable("TB_PARAMETRO_GENERAL", (string)null);
                });

            modelBuilder.Entity("maga.accessData.contracts.entities.PhotoEntity", b =>
                {
                    b.Property<decimal>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("id"));

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_creacion");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("descripcion");

                    b.Property<string>("pathFile")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ruta");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("titulo");

                    b.Property<decimal>("userCreation")
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("usuario_creacion");

                    b.HasKey("id")
                        .HasName("PK_FOTO");

                    b.HasIndex("userCreation");

                    b.ToTable("TB_FOTO", (string)null);
                });

            modelBuilder.Entity("maga.accessData.contracts.entities.UserEntity", b =>
                {
                    b.Property<decimal>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("id"));

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_nacimiento");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_creacion");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("correo");

                    b.Property<DateTime>("expirationTokenDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_exp_token");

                    b.Property<string>("familyNickName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("apodo_familiar");

                    b.Property<decimal>("idFamily")
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("id_familia");

                    b.Property<byte>("isAdmin")
                        .HasColumnType("tinyint")
                        .HasColumnName("es_admin");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("apellido");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("nombre");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contrasena");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("telefono");

                    b.Property<string>("refresToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("refresh_token");

                    b.Property<byte>("state")
                        .HasColumnType("tinyint")
                        .HasColumnName("estado");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("token");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_actualizacion");

                    b.HasKey("id")
                        .HasName("PK_USUARIO");

                    b.ToTable("TB_USUARIO", (string)null);
                });

            modelBuilder.Entity("maga.accessData.contracts.entities.UserFamilyEntity", b =>
                {
                    b.Property<decimal>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("id"));

                    b.Property<decimal>("idFamily")
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("id_familia");

                    b.Property<decimal>("idUser")
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("id_usuario");

                    b.HasKey("id")
                        .HasName("PK_USUARIO_FAMILIA");

                    b.HasIndex("idFamily");

                    b.HasIndex("idUser");

                    b.ToTable("TB_USUARIO_FAMILIA", (string)null);
                });

            modelBuilder.Entity("maga.accessData.contracts.entities.VerifyCodeEntity", b =>
                {
                    b.Property<string>("code")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("codigo");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<DateTime>("expirationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_expiracion");

                    b.HasKey("code")
                        .HasName("PK_VERIFY_EMAIL");

                    b.ToTable("TB_VERIFICACION_CORREO", (string)null);
                });

            modelBuilder.Entity("maga.accessData.contracts.entities.VideoEntity", b =>
                {
                    b.Property<decimal>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("id"));

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_creacion");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("descripcion");

                    b.Property<int>("indexReproduction")
                        .HasColumnType("int")
                        .HasColumnName("index_reproduccion");

                    b.Property<string>("pathFile")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ruta");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("titulo");

                    b.Property<decimal>("userCreation")
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("usuario_creacion");

                    b.Property<byte[]>("videoData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("data_video");

                    b.HasKey("id")
                        .HasName("PK_VIDEO");

                    b.HasIndex("userCreation");

                    b.ToTable("TB_VIDEO", (string)null);
                });

            modelBuilder.Entity("maga.accessData.contracts.entities.PhotoEntity", b =>
                {
                    b.HasOne("maga.accessData.contracts.entities.UserEntity", "User")
                        .WithMany("photos")
                        .HasForeignKey("userCreation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_USUARIO_FOTO ");

                    b.Navigation("User");
                });

            modelBuilder.Entity("maga.accessData.contracts.entities.UserFamilyEntity", b =>
                {
                    b.HasOne("maga.accessData.contracts.entities.FamilyEntity", "families")
                        .WithMany("userFamily")
                        .HasForeignKey("idFamily")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_USUARIOFAMILIA_FAMILIA ");

                    b.HasOne("maga.accessData.contracts.entities.UserEntity", "users")
                        .WithMany("userFamily")
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_USUARIOFAMILIA_USUARIO ");

                    b.Navigation("families");

                    b.Navigation("users");
                });

            modelBuilder.Entity("maga.accessData.contracts.entities.VideoEntity", b =>
                {
                    b.HasOne("maga.accessData.contracts.entities.UserEntity", "User")
                        .WithMany("videos")
                        .HasForeignKey("userCreation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_USUARIO_VIDEO ");

                    b.Navigation("User");
                });

            modelBuilder.Entity("maga.accessData.contracts.entities.FamilyEntity", b =>
                {
                    b.Navigation("userFamily");
                });

            modelBuilder.Entity("maga.accessData.contracts.entities.UserEntity", b =>
                {
                    b.Navigation("photos");

                    b.Navigation("userFamily");

                    b.Navigation("videos");
                });
#pragma warning restore 612, 618
        }
    }
}
