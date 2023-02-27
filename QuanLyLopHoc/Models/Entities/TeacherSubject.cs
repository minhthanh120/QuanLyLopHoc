using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("TeacherSubject")]
    public class TeacherSubject
    {
        [Column(TypeName = "CHAR(32)")]
        public string UserId { get; set; }
        public virtual UserClass User { get; set; }
        [Column(TypeName = "CHAR(32)")]
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
