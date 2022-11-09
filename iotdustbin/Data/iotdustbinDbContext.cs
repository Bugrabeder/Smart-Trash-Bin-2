using iotdustbin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iotdustbin.Data
{
    public class iotdustbinDbContext :DbContext
    {
        public iotdustbinDbContext(DbContextOptions<iotdustbinDbContext> options) : base(options)
        {

        }

        public DbSet<veriler> verilers { get; set; }

    }
}
