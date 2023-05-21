using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("UserInfo")]
    public class User
    {
        [Key]
        public string Id { get; set; }// PRIMARY KEY,
        [Column(TypeName = "NVARCHAR(20)")]
        [MaxLength(20)]
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Họ")]
        public string? FirstName { get; set; }// NOT NULL,
        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR(20)")]
        [Required(ErrorMessage = "{0} không được để trống")]
        //[RegexStringValidator]
        
        [Display(Name = "Tên đệm")]
        public string? LastName { get; set; }// NOT NULL
        [Display(Name = "Thành phố")]
        [Column(TypeName = "NVARCHAR(20)")]
        public string? City { get; set; }
        [Display(Name ="Ngày sinh")]
        [Column(TypeName = "date")]
        public DateTime? BirthDay { get; set; }
        [Display(Name = "Số điện thoại")]
        [MaxLength(12)]
        [Column(TypeName = "Char(12)")]
        public string? Phone { get; set; }
        [Display(Name ="Giới tính")]
        public bool? Gender { get; set; }// BINARY;
        [Display(Name = "Trường")]
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR(100)")]
        public string? School { get; set; }// NVARCHAR(100);
        [Display(Name = "Lớp chuyên ngành")]
        [Column(TypeName = "NVARCHAR(100)")]
        public string? Class { get; set; }//, -- Lớp chủ nhiệm
        [Display(Name = "Ảnh đại diện")]
        [Column(TypeName = "NTEXT")]
        public string? Avatar { get; set; }
        [Display(Name = "Mô tả")]
        [MaxLength(255)]
        [Column(TypeName = "NVARCHAR(255)")]
        public string? About { get; set; }// -- Mô tả bản thân
        [Display(Name = "Địa chỉ Email")]
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR(320)")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string? Email { get; set; }// UNIQUE -- Không đc trùng email
        //public string FullName { get; set; }
        public virtual ICollection<Message> Sent { get;set; }
        public virtual ICollection<Message> Received { get; set; }
        public virtual ICollection<DetailTranscript> Details { get;set; }
        public virtual ICollection<TeacherTranscript> TeacherTranscripts { get;set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get;set;}
        public virtual ICollection<Post> Posts { get;set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get;set; }
        public virtual ICollection<Subject> CreatedSubject { get;set; }
        public virtual ICollection<Transcript> CreatedTranscript { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
    public class DateRange : ValidationAttribute
    {
        DateTime MinDate, MaxDate;

        public DateRange(string minDate, string maxDate)
        {
            MinDate = DateTime.Parse(minDate);
            MaxDate = DateTime.Parse(maxDate);
            if (string.IsNullOrEmpty(ErrorMessage))
                ErrorMessage = $"Ngày sinh phải lớn hơn {minDate} và nhỏ hơn {maxDate}";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var d = (DateTime)value;
            if (d < MinDate || d > MaxDate)
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
    }
}
