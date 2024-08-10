using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maga.accessData.Migrations
{
    /// <inheritdoc />
    public partial class update_table_video : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "data_video",
                table: "TB_VIDEO",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_video",
                table: "TB_VIDEO");
        }
    }
}
