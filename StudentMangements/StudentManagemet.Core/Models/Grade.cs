using System.Collections.Generic;

namespace StudentManagemet.Core.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}