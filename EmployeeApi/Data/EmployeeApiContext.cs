using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

    public class EmployeeApiContext : DbContext
    {
        public EmployeeApiContext (DbContextOptions<EmployeeApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Employee> Employee { get; set; } = default!;
    }
