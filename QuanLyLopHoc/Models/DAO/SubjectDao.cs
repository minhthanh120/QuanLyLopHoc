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
                ts.UserId = obj.CreatorId;//id cua giao vien mac dinh
                db.Add(ts);
                db.SaveChanges(); //ong thu luu xem nao

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
                    db.SaveChanges(); db.SaveChanges();
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

       /* public bool AddStudent(StudentSubject stu)
        {

        }*/
    }
}
