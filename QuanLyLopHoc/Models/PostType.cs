using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models
{
    [Table("PostType")]
    public class PostType
    {
        [Key]
        public int Id;
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string TypeName;
    }
}
