using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace SaleApi.Data
{
    public class SaleApiContext : DbContext
    {
        public SaleApiContext (DbContextOptions<SaleApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Sale> Sale { get; set; } = default!;
    }
}
