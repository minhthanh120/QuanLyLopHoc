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
        // GET: UserController
        public UserController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            this.userManager = userManager;
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
        //[ValidateAntiForgeryToken]
        public ActionResult Search(string search)
        {
            var model = _userService.Search(search);
            ViewData["listUser"] = model;
            return View();
        }

        // GET: UserController/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var user = await _userService.GetUserbyId(id);
            //ViewData["avatar"] = user.Avatar;
            return View(user);
        }

        public async Task< ActionResult> Create(User user)
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
        public async Task<ActionResult> Edit(int id, [Bind("Id,FirstName, LastName,Class,School,Phone,Email, BirthDay, City, Avatar")] User user)
        {
            try
            {
                await _userService.Edit(user);
                return View(user);
            }
            catch
            {
                return View();
            }
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
