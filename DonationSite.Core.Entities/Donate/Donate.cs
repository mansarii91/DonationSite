using System.ComponentModel.DataAnnotations;

namespace DonationSite.Core.Entities.Donate
{
    public class Donate
    {
        public int DonateID { get; set; }
        [Required]
        public string DonatorName { get; set; }
        public decimal Value { get; set; }

        public Site.Site Sites { get; set; }

    }
}
