using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public interface IStudentService
    {
        public List<Subject> GetListSubject(string userId);
    }
}
