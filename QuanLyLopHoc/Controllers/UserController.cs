using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Services;
using System.Security.Claims;

namespace QuanLyLopHoc.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        // GET: UserController
        public UserController(IUserService userService)
        {
            _userService = userService;
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

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,FirstName, LastName,Class,School,Phone,Email, BirthDay, City")] User user)
        {
            try
            {
                _userService.Edit(user);
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
