using DonationSite.Core.Contracts.Site;
using DonationSite.Core.Entities.Site;
using System.Collections.Generic;
using System.Linq;

namespace DonationSite.DataAccess.EF
{
    public class SiteRepository: ISiteRepository
    {
        private readonly DonationSiteDataContext dataContext;

        public SiteRepository(DonationSiteDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool Add(Site model)
        {
            dataContext.Add(model);
            return dataContext.SaveChanges() > 0;
        }

        public bool Delete(int siteId)
        {
            var data= dataContext.Site.Find(siteId);
            dataContext.Site.Remove(data);
            return dataContext.SaveChanges() > 0;
        }

        public IEnumerable<Site> GetAllList()
        {
            return dataContext.Site.ToList();
        }

        public Site GetById(int siteId)
        {
            var data = dataContext.Site.Find(siteId);
            return data;
        }

        public bool Update(Site model)
        {
            dataContext.Site.Update(model);
            return dataContext.SaveChanges() > 0;
        }
    }
}
