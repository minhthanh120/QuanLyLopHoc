using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models
{
    [Table("TeacherSubject")]
    public class TeacherSubject
    {
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string UserId;
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string SubjectId;
    }
}
