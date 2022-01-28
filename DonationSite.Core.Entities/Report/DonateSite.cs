using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationSite.Core.Entities.Report
{
    public class DonateSite
    {
        public string SiteName { get; set; }
        public string SiteURL { get; set; }
        public decimal TotalDonation { get; set; }

    }

    public class DonateSiteDTO : DonateSite {
        public int SiteID { get; set; }

    }
}
