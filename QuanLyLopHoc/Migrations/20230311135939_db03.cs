using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyLopHoc.Migrations
{
    /// <inheritdoc />
    public partial class db03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_PostType_TypeId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserInfo_UserId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "PostType");

            migrationBuilder.DropIndex(
                name: "IX_Post_TypeId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Post",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_UserId",
                table: "Post",
                newName: "IX_Post_CreatorId");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Transcript",
                type: " CHAR(32)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Subject",
                type: " CHAR(32)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DiemTB",
                table: "DetailTranscript",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Transcript_CreatorId",
                table: "Transcript",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CreatorId",
                table: "Subject",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_UserInfo_CreatorId",
                table: "Post",
                column: "CreatorId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_UserInfo_CreatorId",
                table: "Subject",
                column: "CreatorId",
                principalTable: "UserInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transcript_UserInfo_CreatorId",
                table: "Transcript",
                column: "CreatorId",
                principalTable: "UserInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserInfo_CreatorId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_UserInfo_CreatorId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Transcript_UserInfo_CreatorId",
                table: "Transcript");

            migrationBuilder.DropIndex(
                name: "IX_Transcript_CreatorId",
                table: "Transcript");

            migrationBuilder.DropIndex(
                name: "IX_Subject_CreatorId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Transcript");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "DiemTB",
                table: "DetailTranscript");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Post",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CreatorId",
                table: "Post",
                newName: "IX_Post_UserId");

            migrationBuilder.CreateTable(
                name: "PostType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "NVARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_TypeId",
                table: "Post",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_PostType_TypeId",
                table: "Post",
                column: "TypeId",
                principalTable: "PostType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_UserInfo_UserId",
                table: "Post",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
