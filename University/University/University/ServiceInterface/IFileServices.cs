using University.Dto;
using University.Models;
using University.ViewModel.CourseVM;

namespace University.ServiceInterface
{
    public interface IFileServices
    {
        // Muutsime CourseDto -> CourseCreateViewModel
        void FilesToApi(CourseCreateViewModel dto, Course domain);
        Task<FileToApi?> RemoveImageFromApi(FileToApiDto dto);
    }
}