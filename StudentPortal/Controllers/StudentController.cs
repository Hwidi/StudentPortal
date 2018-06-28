using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        private WorkUnit _unit = null;

        public StudentController()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            _unit = new WorkUnit(connString);
        }

        public StudentController(WorkUnit unit)
        {
            _unit = unit;
        }

        //
        // GET: /Student/
        public ActionResult Index()
        {
            return View(_unit.StudentsRepository.GetAll().ToList());
        }

        //
        // GET: /Student/Add/
        public ActionResult Add()
        {
            return PartialView();
        }

        //
        // POST: /Student/Add/
        [HttpPost]
        public ActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                _unit.StudentsRepository.Add(student);
                _unit.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        //
        // GET: /Student/Edit/
        public ActionResult Edit(int id)
        {
            var student = _unit.StudentsRepository.Get(s => s.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return PartialView(student);
        }

        //
        // POST: /Student/Edit/
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _unit.StudentsRepository.Edit(student);
                _unit.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}