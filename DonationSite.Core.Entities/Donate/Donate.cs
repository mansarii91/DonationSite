using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonationSite.Core.Entities.Donate
{
    public class Donate
    {
        public int DonateID { get; set; }
        [Required]
        public string DonatorName { get; set; }
        public decimal Value { get; set; }
        [ForeignKey(nameof(Site))]
        public int FKSiteID { get; set; }
        public Site.Site Site { get; set; }

    }
}
