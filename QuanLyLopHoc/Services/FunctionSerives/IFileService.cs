using QuanLyLopHoc.Models.DAO;

namespace QuanLyLopHoc.Services.FunctionSerives
{
    public interface IFileService
    {
        public IList<String> UploadFile(string userId, string ObjectId, MultipleFilesModel model);
        public IList<String> UploadFile(string userId, string ObjectId, IList<IFormFile> model);

    }
}