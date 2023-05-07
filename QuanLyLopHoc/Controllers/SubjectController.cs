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
        public SubjectController(SMContext db, SubjectDao subjectDao)//day nua
        {
            _db = db;
            _subjectDao = subjectDao;//dey nua nha
        }

        [Authorize]

        public IActionResult Index()
        {
            /*var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<Subject> objSubjectList = _db.Subjects;
            return View(objSubjectList);*/

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var subjectList = _subjectDao.GetListSubjects("1");
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
            ViewData["subjectFromDb"] = subjectFromDb;
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
            string id = "1";
            var studentlist = _subjectDao.GetListUsers(id);
            
            return PartialView(studentlist);
        }
    }
}
