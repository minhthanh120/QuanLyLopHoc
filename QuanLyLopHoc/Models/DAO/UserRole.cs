using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Models.DAO
{
    public class UserRole
    {
        public User User { get; set; }
        public bool IsStudent { get;set; }
        public bool IsJoined { get;set; }
        public UserRole()
        {
            
        }
    }
}
