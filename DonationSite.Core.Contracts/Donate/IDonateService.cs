using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationSite.Core.Contracts.Donate
{
    public interface IDonateService
    {
        Task<bool> SubmitDonate(Entities.Donate.Donate model);

    }
}
