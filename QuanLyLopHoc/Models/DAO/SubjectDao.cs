using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Models.DAO;


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
                //obj.CreatorId = "1";
                obj.Transcript = new Transcript();//???? sao ko lm nhu này
                db.Subjects.Add(obj);
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

        public List<User> GetListUsers(string Id)
        {
            var lst = from a in db.StudentSubjects
                      join b in db.Users on a.UserId equals b.Id
                      join c in db.Subjects on a.SubjectId equals c.Id
                      where c.Id == Id
                      select new User()
                      {
                          FirstName = b.FirstName,
                          LastName = b.LastName,
                          Email = b.Email,
                          Phone = b.Phone,
                      };
            lst.OrderBy(x => x.FirstName);
            return lst.ToList();
        }
        public List<User> GetListStudent(string subjectId, string transcriptId)
        {

            var listSTD = GetListUsers(subjectId);
            foreach (var item in listSTD)
            {
                db.Entry(item)
            .Reference(b => b.Details.Where(fk => fk.TranscriptId == transcriptId))
            .Load();
            }
            return listSTD;
        }
    }
}
