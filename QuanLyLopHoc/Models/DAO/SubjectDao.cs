using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Models.DAO
{
    public class SubjectDao
    {
        SMContext db = null;
        public SubjectDao()
        {
            db = new SMContext();
        }
        public string Create(Subject obj)
        {
            db.Subjects.Add(obj);
            db.SaveChanges();
            return obj.Id;
        }

        public bool Edit(Subject obj)
        {
            try
            {
                var subject = db.Subjects.Find(obj.Id);
                if (subject == null)
                {
                    subject.SubjectName = obj.SubjectName;
                    subject.Description = obj.Description;
                    db.SaveChanges();
                }
                else
                {
                    db.Subjects.Update(obj);
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
    }
}
