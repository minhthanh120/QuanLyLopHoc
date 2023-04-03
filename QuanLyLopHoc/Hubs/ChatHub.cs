using Microsoft.AspNetCore.SignalR;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Services;

namespace QuanLyLopHoc.Hubs
{
    public class ChatHub:Hub
    {
        private readonly SMContext _context;
        private readonly ILogger _logger;
        private IMessageSevice _messageSevice;
        public ChatHub()
        {
            
        }
    }
}
