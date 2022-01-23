using DonationSite.Core.Contracts.Donate;
using DonationSite.Core.Contracts.Report;
using DonationSite.Core.Contracts.Site;

namespace DonationSite.Core.Contracts
{
    public interface IUnitOfWork
    {
        public IDonateRepository DonateRepository { get; }
        public ISiteRepository SiteRepository { get; }
        public IReportRepository ReportRepository { get; }

        bool Save();

        void Dispose();
    }
}
