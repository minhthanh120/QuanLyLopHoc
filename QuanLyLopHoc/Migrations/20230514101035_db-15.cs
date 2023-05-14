using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyLopHoc.Migrations
{
    /// <inheritdoc />
    public partial class db15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Post_PostId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_UserInfo_StudentRepId",
                table: "Replies");

            migrationBuilder.DropTable(
                name: "DetailRollCall");

            migrationBuilder.DropTable(
                name: "RollCall");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Replies",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Replies_StudentRepId",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "StudentRepId",
                table: "Replies");

            migrationBuilder.RenameTable(
                name: "Replies",
                newName: "Reply");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Post",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Reply",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_PostId",
                table: "Reply",
                newName: "IX_Reply_PostId");

            migrationBuilder.AddColumn<string>(
                name: "InviteCode",
                table: "Subject",
                type: "NVARCHAR(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Reply",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitTime",
                table: "Reply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reply",
                table: "Reply",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContentPost",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentPost_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentReply",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentReply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentReply_Reply_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Reply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reply_StudentId",
                table: "Reply",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentPost_PostId",
                table: "ContentPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentReply_ReplyId",
                table: "ContentReply",
                column: "ReplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Post_PostId",
                table: "Reply",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_UserInfo_StudentId",
                table: "Reply",
                column: "StudentId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Post_PostId",
                table: "Reply");

            migrationBuilder.DropForeignKey(
                name: "FK_Reply_UserInfo_StudentId",
                table: "Reply");

            migrationBuilder.DropTable(
                name: "ContentPost");

            migrationBuilder.DropTable(
                name: "ContentReply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reply",
                table: "Reply");

            migrationBuilder.DropIndex(
                name: "IX_Reply_StudentId",
                table: "Reply");

            migrationBuilder.DropColumn(
                name: "InviteCode",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "SubmitTime",
                table: "Reply");

            migrationBuilder.RenameTable(
                name: "Reply",
                newName: "Replies");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Post",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Replies",
                newName: "Content");

            migrationBuilder.RenameIndex(
                name: "IX_Reply_PostId",
                table: "Replies",
                newName: "IX_Replies_PostId");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Replies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "StudentRepId",
                table: "Replies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Replies",
                table: "Replies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RollCall",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollCall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollCall_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RollCall_UserInfo_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailRollCall",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RollCallId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RollCallTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailRollCall", x => new { x.StudentId, x.RollCallId });
                    table.ForeignKey(
                        name: "FK_DetailRollCall_RollCall_RollCallId",
                        column: x => x.RollCallId,
                        principalTable: "RollCall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailRollCall_UserInfo_StudentId",
                        column: x => x.StudentId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_StudentRepId",
                table: "Replies",
                column: "StudentRepId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailRollCall_RollCallId",
                table: "DetailRollCall",
                column: "RollCallId");

            migrationBuilder.CreateIndex(
                name: "IX_RollCall_CreatorId",
                table: "RollCall",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollCall_SubjectId",
                table: "RollCall",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Post_PostId",
                table: "Replies",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_UserInfo_StudentRepId",
                table: "Replies",
                column: "StudentRepId",
                principalTable: "UserInfo",
                principalColumn: "Id");
        }
    }
}
