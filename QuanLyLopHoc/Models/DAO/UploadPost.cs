using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Models.DAO;
using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models.DAO
{
    public class UploadPost:Post
    {
        [Required(ErrorMessage = "Please select files")]
        public List<IFormFile> Files { get; set; }
    }
}
