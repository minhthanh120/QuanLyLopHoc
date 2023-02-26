using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models
{
    [Table("Transcript")]
    public class Transcript
    {
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string Id;
        [Required]
        [Column(TypeName = "CHAR(32)")]
        public string SubjectId;
    }
}
