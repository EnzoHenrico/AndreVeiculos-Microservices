using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AddressApi.Data
{
    public class AddressApiContext : DbContext
    {
        public AddressApiContext (DbContextOptions<AddressApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Address> Address { get; set; } = default!;
    }
}
