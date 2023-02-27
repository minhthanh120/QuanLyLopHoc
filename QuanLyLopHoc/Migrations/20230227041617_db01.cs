using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyLopHoc.Migrations
{
    /// <inheritdoc />
    public partial class db01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(32)", nullable: false),
                    SubjectName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "NTEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClass",
                columns: table => new
                {
                    Id = table.Column<string>(type: " CHAR(32)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    School = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Class = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Avatar = table.Column<string>(type: "NCHAR(255)", nullable: false),
                    About = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(320)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transcript",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(32)", nullable: false),
                    SubjectId = table.Column<string>(type: "CHAR(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcript", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transcript_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(32)", nullable: false),
                    SenderId = table.Column<string>(type: "CHAR(32)", nullable: false),
                    ReceiverId = table.Column<string>(type: "CHAR(32)", nullable: false),
                    SendTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "NTEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_UserClass_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "UserClass",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Message_UserClass_SenderId",
                        column: x => x.SenderId,
                        principalTable: "UserClass",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(32)", nullable: false),
                    UserId = table.Column<string>(type: "CHAR(32)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "NTEXT", nullable: false),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubjectId = table.Column<string>(type: "CHAR(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_PostType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PostType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_UserClass_UserId",
                        column: x => x.UserId,
                        principalTable: "UserClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "CHAR(32)", nullable: false),
                    SubjectId = table.Column<string>(type: "CHAR(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.UserId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_UserClass_UserId",
                        column: x => x.UserId,
                        principalTable: "UserClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubject",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "CHAR(32)", nullable: false),
                    SubjectId = table.Column<string>(type: "CHAR(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubject", x => new { x.UserId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_TeacherSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubject_UserClass_UserId",
                        column: x => x.UserId,
                        principalTable: "UserClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailTranscript",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "CHAR(32)", nullable: false),
                    TranscriptId = table.Column<string>(type: "CHAR(32)", nullable: false),
                    DiemCC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiemTX = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiemCK = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailTranscript", x => new { x.UserId, x.TranscriptId });
                    table.ForeignKey(
                        name: "FK_DetailTranscript_Transcript_TranscriptId",
                        column: x => x.TranscriptId,
                        principalTable: "Transcript",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailTranscript_UserClass_UserId",
                        column: x => x.UserId,
                        principalTable: "UserClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherTranscript",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "CHAR(32)", nullable: false),
                    TranscriptId = table.Column<string>(type: "CHAR(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTranscript", x => new { x.UserId, x.TranscriptId });
                    table.ForeignKey(
                        name: "FK_TeacherTranscript_Transcript_TranscriptId",
                        column: x => x.TranscriptId,
                        principalTable: "Transcript",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherTranscript_UserClass_UserId",
                        column: x => x.UserId,
                        principalTable: "UserClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailTranscript_TranscriptId",
                table: "DetailTranscript",
                column: "TranscriptId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ReceiverId",
                table: "Message",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                table: "Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SubjectId",
                table: "Post",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_TypeId",
                table: "Post",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubject_SubjectId",
                table: "TeacherSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTranscript_TranscriptId",
                table: "TeacherTranscript",
                column: "TranscriptId");

            migrationBuilder.CreateIndex(
                name: "IX_Transcript_SubjectId",
                table: "Transcript",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailTranscript");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "TeacherSubject");

            migrationBuilder.DropTable(
                name: "TeacherTranscript");

            migrationBuilder.DropTable(
                name: "PostType");

            migrationBuilder.DropTable(
                name: "Transcript");

            migrationBuilder.DropTable(
                name: "UserClass");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
