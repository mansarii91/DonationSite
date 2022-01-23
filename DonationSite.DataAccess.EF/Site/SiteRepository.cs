using DonationSite.Core.Contracts.Site;
using DonationSite.Core.Entities.Site;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationSite.DataAccess.EF
{
    public class SiteRepository : ISiteRepository
    {
        private readonly DonationSiteDataContext dataContext;

        public SiteRepository(DonationSiteDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<bool> Add(Site model)
        {
            dataContext.Add(model);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int siteId)
        {
            var data = await dataContext.Site.FindAsync(siteId);
            dataContext.Site.Remove(data);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Site>> GetAllList()
        {
            var data = Task.Run(() =>
                dataContext.Site.ToList()
            );

            await Task.WhenAll(data);

            return data.Result;
        }

        public async Task<Site> GetById(int siteId)
        {
            return await dataContext.Site.FindAsync(siteId);
        }

        public async Task<bool> Update(Site model)
        {
            dataContext.Site.Update(model);
            return await dataContext.SaveChangesAsync() > 0;
        }
    }
}
