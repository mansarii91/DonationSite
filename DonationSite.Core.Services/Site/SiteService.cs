using DonationSite.Core.Contracts;
using DonationSite.Core.Contracts.Site;
using DonationSite.Core.Entities.Site;
using System;
using System.Collections.Generic;

namespace DonationSite.Core.Services
{
    public class SiteService : ISiteService
    {
        private  IUnitOfWork UnitOfWork { get; }
        public SiteService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public bool Add(Site model)
        {
            UnitOfWork.SiteRepository.Add(model);
            return UnitOfWork.Save();
        }

        public Site GetById(int siteId)
        {
           return UnitOfWork.SiteRepository.GetById(siteId);
        }

        public IEnumerable<Site> GetAllList()
        {
            return UnitOfWork.SiteRepository.GetAllList();
        }

        public bool Delete(int siteId)
        {
            return UnitOfWork.SiteRepository.Delete(siteId);
        }

        public bool Update(Site model)
        {
            return UnitOfWork.SiteRepository.Update(model);
        }
    }
}
