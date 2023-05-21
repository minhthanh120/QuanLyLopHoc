using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.DAO;
using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Services;
using QuanLyLopHoc.Services.FunctionSerives;
using System;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text.Json;

namespace QuanLyLopHoc.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SMContext _db;
        private readonly SubjectDao _subjectDao; //inject dey
        private readonly IFileService _fileService;
        private readonly ISubjectService _subjectService;
        private readonly INotyfService _notyf;
        public SubjectController(SMContext db, SubjectDao subjectDao, IFileService fileService, ISubjectService subjectService,
            INotyfService notyf
            )
        {
            _db = db;
            _subjectDao = subjectDao;
            _fileService = fileService;
            _subjectService = subjectService;
            _notyf = notyf;
        }

        [Authorize]

        public IActionResult Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var subjectList = _subjectDao.GetListSubjects(id);
            return View(subjectList);
        }

        [Authorize]
        public IActionResult Details(string id, string StuName, string StuNameTrans)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isTeacher = _subjectService.IsTeacher(userId, id);
            ViewData["isTeacher"] = isTeacher;
            var isStudent = _subjectService.IsStudent(userId, id);
            ViewData["isStudent"] = isStudent;
            if (id == null)
            {
                return NotFound();
            }
            var subjectFromDb = _db.Subjects.Find(id);
            if (subjectFromDb == null)
            {
                return NotFound();
            }
            _db.Entry(subjectFromDb)
            .Reference(b => b.Creator)
            .Load();
            ViewData["subjectFromDb"] = subjectFromDb;
            //pass to detail-> partial view

            var studentList = _subjectDao.GetTranscript(subjectFromDb.Id);
            var lstStu = studentList.Details.OrderBy(i => string.Join(" ", (i.Student.FirstName + i.Student.LastName).Split(" ").Reverse())).ToList();
            if(!string.IsNullOrEmpty(StuName))
            {
                lstStu = lstStu.Where(i => string.Join(" ", (i.Student.FirstName + i.Student.LastName)).ToUpper().Contains(StuName.ToUpper())).ToList();
            }
            ViewData["studentList"] = lstStu;

            var listTeacher = _subjectDao.GetListTeacher(subjectFromDb.Id);
            ViewData["listTeacher"] = listTeacher;

            var listTranscript = _subjectDao.GetListTranscript(subjectFromDb.Id);
            var lstTransSX = listTranscript.OrderBy(i => string.Join(" ", (i.Student.FirstName + i.Student.LastName).Split(" ").Reverse())).ToList();
            if (!string.IsNullOrEmpty(StuNameTrans))
            {
                lstTransSX = lstTransSX.Where(i => string.Join(" ", (i.Student.FirstName + i.Student.LastName)).ToUpper().Contains(StuNameTrans.ToUpper())).ToList();
            }
            ViewData["listTranscript"] = lstTransSX;

            var listPost = _subjectDao.GetListPost(subjectFromDb.Id);
            ViewData["listPost"] = listPost.OrderByDescending(i=>i.PostTime).ToList();

            TempData["subjectId"] = subjectFromDb.Id;

            return View();
        }
        public IActionResult Download(string id)
        {
            if (id == null || !_db.Subjects.Any(i => i.Id == id))
            {
                return NotFound();
            }
            var listTranscript = _subjectDao.GetListTranscript(id);
            var list = listTranscript.OrderBy(i => string.Join(" ", (i.Student.FirstName + i.Student.LastName).Split(" ").Reverse())).ToList();
            try
            {
                var file = DownloadExcel(list);
                _notyf.Information("Đang trong tiến trình tải xuống bảng điểm lớp học");
                return File(file, "application/force-download", "Report.xlsx");
            }
            catch(Exception ex)
            {
                _notyf.Error("Rất tiếc! Đã xảy ra sự cố");
            }
            return View();
        }

        public byte[] DownloadExcel(List<DetailTranscript> detailTranscripts)
        {
            

            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "Họ và tên";
            Sheet.Cells["B1"].Value = "Email";
            Sheet.Cells["C1"].Value = "Điểm Chuyên cần";
            Sheet.Cells["D1"].Value = "Điểm thường xuyên";
            Sheet.Cells["E1"].Value = "Điểm thi cuối kỳ";
            Sheet.Cells["F1"].Value = "Điểm thi Trung bình";
            int row = 2;
            foreach (var item in detailTranscripts)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.Student.FirstName+" "+item.Student.LastName;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.Student.Email;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.DiemCC;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.DiemTX;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.DiemCK;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.DiemTB;
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();

            return Ep.GetAsByteArray();
        }

        [Authorize]
        // GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [Authorize]
        public IActionResult Create(Subject obj)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            obj.CreatorId = id;

            var result = _subjectDao.Create(obj);
            if (result)
            {
                _notyf.Success("Tạo lớp môn học thành công");
                return RedirectToAction("Index", "Subject");
            }
            else
            {
                _notyf.Error("Không tạo được lớp môn học !");
                ModelState.AddModelError("", "Không tạo được lớp môn học !");
            }

            return View();
        }
        // GET
        [HttpGet]
        [Authorize]
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subjectFromDb = _db.Subjects.Find(id);
            if (subjectFromDb == null)
            {
                return NotFound();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isTeacher = _subjectService.IsTeacher(userId, id);
            if(isTeacher == true)
            {
                return View(subjectFromDb);
            }
            else
            {
                return RedirectToAction("Index", "Subject");
            }
            
        }

        // POST
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Subject obj)
        {
            var result = _subjectDao.Edit(obj);
            if (result)
            {
                _notyf.Success("Chỉnh sửa lớp môn học thành công");
                return RedirectToAction("Index", "Subject");
            }
            else
            {
                _notyf.Error("Đã xảy ra lỗi");
                ModelState.AddModelError("", "Không cập nhật được !");
            }
            return View();
        }

        // GET
        [Authorize]
        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subjectFromDb = _db.Subjects.Find(id);
            if (subjectFromDb == null)
            {
                return NotFound();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isTeacher = _subjectService.IsTeacher(userId, id);
            if (isTeacher == true)
            {
                return View(subjectFromDb);
            }
            else
            {
                return RedirectToAction("Index", "Subject");
            }    
        }

        // POST
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(string? id)
        {
            var obj = _db.Subjects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Subjects.Remove(obj);
            _db.SaveChanges();
            _notyf.Success("Xóa lớp môn học thành công");
            return RedirectToAction("Index", "Subject");
        }

        public IActionResult ListStudent()
        {
            return PartialView();
        }


        [HttpGet]
        [Authorize]
        public IActionResult AddStudent()
        {
            ViewData["subjectId"] = TempData["subjectId"].ToString();
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddStudent(User user)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");

            var result = _subjectDao.AddStudent(user, sbId);
            if (result)
            {
                _notyf.Success("Thêm sinh viên thành công");
                return RedirectToAction("Details", "Subject", new { id = sbId });
            }
            else
            {
                _notyf.Error("Đã xảy ra lỗi");
                ModelState.AddModelError("", "Không thêm được học sinh !");
            }
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult DeleteStudent(User user)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");
            StudentSubject stu = _db.StudentSubjects.Where(x => x.UserId == user.Id && x.SubjectId == sbId).FirstOrDefault();
            _db.Entry(stu)
            .Reference(b => b.Users)
            .Load();
            return View(stu);
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteStudent(StudentSubject obj)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");
            _subjectDao.DeleteStudent(obj, sbId);
            _notyf.Success("Xóa sinh viên thành công");
            return RedirectToAction("Details", "Subject", new { id = sbId });
        }


        [HttpGet]
        [Authorize]
        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddTeacher(User user)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");

            var result = _subjectDao.AddTeacher(user, sbId);
            if (result)
            {
                return RedirectToAction("Details", "Subject", new { id = sbId });
            }
            else
            {
                ModelState.AddModelError("", "Không thêm được giáo viên !");
            }
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult DeleteTeacher(User user)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");
            TeacherSubject teacher = _db.TeacherSubjects.Where(x => x.UserId == user.Id && x.SubjectId == sbId).FirstOrDefault();
            _db.Entry(teacher)
            .Reference(b => b.User)
            .Load();
            return View(teacher);
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteTeacher(TeacherSubject obj)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");

            _subjectDao.DeleteTeacher(obj, sbId);
            _notyf.Success("Xóa giáo viên thành công");
            return RedirectToAction("Details", "Subject", new { id = sbId });
        }


        [HttpGet]
        [Authorize]
        public IActionResult EditTranscript()
        {
            return PartialView();
        }
        [HttpPost]
        [Authorize]
        public IActionResult EditTranscript(List<DetailTranscript> transcripts)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");

            foreach (DetailTranscript item in transcripts)
            {
                _subjectDao.EditTranscript(item);
            }
            return RedirectToAction("Details", "Subject", new { id = sbId });
        }

        [Authorize]
        public IActionResult SumaryTranscript()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreatePost(UploadPost obj)
        {
            string sbId = TempData["subjectId"].ToString();
            TempData.Keep("subjectId");

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            obj.CreatorId = id;

            var post = _subjectDao.CreatePost(obj, sbId);
            if (obj.Files != null)
            {
                var listFile = UploadFile(sbId, post.Id, obj.Files);
                var result = _subjectDao.UpdateCreatePost(obj, sbId, listFile);
                if (!result)
                {
                    _notyf.Error("Đã xảy ra lỗi");
                    ModelState.AddModelError("", "Không tạo được bài đăng !");
                }
            }
            _notyf.Success("Đã tạo bài đăng mới", 10);
            return RedirectToAction("Details", "Subject", new { id = sbId });
        }

        [Authorize]
        public IActionResult DetailsPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _db.Posts.Find(id);
            _db.Entry(post).Collection(x => x.Contents).Load();
            _db.Entry(post).Reference(x => x.Creator).Load();
            return View(post);
        }



        [HttpGet]
        [Authorize]
        public IActionResult DeletePost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _db.Posts.Find(id);
            _db.Entry(post).Collection(x => x.Contents).Load();
            _db.Entry(post).Reference(x => x.Creator).Load();
            var subjectId = post.SubjectId;
            try
            {
                var result = _subjectDao.DeletePost(post);
            }
            catch (Exception ex)
            {
                _notyf.Error("Đã xảy ra lỗi");
            }
            _notyf.Success("Xóa bài đăng thành công", 10);
            return RedirectToAction("Details", "Subject", new { id = subjectId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeletePost()
        {
            return View();
        }

        public IList<String> UploadFile(string subId, string ObjectId, IList<IFormFile> model)
        {
            IList<String> fileUploaded = new List<String>();
            foreach (var file in model)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedFiles/" + subId + "/" + ObjectId);

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

        public IActionResult Reply()
        {
            return View();
        }
    }
}
