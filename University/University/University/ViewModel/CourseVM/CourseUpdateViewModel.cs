using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.ViewModel.CourseVM
{
    public class CourseUpdateViewModel
    {
            public int CourseId { get; set; }
            public string Title { get; set; }
            public int Credits { get; set; }
            public int DepartmentId { get; set; }

            public CourseDepartmentIndexViewModel Department { get; set; }
    }
}