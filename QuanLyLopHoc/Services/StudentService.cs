using Microsoft.EntityFrameworkCore;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Repositories;

namespace QuanLyLopHoc.Services
{
    public class StudentService : IStudentService
    {
        private readonly SMContext _context;
        private readonly IUserRepository _userRepository;
        private readonly ISubjectService _subjectService;

        public StudentService(SMContext context, IUserRepository userRepository, ISubjectService subjectService)
        {
            _context = context;
            _userRepository = userRepository;
            _subjectService = subjectService;
        }
        public List<Subject> GetListSubject(string userId)
        {
            var lst = _context.Subjects.Where(con => con.StudentSubjects.First(con2 => con2.UserId == userId).UserId != null).ToList();
            return lst;
        }

        public List<Subject> GetListSubjectandTranscript(string userId)
        {
            var lst = GetListSubject(userId);
            foreach (var item in lst)
            {

                _context.Entry(item).Reference(p => p.Transcript).Load();
                _context.Entry(item.Transcript).Collection(s => s.Details)
                    .Query()
                    .Where(sc => sc.UserId == userId)
                    .Load();
            }
            return lst;
        }
        public ICollection<User> SearchStudentbyEmail(string email, string subjectId)
        {
            var result = _userRepository.FindListUserbyEmail(email);
            if (result != null && result.Any())
            {
                result = (from user in result where !_subjectService.IsStudent(user.Id, subjectId) && !_subjectService.IsTeacher(user.Id, subjectId) select user).ToList();
            }
            return result;
        }
    }
}
