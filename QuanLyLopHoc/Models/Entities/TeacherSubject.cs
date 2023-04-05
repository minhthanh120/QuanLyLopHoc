using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("TeacherSubject")]
    public class TeacherSubject
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
