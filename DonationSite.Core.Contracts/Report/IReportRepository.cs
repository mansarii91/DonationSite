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
        Task<IEnumerable<Entities.Report.DonateReport>> GetDonateReport(int siteId);
    }
}
