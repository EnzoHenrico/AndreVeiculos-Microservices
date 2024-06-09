using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ServiceApi.Data
{
    public class ServiceApiContext : DbContext
    {
        public ServiceApiContext (DbContextOptions<ServiceApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Service> Service { get; set; } = default!;
    }
}
