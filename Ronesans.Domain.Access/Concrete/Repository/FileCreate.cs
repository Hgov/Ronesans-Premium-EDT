using Microsoft.AspNetCore.Http;
using Ronesans.Domain.Access.Abstract.IRepository;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Ronesans.Domain.Concrete.Domain.File;

namespace Ronesans.Domain.Access.Concrete.Repository
{
    public class FileCreate<TEntity> : IFileCreate<File> where TEntity : class
    {
        public enum FileFormat
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            unknown
        }
        public async Task<string> UploadFile(File file)
        {
            if (CheckIfFileFile(file.from_file))
            {
                var path = await WriteFile(file);
                return path;
            }

            return "Invalid File file";
        }


        public void DeleteFile(File file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\" + file.content_type.Substring(0, file.content_type.IndexOf("/")) + "\\", file.file_name);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }

        private bool CheckIfFileFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return GetFileFormat(fileBytes) != FileFormat.unknown;
        }


        public async Task<string> WriteFile(File file)
        {
            string path;
            try
            {                                                                                 //for the file due to security reasons.
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\" + file.content_type.Substring(0, file.content_type.IndexOf("/")) + "\\", file.file_name);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.from_file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return file.file_name;
        }
       
        public static FileFormat GetFileFormat(byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };              // PNG
            var tiff = new byte[] { 73, 73, 42 };                  // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };                 // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 };          // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 };         // jpeg canon


            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return FileFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return FileFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return FileFormat.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return FileFormat.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return FileFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return FileFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return FileFormat.jpeg;

            return FileFormat.unknown;
        }
    }
}
