using DonationSite.Core.Contracts.Donate;
using DonationSite.Core.Entities.Donate;

namespace DonationSite.DataAccess.EF
{
    public class DonateRepository : IDonateRepository
    {
        private readonly DonationSiteDataContext dataContext;

        public DonateRepository(DonationSiteDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool SubmitDonate(Donate model)
        {
            dataContext.Donate.Add(model);
            return dataContext.SaveChanges() > 0;
        }
    }
}
