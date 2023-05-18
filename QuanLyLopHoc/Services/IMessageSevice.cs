using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public interface IMessageSevice
    {
        public Task Send(Message message);
        public void Create(string user, string receiver, string message);
        public Task EditMessage(string messageId, Message newMessage);
        public Task DeleteMessage(string messageId);
        public Task<MessageHistory> GetHistoryChat(string userId, string otherUserId);
        public Task<List<User>> GetRecentChatting(string userId);

    }
}
