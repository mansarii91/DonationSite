using DonationSite.Core.Contracts.Donate;
using DonationSite.Core.Contracts.Report;
using DonationSite.Core.Contracts.Site;
using System.Threading.Tasks;

namespace DonationSite.Core.Contracts
{
    public interface IUnitOfWork
    {
        public IDonateRepository DonateRepository { get; }
        public ISiteRepository SiteRepository { get; }
        public IReportRepository ReportRepository { get; }

        Task<bool> Save();

        Task Dispose();
    }
}
