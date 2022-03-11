using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mingmar4thsem.Models;

namespace mingmar4thsem.Controllers
{
    public class StudentController : Controller
    {
        Entities db = new Entities();
        // GET: Student
        public ActionResult Index()
        {
            List<tbl_student> all_data = db.tbl_student.ToList();
            return View("View",all_data);
        }
    }
}