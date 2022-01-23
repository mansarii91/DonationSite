using System.Threading.Tasks;

namespace DonationSite.Core.Contracts.Donate
{
    public interface IDonateRepository
    {
        Task<bool> SubmitDonate(Entities.Donate.Donate model);
    }
}
