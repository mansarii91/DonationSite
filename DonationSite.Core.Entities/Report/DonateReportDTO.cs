using System.Collections.Generic;

namespace DonationSite.Core.Entities.Report
{
    /// <summary>
    /// DonateReport model for show all donation of a website
    /// </summary>
    public class DonateReportDTO
    {
        public IEnumerable<ReportDTO>  ReportData { get; set; }
        public decimal TotalDonate { get; set; }

    }
}
