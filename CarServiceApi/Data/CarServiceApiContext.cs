using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace CarServiceApi.Data
{
    public class CarServiceApiContext : DbContext
    {
        public CarServiceApiContext (DbContextOptions<CarServiceApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.CarService> CarService { get; set; } = default!;
    }
}
