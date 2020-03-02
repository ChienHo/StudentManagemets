using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagemet.Core.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext():base("StudentConnStr")
        {
            Database.SetInitializer<StudentContext>(new StudentInitilier());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
