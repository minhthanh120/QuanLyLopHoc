using System.ComponentModel.DataAnnotations;
namespace QuanLyLopHoc.Models.Entities
{
    public class Reply
    {
        [Key]
        public string Id { get;set; }
        public string Content { get;set; }
        public string StudentId { get; set; }
        public string PostId { get; set; }
        public User StudentRep { get; set; }
        public Post OriginPost { get; set; }

    }
}
