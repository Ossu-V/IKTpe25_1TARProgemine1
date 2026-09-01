using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http; // Vajalik IFormFile jaoks
using University.Models;

namespace University.ViewModel.CourseVM
{
    public class CourseCreateViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseId { get; set; }

        public string? Title { get; set; } // Lisatud ?

        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        // Kuna me kasutame nüüd üksikut pilti:
        public IFormFile? File { get; set; } // Muudetud üksikuks ja lisatud ?

        // Vanad listid teeme kindlasti nullable'iks, et nad ei blokeeriks vormi:
        public List<IFormFile>? Files { get; set; } // Lisatud ?
        public List<ImageViewModel>? Image { get; set; } = new List<ImageViewModel>(); // Lisatud ?

        public DepartmentViewModel? Department { get; set; } // Lisatud ?
    }

    public class DepartmentViewModel
    {
        public string? Name { get; set; } // Lisatud ?
    }
}