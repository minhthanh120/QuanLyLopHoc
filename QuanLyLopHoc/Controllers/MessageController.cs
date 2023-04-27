using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHoc.Areas.Identity.Data;
using QuanLyLopHoc.Services;
using System.Security.Claims;

namespace QuanLyLopHoc.Controllers
{
    public class MessageController : Controller
    {
        // GET: MessageController
        private readonly IMessageSevice _messageSevice;
        private readonly UserManager<ApplicationUser> userManager;
        public MessageController(IMessageSevice messageSevice)
        {
            _messageSevice = messageSevice;
        }
        [Authorize]
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: MessageController/Details/5
        public ActionResult Details(string Id)
        {
            return View();
        }

        // GET: MessageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageController/Create
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

        // GET: MessageController/Edit/5
        public async Task<IActionResult> PartialChatting(string userId = null)
        {
            if (userId != null)
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var historyChat = await _messageSevice.GetHistoryChat(id, userId);
                ViewData["currentUser"] = id;
                ViewData["receiver"] = userId;
                return View(historyChat);
            }
            return View();
        }

        // POST: MessageController/Edit/5
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

        // GET: MessageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MessageController/Delete/5
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
