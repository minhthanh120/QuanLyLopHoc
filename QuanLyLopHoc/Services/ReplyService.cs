using Microsoft.EntityFrameworkCore;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public class ReplyService : IReplyService
    {
        private readonly ILogger<ReplyService> _logger;
        private readonly SMContext _context;
        public ReplyService(SMContext context, ILogger<ReplyService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool AddReply(Reply reply)
        {
            try
            {
                _context.Add(reply);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return false;
        }
        public bool AddReply(ReplywithContent reply, IList<String> path)
        {
            _context.Add(reply);
            if (path != null)
            {
                foreach (var item in path)
                {
                    var content = new ContentReply();
                    content.ReplyId = reply.Id;
                    content.Content = item;
                    _context.Add(content);
                }
            }
            _context.SaveChanges();
            return true;
        }

        public bool DeleteReply(Reply reply)
        {
            throw new NotImplementedException();
        }

        public Reply GetReply(string studentId, string postId)
        {
            var reply = _context.Replies.Where(i => i.StudentId == studentId && i.PostId == postId)
                .Include(fk => fk.Contents)
                .FirstOrDefault();
            if (reply != null)
            {
                return reply;
            }
            return new Reply();
        }

        public bool UpdateReply(Reply reply)
        {
            throw new NotImplementedException();
        }
    }
}
