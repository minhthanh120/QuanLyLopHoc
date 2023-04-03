using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models.Entities
{
    public class RollCall
    {
        [Key]
        public string Id { get; set; }
        public string SubjectId { get; set; }
        public string CreatorId { get; set; }
        public User Creator { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<DetailRollCall> Details { get; set; }
    }
}
