using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using QuanLyLopHoc.Areas.Identity.Data;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Services;

namespace QuanLyLopHoc.Hubs
{
    public class ChatHub:Hub
    {
        private readonly SMContext _context;
        private readonly ILogger _logger;
        private readonly IMessageSevice _messageSevice;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        public ChatHub(SMContext context, IUserService userService, ILogger<ChatHub> logger, IMessageSevice messageSevice , UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _messageSevice = messageSevice;
            _userService = userService;
        }
        public async Task SendMessage(string user, string receiver, string message)
        {
            var currentUser = _context.Users.FirstOrDefault(s => s.Id == user);
            //var receiveUser = _userManager.Users.FirstOrDefault(s => s.Email == receiver);
            var mess =_messageSevice.Create(user, receiver, message);
            var time = mess.SendTime.ToString();
            var Avatar = currentUser.Avatar==null? "":currentUser.Avatar;
            var AlterAvatar = currentUser.LastName.Split(" ").Last()[0];
            await Clients.Users(receiver, user).SendAsync("ReceiveMessage", user, message, time, Avatar, AlterAvatar);
            //return Clients.Group(receiver).SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendNotification(string subject, IList<string> UserReceive, string message)
        {

        }
    }
}
