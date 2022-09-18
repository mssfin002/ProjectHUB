using Microsoft.AspNetCore.Mvc;
using ProjectHUB.Models;
using System.Diagnostics;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using ProjectHUB.Data;
using System.ComponentModel.DataAnnotations;

namespace ProjectHUB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProjectHUBContext _context;
        private IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, ProjectHUBContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }


        public class BufferedSignleFileUploadDb
        {
            [Required, Display(Name ="File")]
            public IFormFile FormFile { get; set; }

        }


        [HttpPost]
        public async Task<IActionResult> create(UploadedFile model)
        {


            if (ModelState.IsValid)
            {
                if (model.Content != null)
                {
                    string folder = "Areas/Identity/Data/UploadedFiles";
                    folder += model.Content.FileName;
                    string serverFolder = Path.Combine(_env.WebRootPath, folder);


                    await model.Content.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}