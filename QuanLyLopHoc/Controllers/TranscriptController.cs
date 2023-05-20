using Microsoft.AspNetCore.Mvc;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Controllers
{
    public class TranscriptController : Controller
    {
        private readonly SMContext _db;
        public TranscriptController(SMContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<DetailTranscript> objTranscript = _db.Details;
            return View(objTranscript);
        }

        public IActionResult Details(string id)
        {
            return View();
        }

        // GET
    }
}
