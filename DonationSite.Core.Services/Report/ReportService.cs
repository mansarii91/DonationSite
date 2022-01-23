using DonationSite.Core.Contracts;
using DonationSite.Core.Contracts.Report;
using DonationSite.Core.Entities.Report;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonationSite.Core.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DonateReport>> GetDonateReport(int siteId)
        {
            return await unitOfWork.ReportRepository.GetDonateReport(siteId);
        }
    }
}
