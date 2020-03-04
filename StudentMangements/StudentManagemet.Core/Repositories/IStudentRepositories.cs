using StudentManagemet.Core.Models;
using System;
using System.Collections.Generic;

namespace StudentManagemet.Core.Repositories
{
    public interface IStudentRepositories: IDisposable
    {
        int AddStudent(Student student);
        bool RemoveStudent(Student student);
        bool UpdateStudent(Student student);
        IEnumerable<Student> GetAllStudent();
        Student GetStudentById(int? id);
    }
}