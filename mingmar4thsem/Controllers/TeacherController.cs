using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mingmar4thsem.Models;

namespace mingmar4thsem.Controllers
{
    public class TeacherController : Controller
    {
        Entities db = new Entities();
        // GET: Teacher
        public ActionResult TableView()
        {
            List<tbl_teacher> all_data = db.tbl_teacher.ToList();
            return View(all_data);
        }

        public ActionResult Delete(int id)
        {
            tbl_teacher searched = db.tbl_teacher.Find(id);
            db.tbl_teacher.Remove(searched);
            db.SaveChanges();
            return RedirectToAction("TableView");
        }

        public ActionResult Edit(int id)
        {
            tbl_teacher searched = db.tbl_teacher.Find(id);
            return View(searched);
        }
        public ActionResult Update(tbl_teacher teacher1)
        {
            db.Entry(teacher1).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("TableView");
        }

        public ActionResult AddTeacher()
        {
            return View();
        }

        public ActionResult Save(tbl_teacher teacher)
        {
            db.tbl_teacher.Add(teacher);
            db.SaveChanges();
            return RedirectToAction("TableView");
        }
    }
}