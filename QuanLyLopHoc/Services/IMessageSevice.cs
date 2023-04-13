using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public interface IMessageSevice
    {
        public Task Send(Message message);
        public Task EditMessage(string messageId, Message newMessage);
        public Task DeleteMessage(string messageId);
        public Task GetHistoryChat(string userId, string otherUserId);
    }
}
