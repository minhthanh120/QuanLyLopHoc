using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public interface IStudentService
    {
        public List<Subject> GetListSubject(string userId);
        public List<Subject> GetListSubjectandTranscript(string userId);
        public ICollection<User> SearchStudentbyEmail(string email, string subjectId);

    }
}
