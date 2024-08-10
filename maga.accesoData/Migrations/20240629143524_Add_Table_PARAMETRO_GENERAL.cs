using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maga.accessData.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_PARAMETRO_GENERAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PARAMETRO_GENERAL",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etiqueta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor_cadena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor_entero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GENERIC_PARAMETER", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PARAMETRO_GENERAL");
        }
    }
}
