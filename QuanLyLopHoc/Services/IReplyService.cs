using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public interface IReplyService
    {
        public Reply GetReply(string studentId, string postId);
        public bool AddReply(Reply reply); 
        public bool DeleteReply(Reply reply);
        public bool UpdateReply(Reply reply);
        public bool AddReply(ReplywithContent reply, IList<String> path);

    }
}
