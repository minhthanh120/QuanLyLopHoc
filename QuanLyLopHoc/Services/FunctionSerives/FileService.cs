using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.FileProviders;
using QuanLyLopHoc.Models.DAO;

namespace QuanLyLopHoc.Services.FunctionSerives
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }
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
        public IList<String> UploadFile(string objectId1, string ObjectId2, IList<IFormFile> model)
        {
            IList<String> fileUploaded = new List<String>();
            string relativePath = "wwwroot\\UploadedFiles\\" + objectId1 + "\\" + ObjectId2;
            foreach (var file in model)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string relativePathwithPath = Path.Combine(relativePath, file.FileName);
                string fileNameWithPath = Path.Combine(path, file.FileName);
                fileUploaded.Add(relativePathwithPath);
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return fileUploaded;
        }
        public ContentResult GetFormFileFromPath(string relativePath)
        {
            try
            {
                var fileResult = new ContentResult();
                string fileName = Path.GetFileName(relativePath);
                //string extention = "application/" + Path.GetExtension(relativePath).Split(".").Last();
                var contentType = ContentType(fileName);
                string directoryName = Path.GetDirectoryName(relativePath);
                var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), directoryName, fileName);
                //var fileResult = new PhysicalFile(absolutePath, contentType);
                //var fileResult = new PhysicalFileProvider(Path.GetDirectoryName(absolutePath)).GetFileInfo(Path.GetFileName(absolutePath));
                fileResult.FileName = fileName;
                fileResult.ContentType = contentType;
                fileResult.File = File.ReadAllBytes(absolutePath);
                return fileResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;

        }
        public string ContentType(string fileName)
        {
            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);
            return contentType ?? "application/octet-stream";
        }

    }
    public class ContentResult
    {
        public byte[] File { get; set;}
        public string FileName { get; set;}
        public string ContentType { get; set;}
    }
}