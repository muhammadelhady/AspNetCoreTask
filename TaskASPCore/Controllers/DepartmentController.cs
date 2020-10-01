using DAL.Entities;
using DAL.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TaskASPCore.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo departmentRepo;
        private readonly IEmpolyeeRepo empolyeeRepo;

        public DepartmentController(IDepartmentRepo departmentRepo,IEmpolyeeRepo empolyeeRepo)
        {
            this.departmentRepo = departmentRepo;
            this.empolyeeRepo = empolyeeRepo;
        }
        public async Task<IActionResult> Index()
        {
            var depts =await departmentRepo.GetAllDepartments();
            return View(depts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department model)
        {
            await departmentRepo.AddDepartment(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Report()
        {
            ViewBag.Departments = await departmentRepo.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetEmployees(int dept_Id)
        {
            var emps = await empolyeeRepo.GetDepartmentEmployees(dept_Id);
            return Ok(emps);
        }
    }
}
