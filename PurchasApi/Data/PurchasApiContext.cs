using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace PurchasApi.Data
{
    public class PurchasApiContext : DbContext
    {
        public PurchasApiContext (DbContextOptions<PurchasApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Purchase> Purchase { get; set; } = default!;
    }
}
