using System;
using System.Collections.Generic;
using System.Text;

namespace DonationSite.Core.Contracts.Donate
{
    public interface IDonateService
    {
        bool SubmitDonate(Entities.Donate.Donate model);

    }
}
