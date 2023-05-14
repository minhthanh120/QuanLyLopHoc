using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyLopHoc.Areas.Identity.Data;
using QuanLyLopHoc.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models
{
    public class SMContext : IdentityDbContext<ApplicationUser>
    {
        public SMContext() { }
        public SMContext(DbContextOptions<SMContext> options):base(options)
        {
            
        }
        public virtual DbSet<DetailTranscript> Details { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        //public virtual DbSet<PostType> Types { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public virtual DbSet<TeacherTranscript> TeacherTranscripts { get; set; }
        public virtual DbSet<Transcript> Transcripts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<ContentReply> ContentReplies { get; set; }
        public virtual DbSet<ContentPost> ContentPosts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=SUBJECTCLASS;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Message>().Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<DetailTranscript>().HasKey(pk => new { pk.UserId, pk.TranscriptId });
            modelBuilder.Entity<DetailTranscript>()
                .HasOne(pk => pk.Student)
                .WithMany(pk => pk.Details)
                .HasForeignKey(pk => pk.UserId);
            modelBuilder.Entity<DetailTranscript>()
                .HasOne(pk => pk.Transcript)
                .WithMany(pk => pk.Details)
                .HasForeignKey(pk => pk.TranscriptId);
            

            modelBuilder.Entity<Reply>()
                .HasOne(pk => pk.OriginPost)
                .WithMany(pk => pk.Replies)
                .HasForeignKey(pk => pk.PostId);
            
            modelBuilder.Entity<Reply>()
                .HasOne(pk => pk.StudentRep)
                .WithMany(pk => pk.Replies)
                .HasForeignKey(pk => pk.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ContentPost>()
                .HasOne(pk => pk.OriginalPost)
                .WithMany(pk => pk.Contents)
                .HasForeignKey(pk => pk.PostId);

            modelBuilder.Entity<ContentReply>()
                .HasOne(pk => pk.OriginalReply)
                .WithMany(pk => pk.Contents)
                .HasForeignKey(pk => pk.ReplyId);

            modelBuilder.Entity<TeacherTranscript>().HasKey(pk => new { pk.UserId, pk.TranscriptId });
            modelBuilder.Entity<TeacherTranscript>()
                .HasOne(pk => pk.User)
                .WithMany(pk => pk.TeacherTranscripts)
                .HasForeignKey(pk => pk.UserId);
            modelBuilder.Entity<TeacherTranscript>()
                .HasOne(pk => pk.Transcript)
                .WithMany(pk => pk.TeacherTranscripts)
                .HasForeignKey(pk => pk.TranscriptId);

            modelBuilder.Entity<TeacherSubject>().HasKey(pk => new { pk.UserId, pk.SubjectId });
            modelBuilder.Entity<TeacherSubject>()
                .HasOne(pk => pk.User)
                .WithMany(pk => pk.TeacherSubjects)
                .HasForeignKey(pk => pk.UserId);
            modelBuilder.Entity<TeacherSubject>()
                .HasOne(pk => pk.Subject)
                .WithMany(pk => pk.TeacherSubjects)
                .HasForeignKey(pk => pk.SubjectId);

            modelBuilder.Entity<StudentSubject>().HasKey(pk => new { pk.UserId, pk.SubjectId });
            modelBuilder.Entity<StudentSubject>()
                .HasOne(pk => pk.Users)
                .WithMany(pk => pk.StudentSubjects)
                .HasForeignKey(pk => pk.UserId);
            modelBuilder.Entity<StudentSubject>()
                .HasOne(pk => pk.Subject)
                .WithMany(pk => pk.StudentSubjects)
                .HasForeignKey(pk => pk.SubjectId);

            //modelBuilder.Entity<Post>().HasKey(pk => new { pk.UserId, pk.TypeId, pk.SubjectId });
            modelBuilder.Entity<Post>().HasKey(pk => new { pk.Id});
            modelBuilder.Entity<Post>()
                .HasOne(pk => pk.Creator)
                .WithMany(pk => pk.Posts)
                .HasForeignKey(pk => pk.CreatorId);
            //modelBuilder.Entity<Post>()
            //    .HasOne(pk => pk.Type)
            //    .WithMany(pk => pk.Posts)
            //    .HasForeignKey(pk => pk.TypeId);
            modelBuilder.Entity<Post>()
                .HasOne(pk => pk.Subject)
                .WithMany(pk => pk.Posts)
                .HasForeignKey(pk => pk.SubjectId);

            modelBuilder.Entity<Message>().HasKey(pk => new { pk.Id });
            modelBuilder.Entity<Message>()
                .HasOne(s => s.Sender)
                .WithMany(g => g.Sent)
                .HasForeignKey(s => s.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Message>()
                .HasOne(s => s.Receiver)
                .WithMany(g => g.Received)
                .HasForeignKey(s => s.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Transcript>().HasKey(pk => new { pk.Id });
            //modelBuilder.Entity<Transcript>()
            //    .HasOne(pk=>pk.Subject)
            //    .WithOne(pk=>pk.Transcripts)
            //    .HasForeignKey<Subject>(fk=>fk.);
            modelBuilder.Entity<Transcript>()
                .HasOne(s => s.Creator)
                .WithMany(g => g.CreatedTranscript)
                .HasForeignKey(s => s.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //modelBuilder.Entity<PostType>().HasKey(pk => new { pk.Id });
            modelBuilder.Entity<Subject>().HasKey(pk => new { pk.Id });
            modelBuilder.Entity<Subject>()
                .HasOne(pk => pk.Creator)
                .WithMany(pk => pk.CreatedSubject)
                .HasForeignKey(pk => pk.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Subject>()
                .HasOne<Transcript>(pk => pk.Transcript)
                .WithOne(fk => fk.Subject)
                .HasForeignKey<Transcript>(fk => fk.SubjectId);

            modelBuilder.Entity<User>().HasKey(pk => new { pk.Id });
                    }
    }
}
