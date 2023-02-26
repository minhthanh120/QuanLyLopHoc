using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models
{
    [Table("SubjectClass")]
    public class SubjectClass
    {
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string Id;
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string SubjectName;
        [Column(TypeName = "NTEXT")]
        public string Description;
    }
}
