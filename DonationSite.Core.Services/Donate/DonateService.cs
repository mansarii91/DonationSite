using DonationSite.Core.Contracts;
using DonationSite.Core.Contracts.Donate;
using DonationSite.Core.Entities.Donate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DonationSite.Core.Services
{
    public class DonateService : IDonateService
    {
        private IUnitOfWork UnitOfWork { get; }
        public DonateService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public bool SubmitDonate(Donate model)
        {
            return UnitOfWork.DonateRepository.SubmitDonate(model);
        }
    }
}
