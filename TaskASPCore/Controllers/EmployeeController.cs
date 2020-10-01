using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Dto;
using DAL.Entities;
using DAL.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TaskASPCore.Dto;

namespace TaskASPCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpolyeeRepo empolyeeRepo;
        private readonly IDepartmentRepo departmentRepo;

        public EmployeeController(IEmpolyeeRepo empolyeeRepo,IDepartmentRepo departmentRepo)
        {
            this.empolyeeRepo = empolyeeRepo;
            this.departmentRepo = departmentRepo;
        }
        public async Task<IActionResult> Index()
        {
            var emps = await empolyeeRepo.GetAllEmps();
            return View(emps);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await departmentRepo.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee model)
        {
            
            await empolyeeRepo.AddEmployee(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Filter(string textSerach)
        {
            var depts = await empolyeeRepo.EmployeesNameSearch(new NameDto { Name=textSerach});
           
            return Ok(depts.Select(a => new { a.Id, a.Name, dept = a.Department.Name }).ToList());
        }
    }
}
