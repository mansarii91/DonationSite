using DonationSite.Core.Entities.Donate;
using DonationSite.Core.Entities.Site;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DonationSite.DataAccess.EF
{


    public class DonationSiteDataContext : DbContext
    {
        public DbSet<Site> Site { get; set; }
        public DbSet<Donate> Donate { get; set; }

        public DonationSiteDataContext(DbContextOptions<DonationSiteDataContext> optionsBuilder) : base(optionsBuilder) {            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Insert Initial Test Data 

            #region Mock Site

            modelBuilder.Entity<Site>().HasData(
            new Site()
            {
                SiteID = 1,
                Name = "Google Co.",
                URL = "www.google.com",
                CreatedDateTime = DateTime.Now
            },
            new Site()
            {
                SiteID = 2,
                Name = "Facebook Co.",
                URL = "www.Facebook.com",
                CreatedDateTime = DateTime.Now
            },
            new Site()
            {
                SiteID = 3,
                Name = "Amazon Co.",
                URL = "www.Amazon.com",
                CreatedDateTime = DateTime.Now
            },
            new Site()
            {
                SiteID = 4,
                Name = "MCI Co.",
                URL = "www.MCI.com",
                CreatedDateTime = DateTime.Now
            },
            new Site()
            {
                SiteID = 5,
                Name = "Alexa Co.",
                URL = "www.Alexa.com",
                CreatedDateTime = DateTime.Now
            },
            new Site()
            {
                SiteID = 6,
                Name = "Linkedin Co.",
                URL = "www.Linkedin.com",
                CreatedDateTime = DateTime.Now
            },
            new Site()
            {
                SiteID = 7,
                Name = "Microsoft Co.",
                URL = "www.Microsoft.com",
                CreatedDateTime = DateTime.Now
            },
            new Site()
            {
                SiteID = 8,
                Name = "Mozilla Co.",
                URL = "www.Mozilla.com",
                CreatedDateTime = DateTime.Now
            },
            new Site()
            {
                SiteID = 9,
                Name = "Blizzard Co.",
                URL = "www.Blizzard.com",
                CreatedDateTime = DateTime.Now
            },
            new Site()
            {
                SiteID = 10,
                Name = "Activision Co.",
                URL = "www.Activision.com",
                CreatedDateTime = DateTime.Now
            }
           );

            #endregion

            #region Mock Donator

            modelBuilder.Entity<Donate>().HasData(
             new Donate() { DonateID = 1, DonatorName = "Feredrick B ", Value = 20, FKSiteID = 1 },
             new Donate() { DonateID = 2, DonatorName = "Kristopher E Smith", Value = 20, FKSiteID = 1 },
             new Donate() { DonateID = 3, DonatorName = "Edwin E Walker", Value = 34, FKSiteID = 1 },
             new Donate() { DonateID = 4, DonatorName = "Alma J Peterson", Value = 14.5m, FKSiteID = 1 },
             new Donate() { DonateID = 5, DonatorName = "Matt S Moore", Value = 40, FKSiteID = 1 },
             new Donate() { DonateID = 6, DonatorName = "William P Young", Value = 10, FKSiteID = 1 },
             new Donate() { DonateID = 7, DonatorName = "Grace R Square", Value = 50, FKSiteID = 2 },
             new Donate() { DonateID = 8, DonatorName = "Zandra N Sweeney", Value = 70, FKSiteID = 2 },
             new Donate() { DonateID = 9, DonatorName = "Monte L Mosher", Value = 60, FKSiteID = 2 },
             new Donate() { DonateID = 10, DonatorName = "Louis N Leon", Value = 30, FKSiteID = 2 },
             new Donate() { DonateID = 11, DonatorName = "Chris K Thomas", Value = 80, FKSiteID = 2 },
             new Donate() { DonateID = 12, DonatorName = "Corey K Bryson", Value = 500, FKSiteID = 2 },
             new Donate() { DonateID = 13, DonatorName = "Dennis A Schultz", Value = 47, FKSiteID = 2 },
             new Donate() { DonateID = 14, DonatorName = "Kam R Northington", Value = 52, FKSiteID = 2 },
             new Donate() { DonateID = 15, DonatorName = "Mary R Delvalle", Value = 69, FKSiteID = 2 },
             new Donate() { DonateID = 16, DonatorName = "Martha J Wright", Value = 85, FKSiteID = 2 },
             new Donate() { DonateID = 17, DonatorName = "Nickolas D Steiner", Value = 85, FKSiteID = 2 },
             new Donate() { DonateID = 18, DonatorName = "Josephine M Delarosa", Value = 78, FKSiteID = 2 },
             new Donate() { DonateID = 19, DonatorName = "Ernest V Stocking", Value = 35, FKSiteID = 3 },
             new Donate() { DonateID = 20, DonatorName = "Todd L Rodriquez", Value = 36, FKSiteID = 3 },
             new Donate() { DonateID = 21, DonatorName = "Graham S Rhodes", Value = 48, FKSiteID = 3 },
             new Donate() { DonateID = 22, DonatorName = "Walter C Wright", Value = 42, FKSiteID = 4 },
             new Donate() { DonateID = 23, DonatorName = "Sandra M Miles", Value = 19, FKSiteID = 4 },
             new Donate() { DonateID = 24, DonatorName = "Keith J Spencer", Value = 44, FKSiteID = 5 },
             new Donate() { DonateID = 25, DonatorName = "Joel A McDougal", Value = 66, FKSiteID = 6 },
             new Donate() { DonateID = 26, DonatorName = "Lisa H Dudley", Value = 22, FKSiteID = 7 },
             new Donate() { DonateID = 27, DonatorName = "Roderick B French", Value = 28, FKSiteID = 7 },
             new Donate() { DonateID = 28, DonatorName = "Emily P Aultman", Value = 90, FKSiteID = 7 },
             new Donate() { DonateID = 29, DonatorName = "Joanna E Merritt", Value = 159, FKSiteID = 10 },
             new Donate() { DonateID = 30, DonatorName = "George K Harris", Value = 50.5m, FKSiteID = 10 },
             new Donate() { DonateID = 31, DonatorName = "Bart T Aguilar", Value = 74, FKSiteID = 10 },
             new Donate() { DonateID = 32, DonatorName = "Charles E Bowles", Value = 70, FKSiteID = 10 }
            );

            #endregion

            #endregion
        }

    }


}
