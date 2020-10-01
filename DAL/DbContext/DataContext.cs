using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Dbdontext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {  }

        public DbSet<Department>  Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
