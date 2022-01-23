using DonationSite.Core.Contracts.Report;
using DonationSite.Core.Entities.Report;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationSite.DataAccess.EF
{
    public class ReportRepository : IReportRepository
    {
        private readonly DonationSiteDataContext dataContext;

        public ReportRepository(DonationSiteDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<DonateReport>> GetDonateReport(int siteId)
        {
            var res = Task.Run( () => 
                       (from p in dataContext.Site
                       join q in dataContext.Donate
                       on p.SiteID equals q.Sites.SiteID
                       where p.SiteID == siteId
                       select new DonateReport
                       {
                           SiteName = p.Name,
                           SiteURL = p.URL,
                           Value = q.Value,
                           Donator = q.DonatorName

                       }).ToList()
            );
            
            await Task.WhenAll(res);
            
            return res.Result;
          
        }

    }
}
