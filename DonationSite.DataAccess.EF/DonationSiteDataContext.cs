using DonationSite.Core.Entities.Donate;
using DonationSite.Core.Entities.Site;
using Microsoft.EntityFrameworkCore;
using System;

namespace DonationSite.DataAccess.EF
{


    public class DonationSiteDataContext : DbContext
    {
        public DbSet<Site> Site { get; set; }
        public DbSet<Donate> Donate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;initial catalog=DonationSite;integrated security=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>().Property(a=>a.CreatedDateTime).HasDefaultValue(DateTime.Now);
        }

    }


}
