using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DonationSite.Core.Entities.Site
{
    public class Site
    {
        public int SiteID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string URL { get; set; }
        public DateTime CreatedDateTime { get; set; }
        //public ICollection<Donate.Donate> Donates { get; set; }

    }
}
