using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyLopHoc.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Login
        public ActionResult Login(int id)
        {
            return View();
        }

        // GET: UserController/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: UserController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(IFormCollection collection)
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

        // GET: UserController/ResetPassword
        public ActionResult ResetPassword(int id)
        {
            return View();
        }

        // POST: UserController/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(int id, IFormCollection collection)
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
