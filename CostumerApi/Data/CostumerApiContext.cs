using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

    public class CostumerApiContext : DbContext
    {
        public CostumerApiContext (DbContextOptions<CostumerApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Customer> Customer { get; set; } = default!;
    }
