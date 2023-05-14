using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("ContentReply")]
    public class ContentReply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string Content { get; set; }
        public string ReplyId { get; set; }
        public virtual Reply OriginalReply {get; set;}
    }
}
