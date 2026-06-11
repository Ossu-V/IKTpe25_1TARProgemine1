using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace University.ViewModel.CourseVM
{
    public class CourseUpdateViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public CourseDepartmentIndexViewModel Department { get; set; }

        public IFormFile? File { get; set; }
        public List<ImageViewModel>? Image { get; set; } = new List<ImageViewModel>();
    }
}