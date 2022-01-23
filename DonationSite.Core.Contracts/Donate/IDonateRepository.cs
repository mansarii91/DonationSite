namespace DonationSite.Core.Contracts.Donate
{
    public interface IDonateRepository
    {
        bool SubmitDonate(Entities.Donate.Donate model);
    }
}
