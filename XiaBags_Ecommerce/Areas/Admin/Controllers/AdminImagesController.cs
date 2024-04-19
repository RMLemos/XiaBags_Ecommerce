using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using XiaBags_Ecommerce.Models;

namespace XiaBags_Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagesController : Controller
    {
        private readonly ConfigurationImages _myConfig;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminImagesController(IWebHostEnvironment hostingEnvironment, IOptions<ConfigurationImages> myConfiguration)
        {
            _hostingEnvironment = hostingEnvironment;
            _myConfig = myConfiguration.Value;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["Error"] = "Error: File(s) not selected";
                return View(ViewData);
            }

            if (files.Count > 10)
            {
                ViewData["Error"] = "Error: Number of files exceeded limit";
                return View(ViewData);
            }

            long size = files.Sum(f => f.Length);

            var filePathsName = new List<string>();

            var filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                _myConfig.NameFolderImages);

            foreach (var formFile in files)
            {
                if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".gif")
                    || formFile.FileName.Contains(".png"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                    filePathsName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            ViewData["Result"] = $"{files.Count} files were uploaded to the server, " +
                                     $" with a total size of: {size} bytes";

            ViewBag.Files = filePathsName;

            return View(ViewData);
        }

        public IActionResult GetImages()
        {
            FileManagerModel model = new FileManagerModel();

            var userImagesPath = Path.Combine(_hostingEnvironment.WebRootPath,
                _myConfig.NameFolderImages);


            DirectoryInfo dir = new DirectoryInfo(userImagesPath);

            FileInfo[] files = dir.GetFiles();

            model.PathImagesProduct = _myConfig.NameFolderImages;

            if (files.Length == 0)
            {
                ViewData["Error"] = $"No files found in folder {userImagesPath}";
            }

            model.Files = files;

            return View(model);
        }

        public IActionResult Deletefile(string fname)
        {
            string _deleteImage = Path.Combine(_hostingEnvironment.WebRootPath,
                _myConfig.NameFolderImages + "\\", fname);

            if ((System.IO.File.Exists(_deleteImage)))
            {
                System.IO.File.Delete(_deleteImage);

                ViewData["Deleted"] = $"Arquivo(s) {_deleteImage} deleted";
            }

            return View("index");
        }
    }
}
