using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models.Entities
{
    public class Notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Content { get; set; }
        public string? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual User User { get; set; }
    }
}
