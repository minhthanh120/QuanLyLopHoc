using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Models.Entities;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace QuanLyLopHoc.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SMContext _db;
        private readonly SubjectDao _subjectDao; //inject dey
        public SubjectController(SMContext db, SubjectDao subjectDao)
        {
            _db = db;
            _subjectDao = subjectDao;
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
        public IActionResult AddMember()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddMember(User user)
        {
            
            return PartialView();
        }
    }
}
