using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models
{
    [Table("StudentSubject")]
    public class StudentSubject
    {
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string UserId;
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string SubjectId;
    }
}
