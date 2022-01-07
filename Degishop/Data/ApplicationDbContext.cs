using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Degishop.Models;

namespace Degishop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Degishop.Models.Brands> Brands { get; set; }
        public DbSet<Degishop.Models.PC_AND_Laptop> PC_AND_Laptop { get; set; }
    }
}
