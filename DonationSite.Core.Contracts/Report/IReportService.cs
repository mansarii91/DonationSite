using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationSite.Core.Contracts.Report
{
    /// <summary>
    /// this repository interface is for queries that for view required
    /// for example: the list of donation that paid for a specific site
    /// </summary>
    public interface IReportService
    {
        Task<IEnumerable<Entities.Report.DonateReport>> GetDonationSiteReport(int siteId, int take, int skip);
        Task<IEnumerable<Entities.Report.DonateSite>> GetDonationReport(int take,int skip);

    }
}
