using DonationSite.Core.Entities.Donate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DonationSite.Core.Entities.Site
{
    public class CreateSiteDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "URL is required" )]
        public string URL { get; set; }
        public DateTime CreatedDateTime { get; set; }
       // public IEnumerable<DonateDTO> Donates { get; set; }
    }

    public class UpdateSiteDTO : SiteDTO { }

    public class SiteDTO : CreateSiteDTO 
    {
        public int SiteID { get; set; }
    }
}
