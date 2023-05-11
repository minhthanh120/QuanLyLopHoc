using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Models.DAO;
using Microsoft.EntityFrameworkCore;

namespace QuanLyLopHoc.Models.DAO
{
    public class SubjectDao
    {
        private readonly SMContext db;
        public SubjectDao(SMContext context)
        {
            db = context;
        }

        public List<Subject> GetListSubjects(string userId)
        {
            var lst = db.Subjects.Where(con => con.TeacherSubjects.First(con2 => con2.UserId == userId).UserId != null).ToList();
            lst.OrderBy(x => x.CreatedDate).ToList();
            return lst;
        }

        public bool Create(Subject obj)
        {
            try
            {
                obj.Transcript = new Transcript();
                obj.Transcript.CreatorId = obj.CreatorId;
                db.Subjects.Add(obj);
                db.SaveChanges();// tao dc lop thi co id cua lop
                var ts = new TeacherSubject();
                ts.SubjectId = obj.Id;
                ts.UserId = obj.CreatorId;
                db.Add(ts);
                db.SaveChanges(); 

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Subject obj)
        {
            try
            {
                var subject = db.Subjects.Find(obj.Id);
                if (subject == null)
                {
                    subject = new Subject();
                    subject.SubjectName = obj.SubjectName;
                    subject.Description = obj.Description;
                    subject.Credit = obj.Credit;
                    db.SaveChanges();
                }
                else
                {
                    subject.SubjectName = obj.SubjectName;
                    subject.Description = obj.Description;
                    subject.Credit = obj.Credit;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var subject = db.Subjects.Find(id);
                db.Subjects.Remove(subject);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
     
        public Transcript GetTranscript(string subjectId)
        {
            var transcript = db.Transcripts.Where(fk => fk.SubjectId == subjectId)
                .Include(b => b.Details)
                .FirstOrDefault();//Lay row dau tien
            foreach (var item in transcript.Details)
            {
                db.Entry(item)
            .Reference(b => b.Student)
            .Load();
            }
            return transcript;
        }

        public TeacherSubject GetListTeacher(string subjectId)
        {
            var teacher = db.TeacherSubjects.Where(fk => fk.SubjectId == subjectId)
                          .Include(b => b.User).FirstOrDefault();                                       
            db.Entry(teacher)
            .Reference(b => b.User)
            .Load();
            
            return teacher;
        }

        public bool AddStudent(User obj, string subId)
        {
            try
            {               
                var user = db.Users.Where(x => x.Email == obj.Email).FirstOrDefault();
                var ts = db.Transcripts.Where(x => x.SubjectId == subId).FirstOrDefault();
                var stu = new StudentSubject();
                stu.UserId = user.Id;
                stu.SubjectId = subId;
                db.Add(stu);        
                var details = new DetailTranscript();
                details.UserId = user.Id;
                details.TranscriptId = ts.Id;
                db.Add(details);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddTeacher(User user, string subId)
        {
            try
            {
                var teacher = new TeacherSubject();
                teacher.SubjectId = subId;
                teacher.UserId = user.Id;
                db.Add(teacher);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditTranscript(DetailTranscript obj)
        {
            try
            {
                var transcript = db.Details.Find(obj.UserId);
                if (transcript == null)
                {
                    transcript = new DetailTranscript();
                    transcript.UserId = obj.UserId;
                    transcript.DiemCC = obj.DiemCC;
                    transcript.DiemTX = obj.DiemTX;
                    transcript.DiemCK = obj.DiemCK;
                    transcript.DiemTB = obj.DiemTB;
                    db.Details.Add(transcript);
                }
                else
                {
                    transcript.UserId = obj.UserId;
                    transcript.DiemCC = obj.DiemCC;
                    transcript.DiemTX = obj.DiemTX;
                    transcript.DiemCK = obj.DiemCK;
                    transcript.DiemTB = obj.DiemTB;
                    db.SaveChanges();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
