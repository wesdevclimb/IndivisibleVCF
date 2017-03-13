using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using IndivisibleVCF.Models;

namespace IndivisibleVCF.Data
{
    public class Context : DbContext
    {
        public Context() : base("Context")
        {
            Database.SetInitializer(new IndivisibleInitializer());
        }

        public DbSet<ApplicationUser> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}