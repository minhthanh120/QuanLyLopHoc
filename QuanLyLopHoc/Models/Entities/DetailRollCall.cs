using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLopHoc.Models.Entities
{
    [Table("DetailRollCall")]
    public class DetailRollCall
    {
        public string StudentId { get; set; }
        public DateTime RollCallTime { get; set; }
        public string Status { get; set; }
        public User Student { get; set; }
        public string RollCallId { get; set; }
        public RollCall RollCall { get; set; }
        

    }
}
