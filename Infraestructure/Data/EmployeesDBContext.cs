using System;
using Core.Entities;
using Infraestructure.Data.Configurations;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infraestructure.Data
{
    public partial class EmployeesDBContext : DbContext
    {

        public EmployeesDBContext(DbContextOptions<EmployeesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Subarea> Subareas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AreaConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new SubareaConfig());
        }

        //    public virtual ObjectResult<Areas> get() { }
    }
}
