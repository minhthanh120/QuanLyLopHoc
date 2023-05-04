using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public class StudentService : IStudentService
    {
        private readonly SMContext _context;
        public StudentService(SMContext context)
        {
            _context = context;
        }
        public List<Subject> GetListSubject(string userId)
        {
            var lst = _context.Subjects.Where(con => con.StudentSubjects.First(con2 => con2.UserId == userId).UserId != null).ToList();
            return lst;
        }

        public async Task<List<Subject>> GetListSubjectandTranscript(string userId)
        {
            var lst = _context.Subjects.Where(con => con.StudentSubjects.First(con2 => con2.UserId == userId).UserId != null).ToList();
            foreach (var item in lst)
            {
                
                _context.Entry(item).Reference(p => p.Transcript).Load();
                _context.Entry(item.Transcript).Collection(s=>s.Details)
                    .Query()
                    .Where(sc=>sc.UserId == userId).ToList();
            }
            return lst;
        }
    }
}
