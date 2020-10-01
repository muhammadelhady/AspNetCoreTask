using DAL.Dbdontext;
using DAL.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Task_emp.Repos;

namespace DAL.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void DAL_DI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(option =>
            {
                option.UseSqlServer(configuration["Connectionstrings:DefualtConnection"], m => m.MigrationsAssembly("DAL"));
            });

            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            services.AddScoped<IEmpolyeeRepo, EmpolyeeRepo>();
        }
    }
}
