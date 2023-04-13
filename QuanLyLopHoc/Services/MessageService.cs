using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public class MessageService : IMessageSevice
    {
        public Task DeleteMessage(string messageId)
        {
            throw new NotImplementedException();
        }

        public Task EditMessage(string messageId, Message newMessage)
        {
            throw new NotImplementedException();
        }

        public Task GetHistoryChat(string userId, string otherUserId)
        {
            throw new NotImplementedException();
        }

        public Task Send(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
