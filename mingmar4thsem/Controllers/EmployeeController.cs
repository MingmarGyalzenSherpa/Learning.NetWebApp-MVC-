using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mingmar4thsem.Models;

namespace mingmar4thsem.Controllers
{
    public class EmployeeController : Controller
    {
        Entities db = new Entities();
        // GET: Employee
        public ActionResult ShowEmployees()
        {
            List<tbl_employee> all_emp_data = db.tbl_employee.ToList();
          
            return View(all_emp_data);
        }

        public ActionResult AddEmployee(tbl_employee Employee)
        {
            db.tbl_employee.Add(Employee);
            db.SaveChanges();
            return RedirectToAction("ShowEmployees");
        }

    }
}