using DAL.Dbdontext;
using DAL.Entities;
using DAL.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_emp.Repos
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DataContext _dataContext;

        public DepartmentRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> AddDepartment(Department department)
        {
           await _dataContext.Departments.AddAsync(department);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _dataContext.Departments.ToListAsync();
        }

        public async Task<bool> IsDepartmentExists(Department department)
        {
            var dept = await _dataContext.Departments.FirstOrDefaultAsync(x=>x.Name==department.Name);
            if (dept == null)
                return false;
            return true;
        }
    }
}
