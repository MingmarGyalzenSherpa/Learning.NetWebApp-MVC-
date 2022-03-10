using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mingmar4thsem.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult inputPerson()
        {
            return View();
        }
    }
}