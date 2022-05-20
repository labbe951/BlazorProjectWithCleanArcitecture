using CentiroHomeAssignment.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiroHomeAssignment.Data
{
    public class CentiroHomeAssignmentDbContext : DbContext
    {
        public CentiroHomeAssignmentDbContext(DbContextOptions<CentiroHomeAssignmentDbContext> options)
            : base(options)
        {
            ;
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CentiroHomeAssignmentDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
