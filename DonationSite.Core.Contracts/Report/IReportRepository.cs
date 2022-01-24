using DonationSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationSite.Core.Contracts.Report
{
    /// <summary>
    /// this repository interface is for queries that for view required
    /// </summary>
    public interface IReportRepository
    {
        /// <summary>
        /// view all donation for a site 
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        Task<IEnumerable<Entities.Report.DonateReport>> GetDonatioSiteReport(int siteId, int take, int skip);
        /// <summary>
        /// view each site with cumulative donations
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        Task<IEnumerable<Entities.Report.DonateSite>> GetDonationReport(int take,int skip);
    }
}
