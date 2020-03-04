﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagemet.Core.Models
{
   public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
    }
}
