using DAL.Dbdontext;
using DAL.Dto;
using DAL.Entities;
using DAL.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskASPCore.Dto;

namespace Task_emp.Repos
{
    public class EmpolyeeRepo : IEmpolyeeRepo
    {
        private readonly DataContext _dataContext;

        public EmpolyeeRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> AddEmployee(Employee employee)
        {
            await _dataContext.Employees.AddAsync(employee);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Employee>> EmployeesNameSearch(NameDto TextSearch)
        {
            if(TextSearch.Name==null)
                return await _dataContext.Employees.Take(10).Include(e => e.Department).ToListAsync();

            return await _dataContext.Employees.Where(x => x.Name.Contains(TextSearch.Name)).Take(10).Include(e=>e.Department).ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmps()
        {
            return await _dataContext.Employees.Include(e=>e.Department).ToListAsync();
        }

        public async Task<List<Employee>> GetDepartmentEmployees(int department)
        {
            return await _dataContext.Employees.Where(x => x.DeptId == department).ToListAsync();
        }

        public async Task<Employee> GetEmpolyee(EmpDto empNameDto)
        {
            return await _dataContext.Employees.Where(x => x.Name == empNameDto.Name).Include(x => x.Department).FirstOrDefaultAsync();
        }

        public async Task<bool> IsEmployeeExists(Employee employee)
        {
            var emp = await _dataContext.Employees.FirstOrDefaultAsync(x => x.Name == employee.Name);
            if (emp == null)
                return false;
            return true;
        }
    }
}
