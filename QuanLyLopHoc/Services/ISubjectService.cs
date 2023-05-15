using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public interface ISubjectService
    {
        public Subject FindSubjectByInviteCode(string inviteCode);
        public bool IsStudent(string userId, string subjectId);
        public bool IsTeacher(string userId, string subjectId);
    }
}
