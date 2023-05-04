using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHoc.Areas.Identity.Data;
using QuanLyLopHoc.Services;
using System.Security.Claims;

namespace QuanLyLopHoc.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        private readonly IStudentService _studentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        public StudentController(IStudentService studentService, IUserService userService)
        {
            _studentService = studentService;
            _userService = userService;

        }
        [Authorize]
        public ActionResult Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var subjects = _studentService.GetListSubject(id);
            return View(subjects);
        }

        public async Task<IActionResult> MyTranscript()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var subjects = await _studentService.GetListSubjectandTranscript(id);
            var completeList = subjects.Where(d => d.Transcript.Details.FirstOrDefault().DiemTB >= 4).ToList();
            var notcompleteList = subjects.Where(d => d.Transcript.Details.FirstOrDefault().DiemTB < 4).ToList();
            var willcompleteList = subjects.Where(d => d.Transcript.Details.FirstOrDefault().DiemTB == null).ToList();


            return View();
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
