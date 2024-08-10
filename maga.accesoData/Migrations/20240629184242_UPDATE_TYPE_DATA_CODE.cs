using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maga.accessData.Migrations
{
    /// <inheritdoc />
    public partial class UPDATE_TYPE_DATA_CODE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "valor_entero",
                table: "TB_PARAMETRO_GENERAL",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "valor_entero",
                table: "TB_PARAMETRO_GENERAL",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
