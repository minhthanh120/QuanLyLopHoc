using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Repository;
using QuanLyLopHoc.Services;

namespace QuanLyLopHoc.Repositories
{
    public class MessageRepository: IMessageRepository
    {
        private readonly SMContext _context;
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        public MessageRepository(SMContext context, ILogger<MessageRepository> logger, IUserService userService)
        {
            _context = context;
            _logger = logger;
            _userService = userService;
        }
        public async Task Create(Message message)
        {
            try
            {
                await _context.AddAsync<Message>(message);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
        public async Task Edit(string messageId, Message newMessage)
        {
            try
            {
                var currentMessage = await _context.FindAsync<Message>(messageId);
                currentMessage.Content = newMessage.Content;
                _context.Update<Message>(currentMessage);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
        public async Task Delete(string messageId)
        {
            try
            {
                var currentMessage= await _context.FindAsync<Message>(messageId);
                _context.Remove<Message>(currentMessage);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
        public async Task<MessageHistory> GetAll(User currentUser, User oppositeUser)
        {
            var result = new MessageHistory();
            result.oppositeUser = oppositeUser;
            result.currentUser = currentUser;
            try
            {
                var lst1 = _context.Messages.Where(c => c.SenderId == currentUser.Id && c.ReceiverId == oppositeUser.Id).ToList();
                var lst2 = _context.Messages.Where(c => c.SenderId == oppositeUser.Id && c.ReceiverId == currentUser.Id).ToList();
                lst1.AddRange(lst2);
                var ls = lst1.OrderBy(c => c.SendTime);
                result.messages = ls;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return result;
        }

        public Task<MessageHistory> GetAll(string currentUserId, string oppositeUserId)
        {
            throw new NotImplementedException();
        }
        public async Task<List<User>> GetRecentChatting(string userId)
        {
            try
            {
                var result = _context.Messages.Where(c => c.SenderId == userId || c.ReceiverId == userId).ToList();
                //var lstUser = from item in result select item.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return null;
        }

    }
}
