
namespace Practise.Utilities.ImageFile
{
    public static class ImageExtension
    {
        public static string SaveImage(this IFormFile imageFile,IWebHostEnvironment env,string folder)
        {
            string path = Path.Combine(env.WebRootPath,folder);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName =imageFile .FileName;
            string fullPath = Path.Combine(path,fileName);
            using(FileStream stream = new FileStream(fullPath, System.IO.FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            return fileName;
        }
    }
}
