using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models
{
    [Table("Message")]
    public class Message
    {
        [Key]
        [Column(TypeName = "CHAR(32)")]
        public string Id;
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Sender;
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Addressee;
        [Required]
        public DateTime SendTime;
        [Required]
        [Column(TypeName = "NTEXT")]
        public string Content;
    }
}
