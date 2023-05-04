using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyLopHoc.Migrations
{
    /// <inheritdoc />
    public partial class db07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedDate",
                table: "Subject",
                type: "NTEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NTEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedDate",
                table: "Subject",
                type: "NTEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NTEXT",
                oldNullable: true);
        }
    }
}
