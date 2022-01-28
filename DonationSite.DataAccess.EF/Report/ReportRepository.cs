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

        public async Task<IEnumerable<DonateReport>> GetDonatioSiteReport(int siteId, int take, int skip)
        {
            var res = Task.Run(() =>
                      (from p in dataContext.Site
                       join q in dataContext.Donate
                        on p.SiteID equals q.Site.SiteID
                       where p.SiteID == siteId
                       select new DonateReport
                       {
                           SiteName = p.Name,
                           SiteURL = p.URL,
                           Value = q.Value,
                           Donator = q.DonatorName

                       })
                       .Skip(skip)
                       .Take(take)
                       .ToList()

            );

            await Task.WhenAll(res);

            return res.Result;

        }

        public async Task<IEnumerable<DonateSiteDTO>> GetDonationReport(int take, int skip)
        {
            var data = Task.Run(() => (from p in dataContext.Donate
                                       join q in dataContext.Site
                                       on p.FKSiteID equals q.SiteID
                                       select new
                                       {
                                           SiteName = q.Name,
                                           SiteURL = q.URL,
                                           Value = p.Value,
                                           FkSiteID = p.FKSiteID
                                       })
                                       .Skip(skip)
                                       .Take(take)
                                       .ToList()
                                       .GroupBy(a => a.FkSiteID)
                                       .Select(a => new DonateSiteDTO
                                       {
                                           SiteName = a.FirstOrDefault().SiteName,
                                           SiteURL = a.FirstOrDefault().SiteURL,
                                           TotalDonation = a.Sum(a => a.Value),
                                           SiteID = a.FirstOrDefault().FkSiteID
                                       })
                                       .OrderBy(a=>a.TotalDonation)
                                       .ToList()

            );

            await Task.WhenAll(data);
            return data.Result;
        }

    }
}
