using StudentManagemet.Core.Models;
using StudentManagemet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class GradesController : Controller
    {
        IGradeRepository gradeRepository;
        public GradesController()
        {
            gradeRepository = new GradeRepository();
        }
        // GET: Grades
        public ActionResult Index()
        {
            return View(gradeRepository.GetAllGrade());
        }
        public PartialViewResult GetAllGrade()
        {
            return PartialView("_menuPartial", gradeRepository.GetAllGrade());
        }
        // GET: Grade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = gradeRepository.GetById(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }
        //Add grade
        /// <summary>
        /// Get method to Create Grade
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="GradeName")] Grade grade)
        {
            if(ModelState.IsValid)
            {
                gradeRepository.AddGrade(grade);
                return RedirectToAction("Index");
            }
            else
            {
                return View(grade);
            }
        }
    }
}