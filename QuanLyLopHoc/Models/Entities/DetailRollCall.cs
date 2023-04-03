using System.ComponentModel.DataAnnotations;
namespace QuanLyLopHoc.Models.Entities
{
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
