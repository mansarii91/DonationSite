using DonationSite.Core.Contracts;
using DonationSite.Core.Contracts.Site;
using DonationSite.Core.Entities.Site;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonationSite.Core.Services
{
    public class SiteService : ISiteService
    {
        private readonly IUnitOfWork unitOfWork;

        public SiteService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Site model)
        {
            return await unitOfWork.SiteRepository.Add(model);
        }

        public async Task<Site> GetById(int siteId)
        {
            return await unitOfWork.SiteRepository.GetById(siteId);
        }

        public async Task<IEnumerable<Site>> GetAllList(int take, int skip)
        {
            return await unitOfWork.SiteRepository.GetAllList(take, skip);
        }

        public async Task<bool> Delete(int siteId)
        {
            return await unitOfWork.SiteRepository.Delete(siteId);
        }

        public async Task<bool> Update(Site model)
        {
            return await unitOfWork.SiteRepository.Update(model);
        }

        public long GetTotalCount()
        {
           return unitOfWork.SiteRepository.GetTotalCount();
        }
    }
}
