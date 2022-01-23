using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationSite.Core.Contracts.Site
{
    public interface ISiteService
    {
        Task<bool> Add(Entities.Site.Site model);
        Task<Entities.Site.Site> GetById(int siteId);
        Task<IEnumerable<Entities.Site.Site>> GetAllList();
        Task<bool> Delete(int siteId);
        Task<bool> Update(Entities.Site.Site model);
    }
}
