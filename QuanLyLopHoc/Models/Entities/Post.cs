using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("Post")]
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        [Required]
        public string CreatorId { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "NTEXT")]
        public string Comment { get; set; }
        [Required]
        public DateTime PostTime { get; set; } = DateTime.Now;
        [Required]
        public string Type { get;set; }
        public virtual User Creator { get; set; }
        [Required]
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<ContentPost> Contents { get; set; }
    }
}
