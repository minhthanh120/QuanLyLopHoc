using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Repository
{
    public interface IMessageRepository
    {
        public Task Create(Message message);
        public Task Edit(string messageId, Message newMessage);
        public Task Delete(string messageId);
        public Task<MessageHistory> GetAll(User currentUser, User oppositeUser);
        //public Task<MessageHistory> GetAll(string currentUserId, string oppositeUserId);


    }
}
