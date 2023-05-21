using Microsoft.EntityFrameworkCore;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public class SubjectService : ISubjectService
    {
        //private readonly 
        private readonly SMContext _context;
        private readonly ILogger<SubjectService> _logger;
        public SubjectService(SMContext context,
        ILogger<SubjectService> logger)
        {
            _logger = logger;
            _context = context;
        }
        public List<Subject> GetListSubject(string userId)
        {
            throw new NotImplementedException();
        }
        public Subject FindSubjectByInviteCode(string inviteCode){
            try
            {
                var subject = _context.Subjects.Where(c=>c.InviteCode.ToLower() == inviteCode.ToLower())
                    .Include(creator =>creator.Creator )
                    .Include(lst=>lst.TeacherSubjects)
                    .Include(lst=>lst.StudentSubjects)
                    .FirstOrDefault();
                if (subject == null)
                {
                    return new Subject();
                }
                return subject;
            }
            catch (System.Exception ex)
            {
                
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public bool IsStudent(string userId, string subjectId) {
            try
            {
                var result = _context.StudentSubjects.Where(c=>c.UserId == userId &&  c.SubjectId == subjectId).Any();
                return result;
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return false;
        }
        public bool IsTeacher(string userId, string subjectId)
        {
            try
            {
                var result = _context.TeacherSubjects.Where(c => c.UserId == userId && c.SubjectId == subjectId).Any();
                return result;
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return false;
        }
        public bool JoinClass(string userId, string subjectId){
            try
            {
                var student = new StudentSubject();
                var subject = _context.Subjects.Where(c => c.Id==subjectId)
                    .Include(c=>c.Transcript)
                    .FirstOrDefault();
                student.UserId = userId;
                student.SubjectId = subjectId;
                var detailTranscript = new DetailTranscript();
                detailTranscript.UserId = userId;
                detailTranscript.TranscriptId = subject.Transcript.Id;
                _context.Add(student);
                _context.Add(detailTranscript);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return false;
        }
        public bool JoinasTeacher(string userId, string subjectId)
        {
            try
            {
                var teacher = new TeacherSubject();
                teacher.UserId = userId;
                teacher.SubjectId = subjectId;
                _context.Add(teacher);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return false;
        }
    }
}
