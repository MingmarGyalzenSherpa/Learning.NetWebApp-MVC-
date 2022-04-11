using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mingmar4thsem.Models;

namespace mingmar4thsem.Controllers
{
    public class EmployeeSalaryDetailController : Controller
    {
        // GET: EmployeeSalaryDetail

        public void SelectDropDown()
        {
            var empList = db.tbl_employee.ToList();
            ViewBag.empList = new SelectList(empList, "id", "name");
        }

        Entities db = new Entities();
        public ActionResult ShowEmpSalDetails()
        {
            List<employee_salary_details> all_data = db.employee_salary_details.ToList();
            SelectDropDown();
            return View(all_data);
        }

        

        public ActionResult Edit(int id)
        {
            employee_salary_details empDetail = db.employee_salary_details.Find(id);
            var empList = db.tbl_employee.ToList();
            ViewBag.empList = new SelectList(empList, "id", "name");
            return View(empDetail);
        }

        public ActionResult SaveEdit(employee_salary_details empDetails)
        {
            db.Entry(empDetails).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ShowEmpSalDetails");
        }

        public ActionResult Delete(int id)
        {
            employee_salary_details empDetails = db.employee_salary_details.Find(id);
            db.employee_salary_details.Remove(empDetails);
            db.SaveChanges();
            return RedirectToAction("ShowEmpSalDetails");

        }

        [HttpPost]
        public ActionResult Create(employee_salary_details empSalDetails)
        {
            db.employee_salary_details.Add(empSalDetails);
            db.SaveChanges();
            return RedirectToAction("ShowEmpSalDetails");

        }

        public ActionResult Search(DateTime? beginDate,DateTime? endDate,int? searchedID)
        {
            List<employee_salary_details> searchedData = new List<employee_salary_details>();
            if(searchedID != null)
            {
                searchedData = db.employee_salary_details.Where(x => x.employee_id == searchedID).ToList();
                if (beginDate != null && endDate != null)
                {
                    searchedData = searchedData.Where(x => beginDate <= x.paid_date && endDate >= x.paid_date).ToList();
                }
            }
            if (beginDate != null && endDate != null)
            {
                searchedData = db.employee_salary_details.Where(x => beginDate <= x.paid_date && endDate >= x.paid_date).ToList();
            }


            SelectDropDown();
            return View("ShowEmpSalDetails",searchedData);
        }

    }
}