﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyLopHoc.Models;

#nullable disable

namespace QuanLyLopHoc.Migrations
{
    [DbContext(typeof(SMContext))]
    partial class SMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.ApplicationUser", b =>
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

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.DetailTranscript", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("CHAR(32)");

                    b.Property<string>("TranscriptId")
                        .HasColumnType("CHAR(32)");

                    b.Property<decimal>("DiemCC")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DiemCK")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DiemTB")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DiemTX")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("UserId", "TranscriptId");

                    b.HasIndex("TranscriptId");

                    b.ToTable("DetailTranscript");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("CHAR(32)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("NTEXT");

                    b.Property<string>("ReceiverId")
                        .IsRequired()
                        .HasColumnType("CHAR(32)");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("CHAR(32)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Post", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("CHAR(32)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("NTEXT");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("CHAR(32)");

                    b.Property<DateTime>("PostTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("CHAR(32)");

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

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.StudentSubject", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("CHAR(32)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("CHAR(32)");

                    b.HasKey("UserId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Subject", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("CHAR(32)");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType(" CHAR(32)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NTEXT");

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
                        .HasColumnType("CHAR(32)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("CHAR(32)");

                    b.HasKey("UserId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("TeacherSubject");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.TeacherTranscript", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("CHAR(32)");

                    b.Property<string>("TranscriptId")
                        .HasColumnType("CHAR(32)");

                    b.HasKey("UserId", "TranscriptId");

                    b.HasIndex("TranscriptId");

                    b.ToTable("TeacherTranscript");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Transcript", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("CHAR(32)");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType(" CHAR(32)");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("CHAR(32)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Transcript");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType(" CHAR(32)");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("NCHAR(255)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(320)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("Char(12)");

                    b.Property<string>("School")
                        .IsRequired()
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
                    b.HasOne("QuanLyLopHoc.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.ApplicationUser", null)
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

                    b.HasOne("QuanLyLopHoc.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QuanLyLopHoc.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .WithMany("Transcripts")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("QuanLyLopHoc.Models.Entities.Subject", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("StudentSubjects");

                    b.Navigation("TeacherSubjects");

                    b.Navigation("Transcripts");
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

                    b.Navigation("Posts");

                    b.Navigation("Received");

                    b.Navigation("Sent");

                    b.Navigation("StudentSubjects");

                    b.Navigation("TeacherSubjects");

                    b.Navigation("TeacherTranscripts");
                });
#pragma warning restore 612, 618
        }
    }
}
