using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHoc.Areas.Identity.Data;
using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Services;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace QuanLyLopHoc.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INotyfService _notyf;
        private readonly ILogger<UserController> _logger;
        // GET: UserController
        public UserController(IUserService userService, INotyfService notyf, UserManager<ApplicationUser> userManager, ILogger<UserController> logger)
        {
            _userService = userService;
            this.userManager = userManager;
            _notyf = notyf;
            _logger = logger;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string search)
        {
            //var key = search["key"];
            //search = "ok";
            ViewData["listUser"] = _userService.Search(search);
            return View("Search");
        }

        // GET: UserController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Search(string search)
        {
            var model = _userService.Search(search);
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userService.GetUserbyId(id);
            if (model.Any(i => i.Id == id))
            {
                model.Remove(currentUser);
            }
            ViewData["listUser"] = model;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> SearchbyEmail(string emailkey, string subjectId)
        {
            var model = _userService.SearchByEmail(emailkey);
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userService.GetUserbyId(id);
            if (model.Any(i => i.Id == id))
            {
                model.Remove(currentUser);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SearchbyNameandEmail(string searchKey)
        {
            var model = await _userService.SearchByNameandEmail(searchKey);
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userService.GetUserbyId(id);
            if (model.Any(i => i.Id == id))
            {
                model.Remove(currentUser);
            }
            ViewData["listUser"] = model;
            return View();
        }

        // GET: UserController/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit()
        {
            try
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userService.GetUserbyId(id);
                //ViewData["avatar"] = user.Avatar;
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return RedirectToAction("WebError", "Home");
        }

        public ActionResult Create(User user)
        {
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,FirstName, LastName,Email, Avatar")] User user)
        {
            //var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _userService.CreateUserInfo(user);
            //ViewData["avatar"] = user.Avatar;
            return RedirectToAction("Index", "Home");
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,FirstName,Gender, LastName,Class,School,Phone, BirthDay, City, Avatar")] User user)
        {
            try
            {
                var MinDate = DateTime.Parse("1/1/1965");
                var MaxDate = DateTime.Parse("1/1/2005");
                if (user.BirthDay < MinDate || user.BirthDay > MaxDate || user.Gender == null){
                    _notyf.Error("Chỉnh sửa thông tin ko thành công");
                    return View(user);
                }
                await _userService.Edit(user);
                _notyf.Success("Chỉnh sửa thông tin thành công");
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return RedirectToAction("WebError", "Home");

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: UserController/Delete/5
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
