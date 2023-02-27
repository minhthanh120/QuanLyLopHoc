using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("PostType")]
    public class PostType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string TypeName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
