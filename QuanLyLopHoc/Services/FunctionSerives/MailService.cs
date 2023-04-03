using Microsoft.EntityFrameworkCore;
using QuanLyLopHoc.Models;

namespace QuanLyLopHoc.Services.FunctionSerives
{
    public class MailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly SMContext _dbContext;
        public MailService() { }
    }
}
