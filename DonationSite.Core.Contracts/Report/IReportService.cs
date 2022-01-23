using System;
using System.Collections.Generic;
using System.Text;

namespace DonationSite.Core.Contracts.Report
{
    /// <summary>
    /// this repository interface is for queries that for view required
    /// for example: the list of donation that paid for a specific site
    /// </summary>
    public interface IReportService
    {
        IEnumerable<Entities.Report.DonateReport> GetDonateReport(int siteId);
    }
}
