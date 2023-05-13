using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyLopHoc.Migrations
{
    /// <inheritdoc />
    public partial class db12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "UserInfo",
                type: "NTEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NCHAR(255)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "UserInfo",
                type: "NCHAR(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NTEXT",
                oldNullable: true);
        }
    }
}
