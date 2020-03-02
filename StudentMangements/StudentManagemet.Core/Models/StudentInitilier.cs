using System.Collections.Generic;
using System.Data.Entity;

namespace StudentManagemet.Core.Models
{
    internal class StudentInitilier : DropCreateDatabaseAlways<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            List<Grade> grade = new List<Grade>
            {
                new Grade
                {
                    GradeName ="Grade1"
                },
                  new Grade
                {
                    GradeName ="Grade2"
                }
            };
            List<Student> student = new List<Student>
            {
                new Student
                {
                    StudentAge = 12,
                    StudentId = 1,
                    StudentName = "name 1"
                },
                  new Student
                {
                    StudentAge = 12,
                    StudentId = 1,
                    StudentName = "name 2"
                }
            };
            context.Grades.AddRange(grade);
            context.Students.AddRange(student);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}