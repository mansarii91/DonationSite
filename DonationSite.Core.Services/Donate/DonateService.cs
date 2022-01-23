using DonationSite.Core.Contracts;
using DonationSite.Core.Contracts.Donate;
using DonationSite.Core.Entities.Donate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationSite.Core.Services
{
    public class DonateService : IDonateService
    {
        private readonly IUnitOfWork unitOfWork;

        public DonateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> SubmitDonate(Donate model)
        {
            return await unitOfWork.DonateRepository.SubmitDonate(model);
        }
    }
}
