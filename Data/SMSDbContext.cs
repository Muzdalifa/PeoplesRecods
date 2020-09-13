using Microsoft.EntityFrameworkCore;
using RaorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaorPages.Data
{
    public class SMSDbContext:DbContext
    {
        public SMSDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }

    
}
