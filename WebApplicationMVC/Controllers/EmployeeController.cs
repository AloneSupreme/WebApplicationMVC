﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> allEmployees = employeeContext.Employees.ToList<Employee>();

            return View("Index", allEmployees);
        }

        public ActionResult Detail_department(int departmentId)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.Where(emp => emp.DepartmentId == departmentId ).ToList<Employee>();

            return View("Index", employees);
        }

        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeId == id);

            return View(employee);
        }

        public ActionResult AllEmployeeDetails()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> allEmployeeDetails = employeeContext.Employees.ToList<Employee>();

            return View(allEmployeeDetails);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Employee employee = new Employee();
            UpdateModel<Employee>(employee);
            if (ModelState.IsValid)
            {
                EmployeeContext empContext = new EmployeeContext();
                empContext.AddEmployee(employee);

                return RedirectToAction("AllEmployeeDetails");
            }
            return View();
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            EmployeeContext emp = new EmployeeContext();
            Employee employee = emp.Employees.Single(e => e.EmployeeId == id);

            return View(employee);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            EmployeeContext empCnxt = new EmployeeContext();
            Employee employee = empCnxt.Employees.Single(x => x.EmployeeId == id);
            UpdateModel(employee, new string[] { "EmployeeId", "Gender", "City", "DepartmentId", "DateOfBirth" });
            if (ModelState.IsValid) { 
                empCnxt.SaveEmployee(employee);

                return RedirectToAction("AllEmployeeDetails");
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeContext empCnxt = new EmployeeContext();
            empCnxt.DeleteEmployee(id);

            return RedirectToAction("AllEmployeeDetails");
        }
    }
}