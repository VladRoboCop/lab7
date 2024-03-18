using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace MyNamespace.Controllers
{
    public class FileController : Controller
    {
        [Route("File/DownloadFile")]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        [Route("File/DownloadFile")]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName + ".txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Ім`я: {firstName}");
                writer.WriteLine($"Прізвище: {lastName}");
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "text/plain", fileName + ".txt");
        }
    }
}
