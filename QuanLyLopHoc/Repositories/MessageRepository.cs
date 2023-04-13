using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Repository;

namespace QuanLyLopHoc.Repositories
{
    public class MessageRepository: IMessageRepository
    {
        private readonly SMContext _context;
        private readonly ILogger _logger;
        public MessageRepository(SMContext context, ILogger<MessageRepository> logger)
        {
            _context = context;
            _logger = logger;
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
        public async Task<ICollection<Message>> GetAll(string currentUserId, string otherUserId)
        {
            try
            {
                var result = _context.Messages.Where(b => b.SenderId == currentUserId && b.ReceiverId == otherUserId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return Array.Empty<Message>();
        }
    }
}
