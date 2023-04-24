using Microsoft.AspNetCore.Identity;
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

        public MessageService(IMessageRepository message, IUserService userService, SMContext context)
        {
            this._messageRepository = message;
            _userService = userService;
            _context = context;
        }

        public void Create(string user, string receiver, string message)
        {
            //var cUser = await _userService.GetUserbyId(user);
            //var oUser = await _userService.GetUserbyId(receiver);
            var mess = new Message();
            mess.ReceiverId = receiver;
            mess.SenderId = user;
            mess.Content = message;
            _context.Add<Message>(mess);
            _context.SaveChanges();

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
            
            var currentUser = await _userService.GetUserbyId(userId);
            var oppositeUser = await _userService.GetUserbyId(otherUserId);
            if (currentUser != null || oppositeUser != null)
            {
                return await _messageRepository.GetAll(currentUser, oppositeUser);
            }
            return null;

        }

        public async Task Send(Message message)
        {
            await _messageRepository.Create(message);
        }
    }
}
