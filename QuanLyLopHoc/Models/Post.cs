using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string Id;
        [Required]
        [Column(TypeName = "CHAR(32)")]
        public string UserId;
        [Column(TypeName = "NVARCHAR(255)")]
        public string Title;
        [Required]
        [Column(TypeName = "NTEXT")]
        public string Content;
        [Required]
        public DateTime PostTime;
    }
}
