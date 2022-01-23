using DonationSite.Core.Contracts;
using DonationSite.Core.Contracts.Donate;
using DonationSite.Core.Contracts.Report;
using DonationSite.Core.Contracts.Site;

namespace DonationSite.DataAccess.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DonationSiteDataContext dataContext;

        public IDonateRepository DonateRepository => new DonateRepository(dataContext);

        public ISiteRepository SiteRepository => new SiteRepository(dataContext);

        public IReportRepository ReportRepository => new ReportRepository(dataContext);

        public UnitOfWork(DonationSiteDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool Save()
        {
            return dataContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }

    }
}
