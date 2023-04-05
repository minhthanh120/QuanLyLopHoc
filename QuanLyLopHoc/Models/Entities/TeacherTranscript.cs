using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("TeacherTranscript")]
    public class TeacherTranscript
    {
        public string UserId { get; set; }
        public virtual User User { get;set; }
        public string TranscriptId { get; set; }
        public virtual Transcript Transcript { get;set; }
    }
}
