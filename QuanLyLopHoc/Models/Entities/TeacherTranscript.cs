using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("TeacherTranscript")]
    public class TeacherTranscript
    {
        [Column(TypeName = "CHAR(32)")]
        public string UserId { get; set; }
        public virtual UserClass User { get;set; }
        [Column(TypeName = "CHAR(32)")]
        public string TranscriptId { get; set; }
        public virtual Transcript Transcript { get;set; }
    }
}
