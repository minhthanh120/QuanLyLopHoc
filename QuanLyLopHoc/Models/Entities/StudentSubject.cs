using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("StudentSubject")]
    public class StudentSubject
    {
        public string UserId { get; set; }
        public virtual User Users { get; set; }
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
