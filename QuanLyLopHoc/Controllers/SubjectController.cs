using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Services.FunctionSerives;
using System;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace QuanLyLopHoc.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SMContext _db;
        private readonly SubjectDao _subjectDao; //inject dey
        private readonly IFileService fileService;
        public SubjectController(SMContext db, SubjectDao subjectDao, IFileService fileService)
        {
            _db = db;
            _subjectDao = subjectDao;
            fileService = fileService;
        }

        [Authorize]

        public IActionResult Index()
        {                    
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var subjectList = _subjectDao.GetListSubjects(id);
            return View(subjectList);
        }

        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subjectFromDb = _db.Subjects.Find(id);
            if (subjectFromDb == null)
            {
                return NotFound();
            }
            _db.Entry(subjectFromDb)
            .Reference(b => b.Creator)
            .Load();
            ViewData["subjectFromDb"] = subjectFromDb;
            //pass to detail-> partial view

            var studentList = _subjectDao.GetTranscript(subjectFromDb.Id);
            ViewData["studentList"] = studentList;

            var listTeacher = _subjectDao.GetListTeacher(subjectFromDb.Id);
            ViewData["listTeacher"] = listTeacher;

            var listTranscript = _subjectDao.GetListTranscript(subjectFromDb.Id);
            ViewData["listTranscript"] = listTranscript;            

            var listPost = _subjectDao.GetListPost(subjectFromDb.Id);
            ViewData["listPost"] = listPost;

            TempData["subjectId"] = subjectFromDb.Id;

            return View();
        }

        // GET
        [HttpGet]
        public IActionResult Create()
        {        
            return View();
        }

        // POST
        [HttpPost]
        [Authorize]
        public IActionResult Create(Subject obj)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            obj.CreatorId = id;
                         
            var result = _subjectDao.Create(obj);
            if(result)
            {
                return RedirectToAction("Index", "Subject");
            }
            else
            {
                ModelState.AddModelError("", "Không tạo được lớp môn học !");
            }
          
            return View();
        }
        // GET
        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var subjectFromDb = _db.Subjects.Find(id);
            if (subjectFromDb == null)
            {
                return NotFound();
            }

            return View(subjectFromDb);
        }

        // POST
        [HttpPost]
        public IActionResult Edit(Subject obj)
        {
            var result = _subjectDao.Edit(obj);
            if (result)
            {
                return RedirectToAction("Index", "Subject");
            }
            else
            {
                ModelState.AddModelError("", "Không cập nhật được !");
            }
            return View();
        }

        // GET
        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subjectFromDb = _db.Subjects.Find(id);
            if (subjectFromDb == null)
            {
                return NotFound();
            }

            return View(subjectFromDb);
        }

        // POST
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(string? id)
        {
            var obj = _db.Subjects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
            _db.Subjects.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Subject");                     
        }

        public IActionResult ListStudent ()
        {          
            return PartialView();
        }


        [HttpGet]
        public IActionResult AddStudent() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(User user)
        {

            /*tudidoan@cloudclass.software
             travitang@cloudclass.software
            thuytuduong@cloudclass.software*/
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");

            var result = _subjectDao.AddStudent(user, sbId);
            if (result)
            {
                return RedirectToAction("Details", "Subject", new { id = sbId }); 
            }
            else
            {
                ModelState.AddModelError("", "Không thêm được học sinh !");
            }
            return View();
        }


        [HttpGet]
        public IActionResult DeleteStudent(User user)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");
            StudentSubject stu = _db.StudentSubjects.Where(x => x.UserId == user.Id && x.SubjectId == sbId).FirstOrDefault();
            _db.Entry(stu)
            .Reference(b => b.Users)
            .Load();
            return View(stu);
        }

        [HttpPost]
        public IActionResult DeleteStudent(StudentSubject obj)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");
            _subjectDao.DeleteStudent(obj, sbId);
            return RedirectToAction("Details", "Subject", new { id = sbId });
        }


        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeacher(User user)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");

            var result = _subjectDao.AddTeacher(user, sbId);
            if (result)
            {
                return RedirectToAction("Details", "Subject", new { id = sbId });
            }
            else
            {
                ModelState.AddModelError("", "Không thêm được giáo viên !");
            }
            return View();
        }


        [HttpGet]
        public IActionResult DeleteTeacher(User user)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");
            TeacherSubject teacher = _db.TeacherSubjects.Where(x => x.UserId == user.Id && x.SubjectId == sbId).FirstOrDefault();
            _db.Entry(teacher)
            .Reference(b => b.User)
            .Load();
            return View(teacher);
        }

        [HttpPost]
        public IActionResult DeleteTeacher(TeacherSubject obj)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");

            _subjectDao.DeleteTeacher(obj, sbId);
            return RedirectToAction("Details", "Subject", new { id = sbId });
        }


        [HttpGet]
        public IActionResult EditTranscript ()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult EditTranscript(List<DetailTranscript> transcripts) 
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");

            foreach (DetailTranscript item in transcripts)
            {
                _subjectDao.EditTranscript(item);
            }
            return RedirectToAction("Details", "Subject", new { id = sbId });
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(UploadPost obj) 
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");

            var listFile = UploadFile("ABC", "ABC",obj.Files);
            
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            obj.CreatorId = id;
            var result = _subjectDao.CreatePost(obj, sbId, listFile);
            if (result)
            {
                return RedirectToAction("Details", "Subject", new { id = sbId });
            }
            else
            {
                ModelState.AddModelError("", "Không tạo được bài đăng !");
            }
            
            return View();
        }
        public IList<String> UploadFile(string userId, string ObjectId, IList<IFormFile> model)
        {
            IList<String> fileUploaded = new List<String>();
            foreach (var file in model)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedFiles/" + ObjectId + "/" + userId);

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);


                string fileNameWithPath = Path.Combine(path, file.FileName);
                fileUploaded.Add(fileNameWithPath);
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return fileUploaded;
        }
    }
}
