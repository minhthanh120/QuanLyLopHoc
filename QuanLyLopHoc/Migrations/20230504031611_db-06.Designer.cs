﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyLopHoc.Models;

#nullable disable

namespace QuanLyLopHoc.Migrations
{
    [DbContext(typeof(SMContext))]
    [Migration("20230504031611_db-06")]
    partial class db06
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QuanLyLopHoc.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.DetailRollCall", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RollCallId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RollCallTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId", "RollCallId");

                    b.HasIndex("RollCallId");

                    b.ToTable("DetailRollCall");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.DetailTranscript", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TranscriptId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("DiemCC")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DiemCK")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DiemTB")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DiemTX")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("UserId", "TranscriptId");

                    b.HasIndex("TranscriptId");

                    b.ToTable("DetailTranscript");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Message", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("NTEXT");

                    b.Property<string>("ReceiverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Notification", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Post", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("NTEXT");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PostTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Reply", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentRepId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("StudentRepId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.RollCall", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("SubjectId");

                    b.ToTable("RollCall");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.StudentSubject", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Subject", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("NTEXT");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.TeacherSubject", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("TeacherSubject");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.TeacherTranscript", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TranscriptId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "TranscriptId");

                    b.HasIndex("TranscriptId");

                    b.ToTable("TeacherTranscript");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Transcript", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("SubjectId")
                        .IsUnique();

                    b.ToTable("Transcript");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("Avatar")
                        .HasColumnType("NCHAR(255)");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("Class")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(320)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("Char(12)");

                    b.Property<string>("School")
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QuanLyLopHoc.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QuanLyLopHoc.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyLopHoc.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QuanLyLopHoc.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.DetailRollCall", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.RollCall", "RollCall")
                        .WithMany("Details")
                        .HasForeignKey("RollCallId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "Student")
                        .WithMany("Rollcalls")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RollCall");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.DetailTranscript", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.Transcript", "Transcript")
                        .WithMany("Details")
                        .HasForeignKey("TranscriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "Student")
                        .WithMany("Details")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Transcript");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Message", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "Receiver")
                        .WithMany("Received")
                        .HasForeignKey("ReceiverId")
                        .IsRequired();

                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "Sender")
                        .WithMany("Sent")
                        .HasForeignKey("SenderId")
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Notification", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Post", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyLopHoc.Models.Entities.Subject", "Subject")
                        .WithMany("Posts")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Reply", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.Post", "OriginPost")
                        .WithMany("Replies")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "StudentRep")
                        .WithMany("Replies")
                        .HasForeignKey("StudentRepId");

                    b.Navigation("OriginPost");

                    b.Navigation("StudentRep");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.RollCall", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyLopHoc.Models.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.StudentSubject", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "Users")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Subject", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "Creator")
                        .WithMany("CreatedSubject")
                        .HasForeignKey("CreatorId")
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.TeacherSubject", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.Subject", "Subject")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "User")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.TeacherTranscript", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.Transcript", "Transcript")
                        .WithMany("TeacherTranscripts")
                        .HasForeignKey("TranscriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "User")
                        .WithMany("TeacherTranscripts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transcript");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Transcript", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.User", "Creator")
                        .WithMany("CreatedTranscript")
                        .HasForeignKey("CreatorId")
                        .IsRequired();

                    b.HasOne("QuanLyLopHoc.Models.Entities.Subject", "Subject")
                        .WithOne("Transcript")
                        .HasForeignKey("QuanLyLopHoc.Models.Entities.Transcript", "SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Post", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.RollCall", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Subject", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("StudentSubjects");

                    b.Navigation("TeacherSubjects");

                    b.Navigation("Transcript")
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Transcript", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("TeacherTranscripts");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.User", b =>
                {
                    b.Navigation("CreatedSubject");

                    b.Navigation("CreatedTranscript");

                    b.Navigation("Details");

                    b.Navigation("Notifications");

                    b.Navigation("Posts");

                    b.Navigation("Received");

                    b.Navigation("Replies");

                    b.Navigation("Rollcalls");

                    b.Navigation("Sent");

                    b.Navigation("StudentSubjects");

                    b.Navigation("TeacherSubjects");

                    b.Navigation("TeacherTranscripts");
                });
#pragma warning restore 612, 618
        }
    }
}
