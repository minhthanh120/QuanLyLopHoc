using Microsoft.AspNetCore.Mvc;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SMContext _db;
        public SubjectController(SMContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Subject> objSubjectList = _db.Subjects;
            return View(objSubjectList);
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

            return View(subjectFromDb);
        }

        // GET
        public IActionResult Create()
        {        
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Create(Subject obj)
        {
            /*if (ModelState.IsValid)
            {
                _db.Subjects.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Subject");
            }
            return View();*/

            if (ModelState.IsValid)
            {
                var dao = new SubjectDao();
                dao.Create(obj);
                return RedirectToAction("Index", "Subject");
            }
            return View();
        }
        // GET
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
            /*if (ModelState.IsValid)
            {
                _db.Subjects.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Subject");
            }
            return View();*/

            var dao = new SubjectDao();
            var result = dao.Edit(obj);
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
    }
}
