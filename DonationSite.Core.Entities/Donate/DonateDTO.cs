using DonationSite.Core.Entities.Site;
using System.ComponentModel.DataAnnotations;

namespace DonationSite.Core.Entities.Donate
{
    public class CreateDonateDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string DonatorName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Value is required")]
        public decimal Value { get; set; }
        public SiteDTO Sites { get; set; }
    }

    public class DonateDTO : CreateDonateDTO
    {
        public int DonateID { get; set; }

    }


}
