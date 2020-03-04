using System.Net;
using System.Web.Mvc;
using StudentManagemet.Core.Models;
using StudentManagemet.Core.Repositories;

namespace WebApplication2.Controllers
{
    public class StudentsController : Controller
    {
        protected readonly IGradeRepository gradeRepo;
        protected readonly IStudentRepositories studentRepo;
        public StudentsController()
        {
            gradeRepo = new GradeRepository();
            studentRepo = new StudentRepositories();
        }
        // GET: Students
        public ActionResult Index()
        {
            return View(studentRepo.GetAllStudent());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentRepo.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.GradeId = new SelectList(gradeRepo.GetAllGrade(), "GradeId", "GradeName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentName,StudentAge,GradeId")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepo.AddStudent(student);
                return RedirectToAction("Index");
            }

            ViewBag.GradeId = new SelectList(gradeRepo.GetAllGrade(), "GradeId", "GradeName", student.GradeId);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentRepo.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradeId = new SelectList(gradeRepo.GetAllGrade(), "GradeId", "GradeName", student.GradeId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName,StudentAge,GradeId")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepo.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            ViewBag.GradeId = new SelectList(studentRepo.GetAllStudent(), "GradeId", "GradeName", student.GradeId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentRepo.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = studentRepo.GetStudentById(id);
            studentRepo.RemoveStudent(student);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                studentRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
