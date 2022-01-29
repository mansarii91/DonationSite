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

        public async Task<IEnumerable<DonateReport>> GetDonationSiteReport(int siteId, int take, int skip)
        {
            return await unitOfWork.ReportRepository.GetDonatioSiteReport(siteId, take, skip);
        }

        public async Task<IEnumerable<DonateSite>> GetDonationReport(int take, int skip)
        {
            return await unitOfWork.ReportRepository.GetDonationReport(take, skip);

        }

        public async Task<long> GetDonatioSiteReportTotalCount(int siteId)
        {
            return await unitOfWork.ReportRepository.GetDonatioSiteReportTotalCount(siteId);
        }

        public async Task<long> GetDonationReportTotalCount()
        {
            return await unitOfWork.ReportRepository.GetDonationReportTotalCount();
        }
    }
}
