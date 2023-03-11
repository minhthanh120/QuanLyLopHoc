using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("Transcript")]
    public class Transcript
    {
        [Column(TypeName = "CHAR(32)")]
        public string Id { get; set; }
        [Required]
        [Column(TypeName = "CHAR(32)")]
        public string SubjectId { get; set; }
        public string? CreatorId{get; set;}
        public virtual User Creator { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<TeacherTranscript> TeacherTranscripts { get; set; }
        public virtual ICollection<DetailTranscript> Details { get; set; }
    }
}
