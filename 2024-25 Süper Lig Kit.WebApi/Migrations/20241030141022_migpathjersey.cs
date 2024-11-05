using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2024_25_Süper_Lig_Kit.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class migpathjersey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Jerseys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Jerseys");
        }
    }
}
