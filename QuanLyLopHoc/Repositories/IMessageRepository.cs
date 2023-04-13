using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Repository
{
    public interface IMessageRepository
    {
        public Task Create(Message message);
        public Task Edit(string messageId, Message newMessage);
        public Task Delete(string messageId);
        public Task<ICollection<Message>> GetAll(string currentUserId, string otherUserId);

    }
}
