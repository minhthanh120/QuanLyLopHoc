using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("ContentPost")]
    public class ContentPost
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string Content { get; set; }
        public string PostId { get; set; }
        public virtual Post OriginalPost { get; set; }
    }
}
