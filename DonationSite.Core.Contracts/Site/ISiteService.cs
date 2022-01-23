using System;
using System.Collections.Generic;
using System.Text;

namespace DonationSite.Core.Contracts.Site
{
    public interface ISiteService
    {
        bool Add(Entities.Site.Site model);
        Entities.Site.Site GetById(int siteId);
        IEnumerable<Entities.Site.Site> GetAllList();
        bool Delete(int siteId);
        bool Update(Entities.Site.Site model);
    }
}
