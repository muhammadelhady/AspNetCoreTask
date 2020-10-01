using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repos.Interfaces
{
    public interface IDepartmentRepo
    {
        public Task<bool> AddDepartment(Department department);
        public Task<List<Department>> GetAllDepartments();
        public Task<bool> IsDepartmentExists(Department department);



    }
}
