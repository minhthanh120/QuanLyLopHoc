using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHoc.Areas.Identity.Data;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Services;
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

        public HomeController(ILogger<HomeController> logger,
        INotyfService notyf,
        UserManager<ApplicationUser> userManager,
        ISubjectService subjectService)
        {
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
                if(subject != null && subject.Id != null)
                {
                    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (_subjectService.IsStudent(id, subject.Id))
                    {
                        _notyf.Success("is student");
                    }
                    else if (_subjectService.IsTeacher(id, subject.Id))
                    {
                        _notyf.Success("is teacher");

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
    }
}