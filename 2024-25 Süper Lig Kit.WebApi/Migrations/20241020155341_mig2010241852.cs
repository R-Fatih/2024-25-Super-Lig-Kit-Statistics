using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2024_25_Süper_Lig_Kit.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig2010241852 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "Jerseys");

            migrationBuilder.DropColumn(
                name: "Shorts",
                table: "Jerseys");

            migrationBuilder.DropColumn(
                name: "Socks",
                table: "Jerseys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Jerseys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Shorts",
                table: "Jerseys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Socks",
                table: "Jerseys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
