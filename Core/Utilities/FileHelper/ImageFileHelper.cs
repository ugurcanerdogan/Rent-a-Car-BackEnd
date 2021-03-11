using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Business.FileManager
{
    public class ImageFileHelper
    {
        static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        static string path = @"Images\";
        public static string Add(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            string newFileName = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Year + "_"
               + DateTime.Now.Month + "_"
               + DateTime.Now.Day + extension;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (FileStream fileStream = File.Create(directory + path + newFileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return (path + newFileName).Replace("\\", "/");
        }

        public static string Update(IFormFile file, string OldImagePath)
        {
            Delete(OldImagePath);
            return Add(file);
        }

        public static void Delete(string ImagePath)
        {
            if (File.Exists(directory + ImagePath.Replace("/", "\\")) && Path.GetFileName(ImagePath) != "default.png")
            {
                File.Delete(directory + ImagePath.Replace("/", "\\"));
            }
        }

    }
}