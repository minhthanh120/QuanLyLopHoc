using Microsoft.EntityFrameworkCore;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Models
{
    public class SMContext : DbContext
    {
        //public SMContext() { }
        public virtual DbSet<DetailTranscript> Details { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostType> Types { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public virtual DbSet<TeacherTranscript> TeacherTranscripts { get; set; }
        public virtual DbSet<Transcript> Transcripts { get; set; }
        public virtual DbSet<UserClass> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-L67U4QK;Initial Catalog=SUBJECTCLASS;Integrated Security=True;TrustServerCertificate=True"); //Constring sang config
            //Data Source=DESKTOP-L67U4QK;Initial Catalog=tempdb;Integrated Security=True
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailTranscript>().HasKey(pk => new { pk.UserId, pk.TranscriptId });
            modelBuilder.Entity<DetailTranscript>()
                .HasOne(pk => pk.Student)
                .WithMany(pk => pk.Details)
                .HasForeignKey(pk => pk.UserId);
            modelBuilder.Entity<DetailTranscript>()
                .HasOne(pk => pk.Transcript)
                .WithMany(pk => pk.Details)
                .HasForeignKey(pk => pk.TranscriptId);

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
                .HasOne(pk => pk.User)
                .WithMany(pk => pk.Posts)
                .HasForeignKey(pk => pk.UserId);
            modelBuilder.Entity<Post>()
                .HasOne(pk => pk.Type)
                .WithMany(pk => pk.Posts)
                .HasForeignKey(pk => pk.TypeId);
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
            modelBuilder.Entity<Transcript>()
                .HasOne(s=>s.Subject)
                .WithMany(g=>g.Transcripts)
                .HasForeignKey(s => s.SubjectId);

            modelBuilder.Entity<PostType>().HasKey(pk => new { pk.Id });
            modelBuilder.Entity<Subject>().HasKey(pk => new { pk.Id });
            
            modelBuilder.Entity<UserClass>().HasKey(pk => new { pk.Id });


        }
    }
}
