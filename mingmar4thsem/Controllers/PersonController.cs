using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mingmar4thsem.Models;

namespace mingmar4thsem.Controllers
{
    public class PersonController : Controller
    {
        Entities db = new Entities();
        // GET: Person
        public ActionResult inputPerson()
        {
            List<person> all_data = db.people.ToList();
            return View(all_data);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult SaveData(person person)
        {
            db.people.Add(person);
            db.SaveChanges();
            return RedirectToAction("inputPerson");
        }

        public ActionResult Edit(int id)
        {
            person person1 = db.people.Find(id);
            return View(person1);
        }

        public ActionResult DeletePerson(int id)
        {
            person searched = db.people.Find(id);
            db.people.Remove(searched);
            db.SaveChanges();
            return RedirectToAction("inputPerson");
        }

        public ActionResult UpdateData(person person)
        {
            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("inputPerson");
        }



    }
}