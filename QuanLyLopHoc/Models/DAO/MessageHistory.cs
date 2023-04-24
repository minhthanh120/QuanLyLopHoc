using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Models.DAO
{
    public class MessageHistory
    {
        public User currentUser { get; set; }
        public User oppositeUser { get; set; }
        public ICollection<Message> messages { get; set; }
        public MessageHistory()
        {
            
        }
    }
}
