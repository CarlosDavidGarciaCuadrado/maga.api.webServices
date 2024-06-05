using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maga.accessData.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_FAMILIA",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_usuario_creacion = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    estado = table.Column<byte>(type: "tinyint", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_actualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAMILIA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    apodo_familiar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<byte>(type: "tinyint", nullable: false),
                    es_admin = table.Column<byte>(type: "tinyint", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_actualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_familia = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    refresh_token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_exp_token = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_FOTO",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ruta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuario_creacion = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOTO", x => x.id);
                    table.ForeignKey(
                        name: "FK_USUARIO_FOTO ",
                        column: x => x.usuario_creacion,
                        principalTable: "TB_USUARIO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO_FAMILIA",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    id_familia = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_FAMILIA", x => x.id);
                    table.ForeignKey(
                        name: "FK_USUARIOFAMILIA_FAMILIA ",
                        column: x => x.id_familia,
                        principalTable: "TB_FAMILIA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIOFAMILIA_USUARIO ",
                        column: x => x.id_usuario,
                        principalTable: "TB_USUARIO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_FOTO_usuario_creacion",
                table: "TB_FOTO",
                column: "usuario_creacion");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_FAMILIA_id_familia",
                table: "TB_USUARIO_FAMILIA",
                column: "id_familia");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_FAMILIA_id_usuario",
                table: "TB_USUARIO_FAMILIA",
                column: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_FOTO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO_FAMILIA");

            migrationBuilder.DropTable(
                name: "TB_FAMILIA");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
