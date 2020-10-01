using DAL.Dto;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskASPCore.Dto;

namespace DAL.Repos.Interfaces
{
    public interface IEmpolyeeRepo
    {
        public Task<bool> AddEmployee(Employee employee);
        public Task<List<Employee>> GetDepartmentEmployees(int department);
        public Task<List<Employee>> EmployeesNameSearch(NameDto textSerach);
        public Task<Employee> GetEmpolyee(EmpDto empNameDto);
        public Task<bool> IsEmployeeExists(Employee employee);
        public Task<List<Employee>> GetAllEmps();




    }
}
