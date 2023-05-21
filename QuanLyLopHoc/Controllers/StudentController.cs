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
using QuanLyLopHoc.Models.Entities;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.WebUtilities;

using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using NuGet.Common;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json.Linq;

using Org.BouncyCastle.Utilities;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace QuanLyLopHoc.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        private readonly IStudentService _studentService;
        private readonly IConfiguration _config;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly ILogger<StudentController> _logger;
        private readonly IFileService _fileService; //inject file upload service
        private readonly INotyfService _notyf;//inject toast notification
        private readonly ISubjectService _subjectService;
        private readonly IReplyService _replyService;
        public StudentController(UserManager<ApplicationUser> userManager,
        IStudentService studentService,
        IUserService userService,
        ILogger<StudentController> logger,
        IFileService fileService,
        INotyfService notyf,
        ISubjectService subjectService,
        IConfiguration config,
        IReplyService replyService
        )
        {
            _replyService = replyService;
            _config = config;
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
            var user = await _userService.GetUserbyId(id);
            if(user!=null)
            {
                var subjects = _studentService.GetListSubjectandTranscript(id);
                var completeList = subjects.Where(d => d.Transcript.Details.FirstOrDefault().DiemTB >= 4).ToList();
                var notcompleteList = subjects.Where(d => d.Transcript.Details.FirstOrDefault().DiemTB < 4).ToList();
                var willcompleteList = subjects.Where(d => d.Transcript.Details.FirstOrDefault().DiemTB == null).ToList();
                Summary completeListConverted = new Summary();
                if (completeList != null)
                {
                    completeListConverted = new Summary(completeList);
                }
                Summary notcompleteListConverted = new Summary();

                if (notcompleteList != null)
                {
                    notcompleteListConverted = new Summary(notcompleteList);
                }
                var publicKey = _config["Jwt:Key"];
                id += ":" + publicKey;
                var token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(id));
                
                ViewData["complete"] = completeListConverted;
                ViewData["notcomplete"] = notcompleteListConverted;
                ViewData["willcomplete"] = willcompleteList;
                ViewData["token"] = token;
                ViewData["ShareMyTranscript"] = Request.GetDisplayUrl() +"/?token="+ token;
            }
            return View();
        }
        public async Task<IActionResult> Download(string token)
        {
            var userId = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token)).Split(":").First();
            var user = await _userService.GetUserbyId(userId);
            Summary completeListConverted = new Summary();
            if (user != null)
            {
                var subjects = _studentService.GetListSubjectandTranscript(userId);
                var completeList = subjects.Where(d => d.Transcript.Details.FirstOrDefault().DiemTB >= 4).ToList();
                if (completeList != null)
                {
                    completeListConverted = new Summary(completeList);
                    var html = ConverttoPDF.Template(completeListConverted, user);
                    var Renderer = new IronPdf.ChromePdfRenderer();


                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        
                        byte[] bytes = Renderer.RenderHtmlAsPdf(html).Stream.ToArray();
                        memoryStream.Close();
                    _notyf.Information("Đang trong tiến trình tải xuống bảng điểm");
                    return File(bytes, "application/force-download", "MyTranscript.pdf");
                    }
                    // Clears all content output from the buffer stream

                }
            }
            //_userManager.GenerateUserTokenAsync()
            return RedirectToAction("MyTranscript");
        }
        private string GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        

        public async Task<IActionResult> ShareMyTranscript(string token)
        {
            var userId = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token)).Split(":").First();
            var user = await _userService.GetUserbyId(userId);
            Summary completeListConverted = new Summary();
            if(user != null)
            {
                var subjects = _studentService.GetListSubjectandTranscript(userId);
                var completeList = subjects.Where(d => d.Transcript.Details.FirstOrDefault().DiemTB >= 4).ToList();
                if (completeList != null)
                {
                    completeListConverted = new Summary(completeList);
                }
            }
            //_userManager.GenerateUserTokenAsync()
            return View(completeListConverted);
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
        public ActionResult Reply(string PostId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reply = _replyService.GetReply(userId, PostId);
            if(reply.Id != null){
                reply.StudentId = userId;
                reply.PostId = PostId;
            }
            var replyContent = new ReplywithContent(reply);
            return View(replyContent);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Reply(ReplywithContent reply)//file minh post len kieu nay
        {
            reply.Files.Sum(i => i.Length);
            if (reply.Files == null)
            {
                _notyf.Warning("Mời bạn chọn file");
            }
            else if (reply.Files.Count > 0)
            {
                var path = UploadFile(reply.PostId,reply.StudentId, reply.Files);//ma nguoi dung, postId, file can tai len

                var result = _replyService.AddReply(reply, path);
                if (result)
                {
                _notyf.Success("Tải lên thành công");
                }
                else
                {
                    _notyf.Error("Đã xảy ra lỗi");
                }
            }
            else
            {
                _notyf.Error("Mời bạn chọn file");
            }
            return View("Reply", reply);
        }
        public IList<String> UploadFile(string Object1Id, string Object2Id, IList<IFormFile> model)
        {
            IList<String> fileUploaded = new List<String>();
            foreach (var file in model)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedFiles/" + Object1Id + "/" + Object2Id);

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);


                string fileNameWithPath = Path.Combine(path, file.FileName);
                fileUploaded.Add(fileNameWithPath);
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return fileUploaded;
        }
        [Authorize]
        public IActionResult DeleteReplyContent(string subjectId)
        {
            try
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (_subjectService.JoinClass(id, subjectId))
                {
                    _notyf.Success("F");
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return RedirectToAction("WebError", "Home");
        }

        [Authorize]
        public IActionResult JoinClass(string subjectId)
        {
            try
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if(_subjectService.IsTeacher(id, subjectId) || _subjectService.IsStudent(id, subjectId))
                {
                    _notyf.Information("Bạn đã tham gia lớp học này rồi");
                }
                else
                {
                    if (_subjectService.JoinClass(id, subjectId))
                    {
                        _notyf.Success("Tham gia lớp học thành công");
                    }
                    else
                    {
                        _notyf.Error("Đã xảy ra lỗi");
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Details", "Subject", new {id = subjectId});
            }
            catch(Exception ex)
            {
                _notyf.Error("Đã xảy ra lỗi");
                _logger.LogError(ex.Message, ex);
            }
            return RedirectToAction("WebError", "Home");
        }
        
    }
}
