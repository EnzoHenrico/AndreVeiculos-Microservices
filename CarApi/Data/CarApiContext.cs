using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace CarApi.Data
{
    public class CarApiContext : DbContext
    {
        public CarApiContext (DbContextOptions<CarApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; } = default!;
    }
}
