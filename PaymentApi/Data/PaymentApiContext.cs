using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace PaymentApi.Data
{
    public class PaymentApiContext : DbContext
    {
        public PaymentApiContext (DbContextOptions<PaymentApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Payment> Payment { get; set; } = default!;
    }
}
