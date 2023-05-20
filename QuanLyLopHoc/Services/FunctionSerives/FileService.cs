using QuanLyLopHoc.Models.DAO;

namespace QuanLyLopHoc.Services.FunctionSerives
{
    public class FileService : IFileService
    {
        public IList<String> UploadFile(string userId, string ObjectId, MultipleFilesModel model)
        {
            IList<String> fileUploaded = new List<String>();
            foreach (var file in model.Files)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedFiles/" + ObjectId + "/" + userId);

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
        public IList<String> UploadFile(string userId, string ObjectId, IList<IFormFile> model)
        {
            IList<String> fileUploaded = new List<String>();
            foreach (var file in model)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedFiles/" + ObjectId + "/" + userId);

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
    }
}