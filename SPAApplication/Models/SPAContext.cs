using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SPAApplication.Models
{
    public class SPAContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departaments { get; set; }
    }
}