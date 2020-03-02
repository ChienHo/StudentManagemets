using StudentManagemet.Core.Models;
using System.Collections.Generic;

namespace StudentManagemet.Core.Repositories
{
    public interface IGradeRepository
    {
        int AddGrade(Grade grade);
        bool UpdateGrade(Grade grade);
        bool DeleteGrade(Grade grade);
        IEnumerable<Grade> GetAllGrade();
        Grade GetById(int? id);
    }
}