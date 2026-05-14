using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        [Column("FirstName")]
        public string FirstMidName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        //mis on ICollection?
        //Nimekiri kuhu saab panna mitut objekti.

        public ICollection<CourseAssignment> CourseAssignments { get; set; }

        //miks siin ei kasutata ICollection, vaid lihtsalt OfficeAssignment?
        //siin EI kasutata ICollection, sest seos on ainult üks ühele seos Instructoriga.
        public OfficeAssignment OfficeAssignments { get; set; }
    }
}
