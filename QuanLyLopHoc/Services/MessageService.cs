using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuanLyLopHoc.Areas.Identity.Data;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Repository;
using System.Security.Claims;
namespace QuanLyLopHoc.Services
{
    public class MessageService : IMessageSevice
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SMContext _context;
        private readonly ILogger<MessageService> _logger;

        public MessageService(IMessageRepository message,
            IUserService userService,
            SMContext context,
            ILogger<MessageService> logger,
            UserManager<ApplicationUser> userManager)
        {
            this._messageRepository = message;
            _userService = userService;
            _context = context;
            _logger = logger;
            _userManager = userManager;

        }

        public Message Create(string user, string receiver, string message)
        {
            //var cUser = await _userService.GetUserbyId(user);
            //var oUser = await _userService.GetUserbyId(receiver);
            var mess = new Message();
            mess.ReceiverId = receiver;
            mess.SenderId = user;
            mess.Content = message;
            _context.Add<Message>(mess);
            _context.SaveChanges();
            return mess;

        }

        public Task DeleteMessage(string messageId)
        {
            throw new NotImplementedException();
        }

        public Task EditMessage(string messageId, Message newMessage)
        {
            throw new NotImplementedException();
        }

        public async Task<MessageHistory> GetHistoryChat(string userId, string otherUserId)
        {
            try
            {
                var currentUser = await _userService.GetUserbyId(userId);
                var oppositeUser = await _userService.GetUserbyId(otherUserId);
                if (currentUser != null || oppositeUser != null)
                {
                    return await _messageRepository.GetAll(currentUser, oppositeUser);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return null;

        }
        public Chat GetLastestMessage(string currentUserId, string otherUserId)
        {
            var result = new Chat();
            try
            {
                if (_context.Users.Any(i => i.Id == otherUserId))
                {
                    result.User = _context.Find<User>(otherUserId);
                    var lst1 = _context.Messages.Where(c => c.SenderId == currentUserId && c.ReceiverId == otherUserId).ToList();
                    var lst2 = _context.Messages.Where(c => c.SenderId == otherUserId && c.ReceiverId == currentUserId).ToList();
                    lst1.AddRange(lst2);
                    var ls = lst1.OrderByDescending(c => c.SendTime).First();
                    result.Message = _context.Messages.Where(i => i.Id == ls.Id)
                        .Include(fk => fk.Sender)
                        .FirstOrDefault();

                }
                return result;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
            }
            return result;
        }

        public ICollection<Chat> GetUsersRecentChatting(string userId)
        {
            try
            {

                var messages = _context.Messages.Where(u => u.SenderId == userId || u.ReceiverId == userId)
                    .AsEnumerable()
                    .OrderByDescending(t => t.SendTime)
                    .GroupBy(g => new { g.SenderId, g.ReceiverId })
                    //.FirstOrDefault()
                    .ToList();
                var lsi = (from message in messages select message.FirstOrDefault()).ToList();
                var listId = (from u in lsi select u.SenderId).ToList();
                listId = listId.Concat((from u in lsi select u.ReceiverId)).Distinct().ToList();
                if (listId.Any(id => id == userId))
                {
                    var temp = listId.FirstOrDefault(id => id == userId);
                    listId.Remove(userId);
                }
                var result = new List<Chat>();
                foreach (var item in listId)
                {
                    var temp = GetLastestMessage(userId, item);
                    if (temp.User != null)
                    {
                        result.Add(temp);
                    }
                }
                //listId;
                return result.OrderByDescending(i => i.Message.SendTime).ToList();
            }
            catch(Exception ex)
            {

            }
            return new List<Chat>();
        }

        public async Task Send(Message message)
        {
            await _messageRepository.Create(message);
        }
    }
}
