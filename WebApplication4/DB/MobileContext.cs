using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.DB
{
    public class MobileContext:DbContext
    {
        public DbSet<FileModel> Files { get; set; }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }
        public MobileContext(DbContextOptions<MobileContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
