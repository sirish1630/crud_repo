using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crud_mvc.Models;

namespace crud_mvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        //if we do not decorate with http get or post by default it will take get 
        public ActionResult Index()
        {
            Employeebusinesslayer employeebussinesslayer = new Employeebusinesslayer();
            List<Employee> employees = employeebussinesslayer.Employees.ToList();
            return View(employees);

        }
        [HttpGet]//if it gets the data it responds to the below action method
        [ActionName("Create")]
        public ActionResult Create_get()
        {
            return View();
        }
        [HttpPost]//if we want to post the data we use this
        [ActionName("Create")]
        public ActionResult Create_post()
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                UpdateModel(employee);

                Employeebusinesslayer employeebussinesslayer = new Employeebusinesslayer();
                employeebussinesslayer.Addemployee(employee);
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int ID)//id of the employee that we are going to edit
        {
            Employeebusinesslayer employeebusinesslayer= new Employeebusinesslayer();
            Employee employee = employeebusinesslayer.Employees.Single(emp => emp.id == ID);
            return View(employee);

        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employeebusinesslayer employeebussinesslayer = new Employeebusinesslayer();
                employeebussinesslayer.Savemployee(employee);
                return RedirectToAction("Index");

            }
            return View(employee);

        }

        public ActionResult Delete(int id)//id of the employee that we are going to edit
        {
            Employeebusinesslayer employeebusinesslayer = new Employeebusinesslayer();
            employeebusinesslayer.Deletemployee(id);
            return RedirectToAction("Index");

        }




    }
}