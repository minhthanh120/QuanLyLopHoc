using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using QuanLyLopHoc.Areas.Identity.Data;
using QuanLyLopHoc.Services;
using System.Security.Claims;
using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Services.FunctionSerives;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace QuanLyLopHoc.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        private readonly IStudentService _studentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly ILogger<StudentController> _logger;
        private readonly IFileService _fileService; //inject file upload service
        private readonly INotyfService _notyf;//inject toast notification
        private readonly ISubjectService _subjectService;
        public StudentController(UserManager<ApplicationUser> userManager,
        IStudentService studentService,
        IUserService userService,
        ILogger<StudentController> logger,
        IFileService fileService,
        INotyfService notyf,
        ISubjectService subjectService
        )
        {
            _studentService = studentService;
            _userService = userService;
            _logger = logger;
            _userManager = userManager;
            _notyf = notyf;
            _fileService = fileService;
            _subjectService = subjectService;
        }
        [Authorize]
        public ActionResult Index(int page = 1)
        {
            try
            {
                int size = 9;
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var subjects = _studentService.GetListSubject(id);
                return View(subjects.ToPagedList(page, size));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return RedirectToAction("WebError", "Home");
        }
        [Authorize]
        public ActionResult Search(string key)
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
            ViewData["complete"] = completeList;
            ViewData["notcomplete"] = notcompleteList;
            ViewData["willcomplete"] = willcompleteList;
            //completeList.Sum(i => i.Credit);
            //completeList.Sum(i => i.Transcript.Details.Sum(j => j.DiemTB));
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
        [Authorize]
        public ActionResult Reply()
        {
            MultipleFilesModel model = new MultipleFilesModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Reply(MultipleFilesModel model)
        {
            string postId = "";
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            model.IsResponse = true;
            if (model.Files == null)
            {
                model.IsSuccess = false;
                model.Message = "Mời bạn chọn file";
                _notyf.Warning(model.Message);
            }
            else if (model.Files.Count > 0)
            {
                var result = _fileService.UploadFile(userId, postId, model);//ma nguoi dung, postId, file can tai len
                model.IsSuccess = true;
                model.Message = "Tải lên thành công";
                _notyf.Success(model.Message);
            }
            else
            {
                model.IsSuccess = false;
                model.Message = "Mời bạn chọn file";
                _notyf.Error(model.Message);

            }
            return View("Reply", model);
        }
        [Authorize]
        public IActionResult JoinClass(string subjectId)
        {
            try
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (_subjectService.JoinClass(id, subjectId))
                {
                    _notyf.Success("is student");
                }
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return RedirectToAction("WebError", "Home");
        }
    }
}
