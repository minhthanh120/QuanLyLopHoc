using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models
{
    [Table("UserClass")]
    public class UserClass
    {
        [Column(TypeName = " CHAR(32)")]
        public string Id;// PRIMARY KEY,
        [Column(TypeName = "NVARCHAR(20)")]
        public string FirstName;// NOT NULL,
        [Column(TypeName = "NVARCHAR(20)")]
        public string LastName;// NOT NULL
        [Column(TypeName = "NVARCHAR(20)"]
        public string City ;
        public DateTime BirthDay ;
        public bool Gender;// BINARY;
        [Column(TypeName = "NVARCHAR(100)")]
        public string School;// NVARCHAR(100);
        [Column(TypeName = "NVARCHAR(100)")]
        public string Class ;//, -- Lớp chủ nhiệm
        [Column(TypeName = "NCHAR(255)")]
        public string Avatar;
        [Column(TypeName = "NVARCHAR(255)")]
        public string About;// -- Mô tả bản thân
        [Column(TypeName = "NVARCHAR(320)")]
        public string Email;// UNIQUE -- Không đc trùng email
    }
}
