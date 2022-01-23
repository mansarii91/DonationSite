using AutoMapper;
using DonationSite.Core.Entities.Donate;
using DonationSite.Core.Entities.Report;
using DonationSite.Core.Entities.Site;

namespace DonationSite.Endpoint.API
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Site, SiteDTO>().ReverseMap();
            CreateMap<Site, CreateSiteDTO>().ReverseMap();
            CreateMap<Donate, DonateDTO>().ReverseMap();
            CreateMap<Donate, CreateDonateDTO>().ReverseMap();
            CreateMap<DonateReport, DonateReportDTO>().ReverseMap();

        }
    }
}
