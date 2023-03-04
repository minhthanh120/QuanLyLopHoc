using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string Id { get; set; }
        [Required]
        [Column(TypeName = "CHAR(32)")]
        public string UserId { get; set; }
        public int TypeId { get; set; }
[StringLength(255)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "NTEXT")]
        public string Content { get; set; }
        [Required]
        public DateTime PostTime { get; set; }
        public virtual User User { get; set; }
        [Required]
        [Column(TypeName = "CHAR(32)")]
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual PostType Type { get; set; }
    }
}
