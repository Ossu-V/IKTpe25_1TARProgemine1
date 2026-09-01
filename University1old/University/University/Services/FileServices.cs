using Microsoft.AspNetCore.Hosting;
using University.Models;
using University.ViewModel.CourseVM;
using University.ServiceInterface;
using University.Dto;
using University.Data;
using Microsoft.EntityFrameworkCore;

namespace University.Services
{
    public class FileServices : IFileServices
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly UniversityContext _context;

        public FileServices(IWebHostEnvironment webHost, UniversityContext context)
        {
            _webHost = webHost;
            _context = context;
        }

        // 1. ÜHE PILDI SALVESTAMINE
        public void FilesToApi(CourseCreateViewModel dto, Course domain)
        {
            if (dto.File != null && dto.File.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + dto.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    dto.File.CopyTo(fileStream);
                }

                var fileToApi = new FileToApi
                {
                    Id = Guid.NewGuid(),
                    ExistingFilePath = uniqueFileName,
                    CourseId = domain.CourseId
                };

                _context.FileToApis.Add(fileToApi);
            }
        }

        // 2. ÜHE PILDI KUSTUTAMINE
        public async Task<FileToApi?> RemoveImageFromApi(FileToApiDto dto)
        {
            var image = await _context.FileToApis
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (image != null)
            {
                string filePath = Path.Combine(_webHost.WebRootPath, "images", image.ExistingFilePath);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.FileToApis.Remove(image);
                await _context.SaveChangesAsync();
            }

            return image;
        }
    }
}