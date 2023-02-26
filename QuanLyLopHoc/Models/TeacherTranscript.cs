using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models
{
    [Table("TeacherTranscript")]
    public class TeacherTranscript
    {
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string UserId;
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string TranscriptId;
    }
}
