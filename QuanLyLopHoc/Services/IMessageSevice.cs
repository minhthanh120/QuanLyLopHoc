using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public interface IMessageSevice
    {
        public Task Send(Message message);
        public Message Create(string user, string receiver, string message);
        public Task EditMessage(string messageId, Message newMessage);
        public Task DeleteMessage(string messageId);
        public Task<MessageHistory> GetHistoryChat(string userId, string otherUserId);
        public ICollection<Chat> GetUsersRecentChatting(string userId);
        public Chat GetLastestMessage(string currentUserId, string otherUserId);


    }
}
