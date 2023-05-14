using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("Reply")]
    public class Reply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get;set; }
        public string Comment { get;set; }
        public string StudentId { get; set; }
        public DateTime SubmitTime { get; set; } = DateTime.Now;
        public string PostId { get; set; }
        public User StudentRep { get; set; }
        public Post OriginPost { get; set; }
        public ICollection<ContentReply> Contents { get; set; }

    }
}
