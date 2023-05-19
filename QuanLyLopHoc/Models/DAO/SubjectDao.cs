using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Models.DAO;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.IO;

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

        public List<DetailTranscript> GetListTranscript(string subjectId)
        {
            var transcript = db.Transcripts.Where(x => x.SubjectId == subjectId).FirstOrDefault();
            var listtranscript = db.Details.Where(fk => fk.TranscriptId == transcript.Id);               
                
            foreach (var item in listtranscript)
            {
                db.Entry(item)
            .Reference(b => b.Student)
            .Load();
            }
            return listtranscript.ToList();
        }

        public List<TeacherSubject> GetListTeacher(string subjectId)
        {
            var teachers = db.TeacherSubjects.Where(fk => fk.SubjectId == subjectId)
                          .Include(b => b.User);  
            foreach( var item in teachers)
            {
                db.Entry(item)
            .Reference(b => b.User)
            .Load();
            }    
            return teachers.ToList();
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

        public bool DeleteStudent(StudentSubject obj, string subId)
        {
            try 
            {
                var transcript = db.Transcripts.Where(x => x.SubjectId == subId).FirstOrDefault();
                StudentSubject stu = db.StudentSubjects.Where(x => x.UserId == obj.UserId &&  x.SubjectId == subId).FirstOrDefault();
                DetailTranscript details = db.Details.Where(x => x.TranscriptId == transcript.Id && x.UserId == obj.UserId).FirstOrDefault();
                db.StudentSubjects.Remove(stu);
                db.Details.Remove(details);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddTeacher(User obj, string subId)
        {
            try
            {
                var user = db.Users.Where(x => x.Email == obj.Email).FirstOrDefault();
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

        public bool DeleteTeacher(TeacherSubject obj, string subId)
        {
            try 
            {
                TeacherSubject teacher = db.TeacherSubjects.Where(x => x.UserId == obj.UserId && x.SubjectId == subId).FirstOrDefault();
                db.Remove(teacher);
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
                var transcript = db.Details.Where(x =>x.UserId == obj.UserId).FirstOrDefault();
                if (transcript == null)
                {
                    transcript = new DetailTranscript();
                    transcript.UserId = obj.UserId;
                    transcript.DiemCC = obj.DiemCC;
                    transcript.DiemTX = obj.DiemTX;
                    transcript.DiemCK = obj.DiemCK;
                    transcript.DiemTB = obj.DiemTB;
                    db.Details.Add(transcript);
                    db.SaveChanges();
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

        public List<Post> GetListPost(string subjectId)
        {
            var lstpost = db.Posts.Where(x => x.SubjectId == subjectId).ToList();
            lstpost.OrderByDescending(x => x.PostTime);
            foreach(var post in lstpost)
            {
                db.Entry(post)
                .Reference(b => b.Creator)
                .Load();
            }
            return lstpost;
        }

        public Post CreatePost(Post obj, string subjectId)
        {              
                obj.SubjectId = subjectId;
                db.Posts.Add(obj);                   
                db.SaveChanges();
                return obj;                
        }
        public bool UpdateCreatePost(UploadPost obj, string subjectId, IList<string> path)
        {
            try
            {                                      
                foreach(var item in  path)
                {
                    var content = new ContentPost();                
                    content.PostId = obj.Id;
                    content.Content = item;
                    db.Add(content);
                }               
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool EditPost(UploadPost obj) 
        {
            try
            {
                var post = db.Posts.Find(obj.Id);
                post.Title = obj.Title;
                post.Comment = obj.Comment; 
                post.Type = obj.Type;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeletePost(UploadPost obj)
        {
            try
            {
                var post = db.Posts.Find(obj.Id);
                db.Remove(post);
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
