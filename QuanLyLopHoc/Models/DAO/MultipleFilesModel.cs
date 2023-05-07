using System.ComponentModel.DataAnnotations;

namespace QuanLyLopHoc.Models.DAO
{
    public class MultipleFilesModel : ReponseModel
    {
        [Required(ErrorMessage = "Please select files")]
        public List<IFormFile> Files { get; set; }
    }
}
