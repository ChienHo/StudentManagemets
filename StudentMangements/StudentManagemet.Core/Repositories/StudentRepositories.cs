using StudentManagemet.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace StudentManagemet.Core.Repositories
{
    public class StudentRepositories : IStudentRepositories
    {
        protected readonly StudentContext context;
        protected readonly DbSet<Student> dbSet;
        public StudentRepositories()
        {
            context = new StudentContext();
            dbSet = context.Set<Student>();
        }
        public int AddStudent(Student student)
        {
            dbSet.Add(student);
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return dbSet.ToList();
        }

        public Student GetStudentById(int? id)
        {
            return dbSet.Find(id);
        }

        public bool RemoveStudent(Student student)
        {
            dbSet.Remove(student);
            return context.SaveChanges()> 0;
        }

        public bool UpdateStudent(Student student)
        {
            dbSet.AddOrUpdate(student);
            return context.SaveChanges() > 0;
        }
    }
}
