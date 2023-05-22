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
        public bool UpdateReply(UploadReply reply, IList<String> path);
        public bool AddReply(UploadReply reply, IList<String> path);

        public bool DeleteContentReply(string contentId);
        public ContentReply GetContentReply(string contentId);

    }
}
