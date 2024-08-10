using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maga.accessData.Migrations
{
    /// <inheritdoc />
    public partial class add_table_video : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_VIDEO",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ruta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuario_creacion = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    index_reproduccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIDEO", x => x.id);
                    table.ForeignKey(
                        name: "FK_USUARIO_VIDEO ",
                        column: x => x.usuario_creacion,
                        principalTable: "TB_USUARIO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_VIDEO_usuario_creacion",
                table: "TB_VIDEO",
                column: "usuario_creacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_VIDEO");
        }
    }
}
