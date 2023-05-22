using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using QuanLyLopHoc.Areas.Identity.Data;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Services;
using QuanLyLopHoc.Services.FunctionSerives;
using System.Diagnostics;
using System.Security.Claims;

namespace QuanLyLopHoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;//inject toast notification
        private readonly ISubjectService _subjectService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFileService _fileService;
        public HomeController(ILogger<HomeController> logger,
        INotyfService notyf,
        IFileService fileService,
        UserManager<ApplicationUser> userManager,
        ISubjectService subjectService)
        {
            _fileService = fileService;
            _userManager = userManager;
            _logger = logger;
            _notyf = notyf;
            _subjectService = subjectService;
        }
        [Authorize]
        public IActionResult Index(string inviteCode = null)
        {

            if (inviteCode != null && inviteCode.Length > 0)
            {
                var subject = _subjectService.FindSubjectByInviteCode(inviteCode);
                if (subject != null && subject.Id != null)
                {
                    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (_subjectService.IsStudent(id, subject.Id))
                    {
                        _notyf.Information("Bạn đang là học sinh của lớp học này");
                    }
                    else if (_subjectService.IsTeacher(id, subject.Id))
                    {
                        _notyf.Information("Bạn đang là giáo viên của lớp học này");
                    }
                    else
                    {
                        _notyf.Warning("Bạn chưa tham gia lớp học này");
                    }
                }
                ViewData["subject"] = subject;
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/Error")]
        public IActionResult WebError()
        {
            return View();
        }
        [Authorize]
        public IActionResult Join()
        {
            return PartialView();
        }
        public IActionResult DownloadFile(string path = "")
        {
            if (path != null || path != "")
            {
                var file = _fileService.GetFormFileFromPath(path);
                if (file != null)
                {
                    _notyf.Information("Đang trong quá tải xuống tài liệu");
                    return File(file.File, file.ContentType, file.FileName);
                }
                else
                {
                    _notyf.Error("Không tìm thấy tài liệu mà bạn chọn");
                }
            }
            return null;
        }
        
    }
}