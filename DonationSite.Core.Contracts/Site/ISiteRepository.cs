using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonationSite.Core.Contracts.Site
{
    public interface ISiteRepository
    {
        Task<bool> Add(Entities.Site.Site model);
        Task<Entities.Site.Site> GetById(int siteId);
        Task<IEnumerable<Entities.Site.Site>> GetAllList(int take, int skip);
        Task<bool> Delete(int siteId);
        Task<bool> Update(Entities.Site.Site model);
        long GetTotalCount();
    }
}
