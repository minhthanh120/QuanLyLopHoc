using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("Message")]
    public class Message
    {
        [Column(TypeName = "CHAR(32)")]
        public string Id { get; set; }
        [Required]
        [Column(TypeName = "CHAR(32)")]
        public string? SenderId { get; set; }
        [Required]
        [Column(TypeName = "CHAR(32)")]
        public string? ReceiverId { get; set; }
        [Required]
        public DateTime SendTime { get; set; }
        [Required]
        [Column(TypeName = "NTEXT")]
        public string Content { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Receiver { get;set; }
    }
}
