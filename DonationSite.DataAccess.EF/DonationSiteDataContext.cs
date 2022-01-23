using DonationSite.Core.Entities.Donate;
using DonationSite.Core.Entities.Site;
using Microsoft.EntityFrameworkCore;
using System;

namespace DonationSite.DataAccess.EF
{


    public class DonationSiteDataContext : DbContext
    {
        private readonly string conn;

        public DbSet<Site> Site { get; set; }
        public DbSet<Donate> Donate { get; set; }

        public DonationSiteDataContext(DbContextOptions<DonationSiteDataContext> optionsBuilder) :
            base(optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(conn);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>().Property(a=>a.CreatedDateTime).HasDefaultValue(DateTime.Now);
        }

    }


}
