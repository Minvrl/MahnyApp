using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Service.Extensions
{
    public static class FileExtension
    {
        public static string Save(this IFormFile file, string root, string folder)
        {
            string newFileName = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(root, folder, newFileName);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }
            return newFileName;
        }
        public static string Save(this IFormFile file, string folder)
        {
            string newFileName = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot", folder, newFileName);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return newFileName;
        }



        public static void Delete(this string fileName, string root, string folder)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return;

            string filePath = Path.Combine(root, folder, fileName);

            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to delete file! {ex.Message}");
                }
            }
        }

        public static void Delete(this string fileName, string folder)
        {
            string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            Delete(fileName, root, folder);
        }
    }
}
