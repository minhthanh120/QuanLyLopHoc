using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models.Entities
{
    public class Reply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get;set; }
        public string Content { get;set; }
        public string StudentId { get; set; }
        public string PostId { get; set; }
        public User StudentRep { get; set; }
        public Post OriginPost { get; set; }

    }
}
