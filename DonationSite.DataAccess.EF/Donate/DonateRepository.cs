using DonationSite.Core.Contracts.Donate;
using DonationSite.Core.Entities.Donate;
using System.Threading.Tasks;

namespace DonationSite.DataAccess.EF
{
    public class DonateRepository : IDonateRepository
    {
        private readonly DonationSiteDataContext dataContext;

        public DonateRepository(DonationSiteDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<bool> SubmitDonate(Donate model)
        {
            await dataContext.Donate.AddAsync(model);
            return await dataContext.SaveChangesAsync() > 0;
        }
    }
}
