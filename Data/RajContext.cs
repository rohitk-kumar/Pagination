using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RajProj.Models;
using Microsoft.EntityFrameworkCore;

namespace RajProj.Data
{
    public class RajContext : DbContext
    {
        public RajContext(DbContextOptions<RajContext> options)
           : base(options)
        {

        }
        public DbSet<Merchant> Merchant { get; set; }
    }
}





