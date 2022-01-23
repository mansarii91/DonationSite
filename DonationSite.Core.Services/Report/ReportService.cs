using DonationSite.Core.Contracts;
using DonationSite.Core.Contracts.Report;
using DonationSite.Core.Entities.Report;
using System.Collections.Generic;

namespace DonationSite.Core.Services
{
    public class ReportService : IReportService
    {
        private IUnitOfWork UnitOfWork { get; }
        public ReportService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<DonateReport> GetDonateReport(int siteId)
        {
            return UnitOfWork.ReportRepository.GetDonateReport(siteId);
        }
    }
}
