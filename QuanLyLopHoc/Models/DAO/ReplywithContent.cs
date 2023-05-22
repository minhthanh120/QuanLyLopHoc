using QuanLyLopHoc.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models.DAO
{
    public class ReplywithContent:Reply
    {
        [Required(ErrorMessage = "Bạn chưa tải bài tập lên")]
        public List<IFormFile> Files { get; set; }
        public ReplywithContent(Reply reply)
        {
            this.StudentId = reply.StudentId;
            this.PostId = reply.PostId;
            this.Id = reply.Id;
            this.Files = new List<IFormFile>();
            this.Contents = reply.Contents;
            this.Comment = reply.Comment;
            this.SubmitTime = reply.SubmitTime;
            this.StudentRep = reply.StudentRep;
            this.OriginPost = reply.OriginPost;
        }
    }
    public class ReplyExce : ContentReply
    {
        public List<IFormFile> Files { get; set; }
    }
}
