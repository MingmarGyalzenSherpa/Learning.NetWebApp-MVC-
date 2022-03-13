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

    }
}