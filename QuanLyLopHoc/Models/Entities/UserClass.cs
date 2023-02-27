using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("UserClass")]
    public class UserClass
    {
        [Key]
        [Column(TypeName = " CHAR(32)")]
        public string Id { get; set; }// PRIMARY KEY,
        [Column(TypeName = "NVARCHAR(20)")]
        public string FirstName;// NOT NULL,
        [Column(TypeName = "NVARCHAR(20)")]
        public string LastName { get; set; }// NOT NULL
        [Column(TypeName = "NVARCHAR(20)")]
        public string City { get; set; }
        public DateTime BirthDay;
        public bool Gender { get; set; }// BINARY;
        [Column(TypeName = "NVARCHAR(100)")]
        public string School { get; set; }// NVARCHAR(100);
        [Column(TypeName = "NVARCHAR(100)")]
        public string Class { get; set; }//, -- Lớp chủ nhiệm
        [Column(TypeName = "NCHAR(255)")]
        public string Avatar { get; set; }
        [Column(TypeName = "NVARCHAR(255)")]
        public string About { get; set; }// -- Mô tả bản thân
        [Column(TypeName = "NVARCHAR(320)")]
        public string Email { get; set; }// UNIQUE -- Không đc trùng email
        public virtual ICollection<Message> Sent { get;set; }
        public virtual ICollection<Message> Received { get; set; }
        public virtual ICollection<DetailTranscript> Details { get;set; }
        public virtual ICollection<TeacherTranscript> TeacherTranscripts { get;set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get;set;}
        public virtual ICollection<Post> Posts { get;set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get;set; }
    }
}
