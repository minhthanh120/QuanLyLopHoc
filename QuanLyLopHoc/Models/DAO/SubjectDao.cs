using Microsoft.EntityFrameworkCore;
using QuanLyLopHoc.Models.Entities;
using System.Security.Claims;


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
            return lst;
        }

        public bool Create(Subject obj/*, string creatorId*/)
        {
            try
            {
                obj.CreatorId = "1";
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
    }
}
