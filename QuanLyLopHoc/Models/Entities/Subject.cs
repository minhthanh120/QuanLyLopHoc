using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("Subject")]
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string SubjectName { get; set; }
        [Column(TypeName = "NTEXT")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public string? CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects {get;set;}
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual Transcript Transcript { get; set; }

    }
}
