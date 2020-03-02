using StudentManagemet.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagemet.Core.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        protected readonly StudentContext context;
        protected readonly DbSet<Grade> dbSet;
        public GradeRepository()
        {
            context = new StudentContext();
            dbSet = context.Set<Grade>();
        }
        public int AddGrade(Grade grade)
        {
            dbSet.Add(grade);
            return context.SaveChanges();
        }

        public bool DeleteGrade(Grade grade)
        {
            dbSet.Remove(grade);
            return context.SaveChanges() >0;

        }

        public IEnumerable<Grade> GetAllGrade()
        {
           return dbSet.ToList();
        }

        public Grade GetById(int? id)
        {
            return dbSet.Find(id);
        }

        public bool UpdateGrade(Grade grade)
        {
            dbSet.AddOrUpdate(grade);
            return context.SaveChanges() > 0;
        }
    }
}
