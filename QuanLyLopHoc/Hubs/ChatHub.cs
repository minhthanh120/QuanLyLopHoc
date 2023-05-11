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
        public ChatHub(SMContext context, ILogger<ChatHub> logger, IMessageSevice messageSevice , UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _messageSevice = messageSevice;
        }
        public async Task SendMessage(string user, string receiver, string message)
        {
            //var currentUser = _userManager.Users.FirstOrDefault(s => s.Email == user);
            //var receiveUser = _userManager.Users.FirstOrDefault(s => s.Email == receiver);
            _messageSevice.Create(user, receiver, message);
            await Clients.Users(receiver, user).SendAsync("ReceiveMessage", user, message);
            //return Clients.Group(receiver).SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendNotification(string subject, IList<string> UserReceive, string message)
        {

        }
    }
}
